// <copyright file="LocaleDE.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleDE.cs
// Purpose: German entries for FastBikes.

namespace FastBikes
{
    using System.Collections.Generic;  // IEnumerable, Dictionary, KeyValuePair
    using Colossal;                    // IDictionarySource, IDictionaryEntryError

    public sealed class LocaleDE : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleDE(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Aktionen" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "Info" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.ActionsSpeedGrp),      "Geschwindigkeit" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ActionsStabilityGrp),  "Stabilität" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ActionsResetGrp),      "Zurücksetzen" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ActionsStatusGrp),     "Status persönlicher Fahrzeuge" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ActionsPathSpeedGrp),  "Wege" },

                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Mod-Info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutDebugGrp), "Debug" },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableFastBikes)), "Fast Bikes aktivieren" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableFastBikes)),
                    "Schaltet den Mod **EIN / AUS**.\n" +
                    "Wenn AUS, werden Fahrrad- und Scooter-Verhalten auf die Spielstandardwerte zurückgesetzt.\n" +
                    "\n" +
                    "Die Statusinfos unten sind auch verfügbar, wenn Fast Bikes AUS ist."
                },

                // Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SpeedScalar)), "Fahrrad- & Scooter-Geschwindigkeit" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SpeedScalar)),
                    "**Skaliert die Maximalgeschwindigkeit**.\n" +
                    "Beschleunigung + Bremsen nutzen bei hoher Geschwindigkeit Glättung, damit Starts weniger springen und Bremsen weniger panisch wirken.\n" +
                    "**0.30 = 30 %** des Spielstandards\n" +
                    "**1.00 = Spielstandard**\n" +
                    "Hinweis: Straßenlimits und Spielbedingungen gelten weiterhin."
                },

                // Stability
    //            { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StiffnessScalar)), "Steifigkeit" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(Setting.StiffnessScalar)),
    //                "Skalar für **Schwankungsamplitude**.\n" +
    //                "**Höher = weniger Neigung**.\n" +
    //                "**Niedriger = mehr Wackeln**.\n" +
    //                "Empfohlen: 1.25–1.75 für Stabilität bei hoher Geschwindigkeit."
    //            },
    //
    //            { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DampingScalar)), "Dämpfung" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(Setting.DampingScalar)),
    //                "Höher = beruhigt sich schneller (weniger Schwingung).\n" +
    //                "**1.00 = Spielstandard**\n" +
    //                "Empfohlen: 1.25–2.00 für Stabilität bei hoher Geschwindigkeit."
    //            },

                // Path Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PathSpeedScalar)), "Geschwindigkeitslimit für Wege" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PathSpeedScalar)),
                    "Skaliert **Wege**-Geschwindigkeitslimits (Wege sind keine Straßen).\n" +
                    "**1.00 = Spielstandard**\n" +
                    "Betrifft: Fahrradwege, getrennte Fußgänger+Fahrrad-Wege und Fußwege.\n" +
                    "\n" +
                    "Deinstallationshinweis: auf 1.00 setzen oder Reset-Button nutzen, Stadt speichern, dann deinstallieren.\n" +
                    "Falls du es vergisst, behalten alte Wege einfach die Mod-Geschwindigkeit und neue Wege nutzen Vanilla-Standardwerte."
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToModDefaults)), "Mod-Standardwerte" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToModDefaults)),
                    "Wendet die Standardwerte des Mods an."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Spielstandardwerte" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "Setzt alle Regler auf **100 %** und stellt die Spielstandardwerte (Vanilla) wieder her."
                },

                // Status lines
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusSummary1)), "Fahrradgruppe" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusSummary1)),
                    "Fahrräder und E-Scooter.\n" +
                    "**Aktiv** = hat eine aktuelle Spur (in Bewegung).\n" +
                    "**Geparkt gesamt** = enthält alle Parked-Flags überall, nicht nur Parkplätze."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusSummary2)), "Autogruppe" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusSummary2)),
                    "Nur private Autos (ohne Fahrradgruppe).\n" +
                    "**Aktiv** = hat eine aktuelle Spur (in Bewegung).\n" +
                    "**Geparkt** = alle **ParkedCar**, nicht nur Parkplätze.\n" +
                    "Scan läuft nur, wenn das Optionen-Menü offen ist, nicht während normalem Stadt-Gameplay, also keine FPS-Sorge."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusSummary3)), "Versteckt geparkte Autos" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusSummary3)),
                    "**Gesamt an OC-Grenze** = Autogruppen-Fahrzeuge mit ParkedCar an der Outside-City-Verbindung (OC).\n" +
                    "Manche Städte zeigen viele Autos, die an der Outside-City-Verbindung geparkt festhängen.\n" +
                    "Nutze <Log hidden cars> für eine Beispielaufschlüsselung versteckter Autos."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.LogBorderHiddenCars)), "Versteckte Autos loggen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.LogBorderHiddenCars)),
                    "Schreibt einen einmaligen Bericht nach **Logs/FastBikes.log**.\n" +
                    "Enthält Gesamtzahl + Bucket-A/B/C-Aufschlüsselung und Beispiel-IDs.\n" +
                    "Nutze den Scene Explorer Mod, um zu den gelisteten Vehicle-Entity-IDs zu springen und zu prüfen."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLogFromStatus)), "Log öffnen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLogFromStatus)),
                    "Öffnet **Logs/FastBikes.log**, falls vorhanden.\n" +
                    "Wenn die Datei noch nicht gefunden wird, wird stattdessen der Logs-Ordner geöffnet."
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
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),     "Anzeigename." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)),  "Aktuelle Version." },

                // Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),  "Öffnet die Paradox-Mods-Seite des Autors." },

                // Debug
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpBicyclePrefabs)), "Fahrrad-Debugbericht" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpBicyclePrefabs)),
                    "<Für normales Gameplay nicht nötig>.\n" +
                    "Einmaliger Detailbericht zum Debuggen oder Prüfen nach einem Spielpatch.\n" +
                    "Zuerst eine Stadt laden.\n" +
                    "Ausgabeort: **Logs/FastBikes.log**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLogFromDebug)), "Log öffnen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLogFromDebug)),
                    "Öffnet **Logs/FastBikes.log**, falls vorhanden.\n" +
                    "Wenn die Datei noch nicht gefunden wird, wird stattdessen der Logs-Ordner geöffnet."
                }
            };
        }

        public void Unload( )
        {
        }
    }
}
