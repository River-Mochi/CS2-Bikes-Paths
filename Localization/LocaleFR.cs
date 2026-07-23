// <copyright file="LocaleFR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleFR.cs
// Purpose: French entries for FastBikes.

namespace FastBikes
{
    using System.Collections.Generic;  // IEnumerable, Dictionary, KeyValuePair
    using Colossal;                    // IDictionarySource, IDictionaryEntryError

    public sealed class LocaleFR : IDictionarySource
    {
        private readonly FBSetting m_Setting;

        public LocaleFR(FBSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(FBSetting.ActionsTab), "Actions" },
                { m_Setting.GetOptionTabLocaleID(FBSetting.AboutTab),   "À propos" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsSpeedGrp),      "Vitesse" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsStabilityGrp),  "Stabilité" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsResetGrp),      "Réinitialiser" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsStatusGrp),     "État des véhicules personnels" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsPathSpeedGrp),  "Chemins" },

                { m_Setting.GetOptionGroupLocaleID(FBSetting.AboutInfoGrp),  "Infos du mod" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.AboutLinksGrp), "Liens" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.AboutDebugGrp), "Débogage" },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.EnableFastBikes)), "Activer Fast Bikes" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.EnableFastBikes)),
                    "Active ou désactive le mod **ON / OFF**.\n" +
                    "Quand il est désactivé, les vélos et scooters reviennent aux valeurs du jeu.\n" +
                    "\n" +
                    "Les infos d’état ci-dessous restent disponibles même si Fast Bikes est désactivé."
                },

                // Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.SpeedScalar)), "Vitesse vélo & scooter" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.SpeedScalar)),
                    "**Multiplie la vitesse maximale**.\n" +
                    "L’accélération + le freinage utilisent un lissage à haute vitesse pour moins de départs brusques et moins de freinages panique.\n" +
                    "**0.30 = 30 %** de la valeur du jeu\n" +
                    "**1.00 = valeur du jeu**\n" +
                    "Note : les limites de route et les conditions du jeu s’appliquent toujours."
                },

                // Stability
    //            { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.StiffnessScalar)), "Rigidité" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.StiffnessScalar)),
    //                "Multiplicateur de l’**amplitude de balancement**.\n" +
    //                "**Plus haut = moins d’inclinaison**.\n" +
    //                "**Plus bas = plus de wobble**.\n" +
    //                "Conseil : 1.25–1.75 pour plus de stabilité à haute vitesse."
    //            },
    //
    //            { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.DampingScalar)), "Amortissement" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.DampingScalar)),
    //                "Plus haut = se stabilise plus vite (moins d’oscillation).\n" +
    //                "**1.00 = valeur du jeu**\n" +
    //                "Conseil : 1.25–2.00 pour plus de stabilité à haute vitesse."
    //            },

                // Path Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.PathSpeedScalar)), "Limite de vitesse des chemins" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.PathSpeedScalar)),
                    "Multiplie les limites de vitesse des **chemins** (les chemins ne sont pas des routes).\n" +
                    "**1.00 = valeur du jeu**\n" +
                    "Affecte : pistes cyclables, chemins piétons+vélos séparés et chemins piétons.\n" +
                    "\n" +
                    "Note de désinstallation : remettez à 1.00 ou utilisez le bouton de réinitialisation, sauvegardez la ville, puis désinstallez.\n" +
                    "Si vous oubliez, les anciens chemins gardent simplement la vitesse modifiée et les nouveaux chemins utilisent les valeurs vanilla."
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.ResetToModDefaults)), "Valeurs du mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.ResetToModDefaults)),
                    "Applique les valeurs par défaut du mod."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.ResetToVanilla)), "Valeurs du jeu" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.ResetToVanilla)),
                    "Met tous les curseurs à **100 %** et restaure les valeurs du jeu (vanilla)."
                },

                // Status lines
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.StatusSummary1)), "Groupe vélo" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.StatusSummary1)),
                    "Vélos et scooters électriques.\n" +
                    "**Actif** = a une voie actuelle (en mouvement).\n" +
                    "**Total stationné** = inclut tous les états Parked, partout, pas seulement dans les parkings."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.StatusSummary2)), "Groupe voiture" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.StatusSummary2)),
                    "Voitures personnelles seulement (hors groupe vélo).\n" +
                    "**Actif** = a une voie actuelle (en mouvement).\n" +
                    "**Stationné** = tous les **ParkedCar**, pas seulement les parkings.\n" +
                    "Le scan ne tourne que lorsque le menu Options est ouvert, pas pendant le gameplay en ville, donc pas de souci de FPS."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.StatusSummary3)), "Voitures stationnées cachées" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.StatusSummary3)),
                    "**Total à la frontière OC** = véhicules du groupe voiture avec ParkedCar à la connexion Outside City (OC).\n" +
                    "Certaines villes ont beaucoup de voitures bloquées en stationnement à la connexion Outside City.\n" +
                    "Utilisez <Log hidden cars> pour un exemple de détail des voitures cachées."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.LogBorderHiddenCars)), "Journaliser les voitures cachées" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.LogBorderHiddenCars)),
                    "Écrit un rapport unique dans **Logs/FastBikes.log**.\n" +
                    "Inclut le total + le détail Bucket A/B/C et des exemples d’ID.\n" +
                    "Utilisez le mod Scene Explorer pour aller aux ID d’entité Vehicle listés et enquêter."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.OpenLogFromStatus)), "Ouvrir le journal" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.OpenLogFromStatus)),
                    "Ouvre **Logs/FastBikes.log** s’il existe.\n" +
                    "Si le fichier n’existe pas encore, ouvre le dossier Logs à la place."
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
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.AboutName)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.AboutName)),     "Nom affiché." },
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.AboutVersion)),  "Version actuelle." },

                // Links
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.OpenParadoxMods)),  "Ouvre la page Paradox Mods de l’auteur." },

                // Debug
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.DumpBicyclePrefabs)), "Rapport debug vélo" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.DumpBicyclePrefabs)),
                    "<Pas nécessaire pour le jeu normal>.\n" +
                    "Rapport détaillé unique pour le debug ou la vérification après une mise à jour du jeu.\n" +
                    "Chargez d’abord une ville.\n" +
                    "Emplacement de sortie : **Logs/FastBikes.log**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.OpenLogFromDebug)), "Ouvrir le journal" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.OpenLogFromDebug)),
                    "Ouvre **Logs/FastBikes.log** s’il existe.\n" +
                    "Si le fichier n’existe pas encore, ouvre le dossier Logs à la place."
                }
            };
        }

        public void Unload( )
        {
        }
    }
}
