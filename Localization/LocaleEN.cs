// <copyright file="LocaleEN.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleEN.cs
// Purpose: English entries for BikesAndPaths.

namespace BikesAndPaths
{
    using System.Collections.Generic;  // IEnumerable, Dictionary, KeyValuePair
    using Colossal;                    // IDictionarySource, IDictionaryEntryError

    public sealed class LocaleEN : IDictionarySource
    {
        private readonly BPSetting m_Setting;

        public LocaleEN(BPSetting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            string title = Mod.ModName;
            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title = title + " (" + Mod.ModVersion + ")";
            }

            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), title },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(BPSetting.ActionsTab), "Actions" },
                { m_Setting.GetOptionTabLocaleID(BPSetting.AboutTab),   "About" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsSpeedGrp),      "Speed" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsStabilityGrp),  "Stability" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsResetGrp),      "Reset" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsPathSpeedGrp),  "Paths" },

                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutInfoGrp),  "Mod info" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutLinksGrp), "Links" },

                // Retirement notice
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsMigrationGrp), "ASL" },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.MigrationText)),
                    "<Bikes + Paths is retired.>\n\n" +
                    "Thank you for using this mod! I hope you enjoyed it. All its features are now in Adjust All Speed Limits mod, with a more advanced in-city panel for bike and pedestrian paths. <Install Adjust All Speed Limits> using the button below.\n\n" +
                    "You can safely remove Bikes + Paths anytime. To restore vanilla values right away, use Reset to Game Defaults, let the changes finish and save your city. This is optional.\n\n" +
                    "Thank you, River-mochi"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AslMigrationText)),
                    "<Bikes + Paths is retired.>\n\n" +
                    "Thank you for using this mod! I hope you enjoyed it. All its features are now in <Adjust All Speed Limits> mod, with a more advanced in-city panel for bike and pedestrian paths.\n\n" +
                    "ASL already manages these features. You can safely remove Bikes + Paths now. No reset is required.\n\n" +
                    "Thank you, River-mochi"
                },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "Enable Bikes + Paths" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "Turns B+P on or off. When off, restores game defaults for features not controlled by ASL." },

                // Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.SpeedScalar)), "Bike & scooter speed" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.SpeedScalar)),
                    "**Scales max speed**.\n" +
                    "Acceleration + braking use smoothing math at high-speed for less jump starts and panic-braking look.\n" +
                    "**0.30 = 30%** of game default\n" +
                    "**1.00 = game default**\n" +
                    "Note: road limits and game conditions still apply."
                },

                // Stability
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StiffnessScalar)), "Stiffness" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StiffnessScalar)),
    //                "Scalar for **sway amplitude**.\n" +
    //                "**Higher = less leaning**.\n" +
    //                "**Lower = more wobble**.\n" +
    //                "Suggested: 1.25–1.75 for high-speed stability."
    //            },
    //
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.DampingScalar)), "Damping" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.DampingScalar)),
    //                "Higher = settles faster (less oscillation).\n" +
    //                "**1.00 = game default**\n" +
    //                "Suggested: 1.25–2.00 for high-speed stability."
    //            },

                // Path Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "ALL Speed Limits on Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "Opens Adjust All Speed Limits on Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.PathSpeedScalar)), "Path speed limit" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.PathSpeedScalar)),
                    "Scales **Path** speed limits (paths are not roads).\n" +
                    "**1.00 = game default**\n" +
                    "Affects: bike paths, divided pedestrian+bike, and pedestrian paths.\n\n" +
                    "Optional: reset to game defaults and save before removing. Otherwise existing paths may retain modified speeds."
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToModDefaults)), "Mod defaults" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToModDefaults)),
                    "Applies the mod’s default tuning values."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToVanilla)), "Reset to Game Defaults" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToVanilla)),
                    "Sets all sliders to **100%** and restores game defaults (vanilla)."
                },
                // Status fallback keys
                { "FAST_STATUS_NOT_LOADED",     "Status not loaded." },
                { "FAST_STATS_NOT_AVAIL",       "No city... ¯\\_(ツ)_/¯ ...No stats" },
                { "FAST_STATS_CARS_NOT_AVAIL",  "run the city a few minutes for data." },

                // Status rows
                { "FAST_STATS_BIKES_ROW1", "{0} active | {1} bikes | {2} scooters | {3} / {4} parked/total" },
                { "FAST_STATS_CARS_ROW2",  "{0} active | {1} parked | {2} total | {3} trailers" },

                // Row3 shows TOTAL OC hidden
                { "FAST_STATS_CARS_ROW3",  "{0} hidden at OC border | updated {1}" },

                // About: Info
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutName)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutName)),     "Display name." },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutVersion)),  "Current version." },

                // Links
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenParadoxMods)),  "Opens the author’s Paradox mods page." },

            };
        }

        public void Unload( )
        {
        }
    }
}
