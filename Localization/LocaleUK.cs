// <copyright file="LocaleUK.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleUK.cs
// Purpose: Ukrainian entries for BikesAndPaths.

namespace BikesAndPaths
{
    using System.Collections.Generic;  // IEnumerable, Dictionary, KeyValuePair
    using Colossal;                    // IDictionarySource, IDictionaryEntryError

    public sealed class LocaleUK : IDictionarySource
    {
        private readonly BPSetting m_Setting;

        public LocaleUK(BPSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(BPSetting.ActionsTab), "Дії" },
                { m_Setting.GetOptionTabLocaleID(BPSetting.AboutTab),   "Про мод" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsSpeedGrp),      "Швидкість" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsStabilityGrp),  "Стабільність" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsResetGrp),      "Скидання" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsPathSpeedGrp),  "Доріжки" },

                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutInfoGrp),  "Інформація про мод" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutLinksGrp), "Посилання" },

                // Retirement notice
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsMigrationGrp), "ASL" },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.MigrationText)),
                    "❤️ Розробку Bikes + Paths завершено.\n\n" +
                    "Дякую, що користувалися модом! Усі функції тепер є в Adjust All Speed Limits (ASL), із зручнішою панеллю в місті для велодоріжок і пішохідних шляхів. Перейдіть до ASL за кнопкою нижче.\n\n" +
                    "B+P можна видалити будь-коли. Щоб одразу повернути стандартні значення гри, натисніть кнопку відновлення, дочекайтеся завершення змін і збережіть місто. Це необов’язково.\n\n" +
                    "Дякую, River-mochi"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AslMigrationText)),
                    "❤️ Розробку Bikes + Paths завершено.\n\n" +
                    "Дякую, що користувалися модом! Усі функції тепер є в Adjust All Speed Limits (ASL), із зручнішою панеллю в місті для велодоріжок і пішохідних шляхів. Перейдіть до ASL за кнопкою нижче.\n\n" +
                    "ASL уже керує швидкістю. Можна видалити B+P без скидання.\n\n" +
                    "Дякую, River-mochi"
                },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "Увімкнути Bikes + Paths" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "Вмикає або вимикає B+P. При вимкненні відновлює значення, якими не керує ASL." },

                // Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.SpeedScalar)), "Швидкість велосипедів і самокатів" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.SpeedScalar)),
                    "**Масштабує максимальну швидкість**.\n" +
                    "На високій швидкості прискорення й гальмування згладжуються, щоб уникнути різких стартів і панічного гальмування.\n" +
                    "**0.30 = 30%** від стандартного значення гри\n" +
                    "**1.00 = стандартне значення гри**\n" +
                    "Примітка: обмеження швидкості на дорогах та умови гри все одно діють."
                },

                // Stability
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StiffnessScalar)), "Жорсткість" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StiffnessScalar)),
    //                "Множник **амплітуди розгойдування**.\n" +
    //                "**Вище = менший нахил**.\n" +
    //                "**Нижче = більше хитання**.\n" +
    //                "Рекомендовано: 1.25–1.75 для стабільності на високій швидкості."
    //            },
    //
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.DampingScalar)), "Демпфування" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.DampingScalar)),
    //                "Вище = швидше стабілізується (менше коливань).\n" +
    //                "**1.00 = стандартне значення гри**\n" +
    //                "Рекомендовано: 1.25–2.00 для стабільності на високій швидкості."
    //            },

                // Path Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "ALL Speed Limits on Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "Відкриває Adjust All Speed Limits на Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.PathSpeedScalar)), "Обмеження швидкості доріжок" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.PathSpeedScalar)),
                    "Масштабує обмеження швидкості **доріжок** (доріжки не є дорогами).\n" +
                    "**1.00 = стандартне значення гри**\n" +
                    "Впливає на: велодоріжки, розділені пішохідно-велосипедні доріжки та пішохідні доріжки.\n\n" +
                    "Перед видаленням: установіть 1.00 або скористайтеся кнопкою скидання, збережіть місто, а потім видаліть мод.\n" +
                    "Якщо забудете, старі доріжки просто збережуть змінену модом швидкість, а нові матимуть стандартні значення гри."
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToModDefaults)), "Стандартні налаштування мода" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToModDefaults)),
                    "Застосовує стандартні значення налаштувань мода."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToVanilla)), "Відновити стандартні значення" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToVanilla)),
                    "Установлює всі повзунки на **100%** і відновлює стандартні налаштування гри (vanilla)."
                },
                // Status fallback keys
                { "FAST_STATUS_NOT_LOADED",     "Стан не завантажено." },
                { "FAST_STATS_NOT_AVAIL",       "Немає міста... ¯\\_(ツ)_/¯ ...Немає статистики" },
                { "FAST_STATS_CARS_NOT_AVAIL",  "запустіть місто на кілька хвилин, щоб отримати дані." },

                // Status rows
                { "FAST_STATS_BIKES_ROW1", "{0} активних | {1} велосипедів | {2} самокатів | {3} / {4} припарковано/усього" },
                { "FAST_STATS_CARS_ROW2",  "{0} активних | {1} припарковано | {2} усього | {3} причепів" },

                // Row3 shows TOTAL OC hidden
                { "FAST_STATS_CARS_ROW3",  "{0} приховано на межі OC | оновлено {1}" },

                // About: Info
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutName)),    "Мод" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutName)),     "Назва для відображення." },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutVersion)), "Версія" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutVersion)),  "Поточна версія." },

                // Links
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenParadoxMods)),  "Відкриває сторінку автора на Paradox Mods." },

            };
        }

        public void Unload( )
        {
        }
    }
}

