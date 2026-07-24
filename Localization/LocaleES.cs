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
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsStatusGrp),     "Estado de vehículos personales" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsPathSpeedGrp),  "Caminos" },

                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutInfoGrp),  "Info del mod" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutLinksGrp), "Enlaces" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutDebugGrp), "Depuración" },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "Activar Bikes + Paths" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.EnableBikesAndPaths)),
                    "Activa o desactiva el mod **ON / OFF**.\n" +
                    "Cuando está desactivado, las bicis y scooters vuelven a los valores del juego.\n" +
                    "\n" +
                    "La información de estado de abajo sigue disponible aunque Bikes + Paths esté desactivado."
                },

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

                // Status lines
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StatusSummary1)), "Grupo bici" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StatusSummary1)),
                    "Bicis y scooters eléctricos.\n" +
                    "**Activo** = tiene un carril actual (en movimiento).\n" +
                    "**Total aparcado** = incluye todos los estados Parked de cualquier lugar, no solo aparcamientos."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StatusSummary2)), "Grupo coche" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StatusSummary2)),
                    "Solo coches personales (excluye el grupo bici).\n" +
                    "**Activo** = tiene un carril actual (en movimiento).\n" +
                    "**Aparcado** = todos los **ParkedCar**, no solo aparcamientos.\n" +
                    "El escaneo solo se ejecuta con el menú Opciones abierto, no durante el juego normal en la ciudad, así que no afecta a los FPS."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StatusSummary3)), "Coches aparcados ocultos" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StatusSummary3)),
                    "**Total en borde OC** = vehículos del grupo coche con ParkedCar en la conexión Outside City (OC).\n" +
                    "Algunas ciudades muestran muchos coches atrapados aparcados en la conexión Outside City.\n" +
                    "Usa <Log hidden cars> para ver un desglose de ejemplo de coches ocultos."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.LogBorderHiddenCars)), "Registrar coches ocultos" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.LogBorderHiddenCars)),
                    "Escribe un informe único en **Logs/BikesAndPaths.log**.\n" +
                    "Incluye total + desglose Bucket A/B/C y números ID de ejemplo.\n" +
                    "Usa el mod Scene Explorer para saltar a los ID de entidad Vehicle listados e investigar."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenLogFromStatus)), "Abrir log" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenLogFromStatus)),
                    "Abre **Logs/BikesAndPaths.log** si existe.\n" +
                    "Si el archivo aún no existe, abre la carpeta Logs."
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

                // Debug
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.DumpBicyclePrefabs)), "Informe debug de bicis" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.DumpBicyclePrefabs)),
                    "<No es necesario para jugar normalmente>.\n" +
                    "Informe detallado único para depuración o verificación tras un parche del juego.\n" +
                    "Carga primero una ciudad.\n" +
                    "Ubicación de salida: **Logs/BikesAndPaths.log**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenLogFromDebug)), "Abrir log" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenLogFromDebug)),
                    "Abre **Logs/BikesAndPaths.log** si existe.\n" +
                    "Si el archivo aún no existe, abre la carpeta Logs."
                }
            };
        }

        public void Unload( )
        {
        }
    }
}

