// <copyright file="LocaleVI.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleVI.cs
// Purpose: Vietnamese entries for BikeAndPath.

namespace BikeAndPath
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
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsStatusGrp),     "Trạng thái xe cá nhân" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsPathSpeedGrp),  "Đường đi" },

                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutInfoGrp),  "Thông tin mod" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutLinksGrp), "Liên kết" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutDebugGrp), "Gỡ lỗi" },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.EnableFastBikes)), "Bật Fast Bikes" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.EnableFastBikes)),
                    "Bật hoặc tắt mod **ON / OFF**.\n" +
                    "Khi tắt, hành vi xe đạp và scooter trở về mặc định của game.\n" +
                    "\n" +
                    "Thông tin trạng thái bên dưới vẫn dùng được ngay cả khi Fast Bikes tắt."
                },

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
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.PathSpeedScalar)), "Giới hạn tốc độ đường đi" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.PathSpeedScalar)),
                    "Nhân giới hạn tốc độ của **đường đi** (đường đi không phải đường xe chạy).\n" +
                    "**1.00 = mặc định của game**\n" +
                    "Ảnh hưởng: đường xe đạp, đường tách người đi bộ+xe đạp, và đường đi bộ.\n" +
                    "\n" +
                    "Gỡ mod: đặt về 1.00 hoặc dùng nút đặt lại, lưu thành phố, rồi gỡ mod.\n" +
                    "Nếu quên, đường cũ vẫn giữ tốc độ đã chỉnh, còn đường mới dùng mặc định vanilla."
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToModDefaults)), "Mặc định mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToModDefaults)),
                    "Áp dụng các giá trị chỉnh mặc định của mod."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToVanilla)), "Mặc định game" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToVanilla)),
                    "Đặt tất cả thanh trượt về **100%** và khôi phục mặc định của game (vanilla)."
                },

                // Status lines
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StatusSummary1)), "Nhóm xe đạp" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StatusSummary1)),
                    "Xe đạp và scooter điện.\n" +
                    "**Đang chạy** = có làn hiện tại (đang di chuyển).\n" +
                    "**Tổng đang đỗ** = gồm mọi cờ Parked ở mọi nơi, không chỉ bãi đỗ."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StatusSummary2)), "Nhóm ô tô" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StatusSummary2)),
                    "Chỉ xe cá nhân (không gồm nhóm xe đạp).\n" +
                    "**Đang chạy** = có làn hiện tại (đang di chuyển).\n" +
                    "**Đang đỗ** = mọi **ParkedCar**, không chỉ bãi đỗ.\n" +
                    "Quét chỉ chạy khi menu Options mở, không chạy trong lúc chơi thành phố, nên không lo FPS."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StatusSummary3)), "Xe đỗ ẩn" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StatusSummary3)),
                    "**Tổng ở biên OC** = xe trong nhóm ô tô có ParkedCar tại kết nối Outside City (OC).\n" +
                    "Một số thành phố có nhiều xe bị kẹt ở trạng thái đỗ tại kết nối Outside City.\n" +
                    "Dùng <Log hidden cars> để xem phân nhóm mẫu của xe ẩn."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.LogBorderHiddenCars)), "Ghi log xe ẩn" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.LogBorderHiddenCars)),
                    "Ghi báo cáo một lần vào **Logs/FastBikes.log**.\n" +
                    "Có tổng số + phân nhóm Bucket A/B/C và số ID mẫu.\n" +
                    "Dùng mod Scene Explorer để nhảy tới ID thực thể Vehicle được liệt kê và kiểm tra."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenLogFromStatus)), "Mở log" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenLogFromStatus)),
                    "Mở **Logs/FastBikes.log** nếu có.\n" +
                    "Nếu chưa tìm thấy file, sẽ mở thư mục Logs."
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

                // Debug
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.DumpBicyclePrefabs)), "Báo cáo gỡ lỗi xe đạp" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.DumpBicyclePrefabs)),
                    "<Không cần cho chơi bình thường>.\n" +
                    "Báo cáo log chi tiết một lần để gỡ lỗi hoặc kiểm tra sau ngày patch.\n" +
                    "Hãy tải thành phố trước.\n" +
                    "Nơi xuất: **Logs/FastBikes.log**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenLogFromDebug)), "Mở log" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenLogFromDebug)),
                    "Mở **Logs/FastBikes.log** nếu có.\n" +
                    "Nếu chưa tìm thấy file, sẽ mở thư mục Logs."
                }
            };
        }

        public void Unload( )
        {
        }
    }
}
