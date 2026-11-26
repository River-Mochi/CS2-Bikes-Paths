// <copyright file="BPSetting.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Settings/BPSetting.cs
// Purpose: Options UI + live apply triggers for BikesAndPaths.

namespace BikesAndPaths
{
    using System;
    using Colossal.IO.AssetDatabase; // FileLocation
    using Game.Modding;              // IMod, ModSetting
    using Game.Settings;             // Settings UI attributes
    using Game.UI;                   // Unit
    using Unity.Entities;            // World
    using UnityEngine;               // Application.OpenURL


    [FileLocation("ModsSettings/BikesAndPaths/BikesAndPaths")]
    [SettingsUITabOrder(ActionsTab, AboutTab)]
    [SettingsUIGroupOrder(
        ActionsMigrationGrp, ActionsSpeedGrp, ActionsPathSpeedGrp, ActionsResetGrp,
        AboutInfoGrp, AboutLinksGrp)]
    [SettingsUIShowGroupName(
        ActionsSpeedGrp, ActionsPathSpeedGrp, ActionsResetGrp,
        AboutInfoGrp, AboutLinksGrp)]
    public sealed class BPSetting : ModSetting
    {
        public const string ActionsTab = "Actions";
        public const string AboutTab = "About";

        public const string ActionsSpeedGrp = "Speed";

        // Kept for settings compatibility; Stability UI is disabled.
        public const string ActionsStabilityGrp = "Stability";

        public const string ActionsResetGrp = "Reset";
        public const string ActionsMigrationGrp = "Migration";
        public const string ActionsPathSpeedGrp = "PathSpeed";

        public const string AboutInfoGrp = "Mod info";
        public const string AboutLinksGrp = "Links";

        private const string kRetirementIconPath = "coui://bikesandpaths-options/retirement-heart.svg";

        private const string UrlParadox =
            "https://mods.paradoxplaza.com/authors/River-mochi/cities_skylines_2?games=cities_skylines_2&orderBy=desc&sortBy=best&time=alltime";

        private const float Vanilla = 1.0f;

        private const bool DefaultEnabled = true;
        private const float DefaultSpeed = 2.0f;

        // Kept for settings compatibility; Stability behavior is disabled.
        private const float DefaultStiffness = 1.50f;
        private const float DefaultDamping = 1.50f;

        private const float DefaultPathSpeedScalar = 2.0f;

        private const float FloatEpsilon = 0.0001f;

        public BPSetting(IMod mod) : base(mod)
        {
            EnableBikesAndPaths = DefaultEnabled;
            SpeedScalar = DefaultSpeed;

            // Kept for settings compatibility; unused while Stability is disabled.
            StiffnessScalar = DefaultStiffness;
            DampingScalar = DefaultDamping;

            PathSpeedScalar = DefaultPathSpeedScalar;
        }

        // Show the appropriate retirement notice for the active speed owner.
        [SettingsUIMultilineText(kRetirementIconPath)]
        [SettingsUIHideByCondition(typeof(BPSetting), nameof(HideAllTuning))]
        [SettingsUISection(ActionsTab, ActionsMigrationGrp)]
        public string MigrationText => string.Empty;

        [SettingsUIMultilineText(kRetirementIconPath)]
        [SettingsUIHideByCondition(typeof(BPSetting), nameof(HideAslMigrationText))]
        [SettingsUISection(ActionsTab, ActionsMigrationGrp)]
        public string AslMigrationText => string.Empty;

        [SettingsUISection(ActionsTab, ActionsMigrationGrp)]
        [SettingsUIButton]
        public bool OpenAllSpeedLimits
        {
            set
            {
                if (value)
                {
                    Application.OpenURL("https://mods.paradoxplaza.com/mods/149990/Windows");
                }
            }
        }

        // ----------------------------
        // ACTIONS: Main toggle
        // ----------------------------

        [SettingsUISection(ActionsTab, ActionsSpeedGrp)]
        [SettingsUIHideByCondition(typeof(BPSetting), nameof(HideAllTuning))]
        [SettingsUISetter(typeof(BPSetting), nameof(SetEnableBikesAndPaths))]
        public bool EnableBikesAndPaths
        {
            get; set;
        }

        // ------------------------
        // Actions: Speed
        // ------------------------

        [SettingsUISection(ActionsTab, ActionsSpeedGrp)]
        [SettingsUIHideByCondition(typeof(BPSetting), nameof(HideBikeSpeed))]
        [SettingsUISlider(min = 0.30f, max = 10.00f, step = 0.10f, unit = Unit.kFloatTwoFractions)]
        [SettingsUISetter(typeof(BPSetting), nameof(SetSpeedScalar))]
        public float SpeedScalar
        {
            get; set;
        }

        // ------------------------
        // Actions: Stability (disabled)
        // ------------------------
        // Kept for settings compatibility; no Options UI attributes on purpose.

        internal float StiffnessScalar
        {
            get; set;
        }

        internal float DampingScalar
        {
            get; set;
        }

        // -----------------------------
        // Actions: Path speed
        // -----------------------------

        [SettingsUISection(ActionsTab, ActionsPathSpeedGrp)]
        [SettingsUIHideByCondition(typeof(BPSetting), nameof(HidePathSpeed))]
        [SettingsUISlider(min = 1.00f, max = 5.00f, step = 0.25f, unit = Unit.kFloatTwoFractions)]
        [SettingsUISetter(typeof(BPSetting), nameof(SetPathSpeedScalar))]
        public float PathSpeedScalar
        {
            get; set;
        }

        private bool HideBikeSpeed() => !EnableBikesAndPaths || AslOwnership.OwnsBicycles(GetWorld());

        private bool HidePathSpeed() => !EnableBikesAndPaths || AslOwnership.OwnsPaths(GetWorld());

