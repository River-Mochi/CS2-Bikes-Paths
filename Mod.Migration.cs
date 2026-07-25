// <copyright file="Mod.Migration.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Mod.Migration.cs
// Purpose: One-time carry-over of settings from the old FastBikes.coc into the new BikesAndPaths.coc.
// Transitional code: once existing players have updated, delete this file and LegacyFastBikesSettings.cs.

namespace BikesAndPaths
{
    using System;                     // Exception
    using System.IO;                  // File, Path
    using Colossal.IO.AssetDatabase;  // AssetDatabase, SourceMeta
    using Colossal.PSI.Environment;   // EnvPath
    using CS2Shared.RiverMochi;       // LogUtils

    public sealed partial class Mod
    {
        // Settings section name used by the previous release. The old .coc's first line is this name,
        // and the Asset Database registers the file under it.
        private const string LegacyModId = "FastBikes";

        // True when ModsSettings/BikesAndPaths/BikesAndPaths.coc already existed at startup.
        // Captured before LoadSettings so migration runs only for a player coming from the old version.
        private static bool s_NewSettingsFileExisted;

        private static string NewSettingsFilePath => Path.Combine(
            EnvPath.kUserDataPath, "ModsSettings", ModId, $"{ModId}.coc");

        private static string LegacySettingsFilePath => Path.Combine(
            EnvPath.kUserDataPath, "ModsSettings", LegacyModId, $"{LegacyModId}.coc");

        // Must be called at the very start of OnLoad, before anything can write the new file.
        private static void CaptureSettingsFileState()
        {
            try
            {
                s_NewSettingsFileExisted = File.Exists(NewSettingsFilePath);
            }
            catch (Exception)
            {
                // Treat an unreadable path as "already exists" so migration cannot overwrite anything.
                s_NewSettingsFileExisted = true;
            }
        }

        // Copies values from the old FastBikes settings into the live BPSetting, then saves.
        //
        // Values are migrated, NOT files. The old .coc is left untouched on disk and its Asset Database
        // mapping is left alone:
        //  * .coc files are scanned recursively under EnvPath.kUserDataPath before mod OnLoad, so the
        //    legacy file is already parsed and mapped. Physically moving it would leave that live
        //    mapping pointing at a path that no longer exists.
        //  * The read-only LoadSettings<T>(name, Action<T, SourceMeta>) overload only does `new T()` +
        //    JSON.WriteInto. It never assigns SettingAsset.Fragment.source, and SaveSpecificSetting
        //    only targets fragments whose source is non-null, so the legacy file can never be written
        //    to again. It is inert, not a duplicate that competes for saves.
        //  * BPSetting's own mapping is created by the game from [FileLocation] when the new file does
        //    not exist yet, so saves land in ModsSettings/BikesAndPaths/BikesAndPaths.coc.
        //
        // Must run AFTER AssetDatabase.global.LoadSettings(ModId, setting, ...) so the copied values
        // are not overwritten by the load.
        private static void MigrateLegacySettings(BPSetting setting)
        {
            try
            {
                // Already migrated (or a fresh install that has since saved): nothing to do.
                if (s_NewSettingsFileExisted)
                {
                    return;
                }

                if (!File.Exists(LegacySettingsFilePath))
                {
                    return;
                }

                bool migrated = false;

                // Read-only load of the old section; does not register or attach anything.
                AssetDatabase.global.LoadSettings<LegacyFastBikesSettings>(
                    LegacyModId,
                    (LegacyFastBikesSettings legacy, SourceMeta meta) =>
                    {
                        if (legacy == null)
                        {
                            return;
                        }

                        setting.EnableBikesAndPaths = legacy.EnableFastBikes;
                        setting.SpeedScalar = legacy.SpeedScalar;
                        setting.StiffnessScalar = legacy.StiffnessScalar;
                        setting.DampingScalar = legacy.DampingScalar;
                        setting.PathSpeedScalar = legacy.PathSpeedScalar;

                        migrated = true;
                    });

                if (!migrated)
                {
                    return;
                }

                // Writes the carried-over values to the new file through the normal save path.
                setting.ApplyAndSave();

                LogUtils.Info(() =>
                    $"Carried over previous {LegacyModId} settings to ModsSettings/{ModId}/{ModId}.coc.");
            }
            catch (Exception ex)
            {
                // Migration failure must not prevent the mod from loading. Worst case the player sets
                // the two sliders once and the new file is written normally.
                LogUtils.Info(() =>
                    $"Settings carry-over from {LegacyModId} failed: {ex.GetType().Name}: {ex.Message}.\n" +
                    $"Set the sliders once in Options and the new " +
                    $"ModsSettings/{ModId}/{ModId}.coc is written normally.");
            }
        }
    }
}
