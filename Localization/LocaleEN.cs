// <copyright file="LocaleEN.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleEN.cs
// Purpose: English entries for BikeAndPath.

namespace BikeAndPath
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
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsStatusGrp),     "Status personal vehicles" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsPathSpeedGrp),  "Paths" },

                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutInfoGrp),  "Mod info" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutLinksGrp), "Links" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutDebugGrp), "Debug" },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.EnableFastBikes)), "Enable Bikes + Paths" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.EnableFastBikes)),
                    "Turns the mod **ON / OFF**.\n" +
                    "When OFF, bicycle and scooter behavior is restored to game defaults.\n\n" +
                    "And you can still get Status info below even if you have Bikes + Paths Off."
                },

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
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.PathSpeedScalar)), "Path speed limit" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.PathSpeedScalar)),
                    "Scales **Path** speed limits (paths are not roads).\n" +
                    "**1.00 = game default**\n" +
                    "Affects: bike paths, divided pedestrian+bike, and pedestrian paths.\n\n" +
                    "Uninstall note: set to 1.00 or use reset button, save city, then uninstall.\n" +
                    "If you forget, then old paths simply keep the modded speed and new paths are vanilla game defaults."
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToModDefaults)), "Mod defaults" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToModDefaults)),
                    "Applies the mod’s default tuning values."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToVanilla)), "Game defaults" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToVanilla)),
                    "Sets all sliders to **100%** and restores game defaults (vanilla)."
                },

                // Status lines
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StatusSummary1)), "Bike group" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StatusSummary1)),
                    "Bikes and electric scooters.\n" +
                    "**Active** = has a current lane (moving).\n" +
                    "**Total Parked** = includes all Parked flags from anywhere, not just parking lots."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StatusSummary2)), "Car group" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StatusSummary2)),
                    "Personal cars only (excludes the Bike group).\n" +
                    "**Active** = has a current lane (moving).\n" +
                    "**Parked** = all **ParkedCar**, not just parking lots.\n " +
                    "Scan runs only while Options menu is open, not in-city gameplay, so no FPS concern."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StatusSummary3)), "Hidden parked cars" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StatusSummary3)),
                    "**Total at OC border** = car-group vehicles with ParkedCar at Outside City (OC) connection.\n" +
                    "Some cities show a large number of cars stuck parked at Outside City connection.\n" +
                    "Use <Log hidden cars> for sample breakdown of hidden cars.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.LogBorderHiddenCars)), "Log hidden cars" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.LogBorderHiddenCars)),
                    "Writes a one-time report to **Logs/FastBikes.log**.\n" +
                    "Includes Total + Bucket A/B/C breakdown and sample ID numbers.\n" +
                    "Use Scene Explorer mod to Jump To the listed Vehicle entity IDs and investigate."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenLogFromStatus)), "Open Log" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenLogFromStatus)),
                    "Opens **Logs/FastBikes.log** if it exists.\n" +
                    "If the file is not found yet, opens the Logs folder instead."
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

                // Debug
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.DumpBicyclePrefabs)), "Bike debug report" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.DumpBicyclePrefabs)),
                    "<Not needed for normal gameplay>.\n" +
                    "One-time detailed log report for debugging or game patch day verify.\n" +
                    "Load a city first.\n" +
                    "Output location: **Logs/FastBikes.log**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenLogFromDebug)), "Open Log" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenLogFromDebug)),
                    "Opens **Logs/FastBikes.log** if it exists.\n" +
                    "If the file is not found yet, opens the Logs folder instead."
                }
            };
        }

        public void Unload( )
        {
        }
    }
}
