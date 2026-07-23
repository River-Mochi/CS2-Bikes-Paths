// <copyright file="LocalePT_BR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocalePT_BR.cs
// Purpose: Portuguese (Brazil) entries for FastBikes.

namespace FastBikes
{
    using System.Collections.Generic;  // IEnumerable, Dictionary, KeyValuePair
    using Colossal;                    // IDictionarySource, IDictionaryEntryError

    public sealed class LocalePT_BR : IDictionarySource
    {
        private readonly FBSetting m_Setting;

        public LocalePT_BR(FBSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(FBSetting.ActionsTab), "Ações" },
                { m_Setting.GetOptionTabLocaleID(FBSetting.AboutTab),   "Sobre" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsSpeedGrp),      "Velocidade" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsStabilityGrp),  "Estabilidade" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsResetGrp),      "Redefinir" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsStatusGrp),     "Status dos veículos pessoais" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsPathSpeedGrp),  "Caminhos" },

                { m_Setting.GetOptionGroupLocaleID(FBSetting.AboutInfoGrp),  "Info do mod" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.AboutLinksGrp), "Links" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.AboutDebugGrp), "Debug" },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.EnableFastBikes)), "Ativar Fast Bikes" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.EnableFastBikes)),
                    "Liga ou desliga o mod **ON / OFF**.\n" +
                    "Quando desligado, bicicletas e scooters voltam aos padrões do jogo.\n" +
                    "\n" +
                    "As informações de status abaixo continuam disponíveis mesmo com Fast Bikes desligado."
                },

                // Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.SpeedScalar)), "Velocidade de bikes e scooters" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.SpeedScalar)),
                    "**Escala a velocidade máxima**.\n" +
                    "A aceleração + frenagem usam suavização em alta velocidade para menos arrancadas bruscas e menos aparência de freada de pânico.\n" +
                    "**0.30 = 30%** do padrão do jogo\n" +
                    "**1.00 = padrão do jogo**\n" +
                    "Obs.: limites das vias e condições do jogo ainda se aplicam."
                },

                // Stability
    //            { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.StiffnessScalar)), "Rigidez" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.StiffnessScalar)),
    //                "Multiplicador da **amplitude de balanço**.\n" +
    //                "**Maior = menos inclinação**.\n" +
    //                "**Menor = mais oscilação**.\n" +
    //                "Sugestão: 1.25–1.75 para estabilidade em alta velocidade."
    //            },
    //
    //            { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.DampingScalar)), "Amortecimento" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.DampingScalar)),
    //                "Maior = estabiliza mais rápido (menos oscilação).\n" +
    //                "**1.00 = padrão do jogo**\n" +
    //                "Sugestão: 1.25–2.00 para estabilidade em alta velocidade."
    //            },

                // Path Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.PathSpeedScalar)), "Limite de velocidade dos caminhos" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.PathSpeedScalar)),
                    "Escala os limites de velocidade dos **caminhos** (caminhos não são vias).\n" +
                    "**1.00 = padrão do jogo**\n" +
                    "Afeta: ciclovias, caminhos divididos pedestre+bike e caminhos de pedestres.\n" +
                    "\n" +
                    "Nota para desinstalar: coloque em 1.00 ou use o botão de reset, salve a cidade e então desinstale.\n" +
                    "Se esquecer, os caminhos antigos mantêm a velocidade modificada e os novos usam os padrões vanilla."
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.ResetToModDefaults)), "Padrões do mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.ResetToModDefaults)),
                    "Aplica os valores padrão de ajuste do mod."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.ResetToVanilla)), "Padrões do jogo" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.ResetToVanilla)),
                    "Coloca todos os sliders em **100%** e restaura os padrões do jogo (vanilla)."
                },

                // Status lines
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.StatusSummary1)), "Grupo das bikes" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.StatusSummary1)),
                    "Bicicletas e scooters elétricos.\n" +
                    "**Ativo** = tem uma faixa atual (em movimento).\n" +
                    "**Total estacionado** = inclui todos os flags Parked de qualquer lugar, não só estacionamentos."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.StatusSummary2)), "Grupo dos carros" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.StatusSummary2)),
                    "Somente carros pessoais (exclui o grupo das bikes).\n" +
                    "**Ativo** = tem uma faixa atual (em movimento).\n" +
                    "**Estacionado** = todos os **ParkedCar**, não só estacionamentos.\n" +
                    "A varredura só roda enquanto o menu Opções está aberto, não durante o gameplay da cidade, então sem preocupação com FPS."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.StatusSummary3)), "Carros estacionados ocultos" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.StatusSummary3)),
                    "**Total na borda OC** = veículos do grupo de carros com ParkedCar na conexão Outside City (OC).\n" +
                    "Algumas cidades mostram muitos carros presos estacionados na conexão Outside City.\n" +
                    "Use <Log hidden cars> para um exemplo de detalhamento dos carros ocultos."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.LogBorderHiddenCars)), "Registrar carros ocultos" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.LogBorderHiddenCars)),
                    "Escreve um relatório único em **Logs/FastBikes.log**.\n" +
                    "Inclui total + detalhamento Bucket A/B/C e números de ID de exemplo.\n" +
                    "Use o mod Scene Explorer para ir aos IDs de entidade Vehicle listados e investigar."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.OpenLogFromStatus)), "Abrir log" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.OpenLogFromStatus)),
                    "Abre **Logs/FastBikes.log** se existir.\n" +
                    "Se o arquivo ainda não existir, abre a pasta Logs."
                },

                // Status fallback keys
                { "FAST_STATUS_NOT_LOADED",     "Status não carregado." },
                { "FAST_STATS_NOT_AVAIL",       "Sem cidade... ¯\\_(ツ)_/¯ ...Sem estatísticas" },
                { "FAST_STATS_CARS_NOT_AVAIL",  "rode a cidade por alguns minutos para obter dados." },

                // Status rows
                { "FAST_STATS_BIKES_ROW1", "{0} ativos | {1} bikes | {2} scooters | {3} / {4} estacionados/total" },
                { "FAST_STATS_CARS_ROW2",  "{0} ativos | {1} estacionados | {2} total | {3} trailers" },

                // Row3 shows TOTAL OC hidden
                { "FAST_STATS_CARS_ROW3",  "{0} ocultos na borda OC | atualizado {1}" },

                // About: Info
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.AboutName)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.AboutName)),     "Nome exibido." },
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.AboutVersion)), "Versão" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.AboutVersion)),  "Versão atual." },

                // Links
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.OpenParadoxMods)),  "Abre a página do autor no Paradox Mods." },

                // Debug
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.DumpBicyclePrefabs)), "Relatório debug de bikes" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.DumpBicyclePrefabs)),
                    "<Não é necessário para gameplay normal>.\n" +
                    "Relatório detalhado único para debug ou verificação em dia de patch do jogo.\n" +
                    "Carregue uma cidade primeiro.\n" +
                    "Local de saída: **Logs/FastBikes.log**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.OpenLogFromDebug)), "Abrir log" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.OpenLogFromDebug)),
                    "Abre **Logs/FastBikes.log** se existir.\n" +
                    "Se o arquivo ainda não existir, abre a pasta Logs."
                }
            };
        }

        public void Unload( )
        {
        }
    }
}
