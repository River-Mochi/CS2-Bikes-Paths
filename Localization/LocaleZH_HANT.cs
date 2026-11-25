// <copyright file="LocaleZH_HANT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleZH_HANT.cs
// Purpose: Traditional Chinese entries for BikesAndPaths.

namespace BikesAndPaths
{
    using System.Collections.Generic;  // IEnumerable, Dictionary, KeyValuePair
    using Colossal;                    // IDictionarySource, IDictionaryEntryError

    public sealed class LocaleZH_HANT : IDictionarySource
    {
        private readonly BPSetting m_Setting;

        public LocaleZH_HANT(BPSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(BPSetting.AboutTab),   "關於" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsSpeedGrp),      "速度" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsStabilityGrp),  "穩定性" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsResetGrp),      "重設" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsPathSpeedGrp),  "路徑" },

                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutInfoGrp),  "模組資訊" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutLinksGrp), "連結" },

                // Retirement notice
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsMigrationGrp), "ASL" },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.MigrationText)),
                    "❤️ Bikes + Paths 已停止維護。\n\n" +
                    "感謝使用本模組！所有功能現已整合到 Adjust All Speed Limits (ASL)，並提供更方便的城市內面板，可調整自行車道和行人道限速。請點擊下方按鈕移轉至 ASL。\n\n" +
                    "B+P 可隨時移除。如想立即恢復遊戲預設值，請點擊恢復遊戲預設值，等待調整完成後儲存城市。此步驟並非必要。\n\n" +
                    "謝謝，River-mochi"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AslMigrationText)),
                    "❤️ Bikes + Paths 已停止維護。\n\n" +
                    "感謝使用本模組！所有功能現已整合到 Adjust All Speed Limits (ASL)，並提供更方便的城市內面板，可調整自行車道和行人道限速。請點擊下方按鈕移轉至 ASL。\n\n" +
                    "ASL 已接管速度設定。現在可直接移除 B+P，無需重設。\n\n" +
                    "謝謝，River-mochi"
                },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "啟用 Bikes + Paths" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "開啟或關閉 B+P。關閉時恢復未由 ASL 管理的設定。" },

                // Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.SpeedScalar)), "自行車與滑板車速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.SpeedScalar)),
                    "**縮放最高速度**。\n" +
                    "高速時會對加速與煞車做平滑處理，減少突然起步與恐慌煞車的感覺。\n" +
                    "**0.30 = 遊戲預設值的 30%**\n" +
                    "**1.00 = 遊戲預設值**\n" +
                    "注意：道路限速與遊戲條件仍會套用。"
                },

                // Stability
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StiffnessScalar)), "剛性" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StiffnessScalar)),
    //                "**搖擺幅度** 的倍率。\n" +
    //                "**較高 = 傾斜較少**。\n" +
    //                "**較低 = 搖晃較多**。\n" +
    //                "建議：高速穩定性用 1.25–1.75。"
    //            },
    //
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.DampingScalar)), "阻尼" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.DampingScalar)),
    //                "較高 = 更快穩定（振盪較少）。\n" +
    //                "**1.00 = 遊戲預設值**\n" +
    //                "建議：高速穩定性用 1.25–2.00。"
    //            },

                // Path Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "ALL Speed Limits on Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "在 Paradox Mods 開啟 Adjust All Speed Limits。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.PathSpeedScalar)), "路徑速度限制" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.PathSpeedScalar)),
                    "縮放 **路徑** 速度限制（路徑不是道路）。\n" +
                    "**1.00 = 遊戲預設值**\n" +
                    "影響：自行車道、行人+自行車分隔路徑、行人路徑。\n" +
                    "\n" +
                    "解除安裝提示：設為 1.00 或使用重設按鈕，儲存城市，然後解除安裝。\n" +
                    "如果忘記，舊路徑會保留修改後的速度，新路徑會使用 vanilla 遊戲預設值。"
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToModDefaults)), "模組預設值" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToModDefaults)),
                    "套用此模組的預設調校值。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToVanilla)), "恢復遊戲預設值" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToVanilla)),
                    "將所有滑桿設為 **100%**，並恢復遊戲預設值（vanilla）。"
                },
                // Status fallback keys
                { "FAST_STATUS_NOT_LOADED",     "狀態未載入。" },
                { "FAST_STATS_NOT_AVAIL",       "沒有城市... ¯\\_(ツ)_/¯ ...沒有統計" },
                { "FAST_STATS_CARS_NOT_AVAIL",  "執行城市幾分鐘以取得資料。" },

                // Status rows
                { "FAST_STATS_BIKES_ROW1", "{0} 活動 | {1} 自行車 | {2} 滑板車 | {3} / {4} 停放/總數" },
                { "FAST_STATS_CARS_ROW2",  "{0} 活動 | {1} 停放 | {2} 總數 | {3} 拖車" },

                // Row3 shows TOTAL OC hidden
                { "FAST_STATS_CARS_ROW3",  "{0} 在 OC 邊界隱藏 | 更新 {1}" },

                // About: Info
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutName)),    "模組" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutName)),     "顯示名稱。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutVersion)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutVersion)),  "目前版本。" },

                // Links
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenParadoxMods)),  "開啟作者的 Paradox Mods 頁面。" },

            };
        }

        public void Unload( )
        {
        }
    }
}

