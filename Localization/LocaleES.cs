// <copyright file="LocaleES.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleES.cs
// Purpose: Spanish entries for BikesAndPaths.

namespace BikesAndPaths
{
    using System.Collections.Generic;  // IEnumerable, Dictionary, KeyValuePair
    using Colossal;                    // IDictionarySource, IDictionaryEntryError

    public sealed class LocaleES : IDictionarySource
    {
        private readonly BPSetting m_Setting;

        public LocaleES(BPSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(BPSetting.ActionsTab), "Acciones" },
                { m_Setting.GetOptionTabLocaleID(BPSetting.AboutTab),   "Acerca de" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsSpeedGrp),      "Velocidad" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsStabilityGrp),  "Estabilidad" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsResetGrp),      "Restablecer" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsPathSpeedGrp),  "Caminos" },

                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutInfoGrp),  "Info del mod" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutLinksGrp), "Enlaces" },

                // Retirement notice
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsMigrationGrp), "ASL" },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.MigrationText)),
                    "❤️ Bikes + Paths se ha retirado.\n\n" +
                    "¡Gracias por usar este mod! Todas sus funciones están ahora en Adjust All Speed Limits (ASL), con un panel en la ciudad más completo para vías ciclistas y peatonales. Cambia a ASL con el botón de abajo.\n\n" +
                    "Antes de cambiar, usa B+P sin ASL, restaura los valores del juego, espera a que termine y guarda la ciudad. Después elimina B+P e instala ASL.\n\n" +
                    "Gracias, River-mochi"
                },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "Activar Bikes + Paths" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "Activa o desactiva B+P. Al desactivarlo, restaura los valores no controlados por ASL." },

                // Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.SpeedScalar)), "Velocidad de bici y scooter" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.SpeedScalar)),
                    "**Escala la velocidad máxima**.\n" +
                    "La aceleración + frenado usan suavizado a alta velocidad para menos salidas bruscas y menos aspecto de frenazo de pánico.\n" +
                    "**0.30 = 30 %** del valor del juego\n" +
                    "**1.00 = valor del juego**\n" +
                    "Nota: los límites de carretera y las condiciones del juego siguen aplicándose."
                },

                // Stability
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StiffnessScalar)), "Rigidez" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StiffnessScalar)),
    //                "Multiplicador para la **amplitud del balanceo**.\n" +
    //                "**Más alto = menos inclinación**.\n" +
    //                "**Más bajo = más tambaleo**.\n" +
    //                "Sugerido: 1.25–1.75 para estabilidad a alta velocidad."
    //            },
    //
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.DampingScalar)), "Amortiguación" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.DampingScalar)),
    //                "Más alto = se estabiliza antes (menos oscilación).\n" +
    //                "**1.00 = valor del juego**\n" +
    //                "Sugerido: 1.25–2.00 para estabilidad a alta velocidad."
    //            },

                // Path Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "ALL Speed Limits on Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "Abre Adjust All Speed Limits en Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.PathSpeedScalar)), "Límite de velocidad de caminos" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.PathSpeedScalar)),
                    "Escala los límites de velocidad de **caminos** (los caminos no son carreteras).\n" +
                    "**1.00 = valor del juego**\n" +
                    "Afecta: carriles bici, caminos divididos peatón+bici y caminos peatonales.\n" +
                    "\n" +
                    "Nota para desinstalar: ponlo en 1.00 o usa el botón de restablecer, guarda la ciudad y luego desinstala.\n" +
                    "Si se te olvida, los caminos antiguos conservan la velocidad modificada y los nuevos usan los valores vanilla."
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToModDefaults)), "Valores del mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToModDefaults)),
                    "Aplica los valores predeterminados del mod."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToVanilla)), "Valores del juego" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToVanilla)),
                    "Pone todos los deslizadores al **100 %** y restaura los valores del juego (vanilla)."
                },
                // Status fallback keys
                { "FAST_STATUS_NOT_LOADED",     "Estado no cargado." },
                { "FAST_STATS_NOT_AVAIL",       "Sin ciudad... ¯\\_(ツ)_/¯ ...Sin estadísticas" },
                { "FAST_STATS_CARS_NOT_AVAIL",  "ejecuta la ciudad unos minutos para obtener datos." },

                // Status rows
                { "FAST_STATS_BIKES_ROW1", "{0} activos | {1} bicis | {2} scooters | {3} / {4} aparcados/total" },
                { "FAST_STATS_CARS_ROW2",  "{0} activos | {1} aparcados | {2} total | {3} remolques" },

                // Row3 shows TOTAL OC hidden
                { "FAST_STATS_CARS_ROW3",  "{0} ocultos en borde OC | actualizado {1}" },

                // About: Info
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutName)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutName)),     "Nombre mostrado." },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutVersion)), "Versión" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutVersion)),  "Versión actual." },

                // Links
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenParadoxMods)),  "Abre la página de Paradox Mods del autor." },

            };
        }

        public void Unload( )
        {
        }
    }
}

