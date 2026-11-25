// <copyright file="LocaleTH.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleTH.cs
// Purpose: Thai entries for BikesAndPaths.

namespace BikesAndPaths
{
    using System.Collections.Generic;  // IEnumerable, Dictionary, KeyValuePair
    using Colossal;                    // IDictionarySource, IDictionaryEntryError

    public sealed class LocaleTH : IDictionarySource
    {
        private readonly BPSetting m_Setting;

        public LocaleTH(BPSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(BPSetting.ActionsTab), "การทำงาน" },
                { m_Setting.GetOptionTabLocaleID(BPSetting.AboutTab),   "เกี่ยวกับ" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsSpeedGrp),      "ความเร็ว" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsStabilityGrp),  "ความเสถียร" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsResetGrp),      "รีเซ็ต" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsPathSpeedGrp),  "ทางเดิน" },

                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutInfoGrp),  "ข้อมูลม็อด" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutLinksGrp), "ลิงก์" },

                // Retirement notice
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsMigrationGrp), "ASL" },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.MigrationText)),
                    "❤️ Bikes + Paths ยุติการพัฒนาแล้ว\n\n" +
                    "ขอบคุณที่ใช้ม็อดนี้! ทุกฟังก์ชันย้ายไปอยู่ใน Adjust All Speed Limits (ASL) พร้อมแผงควบคุมในเมืองที่ปรับทางจักรยานและทางเดินได้สะดวกกว่าเดิม เปลี่ยนไปใช้ ASL ได้จากปุ่มด้านล่าง\n\n" +
                    "ลบ B+P ได้ทุกเมื่อ หากต้องการคืนค่าเริ่มต้นของเกมทันที ให้กดปุ่มคืนค่า รอให้เสร็จแล้วบันทึกเมือง ขั้นตอนนี้ไม่บังคับ\n\n" +
                    "ขอบคุณ River-mochi"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AslMigrationText)),
                    "❤️ Bikes + Paths ยุติการพัฒนาแล้ว\n\n" +
                    "ขอบคุณที่ใช้ม็อดนี้! ทุกฟังก์ชันย้ายไปอยู่ใน Adjust All Speed Limits (ASL) พร้อมแผงควบคุมในเมืองที่ปรับทางจักรยานและทางเดินได้สะดวกกว่าเดิม\n\n" +
                    "ASL จัดการความเร็วอยู่แล้ว ลบ B+P ได้เลยโดยไม่ต้องคืนค่า\n\n" +
                    "ขอบคุณ River-mochi"
                },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "เปิดใช้งาน Bikes + Paths" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "เปิดหรือปิด B+P เมื่อปิดจะคืนค่าที่ ASL ไม่ได้ควบคุมเป็นค่าเริ่มต้น" },

                // Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.SpeedScalar)), "ความเร็วจักรยานและสกู๊ตเตอร์" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.SpeedScalar)),
                    "**ปรับสัดส่วนความเร็วสูงสุด**\n" +
                    "การเร่งและการเบรกจะถูกปรับให้นุ่มนวลเมื่อใช้ความเร็วสูง เพื่อลดการพุ่งตอนออกตัวและการเบรกกะทันหัน\n" +
                    "**0.30 = 30%** ของค่าเริ่มต้นของเกม\n" +
                    "**1.00 = ค่าเริ่มต้นของเกม**\n" +
                    "หมายเหตุ: ขีดจำกัดความเร็วบนถนนและเงื่อนไขของเกมยังคงมีผล"
                },

                // Stability
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StiffnessScalar)), "ความแข็ง" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StiffnessScalar)),
    //                "ตัวคูณสำหรับ **ขนาดการแกว่ง**\n" +
    //                "**สูงขึ้น = เอียงน้อยลง**\n" +
    //                "**ต่ำลง = โคลงมากขึ้น**\n" +
    //                "แนะนำ: 1.25–1.75 เพื่อความเสถียรเมื่อใช้ความเร็วสูง"
    //            },
    //
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.DampingScalar)), "การหน่วง" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.DampingScalar)),
    //                "ยิ่งสูง = กลับสู่ความนิ่งเร็วขึ้น (แกว่งน้อยลง)\n" +
    //                "**1.00 = ค่าเริ่มต้นของเกม**\n" +
    //                "แนะนำ: 1.25–2.00 เพื่อความเสถียรเมื่อใช้ความเร็วสูง"
    //            },

                // Path Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "ALL Speed Limits on Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "เปิด Adjust All Speed Limits บน Paradox Mods" },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.PathSpeedScalar)), "ขีดจำกัดความเร็วของทางเดิน" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.PathSpeedScalar)),
                    "ปรับสัดส่วนขีดจำกัดความเร็วของ **ทางเดิน** (ทางเดินไม่ใช่ถนน)\n" +
                    "**1.00 = ค่าเริ่มต้นของเกม**\n" +
                    "มีผลกับ: ทางจักรยาน ทางสำหรับคนเดินเท้า+จักรยานแบบแบ่งช่อง และทางเดินเท้า\n\n" +
                    "ไม่บังคับ: คืนค่าเริ่มต้นของเกมและบันทึกก่อนลบม็อด มิฉะนั้นทางเดิมอาจยังใช้ขีดจำกัดที่ปรับไว้"
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToModDefaults)), "ค่าเริ่มต้นของม็อด" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToModDefaults)),
                    "ใช้ค่าปรับแต่งเริ่มต้นของม็อด"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToVanilla)), "คืนค่าเริ่มต้นของเกม" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToVanilla)),
                    "ตั้งแถบเลื่อนทั้งหมดเป็น **100%** และคืนค่าเริ่มต้นของเกม (vanilla)"
                },
                // Status fallback keys
                { "FAST_STATUS_NOT_LOADED",     "ยังไม่ได้โหลดสถานะ" },
                { "FAST_STATS_NOT_AVAIL",       "ไม่มีเมือง... ¯\\_(ツ)_/¯ ...ไม่มีสถิติ" },
                { "FAST_STATS_CARS_NOT_AVAIL",  "เดินเกมสักครู่เพื่อเก็บข้อมูล" },

                // Status rows
                { "FAST_STATS_BIKES_ROW1", "{0} ใช้งาน | {1} จักรยาน | {2} สกู๊ตเตอร์ | {3} / {4} จอด/ทั้งหมด" },
                { "FAST_STATS_CARS_ROW2",  "{0} ใช้งาน | {1} จอด | {2} ทั้งหมด | {3} รถพ่วง" },

                // Row3 shows TOTAL OC hidden
                { "FAST_STATS_CARS_ROW3",  "{0} ซ่อนอยู่ที่ขอบเขต OC | อัปเดต {1}" },

                // About: Info
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutName)),    "ม็อด" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutName)),     "ชื่อที่แสดง" },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutVersion)), "เวอร์ชัน" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutVersion)),  "เวอร์ชันปัจจุบัน" },

                // Links
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenParadoxMods)),  "เปิดหน้า Paradox Mods ของผู้สร้าง" },

            };
        }

        public void Unload( )
        {
        }
    }
}

