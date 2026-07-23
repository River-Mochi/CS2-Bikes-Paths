// <copyright file="LocaleDE.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleDE.cs
// Purpose: German entries for BikeAndPath.

namespace BikeAndPath
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
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsStatusGrp),     "Status persönlicher Fahrzeuge" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsPathSpeedGrp),  "Wege" },

                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutInfoGrp),  "Mod-Info" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutLinksGrp), "Links" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutDebugGrp), "Debug" },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.EnableFastBikes)), "Bikes + Paths aktivieren" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.EnableFastBikes)),
                    "Schaltet den Mod **EIN / AUS**.\n" +
                    "Wenn AUS, werden Fahrrad- und Scooter-Verhalten auf die Spielstandardwerte zurückgesetzt.\n" +
                    "\n" +
                    "Die Statusinfos unten sind auch verfügbar, wenn Bikes + Paths AUS ist."
                },

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
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.PathSpeedScalar)), "Geschwindigkeitslimit für Wege" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.PathSpeedScalar)),
                    "Skaliert **Wege**-Geschwindigkeitslimits (Wege sind keine Straßen).\n" +
                    "**1.00 = Spielstandard**\n" +
                    "Betrifft: Fahrradwege, getrennte Fußgänger+Fahrrad-Wege und Fußwege.\n" +
                    "\n" +
                    "Deinstallationshinweis: auf 1.00 setzen oder Reset-Button nutzen, Stadt speichern, dann deinstallieren.\n" +
                    "Falls du es vergisst, behalten alte Wege einfach die Mod-Geschwindigkeit und neue Wege nutzen Vanilla-Standardwerte."
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToModDefaults)), "Mod-Standardwerte" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToModDefaults)),
                    "Wendet die Standardwerte des Mods an."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToVanilla)), "Spielstandardwerte" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToVanilla)),
                    "Setzt alle Regler auf **100 %** und stellt die Spielstandardwerte (Vanilla) wieder her."
                },

                // Status lines
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StatusSummary1)), "Fahrradgruppe" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StatusSummary1)),
                    "Fahrräder und E-Scooter.\n" +
                    "**Aktiv** = hat eine aktuelle Spur (in Bewegung).\n" +
                    "**Geparkt gesamt** = enthält alle Parked-Flags überall, nicht nur Parkplätze."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StatusSummary2)), "Autogruppe" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StatusSummary2)),
                    "Nur private Autos (ohne Fahrradgruppe).\n" +
                    "**Aktiv** = hat eine aktuelle Spur (in Bewegung).\n" +
                    "**Geparkt** = alle **ParkedCar**, nicht nur Parkplätze.\n" +
                    "Scan läuft nur, wenn das Optionen-Menü offen ist, nicht während normalem Stadt-Gameplay, also keine FPS-Sorge."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StatusSummary3)), "Versteckt geparkte Autos" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StatusSummary3)),
                    "**Gesamt an OC-Grenze** = Autogruppen-Fahrzeuge mit ParkedCar an der Outside-City-Verbindung (OC).\n" +
                    "Manche Städte zeigen viele Autos, die an der Outside-City-Verbindung geparkt festhängen.\n" +
                    "Nutze <Log hidden cars> für eine Beispielaufschlüsselung versteckter Autos."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.LogBorderHiddenCars)), "Versteckte Autos loggen" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.LogBorderHiddenCars)),
                    "Schreibt einen einmaligen Bericht nach **Logs/BikesAndPaths.log**.\n" +
                    "Enthält Gesamtzahl + Bucket-A/B/C-Aufschlüsselung und Beispiel-IDs.\n" +
                    "Nutze den Scene Explorer Mod, um zu den gelisteten Vehicle-Entity-IDs zu springen und zu prüfen."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenLogFromStatus)), "Log öffnen" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenLogFromStatus)),
                    "Öffnet **Logs/BikesAndPaths.log**, falls vorhanden.\n" +
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
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutName)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutName)),     "Anzeigename." },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutVersion)),  "Aktuelle Version." },

                // Links
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenParadoxMods)),  "Öffnet die Paradox-Mods-Seite des Autors." },

                // Debug
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.DumpBicyclePrefabs)), "Fahrrad-Debugbericht" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.DumpBicyclePrefabs)),
                    "<Für normales Gameplay nicht nötig>.\n" +
                    "Einmaliger Detailbericht zum Debuggen oder Prüfen nach einem Spielpatch.\n" +
                    "Zuerst eine Stadt laden.\n" +
                    "Ausgabeort: **Logs/BikesAndPaths.log**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenLogFromDebug)), "Log öffnen" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenLogFromDebug)),
                    "Öffnet **Logs/BikesAndPaths.log**, falls vorhanden.\n" +
                    "Wenn die Datei noch nicht gefunden wird, wird stattdessen der Logs-Ordner geöffnet."
                }
            };
        }

        public void Unload( )
        {
        }
    }
}

