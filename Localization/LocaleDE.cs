// <copyright file="LocaleDE.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleDE.cs
// Purpose: German entries for BikesAndPaths.

namespace BikesAndPaths
{
    using System.Collections.Generic;  // IEnumerable, Dictionary, KeyValuePair
    using Colossal;                    // IDictionarySource, IDictionaryEntryError

    public sealed class LocaleDE : IDictionarySource
    {
        private readonly BPSetting m_Setting;

        public LocaleDE(BPSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(BPSetting.ActionsTab), "Aktionen" },
                { m_Setting.GetOptionTabLocaleID(BPSetting.AboutTab),   "Info" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsSpeedGrp),      "Geschwindigkeit" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsStabilityGrp),  "Stabilität" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsResetGrp),      "Zurücksetzen" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsPathSpeedGrp),  "Wege" },

                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutInfoGrp),  "Mod-Info" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutLinksGrp), "Links" },

                // Retirement notice
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsMigrationGrp), "ASL" },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.MigrationText)),
                    "❤️ Bikes + Paths wird nicht mehr weiterentwickelt.\n\n" +
                    "Danke, dass du den Mod genutzt hast! Alle Funktionen sind jetzt in Adjust All Speed Limits (ASL), mit einem erweiterten Stadt-Panel für Rad- und Fußwege. Wechsle bitte über die Schaltfläche unten zu ASL.\n\n" +
                    "Du kannst B+P jederzeit entfernen. Für sofortige Spielstandardwerte nutze die Zurücksetzen-Schaltfläche, warte auf die Änderungen und speichere die Stadt. Das ist freiwillig.\n\n" +
                    "Danke, River-mochi"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AslMigrationText)),
                    "❤️ Bikes + Paths wird nicht mehr weiterentwickelt.\n\n" +
                    "Danke, dass du den Mod genutzt hast! Alle Funktionen sind jetzt in Adjust All Speed Limits (ASL), mit einem erweiterten Stadt-Panel für Rad- und Fußwege.\n\n" +
                    "ASL verwaltet deine Geschwindigkeitseinstellungen bereits. Du kannst B+P jetzt entfernen. Zurücksetzen ist nicht nötig.\n\n" +
                    "Danke, River-mochi"
                },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "Bikes + Paths aktivieren" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "Schaltet B+P ein oder aus. Beim Ausschalten werden nicht von ASL gesteuerte Werte zurückgesetzt." },

                // Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.SpeedScalar)), "Fahrrad- & Scooter-Geschwindigkeit" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.SpeedScalar)),
                    "**Skaliert die Maximalgeschwindigkeit**.\n" +
                    "Beschleunigung + Bremsen nutzen bei hoher Geschwindigkeit Glättung, damit Starts weniger springen und Bremsen weniger panisch wirken.\n" +
                    "**0.30 = 30 %** des Spielstandards\n" +
                    "**1.00 = Spielstandard**\n" +
                    "Hinweis: Straßenlimits und Spielbedingungen gelten weiterhin."
                },

                // Stability
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StiffnessScalar)), "Steifigkeit" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StiffnessScalar)),
    //                "Skalar für **Schwankungsamplitude**.\n" +
    //                "**Höher = weniger Neigung**.\n" +
    //                "**Niedriger = mehr Wackeln**.\n" +
    //                "Empfohlen: 1.25–1.75 für Stabilität bei hoher Geschwindigkeit."
    //            },
    //
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.DampingScalar)), "Dämpfung" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.DampingScalar)),
    //                "Höher = beruhigt sich schneller (weniger Schwingung).\n" +
    //                "**1.00 = Spielstandard**\n" +
    //                "Empfohlen: 1.25–2.00 für Stabilität bei hoher Geschwindigkeit."
    //            },

                // Path Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "ALL Speed Limits on Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "Öffnet Adjust All Speed Limits auf Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.PathSpeedScalar)), "Geschwindigkeitslimit für Wege" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.PathSpeedScalar)),
                    "Skaliert **Wege**-Geschwindigkeitslimits (Wege sind keine Straßen).\n" +
                    "**1.00 = Spielstandard**\n" +
                    "Betrifft: Fahrradwege, getrennte Fußgänger+Fahrrad-Wege und Fußwege.\n" +
                    "\n" +
                    "Optional: Spielstandard wiederherstellen und vor dem Entfernen speichern. Sonst können bestehende Wege ihr geändertes Tempo behalten."
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToModDefaults)), "Mod-Standardwerte" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToModDefaults)),
                    "Wendet die Standardwerte des Mods an."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToVanilla)), "Auf Spielstandard zurücksetzen" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToVanilla)),
                    "Setzt alle Regler auf **100 %** und stellt die Spielstandardwerte (Vanilla) wieder her."
                },
                // Status fallback keys
                { "FAST_STATUS_NOT_LOADED",     "Status nicht geladen." },
                { "FAST_STATS_NOT_AVAIL",       "Keine Stadt... ¯\\_(ツ)_/¯ ...Keine Stats" },
                { "FAST_STATS_CARS_NOT_AVAIL",  "Stadt ein paar Minuten laufen lassen für Daten." },

                // Status rows
                { "FAST_STATS_BIKES_ROW1", "{0} aktiv | {1} Fahrräder | {2} Scooter | {3} / {4} geparkt/gesamt" },
                { "FAST_STATS_CARS_ROW2",  "{0} aktiv | {1} geparkt | {2} gesamt | {3} Anhänger" },

                // Row3 shows TOTAL OC hidden
                { "FAST_STATS_CARS_ROW3",  "{0} an OC-Grenze versteckt | aktualisiert {1}" },

                // About: Info
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutName)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutName)),     "Anzeigename." },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutVersion)),  "Aktuelle Version." },

                // Links
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenParadoxMods)),  "Öffnet die Paradox-Mods-Seite des Autors." },

            };
        }

        public void Unload( )
        {
        }
    }
}

