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
    using System;                     // Exception, StringComparison
    using System.IO;                  // Directory, File, Path
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

        // Moves the old FastBikes .coc to the new BikesAndPaths location, rewriting its section header
        // (old ModId -> new ModId) and the one renamed key so saved values carry over. Runs in OnLoad
        // BEFORE LoadSettings, which reads the file at the [FileLocation] path directly -- so we touch
        // ONLY the file, never the Asset Database. (An AssetDatabase remap makes the game re-open the
        // file mid-load, which fails if anything else has it open, and adds a second handle that breaks
        // saving. The official CS2 migration guide also just moves the file.)
        private static void MigrateLegacySettingsFile()
        {
            try
            {
                string oldLocation = Path.Combine(
                    EnvPath.kUserDataPath, "ModsSettings", LegacyModId, $"{LegacyModId}.coc");

                if (!File.Exists(oldLocation))
                {
                    return;
                }

                string directory = Path.Combine(EnvPath.kUserDataPath, "ModsSettings", ModId);
                string correctLocation = Path.Combine(directory, $"{ModId}.coc");

                // New settings already exist (already migrated, or set on the new build): just remove
                // the stale old file so this never runs again. Never overwrite the new file.
                if (File.Exists(correctLocation))
                {
                    TryDeleteLegacyFileAndFolder(oldLocation);
                    return;
                }

                string coc = File.ReadAllText(oldLocation);

                // The .coc's first line is the section header = the old LoadSettings name. LoadSettings
                // (ModId, ...) matches on it, so rewrite it to the new ModId or the values would reset.
                if (coc.StartsWith(LegacyModId, StringComparison.Ordinal))
                {
                    coc = ModId + coc.Substring(LegacyModId.Length);
                }

                coc = coc.Replace(LegacyEnableKey, CurrentEnableKey);

                Directory.CreateDirectory(directory);
                File.WriteAllText(correctLocation, coc);

                TryDeleteLegacyFileAndFolder(oldLocation);

                LogUtils.Info(() => $"Migrated settings to ModsSettings/{ModId}/{ModId}.coc.");
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