        private bool HideAllTuning() => AslOwnership.OwnsPaths(GetWorld()) && AslOwnership.OwnsBicycles(GetWorld());

        private bool HideAslMigrationText() => !HideAllTuning();

        private bool HideResetButtons() => !EnableBikesAndPaths || HideAllTuning();

        // ------------------------
        // Actions: Reset buttons
        // ------------------------

        [SettingsUISection(ActionsTab, ActionsResetGrp)]
        [SettingsUIHideByCondition(typeof(BPSetting), nameof(HideResetButtons))]
        [SettingsUIButton]
        [SettingsUIButtonGroup("ResetRow")]
        public bool ResetToModDefaults
        {
            set
            {
                if (!value)
                {
                    return;
                }

                DoResetToModDefaults();
            }
        }

        [SettingsUISection(ActionsTab, ActionsResetGrp)]
        [SettingsUIHideByCondition(typeof(BPSetting), nameof(HideAllTuning))]
        [SettingsUIButton]
        [SettingsUIButtonGroup("ResetRow")]
        public bool ResetToVanilla
        {
            set
            {
                if (!value)
                {
                    return;
                }

                DoResetToVanilla();
            }
        }

        // ------------------------
        // About: Info
        // ------------------------

        [SettingsUISection(AboutTab, AboutInfoGrp)]
        public string AboutName => Mod.ModName;

        [SettingsUISection(AboutTab, AboutInfoGrp)]
        public string AboutVersion => Mod.ModVersion;

        // ------------------------
        // About: Links
        // ------------------------

        [SettingsUIButton]
        [SettingsUIButtonGroup("LinksRow")]
        [SettingsUISection(AboutTab, AboutLinksGrp)]
        public bool OpenParadoxMods
        {
            set
            {
                if (!value)
                {
                    return;
                }

                try
                {
                    Application.OpenURL(UrlParadox);
                }
                catch (Exception)
                {
                }
            }
        }

        // --------------------------------------------------------------------
        // Defaults
        // --------------------------------------------------------------------

        public override void SetDefaults( )
        {
            EnableBikesAndPaths = DefaultEnabled;
            SpeedScalar = DefaultSpeed;

            // Kept for settings compatibility; unused while Stability is disabled.
            StiffnessScalar = DefaultStiffness;
            DampingScalar = DefaultDamping;

            PathSpeedScalar = DefaultPathSpeedScalar;
        }

        // --------------------------------------------------------------------
        // Helpers
        // --------------------------------------------------------------------

        private static World? GetWorld( )
        {
            World world = World.DefaultGameObjectInjectionWorld;
            if (world == null || !world.IsCreated)
            {
                return null;
            }

            return world;
        }

        private static BikesAndPathsSystem? GetSystem( )
        {
            World? world = GetWorld();
            if (world == null)
            {
                return null;
            }

            return world.GetOrCreateSystemManaged<BikesAndPathsSystem>();
        }

        // ------------------------------------------------
        // UI setter handlers
        // ------------------------------------------------

        private void SetEnableBikesAndPaths(bool value)
        {
            if (EnableBikesAndPaths == value)
            {
                return;
            }

            if (value)
            {
                GetSystem()?.ScheduleApplyAll();
            }
            else
            {
                GetSystem()?.ScheduleResetVanillaAll();
            }
        }

        private void SetSpeedScalar(float value)
        {
            if (Math.Abs(SpeedScalar - value) < FloatEpsilon)
            {
                return;
            }

            if (EnableBikesAndPaths)
            {
                GetSystem()?.ScheduleApplyBicyclesAndStability();
            }
        }

        // Kept for settings compatibility (no UI setter attributes reference these).
        private void SetStiffnessScalar(float value)
        {
            if (Math.Abs(StiffnessScalar - value) < FloatEpsilon)
            {
                return;
            }

            if (EnableBikesAndPaths)
            {
                GetSystem()?.ScheduleApplyBicyclesAndStability();
            }
        }

        // Kept for settings compatibility (no UI setter attributes reference these).
        private void SetDampingScalar(float value)
        {
            if (Math.Abs(DampingScalar - value) < FloatEpsilon)
            {
                return;
            }

            if (EnableBikesAndPaths)
            {
                GetSystem()?.ScheduleApplyBicyclesAndStability();
            }
        }

        private void SetPathSpeedScalar(float value)
        {
            if (Math.Abs(PathSpeedScalar - value) < FloatEpsilon)
            {
                return;
            }

            if (EnableBikesAndPaths)
            {
                GetSystem()?.ScheduleApplyPaths();
            }
        }

        private void DoResetToVanilla( )
        {
            if (!AslOwnership.OwnsBicycles(GetWorld()))
            {
                SpeedScalar = Vanilla;
            }

            // Kept for settings compatibility; unused while Stability is disabled.
            StiffnessScalar = Vanilla;
            DampingScalar = Vanilla;

            if (!AslOwnership.OwnsPaths(GetWorld()))
            {
                PathSpeedScalar = Vanilla;
            }

            ApplyAndSave();
            GetSystem()?.ScheduleResetVanillaAll();
        }

        private void DoResetToModDefaults( )
        {
            if (!AslOwnership.OwnsBicycles(GetWorld()))
            {
                SpeedScalar = DefaultSpeed;
            }

            // Kept for settings compatibility; unused while Stability is disabled.
            StiffnessScalar = DefaultStiffness;
            DampingScalar = DefaultDamping;

            if (!AslOwnership.OwnsPaths(GetWorld()))
            {
                PathSpeedScalar = DefaultPathSpeedScalar;
            }

            ApplyAndSave();
            GetSystem()?.ScheduleApplyAll();
        }
    }
}
