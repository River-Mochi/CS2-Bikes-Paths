// <copyright file="LocaleIT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleIT.cs
// Purpose: Italian entries for BikesAndPaths.

namespace BikesAndPaths
{
    using System.Collections.Generic;  // IEnumerable, Dictionary, KeyValuePair
    using Colossal;                    // IDictionarySource, IDictionaryEntryError

    public sealed class LocaleIT : IDictionarySource
    {
        private readonly BPSetting m_Setting;

        public LocaleIT(BPSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(BPSetting.ActionsTab), "Azioni" },
                { m_Setting.GetOptionTabLocaleID(BPSetting.AboutTab),   "Info" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsSpeedGrp),      "Velocità" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsStabilityGrp),  "Stabilità" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsResetGrp),      "Ripristina" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsStatusGrp),     "Stato veicoli personali" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsPathSpeedGrp),  "Percorsi" },

                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutInfoGrp),  "Info mod" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutLinksGrp), "Link" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutDebugGrp), "Debug" },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "Abilita Bikes + Paths" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.EnableBikesAndPaths)),
                    "Attiva o disattiva la mod **ON / OFF**.\n" +
                    "Quando è OFF, bici e scooter tornano ai valori predefiniti del gioco.\n" +
                    "\n" +
                    "Le info di stato sotto restano disponibili anche se Bikes + Paths è OFF."
                },

                // Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.SpeedScalar)), "Velocità bici e scooter" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.SpeedScalar)),
                    "**Scala la velocità massima**.\n" +
                    "Accelerazione + frenata usano uno smoothing ad alta velocità per meno partenze a scatto e meno effetto frenata di panico.\n" +
                    "**0.30 = 30%** del valore del gioco\n" +
                    "**1.00 = valore del gioco**\n" +
                    "Nota: limiti stradali e condizioni di gioco si applicano comunque."
                },

                // Stability
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StiffnessScalar)), "Rigidità" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StiffnessScalar)),
    //                "Moltiplicatore per l’**ampiezza dell’oscillazione**.\n" +
    //                "**Più alto = meno inclinazione**.\n" +
    //                "**Più basso = più ondeggiamento**.\n" +
    //                "Consigliato: 1.25–1.75 per stabilità ad alta velocità."
    //            },
    //
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.DampingScalar)), "Smorzamento" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.DampingScalar)),
    //                "Più alto = si stabilizza più in fretta (meno oscillazione).\n" +
    //                "**1.00 = valore del gioco**\n" +
    //                "Consigliato: 1.25–2.00 per stabilità ad alta velocità."
    //            },

                // Path Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.PathSpeedScalar)), "Limite velocità percorsi" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.PathSpeedScalar)),
                    "Scala i limiti di velocità dei **percorsi** (i percorsi non sono strade).\n" +
                    "**1.00 = valore del gioco**\n" +
                    "Influisce su: piste ciclabili, percorsi separati pedoni+bici e percorsi pedonali.\n" +
                    "\n" +
                    "Nota disinstallazione: imposta 1.00 o usa il pulsante di reset, salva la città, poi disinstalla.\n" +
                    "Se te ne dimentichi, i vecchi percorsi restano alla velocità modificata e i nuovi usano i valori vanilla."
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToModDefaults)), "Predefiniti mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToModDefaults)),
                    "Applica i valori predefiniti della mod."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToVanilla)), "Predefiniti gioco" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToVanilla)),
                    "Imposta tutti gli slider al **100%** e ripristina i valori del gioco (vanilla)."
                },

                // Status lines
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StatusSummary1)), "Gruppo bici" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StatusSummary1)),
                    "Bici e scooter elettrici.\n" +
                    "**Attivi** = hanno una corsia attuale (in movimento).\n" +
                    "**Totale parcheggiati** = include tutti i flag Parked ovunque, non solo nei parcheggi."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StatusSummary2)), "Gruppo auto" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StatusSummary2)),
                    "Solo auto personali (esclude il gruppo bici).\n" +
                    "**Attive** = hanno una corsia attuale (in movimento).\n" +
                    "**Parcheggiate** = tutte le **ParkedCar**, non solo i parcheggi.\n" +
                    "La scansione gira solo con il menu Opzioni aperto, non durante il gameplay in città, quindi nessun problema di FPS."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StatusSummary3)), "Auto parcheggiate nascoste" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StatusSummary3)),
                    "**Totale al bordo OC** = veicoli del gruppo auto con ParkedCar alla connessione Outside City (OC).\n" +
                    "Alcune città mostrano molte auto bloccate parcheggiate alla connessione Outside City.\n" +
                    "Usa <Log hidden cars> per un esempio di dettaglio delle auto nascoste."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.LogBorderHiddenCars)), "Registra auto nascoste" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.LogBorderHiddenCars)),
                    "Scrive un report una tantum in **Logs/BikesAndPaths.log**.\n" +
                    "Include totale + dettaglio Bucket A/B/C e ID di esempio.\n" +
                    "Usa la mod Scene Explorer per saltare agli ID entità Vehicle elencati e controllare."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenLogFromStatus)), "Apri log" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenLogFromStatus)),
                    "Apre **Logs/BikesAndPaths.log** se esiste.\n" +
                    "Se il file non esiste ancora, apre invece la cartella Logs."
                },

                // Status fallback keys
                { "FAST_STATUS_NOT_LOADED",     "Stato non caricato." },
                { "FAST_STATS_NOT_AVAIL",       "Nessuna città... ¯\\_(ツ)_/¯ ...Nessuna statistica" },
                { "FAST_STATS_CARS_NOT_AVAIL",  "fai andare la città per qualche minuto per avere dati." },

                // Status rows
                { "FAST_STATS_BIKES_ROW1", "{0} attive | {1} bici | {2} scooter | {3} / {4} parcheggiate/totale" },
                { "FAST_STATS_CARS_ROW2",  "{0} attive | {1} parcheggiate | {2} totale | {3} rimorchi" },

                // Row3 shows TOTAL OC hidden
                { "FAST_STATS_CARS_ROW3",  "{0} nascoste al bordo OC | aggiornato {1}" },

                // About: Info
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutName)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutName)),     "Nome visualizzato." },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutVersion)), "Versione" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutVersion)),  "Versione attuale." },

                // Links
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenParadoxMods)),  "Apre la pagina Paradox Mods dell’autore." },

                // Debug
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.DumpBicyclePrefabs)), "Report debug bici" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.DumpBicyclePrefabs)),
                    "<Non necessario per il gameplay normale>.\n" +
                    "Report dettagliato una tantum per debug o verifica dopo patch del gioco.\n" +
                    "Carica prima una città.\n" +
                    "Percorso output: **Logs/BikesAndPaths.log**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenLogFromDebug)), "Apri log" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenLogFromDebug)),
                    "Apre **Logs/BikesAndPaths.log** se esiste.\n" +
                    "Se il file non esiste ancora, apre invece la cartella Logs."
                }
            };
        }

        public void Unload( )
        {
        }
    }
}

