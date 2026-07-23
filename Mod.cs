// <copyright file="Mod.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Mod.cs
// Entry point for Bikes + Paths.

namespace BikeAndPath
{
    using System;                     // Exception, StringComparison, Type
    using System.IO;                  // Directory, File, Path
    using System.Reflection;
    using Colossal;                   // Hash128
    using Colossal.IO.AssetDatabase;
    using Colossal.Localization;
    using Colossal.Logging;
    using Colossal.PSI.Environment;   // EnvPath
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Modding;
    using Game.SceneFlow;

    public sealed class Mod : IMod
    {
        public const string ModId = "BikesAndPaths";
        public const string ModName = "Bikes + Paths";
        public const string ModTag = "[BP]";

        // Previous ModId, used only to migrate any old settings file to the new location.
        private const string LegacyModId = "FastBikes";

        private static bool s_BannerLogged;

        public static readonly string ModVersion =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "1.0.0";

        public static readonly ILog s_Log =
            LogManager.GetLogger(ModId).SetShowsErrorsInUI(false);

        public static BPSetting? Settings
        {
            get; private set;
        }

        public void OnLoad(UpdateSystem updateSystem)
        {
            // also configures LogUtils.
            ShellOpen.Configure(s_Log, ModId, ModTag);

            if (!s_BannerLogged)
            {
                s_BannerLogged = true;
                LogUtils.Info($"{ModName} {ModTag} v{ModVersion} OnLoad");
            }

            // Move player's old FastBikes settings file to new BikesAndPaths location
            // before LoadSettings runs, so saved options carry over after the rename.
            MigrateLegacySettingsFile();

            BPSetting setting = new BPSetting(this);
            Settings = setting;

            LocalizationManager? lm = GameManager.instance?.localizationManager;
            if (lm != null)
            {
                lm.AddSource("en-US", new LocaleEN(setting));
                lm.AddSource("de-DE", new LocaleDE(setting));
                lm.AddSource("es-ES", new LocaleES(setting));
                lm.AddSource("fr-FR", new LocaleFR(setting));
                lm.AddSource("it-IT", new LocaleIT(setting));
                lm.AddSource("ja-JP", new LocaleJA(setting));
                lm.AddSource("ko-KR", new LocaleKO(setting));
                lm.AddSource("pl-PL", new LocalePL(setting));
                lm.AddSource("pt-BR", new LocalePT_BR(setting));
                lm.AddSource("th-TH", new LocaleTH(setting));
                lm.AddSource("tr-TR", new LocaleTR(setting));
                lm.AddSource("uk-UA", new LocaleUK(setting));
                lm.AddSource("vi-VN", new LocaleVI(setting));
                lm.AddSource("zh-HANS", new LocaleZH_CN(setting));
                lm.AddSource("zh-HANT", new LocaleZH_HANT(setting));
            }
            else
            {
                LogUtils.Warn($"{ModTag} LocalizationManager is null; skipping locale registration.");
            }

            AssetDatabase.global.LoadSettings(ModId, setting, new BPSetting(this));
            setting.RegisterInOptionsUI();

            updateSystem.UpdateAfter<BikeAndPathSystem>(SystemUpdatePhase.PrefabUpdate);
        }

        // One-time move of legacy FastBikes settings file to the BikesAndPaths.
        // Copies .coc file and remaps its AssetDatabase entry to the new path.
        // running session (and every future load) reads settings from the new location.
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
                    // Benign: settings already exist at the new location, so there is nothing to migrate.
                    LogUtils.Info(() =>
                        "BikesAndPaths settings file already exists; skipping migration of the old FastBikes file.");
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
                    // Benign: the old file exists on disk but the game did not load it as a settings
                    // asset this session, so there is nothing to remap. The player just re-sets the
                    // sliders once and the new BikesAndPaths file is written on the next save.
                    LogUtils.Info(() =>
                        "Old FastBikes settings file found but not loaded as a settings asset; skipping migration.");
                    return;
                }

                Directory.CreateDirectory(directory);

                // Copy first so the settings data is in the new location.
                File.Copy(oldLocation, correctLocation, overwrite: false);

                // Keep the same AssetDatabase GUID, but remap it from the old
                // physical path to the new path for this running session.
                dataSource.DeleteEntryFromDatabase(oldGuid);
                dataSource.AddEntryFromDatabase(
                    AssetDataPath.Create(
                        $"ModsSettings/{ModId}/{ModId}.coc",
                        EscapeStrategy.None),
                    typeof(SettingAsset),
                    oldGuid);

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

        public void OnDispose()
        {
            if (Settings != null)
            {
                Settings.UnregisterInOptionsUI();
                Settings = null;
            }
        }
    }
}
