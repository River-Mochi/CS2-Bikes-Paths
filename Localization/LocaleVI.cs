// <copyright file="LocaleVI.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleVI.cs
// Purpose: Vietnamese entries for BikesAndPaths.

namespace BikesAndPaths
{
    using System.Collections.Generic;  // IEnumerable, Dictionary, KeyValuePair
    using Colossal;                    // IDictionarySource, IDictionaryEntryError

    public sealed class LocaleVI : IDictionarySource
    {
        private readonly BPSetting m_Setting;

        public LocaleVI(BPSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(BPSetting.ActionsTab), "Thao tác" },
                { m_Setting.GetOptionTabLocaleID(BPSetting.AboutTab),   "Giới thiệu" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsSpeedGrp),      "Tốc độ" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsStabilityGrp),  "Ổn định" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsResetGrp),      "Đặt lại" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsPathSpeedGrp),  "Đường đi" },

                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutInfoGrp),  "Thông tin mod" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutLinksGrp), "Liên kết" },

                // Retirement notice
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsMigrationGrp), "ASL" },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.MigrationText)),
                    "❤️ Bikes + Paths đã ngừng phát triển.\n\n" +
                    "Cảm ơn bạn đã dùng mod! Mọi tính năng đã được đưa vào Adjust All Speed Limits (ASL), với bảng điều khiển trong thành phố tiện hơn cho đường xe đạp và lối đi bộ. Hãy chuyển sang ASL bằng nút bên dưới.\n\n" +
                    "Bạn có thể gỡ B+P bất cứ lúc nào. Nếu muốn khôi phục ngay mặc định của game, hãy dùng nút khôi phục, chờ áp dụng xong và lưu thành phố. Không bắt buộc.\n\n" +
                    "Cảm ơn, River-mochi"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AslMigrationText)),
                    "❤️ Bikes + Paths đã ngừng phát triển.\n\n" +
                    "Cảm ơn bạn đã dùng mod! Mọi tính năng đã được đưa vào Adjust All Speed Limits (ASL), với bảng điều khiển trong thành phố tiện hơn cho đường xe đạp và lối đi bộ.\n\n" +
                    "ASL đã quản lý tốc độ. Bạn có thể gỡ B+P mà không cần đặt lại.\n\n" +
                    "Cảm ơn, River-mochi"
                },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "Bật Bikes + Paths" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "Bật hoặc tắt B+P. Khi tắt, khôi phục các giá trị không do ASL quản lý." },

                // Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.SpeedScalar)), "Tốc độ xe đạp & scooter" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.SpeedScalar)),
                    "**Nhân tốc độ tối đa**.\n" +
                    "Tăng tốc + phanh dùng làm mượt ở tốc độ cao để bớt giật khi khởi hành và bớt cảm giác phanh gấp.\n" +
                    "**0.30 = 30%** mặc định của game\n" +
                    "**1.00 = mặc định của game**\n" +
                    "Lưu ý: giới hạn đường và điều kiện trong game vẫn áp dụng."
                },

                // Stability
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StiffnessScalar)), "Độ cứng" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StiffnessScalar)),
    //                "Hệ số cho **biên độ lắc**.\n" +
    //                "**Cao hơn = ít nghiêng hơn**.\n" +
    //                "**Thấp hơn = lắc nhiều hơn**.\n" +
    //                "Gợi ý: 1.25–1.75 để ổn định hơn ở tốc độ cao."
    //            },
    //
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.DampingScalar)), "Giảm chấn" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.DampingScalar)),
    //                "Cao hơn = ổn định nhanh hơn (ít dao động hơn).\n" +
    //                "**1.00 = mặc định của game**\n" +
    //                "Gợi ý: 1.25–2.00 để ổn định hơn ở tốc độ cao."
    //            },

                // Path Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "ALL Speed Limits on Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "Mở Adjust All Speed Limits trên Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.PathSpeedScalar)), "Giới hạn tốc độ đường đi" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.PathSpeedScalar)),
                    "Nhân giới hạn tốc độ của **đường đi** (đường đi không phải đường xe chạy).\n" +
                    "**1.00 = mặc định của game**\n" +
                    "Ảnh hưởng: đường xe đạp, đường tách người đi bộ+xe đạp, và đường đi bộ.\n" +
                    "\n" +
                    "Không bắt buộc: khôi phục mặc định game và lưu trước khi gỡ. Nếu không, đường hiện có có thể giữ giới hạn đã chỉnh."
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToModDefaults)), "Mặc định mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToModDefaults)),
                    "Áp dụng các giá trị chỉnh mặc định của mod."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToVanilla)), "Khôi phục mặc định game" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToVanilla)),
                    "Đặt tất cả thanh trượt về **100%** và khôi phục mặc định của game (vanilla)."
                },
                // Status fallback keys
                { "FAST_STATUS_NOT_LOADED",     "Chưa tải trạng thái." },
                { "FAST_STATS_NOT_AVAIL",       "Chưa có thành phố... ¯\\_(ツ)_/¯ ...Không có thống kê" },
                { "FAST_STATS_CARS_NOT_AVAIL",  "chạy thành phố vài phút để có dữ liệu." },

                // Status rows
                { "FAST_STATS_BIKES_ROW1", "{0} chạy | {1} xe đạp | {2} scooter | {3} / {4} đỗ/tổng" },
                { "FAST_STATS_CARS_ROW2",  "{0} chạy | {1} đỗ | {2} tổng | {3} rơ moóc" },

                // Row3 shows TOTAL OC hidden
                { "FAST_STATS_CARS_ROW3",  "{0} ẩn ở biên OC | cập nhật {1}" },

                // About: Info
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutName)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutName)),     "Tên hiển thị." },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutVersion)), "Phiên bản" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutVersion)),  "Phiên bản hiện tại." },

                // Links
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenParadoxMods)),  "Mở trang Paradox Mods của tác giả." },

            };
        }

        public void Unload( )
        {
        }
    }
}

