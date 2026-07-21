// <copyright file="LocaleZH_CN.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleZH_CN.cs
// Purpose: Simplified Chinese entries for FastBikes.

namespace FastBikes
{
    using System.Collections.Generic;  // IEnumerable, Dictionary, KeyValuePair
    using Colossal;                    // IDictionarySource, IDictionaryEntryError

    public sealed class LocaleZH_CN : IDictionarySource
    {
        private readonly FBSetting m_Setting;

        public LocaleZH_CN(FBSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(FBSetting.ActionsTab), "操作" },
                { m_Setting.GetOptionTabLocaleID(FBSetting.AboutTab),   "关于" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsSpeedGrp),      "速度" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsStabilityGrp),  "稳定性" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsResetGrp),      "重置" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsStatusGrp),     "个人车辆状态" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsPathSpeedGrp),  "路径" },

                { m_Setting.GetOptionGroupLocaleID(FBSetting.AboutInfoGrp),  "模组信息" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.AboutLinksGrp), "链接" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.AboutDebugGrp), "调试" },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.EnableFastBikes)), "启用 Fast Bikes" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.EnableFastBikes)),
                    "开启或关闭此模组 **ON / OFF**。\n" +
                    "关闭后，自行车和滑板车行为会恢复为游戏默认值。\n" +
                    "\n" +
                    "即使 Fast Bikes 关闭，下方状态信息仍可使用。"
                },

                // Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.SpeedScalar)), "自行车和滑板车速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.SpeedScalar)),
                    "**缩放最高速度**。\n" +
                    "高速时会对加速和刹车做平滑处理，减少突然起步和恐慌刹车的感觉。\n" +
                    "**0.30 = 游戏默认值的 30%**\n" +
                    "**1.00 = 游戏默认值**\n" +
                    "注意：道路限速和游戏条件仍然生效。"
                },

                // Stability
    //            { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StiffnessScalar)), "刚性" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(Setting.StiffnessScalar)),
    //                "**摇摆幅度** 的倍率。\n" +
    //                "**更高 = 倾斜更少**。\n" +
    //                "**更低 = 摇晃更多**。\n" +
    //                "建议：高速稳定性用 1.25–1.75。"
    //            },
    //
    //            { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DampingScalar)), "阻尼" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(Setting.DampingScalar)),
    //                "更高 = 更快稳定（振荡更少）。\n" +
    //                "**1.00 = 游戏默认值**\n" +
    //                "建议：高速稳定性用 1.25–2.00。"
    //            },

                // Path Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.PathSpeedScalar)), "路径速度限制" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.PathSpeedScalar)),
                    "缩放 **路径** 速度限制（路径不是道路）。\n" +
                    "**1.00 = 游戏默认值**\n" +
                    "影响：自行车道、行人+自行车分隔路径、行人路径。\n" +
                    "\n" +
                    "卸载提示：设为 1.00 或使用重置按钮，保存城市，然后卸载。\n" +
                    "如果忘记了，旧路径会保留修改后的速度，新路径会使用 vanilla 游戏默认值。"
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.ResetToModDefaults)), "模组默认值" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.ResetToModDefaults)),
                    "应用此模组的默认调校值。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.ResetToVanilla)), "游戏默认值" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.ResetToVanilla)),
                    "将所有滑块设为 **100%** 并恢复游戏默认值（vanilla）。"
                },

                // Status lines
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.StatusSummary1)), "自行车组" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.StatusSummary1)),
                    "自行车和电动滑板车。\n" +
                    "**活动** = 当前有车道（正在移动）。\n" +
                    "**总停放** = 包含所有位置的 Parked 标记，不只是停车场。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.StatusSummary2)), "汽车组" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.StatusSummary2)),
                    "仅个人汽车（不包括自行车组）。\n" +
                    "**活动** = 当前有车道（正在移动）。\n" +
                    "**停放** = 所有 **ParkedCar**，不只是停车场。\n" +
                    "扫描只在选项菜单打开时运行，不在城市正常游玩时运行，因此不用担心 FPS。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.StatusSummary3)), "隐藏停放汽车" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.StatusSummary3)),
                    "**OC 边界总数** = 在 Outside City (OC) 连接处带 ParkedCar 的汽车组车辆。\n" +
                    "有些城市会在 Outside City 连接处显示大量卡住的停放汽车。\n" +
                    "使用 <Log hidden cars> 查看隐藏汽车的示例分类。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.LogBorderHiddenCars)), "记录隐藏汽车" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.LogBorderHiddenCars)),
                    "向 **Logs/FastBikes.log** 写入一次性报告。\n" +
                    "包含总数 + Bucket A/B/C 分类和示例 ID。\n" +
                    "使用 Scene Explorer 模组跳转到列出的 Vehicle 实体 ID 并检查。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.OpenLogFromStatus)), "打开日志" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.OpenLogFromStatus)),
                    "如果存在，则打开 **Logs/FastBikes.log**。\n" +
                    "如果尚未找到文件，则改为打开 Logs 文件夹。"
                },

                // Status fallback keys
                { "FAST_STATUS_NOT_LOADED",     "状态未加载。" },
                { "FAST_STATS_NOT_AVAIL",       "没有城市... ¯\\_(ツ)_/¯ ...没有统计" },
                { "FAST_STATS_CARS_NOT_AVAIL",  "运行城市几分钟以获取数据。" },

                // Status rows
                { "FAST_STATS_BIKES_ROW1", "{0} 活动 | {1} 自行车 | {2} 滑板车 | {3} / {4} 停放/总数" },
                { "FAST_STATS_CARS_ROW2",  "{0} 活动 | {1} 停放 | {2} 总数 | {3} 拖车" },

                // Row3 shows TOTAL OC hidden
                { "FAST_STATS_CARS_ROW3",  "{0} 在 OC 边界隐藏 | 更新 {1}" },

                // About: Info
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.AboutName)),    "模组" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.AboutName)),     "显示名称。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.AboutVersion)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.AboutVersion)),  "当前版本。" },

                // Links
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.OpenParadoxMods)),  "打开作者的 Paradox Mods 页面。" },

                // Debug
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.DumpBicyclePrefabs)), "自行车调试报告" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.DumpBicyclePrefabs)),
                    "<正常游玩不需要>。\n" +
                    "用于调试或游戏补丁日检查的一次性详细日志报告。\n" +
                    "请先加载城市。\n" +
                    "输出位置：**Logs/FastBikes.log**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.OpenLogFromDebug)), "打开日志" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.OpenLogFromDebug)),
                    "如果存在，则打开 **Logs/FastBikes.log**。\n" +
                    "如果尚未找到文件，则改为打开 Logs 文件夹。"
                }
            };
        }

        public void Unload( )
        {
        }
    }
}
