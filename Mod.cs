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
    using System.Reflection;
    using Colossal.IO.AssetDatabase;
    using Colossal.Localization;
    using Colossal.Logging;
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Modding;
    using Game.SceneFlow;

    public sealed class Mod : IMod
    {
        public const string ModId = "FastBikes";
        public const string ModName = "Bikes + Paths";
        public const string ModTag = "[BP]";

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
            // This also configures LogUtils.
            ShellOpen.Configure(s_Log, ModId, ModTag);

            if (!s_BannerLogged)
            {
                s_BannerLogged = true;
                LogUtils.Info($"{ModName} {ModTag} v{ModVersion} OnLoad");
            }

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
