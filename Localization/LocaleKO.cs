// <copyright file="LocaleKO.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleKO.cs
// Purpose: Korean entries for BikeAndPath.

namespace BikeAndPath
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
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsStatusGrp),     "개인 차량 상태" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsPathSpeedGrp),  "경로" },

                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutInfoGrp),  "모드 정보" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutLinksGrp), "링크" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutDebugGrp), "디버그" },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.EnableFastBikes)), "Bikes + Paths 켜기" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.EnableFastBikes)),
                    "모드를 **ON / OFF** 합니다.\n" +
                    "OFF이면 자전거와 스쿠터 동작이 게임 기본값으로 돌아갑니다.\n" +
                    "\n" +
                    "아래 상태 정보는 Bikes + Paths가 OFF여도 사용할 수 있습니다."
                },

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

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToVanilla)), "게임 기본값" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToVanilla)),
                    "모든 슬라이더를 **100%**로 설정하고 게임 기본값(vanilla)을 복원합니다."
                },

                // Status lines
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StatusSummary1)), "자전거 그룹" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StatusSummary1)),
                    "자전거와 전동 스쿠터.\n" +
                    "**활성** = 현재 차선이 있음(이동 중).\n" +
                    "**총 주차** = 주차장뿐 아니라 모든 곳의 Parked 플래그를 포함합니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StatusSummary2)), "자동차 그룹" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StatusSummary2)),
                    "개인 자동차만 포함(자전거 그룹 제외).\n" +
                    "**활성** = 현재 차선이 있음(이동 중).\n" +
                    "**주차** = 주차장뿐 아니라 모든 **ParkedCar**.\n" +
                    "스캔은 옵션 메뉴가 열려 있을 때만 실행되며 도시 플레이 중에는 실행되지 않으므로 FPS 걱정이 없습니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StatusSummary3)), "숨겨진 주차 차량" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StatusSummary3)),
                    "**OC 경계 총합** = Outside City (OC) 연결 지점에서 ParkedCar 상태인 자동차 그룹 차량.\n" +
                    "일부 도시에서는 Outside City 연결 지점에 주차된 채 멈춘 차량이 많이 보일 수 있습니다.\n" +
                    "숨겨진 차량의 샘플 분류는 <Log hidden cars>를 사용하세요."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.LogBorderHiddenCars)), "숨겨진 차량 로그" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.LogBorderHiddenCars)),
                    "**Logs/BikesAndPaths.log**에 1회 보고서를 작성합니다.\n" +
                    "총합 + Bucket A/B/C 분류와 샘플 ID 번호를 포함합니다.\n" +
                    "Scene Explorer 모드로 나열된 Vehicle 엔티티 ID로 이동해 확인하세요."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenLogFromStatus)), "로그 열기" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenLogFromStatus)),
                    "**Logs/BikesAndPaths.log**가 있으면 엽니다.\n" +
                    "파일이 아직 없으면 대신 Logs 폴더를 엽니다."
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

                // Debug
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.DumpBicyclePrefabs)), "자전거 디버그 보고서" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.DumpBicyclePrefabs)),
                    "<일반 플레이에는 필요 없습니다>.\n" +
                    "디버그 또는 게임 패치 후 확인용 1회 상세 로그 보고서입니다.\n" +
                    "먼저 도시를 불러오세요.\n" +
                    "출력 위치: **Logs/BikesAndPaths.log**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenLogFromDebug)), "로그 열기" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenLogFromDebug)),
                    "**Logs/BikesAndPaths.log**가 있으면 엽니다.\n" +
                    "파일이 아직 없으면 대신 Logs 폴더를 엽니다."
                }
            };
        }

        public void Unload( )
        {
        }
    }
}

