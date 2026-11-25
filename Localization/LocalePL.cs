// <copyright file="LocalePL.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocalePL.cs
// Purpose: Polish entries for BikesAndPaths.

namespace BikesAndPaths
{
    using System.Collections.Generic;  // IEnumerable, Dictionary, KeyValuePair
    using Colossal;                    // IDictionarySource, IDictionaryEntryError

    public sealed class LocalePL : IDictionarySource
    {
        private readonly BPSetting m_Setting;

        public LocalePL(BPSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(BPSetting.ActionsTab), "Akcje" },
                { m_Setting.GetOptionTabLocaleID(BPSetting.AboutTab),   "O modzie" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsSpeedGrp),      "Prędkość" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsStabilityGrp),  "Stabilność" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsResetGrp),      "Reset" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsPathSpeedGrp),  "Ścieżki" },

                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutInfoGrp),  "Informacje o modzie" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutLinksGrp), "Linki" },

                // Retirement notice
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsMigrationGrp), "ASL" },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.MigrationText)),
                    "❤️ Bikes + Paths nie jest już rozwijany.\n\n" +
                    "Dziękuję za korzystanie z moda! Wszystkie funkcje są teraz w Adjust All Speed Limits (ASL), z bardziej rozbudowanym panelem w mieście dla ścieżek rowerowych i pieszych. Przejdź do ASL przyciskiem poniżej.\n\n" +
                    "B+P możesz usunąć w każdej chwili. Aby od razu przywrócić ustawienia gry, użyj przycisku przywracania, poczekaj na zakończenie zmian i zapisz miasto. To opcjonalne.\n\n" +
                    "Dziękuję, River-mochi"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AslMigrationText)),
                    "❤️ Bikes + Paths nie jest już rozwijany.\n\n" +
                    "Dziękuję za korzystanie z moda! Wszystkie funkcje są teraz w Adjust All Speed Limits (ASL), z bardziej rozbudowanym panelem w mieście dla ścieżek rowerowych i pieszych. Przejdź do ASL przyciskiem poniżej.\n\n" +
                    "ASL już zarządza ustawieniami prędkości. Możesz usunąć B+P bez resetowania.\n\n" +
                    "Dziękuję, River-mochi"
                },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "Włącz Bikes + Paths" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "Włącza lub wyłącza B+P. Wyłączenie przywraca wartości niezarządzane przez ASL." },

                // Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.SpeedScalar)), "Prędkość rowerów i hulajnóg" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.SpeedScalar)),
                    "**Skaluje prędkość maksymalną**.\n" +
                    "Przy dużej prędkości przyspieszanie + hamowanie używa wygładzania, aby było mniej nagłych startów i panikowego hamowania.\n" +
                    "**0.30 = 30%** domyślnej wartości gry\n" +
                    "**1.00 = domyślna wartość gry**\n" +
                    "Uwaga: limity dróg i warunki gry nadal obowiązują."
                },

                // Stability
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StiffnessScalar)), "Sztywność" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StiffnessScalar)),
    //                "Mnożnik **amplitudy kołysania**.\n" +
    //                "**Wyżej = mniej przechyłu**.\n" +
    //                "**Niżej = więcej chwiania**.\n" +
    //                "Zalecane: 1.25–1.75 dla stabilności przy dużej prędkości."
    //            },
    //
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.DampingScalar)), "Tłumienie" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.DampingScalar)),
    //                "Wyżej = szybciej się uspokaja (mniej oscylacji).\n" +
    //                "**1.00 = domyślna wartość gry**\n" +
    //                "Zalecane: 1.25–2.00 dla stabilności przy dużej prędkości."
    //            },

                // Path Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "ALL Speed Limits on Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "Otwiera Adjust All Speed Limits w Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.PathSpeedScalar)), "Limit prędkości ścieżek" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.PathSpeedScalar)),
                    "Skaluje limity prędkości **ścieżek** (ścieżki nie są drogami).\n" +
                    "**1.00 = domyślna wartość gry**\n" +
                    "Dotyczy: ścieżek rowerowych, dzielonych pieszy+rower oraz ścieżek pieszych.\n" +
                    "\n" +
                    "Przed odinstalowaniem: ustaw 1.00 lub użyj resetu, zapisz miasto, potem odinstaluj.\n" +
                    "Jeśli zapomnisz, stare ścieżki zachowają zmienioną prędkość, a nowe będą używać wartości vanilla."
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToModDefaults)), "Domyślne moda" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToModDefaults)),
                    "Stosuje domyślne wartości strojenia moda."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToVanilla)), "Przywróć ustawienia gry" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToVanilla)),
                    "Ustawia wszystkie suwaki na **100%** i przywraca domyślne wartości gry (vanilla)."
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
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutName)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutName)),     "Nazwa wyświetlana." },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutVersion)), "Wersja" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutVersion)),  "Aktualna wersja." },

                // Links
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenParadoxMods)),  "Otwiera stronę autora w Paradox Mods." },

            };
        }

        public void Unload( )
        {
        }
    }
}

