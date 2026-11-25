// <copyright file="LocaleKO.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleKO.cs
// Purpose: Korean entries for BikesAndPaths.

namespace BikesAndPaths
{
    using System.Collections.Generic;  // IEnumerable, Dictionary, KeyValuePair
    using Colossal;                    // IDictionarySource, IDictionaryEntryError

    public sealed class LocaleKO : IDictionarySource
    {
        private readonly BPSetting m_Setting;

        public LocaleKO(BPSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(BPSetting.ActionsTab), "동작" },
                { m_Setting.GetOptionTabLocaleID(BPSetting.AboutTab),   "정보" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsSpeedGrp),      "속도" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsStabilityGrp),  "안정성" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsResetGrp),      "초기화" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsPathSpeedGrp),  "경로" },

                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutInfoGrp),  "모드 정보" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutLinksGrp), "링크" },

                // Retirement notice
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsMigrationGrp), "ASL" },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.MigrationText)),
                    "❤️ Bikes + Paths 지원이 종료되었습니다.\n\n" +
                    "이 모드를 이용해 주셔서 감사합니다! 모든 기능이 Adjust All Speed Limits (ASL)에 통합되었으며, 도시 내 패널에서 자전거길과 보행로를 더 편리하게 조절할 수 있습니다. 아래 버튼으로 ASL로 이동하세요.\n\n" +
                    "B+P는 언제든 제거할 수 있습니다. 바로 게임 기본값으로 복원하려면 기본값 복원 버튼을 누르고 작업이 끝난 뒤 도시를 저장하세요. 선택 사항입니다.\n\n" +
                    "감사합니다, River-mochi"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AslMigrationText)),
                    "❤️ Bikes + Paths 지원이 종료되었습니다.\n\n" +
                    "이 모드를 이용해 주셔서 감사합니다! 모든 기능이 Adjust All Speed Limits (ASL)에 통합되었으며, 도시 내 패널에서 자전거길과 보행로를 더 편리하게 조절할 수 있습니다. 아래 버튼으로 ASL로 이동하세요.\n\n" +
                    "ASL이 이미 속도 설정을 관리합니다. 초기화 없이 B+P를 제거해도 됩니다.\n\n" +
                    "감사합니다, River-mochi"
                },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "Bikes + Paths 켜기" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "B+P를 켜거나 끕니다. 끄면 ASL이 관리하지 않는 값을 기본값으로 복원합니다." },

                // Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.SpeedScalar)), "자전거 & 스쿠터 속도" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.SpeedScalar)),
                    "**최대 속도를 배율로 조정**합니다.\n" +
                    "고속에서 가속 + 제동에 스무딩을 적용해 급출발과 패닉 브레이크처럼 보이는 움직임을 줄입니다.\n" +
                    "**0.30 = 게임 기본값의 30%**\n" +
                    "**1.00 = 게임 기본값**\n" +
                    "참고: 도로 제한과 게임 조건은 여전히 적용됩니다."
                },

                // Stability
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StiffnessScalar)), "강성" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StiffnessScalar)),
    //                "**흔들림 진폭** 배율입니다.\n" +
    //                "**높을수록 = 덜 기울어짐**.\n" +
    //                "**낮을수록 = 더 흔들림**.\n" +
    //                "권장: 고속 안정성은 1.25–1.75."
    //            },
    //
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.DampingScalar)), "감쇠" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.DampingScalar)),
    //                "높을수록 = 더 빨리 안정됨(진동 감소).\n" +
    //                "**1.00 = 게임 기본값**\n" +
    //                "권장: 고속 안정성은 1.25–2.00."
    //            },

                // Path Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "ALL Speed Limits on Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "Paradox Mods에서 Adjust All Speed Limits를 엽니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.PathSpeedScalar)), "경로 속도 제한" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.PathSpeedScalar)),
                    "**경로** 속도 제한을 배율로 조정합니다(경로는 도로가 아닙니다).\n" +
                    "**1.00 = 게임 기본값**\n" +
                    "적용 대상: 자전거길, 보행자+자전거 분리 경로, 보행자 경로.\n" +
                    "\n" +
                    "제거 안내: 1.00으로 설정하거나 초기화 버튼을 누르고, 도시를 저장한 뒤 제거하세요.\n" +
                    "잊어도 기존 경로는 변경된 속도를 유지하고, 새 경로는 vanilla 기본값을 사용합니다."
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToModDefaults)), "모드 기본값" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToModDefaults)),
                    "모드의 기본 튜닝 값을 적용합니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToVanilla)), "게임 기본값 복원" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToVanilla)),
                    "모든 슬라이더를 **100%**로 설정하고 게임 기본값(vanilla)을 복원합니다."
                },
                // Status fallback keys
                { "FAST_STATUS_NOT_LOADED",     "상태를 불러오지 않았습니다." },
                { "FAST_STATS_NOT_AVAIL",       "도시 없음... ¯\\_(ツ)_/¯ ...통계 없음" },
                { "FAST_STATS_CARS_NOT_AVAIL",  "데이터를 얻으려면 도시를 몇 분 실행하세요." },

                // Status rows
                { "FAST_STATS_BIKES_ROW1", "{0} 활성 | {1} 자전거 | {2} 스쿠터 | {3} / {4} 주차/총합" },
                { "FAST_STATS_CARS_ROW2",  "{0} 활성 | {1} 주차 | {2} 총합 | {3} 트레일러" },

                // Row3 shows TOTAL OC hidden
                { "FAST_STATS_CARS_ROW3",  "{0} OC 경계에서 숨김 | 업데이트 {1}" },

                // About: Info
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutName)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutName)),     "표시 이름." },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutVersion)), "버전" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutVersion)),  "현재 버전." },

                // Links
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenParadoxMods)),  "제작자의 Paradox Mods 페이지를 엽니다." },

            };
        }

        public void Unload( )
        {
        }
    }
}

