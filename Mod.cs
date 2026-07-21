// <copyright file="Mod.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Mod.cs
// Purpose: Entry point for FastBikes. Registers settings, localization, and ECS systems.

namespace FastBikes
{
    using System;                    // Exception, Func<T>
    using System.Reflection;         // Assembly
    using Colossal;                  // IDictionarySource
    using Colossal.IO.AssetDatabase; // AssetDatabase.LoadSettings
    using Colossal.Localization;     // LocalizationManager
    using Colossal.Logging;          // ILog, LogManager
    using CS2Shared.RiverMochi;      // LogUtils, ShellOpen
    using Game;                      // UpdateSystem, SystemUpdatePhase
    using Game.Modding;              // IMod
    using Game.SceneFlow;            // GameManager

    public sealed class Mod : IMod
    {
        public const string ModId = "FastBikes";
        public const string ModName = "Bikes + Paths";
        public const string ModTag = "[FB]";

        public static readonly string ModVersion =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "1.0.0";

        private static bool s_BannerLogged;

#if DEBUG
        private const string BuildTag = "[DEBUG]";
#else
        private const string BuildTag = "[RELEASE]";
#endif

        public static readonly ILog s_Log =
            LogManager.GetLogger(ModId).SetShowsErrorsInUI(
#if DEBUG
                true
#else
                false
#endif
            );

        public static FBSetting? Settings
        {
            get; private set;
        }

        public void OnLoad(UpdateSystem updateSystem)
        {
            ShellOpen.Configure(s_Log, ModId, ModTag);

            if (!s_BannerLogged)
            {
                s_BannerLogged = true;
                LogSafe(( ) => $"{ModName} v{ModVersion} OnLoad {BuildTag}");
            }

            if (GameManager.instance == null)
            {
                WarnSafe(( ) => "GameManager.instance is null in Mod.OnLoad.");
                return;
            }

            FBSetting setting = new FBSetting(this);
            Settings = setting;

            AddLocaleSource("en-US", new LocaleEN(setting));
            AddLocaleSource("fr-FR", new LocaleFR(setting));
            AddLocaleSource("es-ES", new LocaleES(setting));
            AddLocaleSource("de-DE", new LocaleDE(setting));
            AddLocaleSource("it-IT", new LocaleIT(setting));
            AddLocaleSource("ja-JP", new LocaleJA(setting));
            AddLocaleSource("ko-KR", new LocaleKO(setting));
            AddLocaleSource("pl-PL", new LocalePL(setting));
            AddLocaleSource("pt-BR", new LocalePT_BR(setting));
            AddLocaleSource("zh-HANS", new LocaleZH_CN(setting));    // Simplified Chinese
            AddLocaleSource("zh-HANT", new LocaleZH_HANT(setting));  // Traditional Chinese
            AddLocaleSource("tr-TR", new LocaleTR(setting));         // Turkish
            AddLocaleSource("vi-VN", new LocaleVI(setting));         // Vietnamese

            try
            {
                AssetDatabase.global.LoadSettings(ModId, setting, new FBSetting(this));
                setting.RegisterInOptionsUI();
            }
            catch (Exception ex)
            {
                WarnSafe(( ) => $"Settings/UI init failed: {ex.GetType().Name}: {ex.Message}");
            }

            try
            {
                updateSystem.UpdateAfter<FastBikeSystem>(SystemUpdatePhase.PrefabUpdate);
                updateSystem.World.GetOrCreateSystemManaged<FastBikeSystem>();
            }
            catch (Exception ex)
            {
                WarnSafe(( ) => $"System scheduling/init failed: {ex.GetType().Name}: {ex.Message}");
            }
        }

        public void OnDispose( )
        {
            LogSafe(( ) => "OnDispose");

            if (Settings != null)
            {
                try
                {
                    Settings.UnregisterInOptionsUI();
                }
                catch (Exception ex)
                {
                    WarnSafe(( ) => $"UnregisterInOptionsUI failed: {ex.GetType().Name}: {ex.Message}");
                }

                Settings = null;
            }
        }

        public static void LogSafe(Func<string> messageFactory) => LogUtils.TryLog(s_Log, Level.Info, messageFactory);
        public static void WarnSafe(Func<string> messageFactory) => LogUtils.TryLog(s_Log, Level.Warn, messageFactory);
        public static void WarnOnce(string key, Func<string> messageFactory) => LogUtils.WarnOnce(s_Log, key, messageFactory);

        private static void AddLocaleSource(string localeId, IDictionarySource source)
        {
            if (string.IsNullOrEmpty(localeId))
            {
                return;
            }

            LocalizationManager? lm = GameManager.instance?.localizationManager;
            if (lm == null)
            {
                WarnSafe(( ) => $"AddLocaleSource: No LocalizationManager; cannot add source for '{localeId}'.");
                return;
            }

            try
            {
                lm.AddSource(localeId, source);
            }
            catch (Exception ex)
            {
                WarnSafe(( ) => $"AddLocaleSource: AddSource for '{localeId}' failed: {ex.GetType().Name}: {ex.Message}");
            }
        }
    }
}
