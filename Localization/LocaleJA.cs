// <copyright file="LocaleJA.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleJA.cs
// Purpose: Japanese entries for FastBikes.

namespace FastBikes
{
    using System.Collections.Generic;  // IEnumerable, Dictionary, KeyValuePair
    using Colossal;                    // IDictionarySource, IDictionaryEntryError

    public sealed class LocaleJA : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleJA(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "アクション" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "情報" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.ActionsSpeedGrp),      "速度" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ActionsStabilityGrp),  "安定性" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ActionsResetGrp),      "リセット" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ActionsStatusGrp),     "個人車両ステータス" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ActionsPathSpeedGrp),  "パス" },

                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "MOD情報" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "リンク" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutDebugGrp), "デバッグ" },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableFastBikes)), "Fast Bikes を有効化" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableFastBikes)),
                    "MOD を **ON / OFF** します。\n" +
                    "OFF の時は、自転車とスクーターの挙動をゲーム既定値に戻します。\n" +
                    "\n" +
                    "下のステータス情報は、Fast Bikes が OFF でも使用できます。"
                },

                // Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SpeedScalar)), "自転車＆スクーター速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SpeedScalar)),
                    "**最高速度を倍率変更**します。\n" +
                    "高速時は加速＋ブレーキを滑らかにし、急発進やパニックブレーキっぽさを減らします。\n" +
                    "**0.30 = ゲーム既定値の 30%**\n" +
                    "**1.00 = ゲーム既定値**\n" +
                    "注: 道路の制限速度やゲーム内条件は引き続き適用されます。"
                },

                // Stability
    //            { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StiffnessScalar)), "剛性" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(Setting.StiffnessScalar)),
    //                "**揺れ幅** の倍率です。\n" +
    //                "**高いほど = 傾きが少ない**。\n" +
    //                "**低いほど = 揺れが大きい**。\n" +
    //                "推奨: 高速安定性なら 1.25–1.75。"
    //            },
    //
    //            { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DampingScalar)), "減衰" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(Setting.DampingScalar)),
    //                "高いほど = 早く落ち着く（振動が少ない）。\n" +
    //                "**1.00 = ゲーム既定値**\n" +
    //                "推奨: 高速安定性なら 1.25–2.00。"
    //            },

                // Path Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PathSpeedScalar)), "パス速度制限" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PathSpeedScalar)),
                    "**パス** の速度制限を倍率変更します（パスは道路ではありません）。\n" +
                    "**1.00 = ゲーム既定値**\n" +
                    "対象: 自転車道、歩行者＋自転車の分離パス、歩道パス。\n" +
                    "\n" +
                    "アンインストール時: 1.00 に戻すかリセットボタンを使い、都市を保存してからアンインストールしてください。\n" +
                    "忘れても、古いパスは変更後の速度を保持し、新しいパスは vanilla の既定値になります。"
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToModDefaults)), "MOD既定値" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToModDefaults)),
                    "MOD の既定チューニング値を適用します。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "ゲーム既定値" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "すべてのスライダーを **100%** にし、ゲーム既定値（vanilla）に戻します。"
                },

                // Status lines
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusSummary1)), "自転車グループ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusSummary1)),
                    "自転車と電動スクーター。\n" +
                    "**Active** = 現在のレーンがある（移動中）。\n" +
                    "**Total Parked** = 駐車場だけでなく、どこにある Parked フラグも含みます。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusSummary2)), "車グループ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusSummary2)),
                    "個人車のみ（自転車グループを除く）。\n" +
                    "**Active** = 現在のレーンがある（移動中）。\n" +
                    "**Parked** = 駐車場だけでなく、すべての **ParkedCar**。\n" +
                    "スキャンは Options メニューが開いている時だけ実行され、都市プレイ中は動かないので FPS の心配はありません。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusSummary3)), "隠れた駐車車両" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusSummary3)),
                    "**OC 境界の合計** = Outside City (OC) 接続にある ParkedCar の車グループ車両。\n" +
                    "都市によっては、Outside City 接続で駐車状態のまま詰まった車が大量に出ることがあります。\n" +
                    "隠れた車のサンプル内訳は <Log hidden cars> を使ってください。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.LogBorderHiddenCars)), "隠れた車をログ出力" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.LogBorderHiddenCars)),
                    "**Logs/FastBikes.log** に 1 回だけレポートを書き込みます。\n" +
                    "合計 + Bucket A/B/C の内訳とサンプル ID 番号を含みます。\n" +
                    "Scene Explorer mod で一覧の Vehicle エンティティ ID へジャンプして調査できます。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLogFromStatus)), "ログを開く" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLogFromStatus)),
                    "**Logs/FastBikes.log** があれば開きます。\n" +
                    "ファイルがまだ見つからない場合は、代わりに Logs フォルダーを開きます。"
                },

                // Status fallback keys
                { "FAST_STATUS_NOT_LOADED",     "ステータス未読み込み。" },
                { "FAST_STATS_NOT_AVAIL",       "都市なし... ¯\\_(ツ)_/¯ ...統計なし" },
                { "FAST_STATS_CARS_NOT_AVAIL",  "データ取得のため、都市を数分動かしてください。" },

                // Status rows
                { "FAST_STATS_BIKES_ROW1", "{0} active | {1} bikes | {2} scooters | {3} / {4} parked/total" },
                { "FAST_STATS_CARS_ROW2",  "{0} active | {1} parked | {2} total | {3} trailers" },

                // Row3 shows TOTAL OC hidden
                { "FAST_STATS_CARS_ROW3",  "{0} OC 境界で非表示 | 更新 {1}" },

                // About: Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),     "表示名。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "バージョン" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)),  "現在のバージョン。" },

                // Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),  "作者の Paradox Mods ページを開きます。" },

                // Debug
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpBicyclePrefabs)), "自転車デバッグレポート" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpBicyclePrefabs)),
                    "<通常プレイには不要です>。\n" +
                    "デバッグやゲームパッチ後の確認用に、詳細ログレポートを 1 回出力します。\n" +
                    "先に都市を読み込んでください。\n" +
                    "出力先: **Logs/FastBikes.log**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLogFromDebug)), "ログを開く" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLogFromDebug)),
                    "**Logs/FastBikes.log** があれば開きます。\n" +
                    "ファイルがまだ見つからない場合は、代わりに Logs フォルダーを開きます。"
                }
            };
        }

        public void Unload( )
        {
        }
    }
}
