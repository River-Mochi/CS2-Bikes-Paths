// <copyright file="LocaleUK.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleUK.cs
// Purpose: Ukrainian entries for FastBikes.

namespace FastBikes
{
    using System.Collections.Generic;  // IEnumerable, Dictionary, KeyValuePair
    using Colossal;                    // IDictionarySource, IDictionaryEntryError

    public sealed class LocaleUK : IDictionarySource
    {
        private readonly FBSetting m_Setting;

        public LocaleUK(FBSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(FBSetting.ActionsTab), "Дії" },
                { m_Setting.GetOptionTabLocaleID(FBSetting.AboutTab),   "Про мод" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsSpeedGrp),      "Швидкість" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsStabilityGrp),  "Стабільність" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsResetGrp),      "Скидання" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsStatusGrp),     "Стан особистого транспорту" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsPathSpeedGrp),  "Доріжки" },

                { m_Setting.GetOptionGroupLocaleID(FBSetting.AboutInfoGrp),  "Інформація про мод" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.AboutLinksGrp), "Посилання" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.AboutDebugGrp), "Налагодження" },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.EnableFastBikes)), "Увімкнути Fast Bikes" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.EnableFastBikes)),
                    "**Вмикає / вимикає** мод.\n" +
                    "Коли мод вимкнено, поведінка велосипедів і самокатів повертається до стандартних налаштувань гри.\n\n" +
                    "Інформація про стан нижче доступна, навіть якщо Fast Bikes вимкнено."
                },

                // Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.SpeedScalar)), "Швидкість велосипедів і самокатів" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.SpeedScalar)),
                    "**Масштабує максимальну швидкість**.\n" +
                    "На високій швидкості прискорення й гальмування згладжуються, щоб уникнути різких стартів і панічного гальмування.\n" +
                    "**0.30 = 30%** від стандартного значення гри\n" +
                    "**1.00 = стандартне значення гри**\n" +
                    "Примітка: обмеження швидкості на дорогах та умови гри все одно діють."
                },

                // Stability
    //            { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.StiffnessScalar)), "Жорсткість" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.StiffnessScalar)),
    //                "Множник **амплітуди розгойдування**.\n" +
    //                "**Вище = менший нахил**.\n" +
    //                "**Нижче = більше хитання**.\n" +
    //                "Рекомендовано: 1.25–1.75 для стабільності на високій швидкості."
    //            },
    //
    //            { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.DampingScalar)), "Демпфування" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.DampingScalar)),
    //                "Вище = швидше стабілізується (менше коливань).\n" +
    //                "**1.00 = стандартне значення гри**\n" +
    //                "Рекомендовано: 1.25–2.00 для стабільності на високій швидкості."
    //            },

                // Path Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.PathSpeedScalar)), "Обмеження швидкості доріжок" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.PathSpeedScalar)),
                    "Масштабує обмеження швидкості **доріжок** (доріжки не є дорогами).\n" +
                    "**1.00 = стандартне значення гри**\n" +
                    "Впливає на: велодоріжки, розділені пішохідно-велосипедні доріжки та пішохідні доріжки.\n\n" +
                    "Перед видаленням: установіть 1.00 або скористайтеся кнопкою скидання, збережіть місто, а потім видаліть мод.\n" +
                    "Якщо забудете, старі доріжки просто збережуть змінену модом швидкість, а нові матимуть стандартні значення гри."
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.ResetToModDefaults)), "Стандартні налаштування мода" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.ResetToModDefaults)),
                    "Застосовує стандартні значення налаштувань мода."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.ResetToVanilla)), "Стандартні налаштування гри" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.ResetToVanilla)),
                    "Установлює всі повзунки на **100%** і відновлює стандартні налаштування гри (vanilla)."
                },

                // Status lines
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.StatusSummary1)), "Група велосипедів" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.StatusSummary1)),
                    "Велосипеди та електричні самокати.\n" +
                    "**Активні** = мають поточну смугу (рухаються).\n" +
                    "**Усього припарковано** = включає всі прапорці Parked звідусіль, а не лише з паркінгів."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.StatusSummary2)), "Група автомобілів" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.StatusSummary2)),
                    "Лише особисті автомобілі (без групи велосипедів).\n" +
                    "**Активні** = мають поточну смугу (рухаються).\n" +
                    "**Припарковані** = усі **ParkedCar**, а не лише автомобілі на паркінгах.\n " +
                    "Сканування виконується лише тоді, коли відкрито меню параметрів, а не під час гри в місті, тому на FPS це не впливає."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.StatusSummary3)), "Приховані припарковані автомобілі" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.StatusSummary3)),
                    "**Усього на межі OC** = автомобілі групи з ParkedCar на з'єднанні Outside City (OC).\n" +
                    "У деяких містах багато автомобілів застрягають припаркованими на з'єднанні Outside City.\n" +
                    "Скористайтеся <Записати приховані авто в журнал>, щоб переглянути приклади розподілу прихованих автомобілів.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.LogBorderHiddenCars)), "Записати приховані авто в журнал" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.LogBorderHiddenCars)),
                    "Записує одноразовий звіт у **Logs/FastBikes.log**.\n" +
                    "Містить загальну кількість + розподіл Bucket A/B/C і приклади номерів ID.\n" +
                    "У моді Scene Explorer скористайтеся Jump To, щоб перейти до наведених ID сутностей Vehicle та перевірити їх."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.OpenLogFromStatus)), "Відкрити журнал" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.OpenLogFromStatus)),
                    "Відкриває **Logs/FastBikes.log**, якщо файл існує.\n" +
                    "Якщо файл ще не знайдено, натомість відкриває папку Logs."
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
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.AboutName)),    "Мод" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.AboutName)),     "Назва для відображення." },
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.AboutVersion)), "Версія" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.AboutVersion)),  "Поточна версія." },

                // Links
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.OpenParadoxMods)),  "Відкриває сторінку автора на Paradox Mods." },

                // Debug
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.DumpBicyclePrefabs)), "Звіт налагодження велосипедів" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.DumpBicyclePrefabs)),
                    "<Не потрібно для звичайної гри>.\n" +
                    "Одноразовий докладний звіт журналу для налагодження або перевірки в день оновлення гри.\n" +
                    "Спочатку завантажте місто.\n" +
                    "Розташування файлу: **Logs/FastBikes.log**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.OpenLogFromDebug)), "Відкрити журнал" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.OpenLogFromDebug)),
                    "Відкриває **Logs/FastBikes.log**, якщо файл існує.\n" +
                    "Якщо файл ще не знайдено, натомість відкриває папку Logs."
                }
            };
        }

        public void Unload( )
        {
        }
    }
}
