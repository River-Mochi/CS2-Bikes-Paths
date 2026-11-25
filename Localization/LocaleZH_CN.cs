// <copyright file="LocaleZH_CN.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleZH_CN.cs
// Purpose: Simplified Chinese entries for BikesAndPaths.

namespace BikesAndPaths
{
    using System.Collections.Generic;  // IEnumerable, Dictionary, KeyValuePair
    using Colossal;                    // IDictionarySource, IDictionaryEntryError

    public sealed class LocaleZH_CN : IDictionarySource
    {
        private readonly BPSetting m_Setting;

        public LocaleZH_CN(BPSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(BPSetting.ActionsTab), "操作" },
                { m_Setting.GetOptionTabLocaleID(BPSetting.AboutTab),   "关于" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsSpeedGrp),      "速度" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsStabilityGrp),  "稳定性" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsResetGrp),      "重置" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsPathSpeedGrp),  "路径" },

                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutInfoGrp),  "模组信息" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutLinksGrp), "链接" },

                // Retirement notice
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsMigrationGrp), "ASL" },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.MigrationText)),
                    "❤️ Bikes + Paths 已停止维护。\n\n" +
                    "感谢使用本模组！所有功能现已整合到 Adjust All Speed Limits (ASL)，并提供更方便的城市内面板，可调整自行车道和人行道限速。请点击下方按钮迁移至 ASL。\n\n" +
                    "B+P 可随时卸载。如想立即恢复游戏默认值，请点击恢复游戏默认值，等待调整完成后保存城市。此步骤并非必需。\n\n" +
                    "谢谢，River-mochi"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AslMigrationText)),
                    "❤️ Bikes + Paths 已停止维护。\n\n" +
                    "感谢使用本模组！所有功能现已整合到 Adjust All Speed Limits (ASL)，并提供更方便的城市内面板，可调整自行车道和人行道限速。请点击下方按钮迁移至 ASL。\n\n" +
                    "ASL 已接管速度设置。现在可直接卸载 B+P，无需重置。\n\n" +
                    "谢谢，River-mochi"
                },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "启用 Bikes + Paths" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "开启或关闭 B+P。关闭时恢复未由 ASL 管理的设置。" },

                // Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.SpeedScalar)), "自行车和滑板车速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.SpeedScalar)),
                    "**缩放最高速度**。\n" +
                    "高速时会对加速和刹车做平滑处理，减少突然起步和恐慌刹车的感觉。\n" +
                    "**0.30 = 游戏默认值的 30%**\n" +
                    "**1.00 = 游戏默认值**\n" +
                    "注意：道路限速和游戏条件仍然生效。"
                },

                // Stability
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StiffnessScalar)), "刚性" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StiffnessScalar)),
    //                "**摇摆幅度** 的倍率。\n" +
    //                "**更高 = 倾斜更少**。\n" +
    //                "**更低 = 摇晃更多**。\n" +
    //                "建议：高速稳定性用 1.25–1.75。"
    //            },
    //
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.DampingScalar)), "阻尼" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.DampingScalar)),
    //                "更高 = 更快稳定（振荡更少）。\n" +
    //                "**1.00 = 游戏默认值**\n" +
    //                "建议：高速稳定性用 1.25–2.00。"
    //            },

                // Path Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "ALL Speed Limits on Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "在 Paradox Mods 打开 Adjust All Speed Limits。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.PathSpeedScalar)), "路径速度限制" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.PathSpeedScalar)),
                    "缩放 **路径** 速度限制（路径不是道路）。\n" +
                    "**1.00 = 游戏默认值**\n" +
                    "影响：自行车道、行人+自行车分隔路径、行人路径。\n" +
                    "\n" +
                    "卸载提示：设为 1.00 或使用重置按钮，保存城市，然后卸载。\n" +
                    "如果忘记了，旧路径会保留修改后的速度，新路径会使用 vanilla 游戏默认值。"
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToModDefaults)), "模组默认值" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToModDefaults)),
                    "应用此模组的默认调校值。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToVanilla)), "恢复游戏默认值" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToVanilla)),
                    "将所有滑块设为 **100%** 并恢复游戏默认值（vanilla）。"
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
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutName)),    "模组" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutName)),     "显示名称。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutVersion)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutVersion)),  "当前版本。" },

                // Links
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenParadoxMods)),  "打开作者的 Paradox Mods 页面。" },

            };
        }

        public void Unload( )
        {
        }
    }
}

