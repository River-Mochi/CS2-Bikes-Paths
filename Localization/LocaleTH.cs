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
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsStatusGrp),     "สถานะยานพาหนะส่วนบุคคล" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsPathSpeedGrp),  "ทางเดิน" },

                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutInfoGrp),  "ข้อมูลม็อด" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutLinksGrp), "ลิงก์" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutDebugGrp), "ดีบัก" },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "เปิดใช้งาน Bikes + Paths" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.EnableBikesAndPaths)),
                    "**เปิด / ปิด** ม็อด\n" +
                    "เมื่อปิด การทำงานของจักรยานและสกู๊ตเตอร์จะกลับเป็นค่าเริ่มต้นของเกม\n\n" +
                    "ข้อมูลสถานะด้านล่างยังดูได้แม้จะปิด Bikes + Paths"
                },

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
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.PathSpeedScalar)), "ขีดจำกัดความเร็วของทางเดิน" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.PathSpeedScalar)),
                    "ปรับสัดส่วนขีดจำกัดความเร็วของ **ทางเดิน** (ทางเดินไม่ใช่ถนน)\n" +
                    "**1.00 = ค่าเริ่มต้นของเกม**\n" +
                    "มีผลกับ: ทางจักรยาน ทางสำหรับคนเดินเท้า+จักรยานแบบแบ่งช่อง และทางเดินเท้า\n\n" +
                    "หมายเหตุเมื่อลบม็อด: ตั้งเป็น 1.00 หรือใช้ปุ่มรีเซ็ต บันทึกเมือง แล้วจึงลบม็อด\n" +
                    "หากลืม ทางเดินเก่าจะยังคงใช้ความเร็วที่ม็อดปรับไว้ ส่วนทางเดินใหม่จะใช้ค่าเริ่มต้นของเกม"
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToModDefaults)), "ค่าเริ่มต้นของม็อด" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToModDefaults)),
                    "ใช้ค่าปรับแต่งเริ่มต้นของม็อด"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToVanilla)), "ค่าเริ่มต้นของเกม" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToVanilla)),
                    "ตั้งแถบเลื่อนทั้งหมดเป็น **100%** และคืนค่าเริ่มต้นของเกม (vanilla)"
                },

                // Status lines
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StatusSummary1)), "กลุ่มจักรยาน" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StatusSummary1)),
                    "จักรยานและสกู๊ตเตอร์ไฟฟ้า\n" +
                    "**กำลังใช้งาน** = มีเลนปัจจุบัน (กำลังเคลื่อนที่)\n" +
                    "**จอดทั้งหมด** = รวมสถานะ Parked จากทุกที่ ไม่ใช่เฉพาะลานจอดรถ"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StatusSummary2)), "กลุ่มรถยนต์" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StatusSummary2)),
                    "เฉพาะรถยนต์ส่วนบุคคล (ไม่รวมกลุ่มจักรยาน)\n" +
                    "**กำลังใช้งาน** = มีเลนปัจจุบัน (กำลังเคลื่อนที่)\n" +
                    "**จอดอยู่** = รถที่มีสถานะ **ParkedCar** ทั้งหมด ไม่ใช่เฉพาะในลานจอดรถ\n " +
                    "การสแกนทำงานเฉพาะเมื่อเปิดเมนูตัวเลือก ไม่ทำงานระหว่างเล่นในเมือง จึงไม่กระทบ FPS"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StatusSummary3)), "รถที่จอดแบบซ่อนอยู่" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StatusSummary3)),
                    "**รวมที่ขอบเขต OC** = รถยนต์ในกลุ่มรถที่มี ParkedCar ณ จุดเชื่อมต่อนอกเมือง (OC)\n" +
                    "บางเมืองอาจมีรถจำนวนมากติดค้างในสถานะจอดที่จุดเชื่อมต่อนอกเมือง\n" +
                    "ใช้ <บันทึกรถที่ซ่อนอยู่> เพื่อดูตัวอย่างการแบ่งกลุ่มรถที่ซ่อนอยู่\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.LogBorderHiddenCars)), "บันทึกรถที่ซ่อนอยู่" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.LogBorderHiddenCars)),
                    "เขียนรายงานหนึ่งครั้งไปยัง **Logs/BikesAndPaths.log**\n" +
                    "มีจำนวนรวม + การแบ่ง Bucket A/B/C และหมายเลข ID ตัวอย่าง\n" +
                    "ใช้ม็อด Scene Explorer เพื่อ Jump To ไปยัง ID เอนทิตี Vehicle ที่แสดงไว้และตรวจสอบ"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenLogFromStatus)), "เปิดไฟล์บันทึก" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenLogFromStatus)),
                    "เปิด **Logs/BikesAndPaths.log** หากมีไฟล์นี้\n" +
                    "หากยังไม่พบไฟล์ จะเปิดโฟลเดอร์ Logs แทน"
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

                // Debug
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.DumpBicyclePrefabs)), "รายงานดีบักจักรยาน" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.DumpBicyclePrefabs)),
                    "<ไม่จำเป็นสำหรับการเล่นตามปกติ>\n" +
                    "รายงานบันทึกแบบละเอียดหนึ่งครั้งสำหรับการดีบักหรือตรวจสอบในวันที่เกมอัปเดต\n" +
                    "โหลดเมืองก่อน\n" +
                    "ตำแหน่งไฟล์: **Logs/BikesAndPaths.log**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenLogFromDebug)), "เปิดไฟล์บันทึก" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenLogFromDebug)),
                    "เปิด **Logs/BikesAndPaths.log** หากมีไฟล์นี้\n" +
                    "หากยังไม่พบไฟล์ จะเปิดโฟลเดอร์ Logs แทน"
                }
            };
        }

        public void Unload( )
        {
        }
    }
}

