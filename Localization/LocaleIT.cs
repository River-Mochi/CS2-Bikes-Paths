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
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsPathSpeedGrp),  "Percorsi" },

                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutInfoGrp),  "Info mod" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutLinksGrp), "Link" },

                // Retirement notice
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsMigrationGrp), "ASL" },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.MigrationText)),
                    "❤️ Bikes + Paths è stato ritirato.\n\n" +
                    "Grazie per aver usato questa mod! Tutte le funzioni sono ora in Adjust All Speed Limits (ASL), con un pannello in città più avanzato per piste ciclabili e percorsi pedonali. Passa ad ASL con il pulsante qui sotto.\n\n" +
                    "Prima di passare ad ASL, usa solo B+P, ripristina i valori di gioco, attendi la fine delle modifiche e salva la città. Poi rimuovi B+P e installa ASL.\n\n" +
                    "Grazie, River-mochi"
                },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "Abilita Bikes + Paths" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "Attiva o disattiva B+P. Se disattivato, ripristina i valori non gestiti da ASL." },

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
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "ALL Speed Limits on Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "Apre Adjust All Speed Limits su Paradox Mods." },

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

            };
        }

        public void Unload( )
        {
        }
    }
}

