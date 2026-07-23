// <copyright file="LocaleZH_HANT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleZH_HANT.cs
// Purpose: Traditional Chinese entries for FastBikes.

namespace FastBikes
{
    using System.Collections.Generic;  // IEnumerable, Dictionary, KeyValuePair
    using Colossal;                    // IDictionarySource, IDictionaryEntryError

    public sealed class LocaleZH_HANT : IDictionarySource
    {
        private readonly FBSetting m_Setting;

        public LocaleZH_HANT(FBSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(FBSetting.AboutTab),   "關於" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsSpeedGrp),      "速度" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsStabilityGrp),  "穩定性" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsResetGrp),      "重設" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsStatusGrp),     "個人車輛狀態" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsPathSpeedGrp),  "路徑" },

                { m_Setting.GetOptionGroupLocaleID(FBSetting.AboutInfoGrp),  "模組資訊" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.AboutLinksGrp), "連結" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.AboutDebugGrp), "偵錯" },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.EnableFastBikes)), "啟用 Fast Bikes" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.EnableFastBikes)),
                    "開啟或關閉此模組 **ON / OFF**。\n" +
                    "關閉時，自行車與滑板車行為會恢復為遊戲預設值。\n" +
                    "\n" +
                    "即使 Fast Bikes 關閉，下方狀態資訊仍可使用。"
                },

                // Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.SpeedScalar)), "自行車與滑板車速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.SpeedScalar)),
                    "**縮放最高速度**。\n" +
                    "高速時會對加速與煞車做平滑處理，減少突然起步與恐慌煞車的感覺。\n" +
                    "**0.30 = 遊戲預設值的 30%**\n" +
                    "**1.00 = 遊戲預設值**\n" +
                    "注意：道路限速與遊戲條件仍會套用。"
                },

                // Stability
    //            { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.StiffnessScalar)), "剛性" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.StiffnessScalar)),
    //                "**搖擺幅度** 的倍率。\n" +
    //                "**較高 = 傾斜較少**。\n" +
    //                "**較低 = 搖晃較多**。\n" +
    //                "建議：高速穩定性用 1.25–1.75。"
    //            },
    //
    //            { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.DampingScalar)), "阻尼" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.DampingScalar)),
    //                "較高 = 更快穩定（振盪較少）。\n" +
    //                "**1.00 = 遊戲預設值**\n" +
    //                "建議：高速穩定性用 1.25–2.00。"
    //            },

                // Path Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.PathSpeedScalar)), "路徑速度限制" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.PathSpeedScalar)),
                    "縮放 **路徑** 速度限制（路徑不是道路）。\n" +
                    "**1.00 = 遊戲預設值**\n" +
                    "影響：自行車道、行人+自行車分隔路徑、行人路徑。\n" +
                    "\n" +
                    "解除安裝提示：設為 1.00 或使用重設按鈕，儲存城市，然後解除安裝。\n" +
                    "如果忘記，舊路徑會保留修改後的速度，新路徑會使用 vanilla 遊戲預設值。"
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.ResetToModDefaults)), "模組預設值" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.ResetToModDefaults)),
                    "套用此模組的預設調校值。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.ResetToVanilla)), "遊戲預設值" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.ResetToVanilla)),
                    "將所有滑桿設為 **100%**，並恢復遊戲預設值（vanilla）。"
                },

                // Status lines
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.StatusSummary1)), "自行車群組" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.StatusSummary1)),
                    "自行車與電動滑板車。\n" +
                    "**活動** = 目前有車道（正在移動）。\n" +
                    "**總停放** = 包含所有位置的 Parked 標記，不只是停車場。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.StatusSummary2)), "汽車群組" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.StatusSummary2)),
                    "僅個人汽車（不包含自行車群組）。\n" +
                    "**活動** = 目前有車道（正在移動）。\n" +
                    "**停放** = 所有 **ParkedCar**，不只是停車場。\n" +
                    "掃描只在選項選單開啟時執行，不在城市正常遊玩時執行，因此不用擔心 FPS。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.StatusSummary3)), "隱藏停放汽車" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.StatusSummary3)),
                    "**OC 邊界總數** = 在 Outside City (OC) 連接處帶 ParkedCar 的汽車群組車輛。\n" +
                    "有些城市會在 Outside City 連接處出現大量卡住的停放汽車。\n" +
                    "使用 <Log hidden cars> 查看隱藏汽車的範例分類。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.LogBorderHiddenCars)), "記錄隱藏汽車" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.LogBorderHiddenCars)),
                    "向 **Logs/FastBikes.log** 寫入一次性報告。\n" +
                    "包含總數 + Bucket A/B/C 分類與範例 ID。\n" +
                    "使用 Scene Explorer 模組跳到列出的 Vehicle 實體 ID 並檢查。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.OpenLogFromStatus)), "開啟日誌" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.OpenLogFromStatus)),
                    "如果存在，開啟 **Logs/FastBikes.log**。\n" +
                    "如果尚未找到檔案，則改為開啟 Logs 資料夾。"
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
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.AboutName)),    "模組" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.AboutName)),     "顯示名稱。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.AboutVersion)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.AboutVersion)),  "目前版本。" },

                // Links
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.OpenParadoxMods)),  "開啟作者的 Paradox Mods 頁面。" },

                // Debug
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.DumpBicyclePrefabs)), "自行車偵錯報告" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.DumpBicyclePrefabs)),
                    "<正常遊玩不需要>。\n" +
                    "用於偵錯或遊戲更新後檢查的一次性詳細日誌報告。\n" +
                    "請先載入城市。\n" +
                    "輸出位置：**Logs/FastBikes.log**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.OpenLogFromDebug)), "開啟日誌" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.OpenLogFromDebug)),
                    "如果存在，開啟 **Logs/FastBikes.log**。\n" +
                    "如果尚未找到檔案，則改為開啟 Logs 資料夾。"
                }
            };
        }

        public void Unload( )
        {
        }
    }
}
