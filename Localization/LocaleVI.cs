// File: Localization/LocaleVI.cs
// Purpose: Vietnamese entries for FastBikes.

namespace FastBikes
{
    using Colossal;                    // IDictionarySource, IDictionaryEntryError
    using System.Collections.Generic;  // IEnumerable, Dictionary, KeyValuePair

    public sealed class LocaleVI : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleVI(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Thao tác" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "Giới thiệu" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.ActionsSpeedGrp),      "Tốc độ" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ActionsStabilityGrp),  "Ổn định" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ActionsResetGrp),      "Đặt lại" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ActionsStatusGrp),     "Trạng thái xe cá nhân" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ActionsPathSpeedGrp),  "Đường đi" },

                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Thông tin mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Liên kết" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutDebugGrp), "Gỡ lỗi" },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableFastBikes)), "Bật Fast Bikes" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableFastBikes)),
                    "**Bật / tắt** mod.\n" +
                    "Khi tắt, xe đạp và scooter sẽ về hành vi mặc định của game.\n\n" +
                    "Thông tin trạng thái bên dưới vẫn xem được dù Fast Bikes đang tắt."
                },

                // Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SpeedScalar)), "Tốc độ xe đạp & scooter" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SpeedScalar)),
                    "**Nhân tốc độ tối đa**.\n" +
                    "Tăng tốc + phanh dùng công thức làm mượt ở tốc độ cao để bớt giật và bớt phanh gấp.\n" +
                    "**0.30 = 30%** mặc định game\n" +
                    "**1.00 = mặc định game**\n" +
                    "Lưu ý: giới hạn đường và điều kiện trong game vẫn áp dụng."
                },

                // Stability
    //            { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StiffnessScalar)), "Độ cứng" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(Setting.StiffnessScalar)),
    //                "Hệ số cho **biên độ lắc**.\n" +
    //                "**Cao hơn = ít nghiêng hơn**.\n" +
    //                "**Thấp hơn = lắc nhiều hơn**.\n" +
    //                "Gợi ý: 1.25–1.75 để ổn định ở tốc độ cao."
    //            },
    //
    //            { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DampingScalar)), "Giảm dao động" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(Setting.DampingScalar)),
    //                "Cao hơn = ổn định nhanh hơn (ít dao động hơn).\n" +
    //                "**1.00 = mặc định game**\n" +
    //                "Gợi ý: 1.25–2.00 để ổn định ở tốc độ cao."
    //            },

                // Path Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PathSpeedScalar)), "Giới hạn tốc độ đường đi" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PathSpeedScalar)),
                    "Nhân giới hạn tốc độ **đường đi** (đường đi không phải đường xe chạy).\n" +
                    "**1.00 = mặc định game**\n" +
                    "Ảnh hưởng: đường xe đạp, đường đi bộ+xe đạp tách làn, và đường đi bộ.\n\n" +
                    "Gỡ mod: đặt về 1.00 hoặc dùng nút đặt lại, lưu thành phố, rồi gỡ mod.\n" +
                    "Nếu quên, đường đi cũ giữ tốc độ modded, đường đi mới dùng mặc định vanilla."
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToModDefaults)), "Mặc định mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToModDefaults)),
                    "Áp dụng giá trị tinh chỉnh mặc định của mod."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Mặc định game" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "Đưa mọi thanh trượt về **100%** và khôi phục mặc định game (vanilla)."
                },

                // Status lines
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusSummary1)), "Nhóm xe đạp" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusSummary1)),
                    "Xe đạp và scooter điện.\n" +
                    "**Đang chạy** = có làn hiện tại (đang di chuyển).\n" +
                    "**Tổng đang đỗ** = tính mọi trạng thái đỗ ở mọi nơi, không chỉ bãi đỗ."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusSummary2)), "Nhóm ô tô" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusSummary2)),
                    "Chỉ xe cá nhân (không tính nhóm xe đạp).\n" +
                    "**Đang chạy** = có làn hiện tại (đang di chuyển).\n" +
                    "**Đang đỗ** = tất cả **ParkedCar**, không chỉ bãi đỗ.\n " +
                    "Quét chỉ chạy khi Options đang mở, không chạy vào fps trong thành phố, nên đừng lo hiệu năng."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusSummary3)), "Xe đỗ ẩn" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusSummary3)),
                    "**Tổng ở biên OC** = xe nhóm ô tô có ParkedCar tại kết nối Ngoài Thành Phố (OC).\n" +
                    "Một số thành phố có rất nhiều xe bị kẹt đang đỗ ở kết nối Ngoài Thành Phố.\n" +
                    "Dùng <Ghi log xe ẩn> để xem mẫu phân nhóm xe ẩn.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.LogBorderHiddenCars)), "Ghi log xe ẩn" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.LogBorderHiddenCars)),
                    "Ghi báo cáo một lần vào **Logs/FastBikes.log**.\n" +
                    "Có tổng số + phân nhóm A/B/C và số ID mẫu.\n" +
                    "Dùng mod Scene Explorer để nhảy tới ID thực thể xe được liệt kê và kiểm tra."
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
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),     "Tên hiển thị." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Phiên bản" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)),  "Phiên bản hiện tại." },

                // Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),  "Mở trang Paradox Mods của tác giả." },

                // Debug
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpBicyclePrefabs)), "Báo cáo gỡ lỗi xe đạp" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpBicyclePrefabs)),
                    "Báo cáo log chi tiết một lần để gỡ lỗi hoặc kiểm tra sau ngày patch.\n" +
                    "Không cần cho chơi bình thường.\n" +
                    "Hãy tải thành phố trước.\n" +
                    "Nơi xuất: **Logs/FastBikes.log**"
                }
            };
        }

        public void Unload( )
        {
        }
    }
}
