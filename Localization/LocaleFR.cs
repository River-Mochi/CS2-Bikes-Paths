// <copyright file="LocaleFR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleFR.cs
// Purpose: French entries for BikesAndPaths.

namespace BikesAndPaths
{
    using System.Collections.Generic;  // IEnumerable, Dictionary, KeyValuePair
    using Colossal;                    // IDictionarySource, IDictionaryEntryError

    public sealed class LocaleFR : IDictionarySource
    {
        private readonly BPSetting m_Setting;

        public LocaleFR(BPSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(BPSetting.AboutTab),   "À propos" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsSpeedGrp),      "Vitesse" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsStabilityGrp),  "Stabilité" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsResetGrp),      "Réinitialiser" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsPathSpeedGrp),  "Chemins" },

                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutInfoGrp),  "Infos du mod" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutLinksGrp), "Liens" },

                // Retirement notice
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsMigrationGrp), "ASL" },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.MigrationText)),
                    "❤️ Bikes + Paths n’est plus maintenu.\n\n" +
                    "Merci d’avoir utilisé ce mod ! Toutes ses fonctions sont maintenant dans Adjust All Speed Limits (ASL), avec un panneau en ville plus complet pour les pistes cyclables et les chemins piétons. Passe à ASL via le bouton ci-dessous.\n\n" +
                    "Tu peux retirer B+P à tout moment. Pour retrouver les valeurs du jeu tout de suite, utilise Rétablir les valeurs du jeu, attends la fin des changements et sauvegarde la ville. C’est facultatif.\n\n" +
                    "Merci, River-mochi"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AslMigrationText)),
                    "❤️ Bikes + Paths n’est plus maintenu.\n\n" +
                    "Merci d’avoir utilisé ce mod ! Toutes ses fonctions sont maintenant dans Adjust All Speed Limits (ASL), avec un panneau en ville plus complet pour les pistes cyclables et les chemins piétons. Passe à ASL via le bouton ci-dessous.\n\n" +
                    "ASL gère déjà tes réglages de vitesse. Tu peux retirer B+P maintenant, sans réinitialisation.\n\n" +
                    "Merci, River-mochi"
                },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "Activer Bikes + Paths" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "Active ou désactive B+P. À la désactivation, rétablit les valeurs non gérées par ASL." },

                // Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.SpeedScalar)), "Vitesse vélo & scooter" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.SpeedScalar)),
                    "**Multiplie la vitesse maximale**.\n" +
                    "L’accélération + le freinage utilisent un lissage à haute vitesse pour moins de départs brusques et moins de freinages panique.\n" +
                    "**0.30 = 30 %** de la valeur du jeu\n" +
                    "**1.00 = valeur du jeu**\n" +
                    "Note : les limites de route et les conditions du jeu s’appliquent toujours."
                },

                // Stability
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StiffnessScalar)), "Rigidité" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StiffnessScalar)),
    //                "Multiplicateur de l’**amplitude de balancement**.\n" +
    //                "**Plus haut = moins d’inclinaison**.\n" +
    //                "**Plus bas = plus de wobble**.\n" +
    //                "Conseil : 1.25–1.75 pour plus de stabilité à haute vitesse."
    //            },
    //
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.DampingScalar)), "Amortissement" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.DampingScalar)),
    //                "Plus haut = se stabilise plus vite (moins d’oscillation).\n" +
    //                "**1.00 = valeur du jeu**\n" +
    //                "Conseil : 1.25–2.00 pour plus de stabilité à haute vitesse."
    //            },

                // Path Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "ALL Speed Limits on Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "Ouvre Adjust All Speed Limits sur Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.PathSpeedScalar)), "Limite de vitesse des chemins" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.PathSpeedScalar)),
                    "Multiplie les limites de vitesse des **chemins** (les chemins ne sont pas des routes).\n" +
                    "**1.00 = valeur du jeu**\n" +
                    "Affecte : pistes cyclables, chemins piétons+vélos séparés et chemins piétons.\n" +
                    "\n" +
                    "Note de désinstallation : remettez à 1.00 ou utilisez le bouton de réinitialisation, sauvegardez la ville, puis désinstallez.\n" +
                    "Si vous oubliez, les anciens chemins gardent simplement la vitesse modifiée et les nouveaux chemins utilisent les valeurs vanilla."
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToModDefaults)), "Valeurs du mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToModDefaults)),
                    "Applique les valeurs par défaut du mod."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToVanilla)), "Rétablir les valeurs du jeu" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToVanilla)),
                    "Met tous les curseurs à **100 %** et restaure les valeurs du jeu (vanilla)."
                },
                // Status fallback keys
                { "FAST_STATUS_NOT_LOADED",     "État non chargé." },
                { "FAST_STATS_NOT_AVAIL",       "Pas de ville... ¯\\_(ツ)_/¯ ...Pas de stats" },
                { "FAST_STATS_CARS_NOT_AVAIL",  "faites tourner la ville quelques minutes pour avoir des données." },

                // Status rows
                { "FAST_STATS_BIKES_ROW1", "{0} actifs | {1} vélos | {2} scooters | {3} / {4} stationnés/total" },
                { "FAST_STATS_CARS_ROW2",  "{0} actifs | {1} stationnés | {2} total | {3} remorques" },

                // Row3 shows TOTAL OC hidden
                { "FAST_STATS_CARS_ROW3",  "{0} cachés à la frontière OC | mis à jour {1}" },

                // About: Info
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutName)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutName)),     "Nom affiché." },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutVersion)),  "Version actuelle." },

                // Links
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenParadoxMods)),  "Ouvre la page Paradox Mods de l’auteur." },

            };
        }

        public void Unload( )
        {
        }
    }
}

