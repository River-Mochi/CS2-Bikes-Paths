// <copyright file="LocalePL.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocalePL.cs
// Purpose: Polish entries for FastBikes.

namespace FastBikes
{
    using System.Collections.Generic;  // IEnumerable, Dictionary, KeyValuePair
    using Colossal;                    // IDictionarySource, IDictionaryEntryError

    public sealed class LocalePL : IDictionarySource
    {
        private readonly FBSetting m_Setting;

        public LocalePL(FBSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(FBSetting.ActionsTab), "Akcje" },
                { m_Setting.GetOptionTabLocaleID(FBSetting.AboutTab),   "O modzie" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsSpeedGrp),      "Prędkość" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsStabilityGrp),  "Stabilność" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsResetGrp),      "Reset" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsStatusGrp),     "Status pojazdów osobistych" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsPathSpeedGrp),  "Ścieżki" },

                { m_Setting.GetOptionGroupLocaleID(FBSetting.AboutInfoGrp),  "Informacje o modzie" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.AboutLinksGrp), "Linki" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.AboutDebugGrp), "Debug" },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.EnableFastBikes)), "Włącz Fast Bikes" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.EnableFastBikes)),
                    "Włącza lub wyłącza mod **ON / OFF**.\n" +
                    "Gdy jest wyłączony, zachowanie rowerów i hulajnóg wraca do wartości gry.\n" +
                    "\n" +
                    "Status poniżej jest dostępny nawet wtedy, gdy Fast Bikes jest wyłączony."
                },

                // Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.SpeedScalar)), "Prędkość rowerów i hulajnóg" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.SpeedScalar)),
                    "**Skaluje prędkość maksymalną**.\n" +
                    "Przy dużej prędkości przyspieszanie + hamowanie używa wygładzania, aby było mniej nagłych startów i panikowego hamowania.\n" +
                    "**0.30 = 30%** domyślnej wartości gry\n" +
                    "**1.00 = domyślna wartość gry**\n" +
                    "Uwaga: limity dróg i warunki gry nadal obowiązują."
                },

                // Stability
    //            { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StiffnessScalar)), "Sztywność" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(Setting.StiffnessScalar)),
    //                "Mnożnik **amplitudy kołysania**.\n" +
    //                "**Wyżej = mniej przechyłu**.\n" +
    //                "**Niżej = więcej chwiania**.\n" +
    //                "Zalecane: 1.25–1.75 dla stabilności przy dużej prędkości."
    //            },
    //
    //            { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DampingScalar)), "Tłumienie" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(Setting.DampingScalar)),
    //                "Wyżej = szybciej się uspokaja (mniej oscylacji).\n" +
    //                "**1.00 = domyślna wartość gry**\n" +
    //                "Zalecane: 1.25–2.00 dla stabilności przy dużej prędkości."
    //            },

                // Path Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.PathSpeedScalar)), "Limit prędkości ścieżek" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.PathSpeedScalar)),
                    "Skaluje limity prędkości **ścieżek** (ścieżki nie są drogami).\n" +
                    "**1.00 = domyślna wartość gry**\n" +
                    "Dotyczy: ścieżek rowerowych, dzielonych pieszy+rower oraz ścieżek pieszych.\n" +
                    "\n" +
                    "Przed odinstalowaniem: ustaw 1.00 lub użyj resetu, zapisz miasto, potem odinstaluj.\n" +
                    "Jeśli zapomnisz, stare ścieżki zachowają zmienioną prędkość, a nowe będą używać wartości vanilla."
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.ResetToModDefaults)), "Domyślne moda" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.ResetToModDefaults)),
                    "Stosuje domyślne wartości strojenia moda."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.ResetToVanilla)), "Domyślne gry" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.ResetToVanilla)),
                    "Ustawia wszystkie suwaki na **100%** i przywraca domyślne wartości gry (vanilla)."
                },

                // Status lines
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.StatusSummary1)), "Grupa rowerów" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.StatusSummary1)),
                    "Rowery i hulajnogi elektryczne.\n" +
                    "**Aktywne** = mają aktualny pas (poruszają się).\n" +
                    "**Łącznie zaparkowane** = obejmuje wszystkie flagi Parked z każdego miejsca, nie tylko parkingi."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.StatusSummary2)), "Grupa aut" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.StatusSummary2)),
                    "Tylko auta osobiste (bez grupy rowerów).\n" +
                    "**Aktywne** = mają aktualny pas (poruszają się).\n" +
                    "**Zaparkowane** = wszystkie **ParkedCar**, nie tylko parkingi.\n" +
                    "Skan działa tylko przy otwartym menu Opcje, nie podczas normalnej gry w mieście, więc bez obaw o FPS."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.StatusSummary3)), "Ukryte zaparkowane auta" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.StatusSummary3)),
                    "**Łącznie na granicy OC** = pojazdy z grupy aut z ParkedCar przy połączeniu Outside City (OC).\n" +
                    "W niektórych miastach wiele aut może utknąć zaparkowanych przy połączeniu Outside City.\n" +
                    "Użyj <Log hidden cars>, aby zobaczyć przykładowy podział ukrytych aut."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.LogBorderHiddenCars)), "Zaloguj ukryte auta" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.LogBorderHiddenCars)),
                    "Zapisuje jednorazowy raport do **Logs/FastBikes.log**.\n" +
                    "Zawiera łączną liczbę + podział Bucket A/B/C oraz przykładowe numery ID.\n" +
                    "Użyj moda Scene Explorer, aby przejść do podanych ID encji Vehicle i sprawdzić."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.OpenLogFromStatus)), "Otwórz log" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.OpenLogFromStatus)),
                    "Otwiera **Logs/FastBikes.log**, jeśli istnieje.\n" +
                    "Jeśli plik jeszcze nie istnieje, otwiera folder Logs."
                },

                // Status fallback keys
                { "FAST_STATUS_NOT_LOADED",     "Status niezaładowany." },
                { "FAST_STATS_NOT_AVAIL",       "Brak miasta... ¯\\_(ツ)_/¯ ...Brak statystyk" },
                { "FAST_STATS_CARS_NOT_AVAIL",  "uruchom miasto na kilka minut, aby zebrać dane." },

                // Status rows
                { "FAST_STATS_BIKES_ROW1", "{0} aktywne | {1} rowery | {2} hulajnogi | {3} / {4} zaparkowane/łącznie" },
                { "FAST_STATS_CARS_ROW2",  "{0} aktywne | {1} zaparkowane | {2} łącznie | {3} przyczepy" },

                // Row3 shows TOTAL OC hidden
                { "FAST_STATS_CARS_ROW3",  "{0} ukryte na granicy OC | aktualizacja {1}" },

                // About: Info
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.AboutName)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.AboutName)),     "Nazwa wyświetlana." },
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.AboutVersion)), "Wersja" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.AboutVersion)),  "Aktualna wersja." },

                // Links
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.OpenParadoxMods)),  "Otwiera stronę autora w Paradox Mods." },

                // Debug
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.DumpBicyclePrefabs)), "Raport debug rowerów" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.DumpBicyclePrefabs)),
                    "<Niepotrzebne do normalnej gry>.\n" +
                    "Jednorazowy szczegółowy raport do debugowania lub sprawdzenia po aktualizacji gry.\n" +
                    "Najpierw wczytaj miasto.\n" +
                    "Lokalizacja wyjścia: **Logs/FastBikes.log**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.OpenLogFromDebug)), "Otwórz log" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.OpenLogFromDebug)),
                    "Otwiera **Logs/FastBikes.log**, jeśli istnieje.\n" +
                    "Jeśli plik jeszcze nie istnieje, otwiera folder Logs."
                }
            };
        }

        public void Unload( )
        {
        }
    }
}
