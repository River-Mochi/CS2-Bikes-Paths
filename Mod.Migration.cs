// <copyright file="Mod.Migration.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Mod.Migration.cs
// Purpose: Carry FastBikes settings into BikesAndPaths.
// Keep while upgrades from FastBikes 1.1.3 are supported.

namespace BikesAndPaths
{
    using System;                     // Exception
    using System.IO;                  // File, Path
    using Colossal.IO.AssetDatabase;  // AssetDatabase, SourceMeta
    using Colossal.PSI.Environment;   // EnvPath
    using CS2Shared.RiverMochi;       // LogUtils

    public sealed partial class Mod
    {
        // Old .coc section name and folder.
        private const string LegacyModId = "FastBikes";

        // Captured before LoadSettings can create the new mapping.
        private static bool s_NewSettingsFileExisted;

        private static string NewSettingsFilePath => Path.Combine(
            EnvPath.kUserDataPath, "ModsSettings", ModId, $"{ModId}.coc");

        private static string LegacySettingsFilePath => Path.Combine(
            EnvPath.kUserDataPath, "ModsSettings", LegacyModId, $"{LegacyModId}.coc");

        // Call near the start of OnLoad.
        private static void CaptureSettingsFileState()
        {
            try
            {
                s_NewSettingsFileExisted = File.Exists(NewSettingsFilePath);
            }
            catch (Exception)
            {
                // Fail closed; never overwrite uncertain settings.
                s_NewSettingsFileExisted = true;
            }
        }

        // Copy values after the normal BikesAndPaths settings load.
        private static void MigrateLegacySettings(BPSetting setting)
        {
            try
            {
                if (s_NewSettingsFileExisted || !File.Exists(LegacySettingsFilePath))
                {
                    return;
                }

                bool migrated = false;

                // Read old JSON without attaching another save source.
                AssetDatabase.global.LoadSettings<LegacyFastBikesSettings>(
                    LegacyModId,
                    (LegacyFastBikesSettings legacy, SourceMeta _) =>
                    {
                        setting.EnableBikesAndPaths = legacy.EnableFastBikes;
                        setting.SpeedScalar = legacy.SpeedScalar;
                        setting.PathSpeedScalar = legacy.PathSpeedScalar;

                        // Stability is disabled; do not carry its old values forward.
                        migrated = true;
                    });

                if (!migrated)
                {
                    return;
                }

                // Normal BPSetting save writes BikesAndPaths.coc.
                setting.ApplyAndSave();

                LogUtils.Info(() =>
                    $"Loaded previous {LegacyModId} settings; saving to " +
                    $"ModsSettings/{ModId}/{ModId}.coc.");
            }
            catch (Exception ex)
            {
                // Harmless fallback: the new settings still work.
                LogUtils.Info(() =>
                    $"Settings carry-over from {LegacyModId} failed: {ex.GetType().Name}: {ex.Message}.\n" +
                    $"Set the sliders once in Options and the new " +
                    $"ModsSettings/{ModId}/{ModId}.coc is written normally.");
            }
        }
    }
}
