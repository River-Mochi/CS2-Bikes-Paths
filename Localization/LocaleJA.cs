// <copyright file="LocaleJA.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleJA.cs
// Purpose: Japanese entries for BikesAndPaths.

namespace BikesAndPaths
{
    using System.Collections.Generic;  // IEnumerable, Dictionary, KeyValuePair
    using Colossal;                    // IDictionarySource, IDictionaryEntryError

    public sealed class LocaleJA : IDictionarySource
    {
        private readonly BPSetting m_Setting;

        public LocaleJA(BPSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(BPSetting.ActionsTab), "アクション" },
                { m_Setting.GetOptionTabLocaleID(BPSetting.AboutTab),   "情報" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsSpeedGrp),      "速度" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsStabilityGrp),  "安定性" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsResetGrp),      "リセット" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsPathSpeedGrp),  "パス" },

                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutInfoGrp),  "MOD情報" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutLinksGrp), "リンク" },

                // Retirement notice
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsMigrationGrp), "ASL" },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.MigrationText)),
                    "❤️ Bikes + Paths は開発を終了しました。\n\n" +
                    "ご利用ありがとうございました！すべての機能は Adjust All Speed Limits (ASL) に統合され、自転車道と歩道をより便利な都市内パネルで調整できます。下のボタンから ASL に移行してください。\n\n" +
                    "B+P はいつでも削除できます。すぐにゲーム既定値へ戻したい場合は、ゲーム既定値に戻すボタンを押し、処理完了後に都市を保存してください。これは任意です。\n\n" +
                    "ありがとう、River-mochi"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AslMigrationText)),
                    "❤️ Bikes + Paths は開発を終了しました。\n\n" +
                    "ご利用ありがとうございました！すべての機能は Adjust All Speed Limits (ASL) に統合され、自転車道と歩道をより便利な都市内パネルで調整できます。下のボタンから ASL に移行してください。\n\n" +
                    "速度設定はすでに ASL が管理しています。リセットせずに B+P を削除できます。\n\n" +
                    "ありがとう、River-mochi"
                },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "Bikes + Paths を有効化" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "B+P をオン／オフ。オフにすると ASL が管理していない設定を既定値に戻します。" },

                // Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.SpeedScalar)), "自転車＆スクーター速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.SpeedScalar)),
                    "**最高速度を倍率変更**します。\n" +
                    "高速時は加速＋ブレーキを滑らかにし、急発進やパニックブレーキっぽさを減らします。\n" +
                    "**0.30 = ゲーム既定値の 30%**\n" +
                    "**1.00 = ゲーム既定値**\n" +
                    "注: 道路の制限速度やゲーム内条件は引き続き適用されます。"
                },

                // Stability
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StiffnessScalar)), "剛性" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StiffnessScalar)),
    //                "**揺れ幅** の倍率です。\n" +
    //                "**高いほど = 傾きが少ない**。\n" +
    //                "**低いほど = 揺れが大きい**。\n" +
    //                "推奨: 高速安定性なら 1.25–1.75。"
    //            },
    //
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.DampingScalar)), "減衰" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.DampingScalar)),
    //                "高いほど = 早く落ち着く（振動が少ない）。\n" +
    //                "**1.00 = ゲーム既定値**\n" +
    //                "推奨: 高速安定性なら 1.25–2.00。"
    //            },

                // Path Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "ALL Speed Limits on Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "Paradox Mods で Adjust All Speed Limits を開きます。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.PathSpeedScalar)), "パス速度制限" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.PathSpeedScalar)),
                    "**パス** の速度制限を倍率変更します（パスは道路ではありません）。\n" +
                    "**1.00 = ゲーム既定値**\n" +
                    "対象: 自転車道、歩行者＋自転車の分離パス、歩道パス。\n" +
                    "\n" +
                    "アンインストール時: 1.00 に戻すかリセットボタンを使い、都市を保存してからアンインストールしてください。\n" +
                    "忘れても、古いパスは変更後の速度を保持し、新しいパスは vanilla の既定値になります。"
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToModDefaults)), "MOD既定値" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToModDefaults)),
                    "MOD の既定チューニング値を適用します。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToVanilla)), "ゲーム既定値に戻す" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToVanilla)),
                    "すべてのスライダーを **100%** にし、ゲーム既定値（vanilla）に戻します。"
                },
                // Status fallback keys
                { "FAST_STATUS_NOT_LOADED",     "ステータス未読み込み。" },
                { "FAST_STATS_NOT_AVAIL",       "都市なし... ¯\\_(ツ)_/¯ ...統計なし" },
                { "FAST_STATS_CARS_NOT_AVAIL",  "データ取得のため、都市を数分動かしてください。" },

                // Status rows
                { "FAST_STATS_BIKES_ROW1", "{0} 稼働中 | 自転車 {1} | スクーター {2} | 駐車/合計 {3} / {4}" },
                { "FAST_STATS_CARS_ROW2",  "{0} 稼働中 | 駐車 {1} | 合計 {2} | トレーラー {3}" },

                // Row3 shows TOTAL OC hidden
                { "FAST_STATS_CARS_ROW3",  "{0} OC 境界で非表示 | 更新 {1}" },

                // About: Info
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutName)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutName)),     "表示名。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutVersion)), "バージョン" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutVersion)),  "現在のバージョン。" },

                // Links
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenParadoxMods)),  "作者の Paradox Mods ページを開きます。" },

            };
        }

        public void Unload( )
        {
        }
    }
}

