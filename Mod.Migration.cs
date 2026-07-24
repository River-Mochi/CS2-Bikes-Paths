// <copyright file="Mod.Migration.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Mod.Migration.cs
// Purpose: One-time move of the legacy FastBikes settings file to the BikesAndPaths location.
// Transitional code: once existing players have updated, can be deleted in a later release.

namespace BikesAndPaths
{
    using System;                     // Exception, StringComparison, Type
    using System.IO;                  // Directory, File, Path
    using Colossal;                   // Hash128
    using Colossal.IO.AssetDatabase;  // AssetDatabase, AssetDataPath, SettingAsset, SourceMeta, IDataSourceProvider, EscapeStrategy
    using Colossal.PSI.Environment;   // EnvPath
    using CS2Shared.RiverMochi;       // LogUtils

    public sealed partial class Mod
    {
        // Previous ModId, used only to migrate an old settings file to the new location.
        private const string LegacyModId = "FastBikes";

        // The mod-enable toggle was renamed EnableFastBikes -> EnableBikesAndPaths. Because only
        // non-default values are serialized, this JSON key is present in the .coc ONLY for a player
        // who turned the mod OFF; rewriting it preserves that choice across the rename.
        private const string LegacyEnableKey = "\"EnableFastBikes\"";
        private const string CurrentEnableKey = "\"EnableBikesAndPaths\"";

        // Copies the legacy .coc to the new path (rewriting its section header + renamed key),
        // remaps its Asset Database entry, and deletes the old file. Runs in OnLoad before
        // LoadSettings so the current session reads settings from the new location.
        private static void MigrateLegacySettingsFile()
        {
            try
            {
                string oldLocation = Path.Combine(
                    EnvPath.kUserDataPath,
                    "ModsSettings",
                    LegacyModId,
                    $"{LegacyModId}.coc");

                if (!File.Exists(oldLocation))
                {
                    return;
                }

                string directory = Path.Combine(
                    EnvPath.kUserDataPath,
                    "ModsSettings",
                    ModId);

                string correctLocation = Path.Combine(
                    directory,
                    $"{ModId}.coc");

                // Two files are ambiguous. Do not overwrite either one automatically.
                if (File.Exists(correctLocation))
                {
#if DEBUG
                    // Benign: settings already exist at the new location, so there is nothing to migrate.
                    LogUtils.Info(() =>
                        "BikesAndPaths settings file already exists; skipping migration of the old FastBikes file.");
#endif
                    return;
                }

                IDataSourceProvider dataSource = AssetDatabase.user.dataSource;
                string normalizedOldLocation = Path.GetFullPath(oldLocation);

                bool oldEntryFound = false;
                Hash128 oldGuid = default;

                foreach ((Type type, Hash128 hash) entry in dataSource.Enumerate())
                {
                    if (entry.type != typeof(SettingAsset))
                    {
                        continue;
                    }

                    SourceMeta meta = dataSource.GetMeta(entry.hash);
                    if (string.IsNullOrEmpty(meta.path))
                    {
                        continue;
                    }

                    string candidateLocation = Path.GetFullPath(meta.path);
                    if (!string.Equals(
                            candidateLocation,
                            normalizedOldLocation,
                            StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    oldGuid = entry.hash;
                    oldEntryFound = true;
                    break;
                }

                if (!oldEntryFound)
                {
                    // The old file exists on disk but the game did not load it as a settings asset
                    // this session, so there is nothing to remap. The player just re-sets the sliders
                    // once and the new BikesAndPaths file is written on the next save. Kept at Info so
                    // a curious player understands why their old options did not carry over.
                    LogUtils.Info(() =>
                        "Old FastBikes settings file found but not loaded as a settings asset; skipping migration.");
                    return;
                }

                Directory.CreateDirectory(directory);

                // Write the file to the new location first, so the settings data is safe even if the
                // Asset Database remap below were to throw.
                //
                // The .coc's first line is the section header, and it equals the OLD LoadSettings name
                // (LegacyModId). LoadSettings(ModId, ...) matches on that header, so a plain copy would
                // keep "FastBikes" and the values would NOT load (they would silently reset). Rewrite the
                // header to the new ModId, and rename the one renamed key, so saved values carry over.
                string coc = File.ReadAllText(oldLocation);
                if (coc.StartsWith(LegacyModId, StringComparison.Ordinal))
                {
                    coc = ModId + coc.Substring(LegacyModId.Length);
                }

                coc = coc.Replace(LegacyEnableKey, CurrentEnableKey);

                File.WriteAllText(correctLocation, coc);

                // Keep the same AssetDatabase GUID, but remap it from the old physical path to the new
                // path for this running session.
                dataSource.DeleteEntryFromDatabase(oldGuid);
                dataSource.AddEntryFromDatabase(
                    AssetDataPath.Create(
                        $"ModsSettings/{ModId}/{ModId}.coc",
                        EscapeStrategy.None),
                    typeof(SettingAsset),
                    oldGuid);

                // Remap succeeded, so the old file is now safe to remove. Deleting it keeps ModsSettings
                // clean and prevents the "already exists" skip on future loads. Done last, and in its own
                // guard, so a delete failure cannot lose settings.
                TryDeleteLegacyFileAndFolder(oldLocation);

                LogUtils.Info(() =>
                    $"Migrated settings to ModsSettings/{ModId}/{ModId}.coc file.");
            }
            catch (Exception ex)
            {
                // Migration failure must not prevent the mod from loading.
                LogUtils.Info(() =>
                    $"Settings migration failed: {ex.GetType().Name}: {ex.Message}.\n" +
                    $"Delete old ModsSettings/FastBikes file and restart the game.\n" +
                    $"A new ModsSettings/BikesAndPaths file appears after making any slider change and a clean game exit.");
            }
        }

        // Best-effort cleanup of the old settings file and its now-empty folder.
        // Any failure here is harmless: the settings already live at the new location.
        private static void TryDeleteLegacyFileAndFolder(string oldLocation)
        {
            try
            {
                File.Delete(oldLocation);

                string? oldDir = Path.GetDirectoryName(oldLocation);
                if (!string.IsNullOrEmpty(oldDir) &&
                    Directory.Exists(oldDir) &&
                    Directory.GetFileSystemEntries(oldDir).Length == 0)
                {
                    Directory.Delete(oldDir);
                }
            }
            catch
            {
                // A leftover legacy file is harmless; ignore.
            }
        }
    }
}
