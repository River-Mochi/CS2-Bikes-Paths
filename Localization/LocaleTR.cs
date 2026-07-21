// <copyright file="LocaleTR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleTR.cs
// Purpose: Turkish entries for FastBikes.

namespace FastBikes
{
    using System.Collections.Generic;  // IEnumerable, Dictionary, KeyValuePair
    using Colossal;                    // IDictionarySource, IDictionaryEntryError

    public sealed class LocaleTR : IDictionarySource
    {
        private readonly FBSetting m_Setting;

        public LocaleTR(FBSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(FBSetting.ActionsTab), "İşlemler" },
                { m_Setting.GetOptionTabLocaleID(FBSetting.AboutTab),   "Hakkında" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsSpeedGrp),      "Hız" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsStabilityGrp),  "Stabilite" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsResetGrp),      "Sıfırla" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsStatusGrp),     "Kişisel araç durumu" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.ActionsPathSpeedGrp),  "Patikalar" },

                { m_Setting.GetOptionGroupLocaleID(FBSetting.AboutInfoGrp),  "Mod bilgisi" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.AboutLinksGrp), "Bağlantılar" },
                { m_Setting.GetOptionGroupLocaleID(FBSetting.AboutDebugGrp), "Debug" },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.EnableFastBikes)), "Fast Bikes'i etkinleştir" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.EnableFastBikes)),
                    "Modu **AÇ / KAPAT** yapar.\n" +
                    "Kapalıyken bisiklet ve scooter davranışı oyun varsayılanına döner.\n" +
                    "\n" +
                    "Fast Bikes kapalı olsa bile aşağıdaki durum bilgisi kullanılabilir."
                },

                // Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.SpeedScalar)), "Bisiklet & scooter hızı" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.SpeedScalar)),
                    "**Maksimum hızı ölçekler**.\n" +
                    "Yüksek hızda daha az ani kalkış ve panik fren görünümü için hızlanma + fren yumuşatma hesabı kullanır.\n" +
                    "**0.30 = oyun varsayılanının %30'u**\n" +
                    "**1.00 = oyun varsayılanı**\n" +
                    "Not: yol sınırları ve oyun koşulları yine de geçerlidir."
                },

                // Stability
    //            { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StiffnessScalar)), "Sertlik" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(Setting.StiffnessScalar)),
    //                "**Sallanma genliği** için çarpan.\n" +
    //                "**Daha yüksek = daha az yatma**.\n" +
    //                "**Daha düşük = daha çok sallanma**.\n" +
    //                "Öneri: yüksek hız stabilitesi için 1.25–1.75."
    //            },
    //
    //            { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DampingScalar)), "Sönümleme" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(Setting.DampingScalar)),
    //                "Daha yüksek = daha hızlı durulur (daha az salınım).\n" +
    //                "**1.00 = oyun varsayılanı**\n" +
    //                "Öneri: yüksek hız stabilitesi için 1.25–2.00."
    //            },

                // Path Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.PathSpeedScalar)), "Patika hız sınırı" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.PathSpeedScalar)),
                    "**Patika** hız sınırlarını ölçekler (patikalar yol değildir).\n" +
                    "**1.00 = oyun varsayılanı**\n" +
                    "Etkiler: bisiklet yolları, ayrılmış yaya+bisiklet yolları ve yaya patikaları.\n" +
                    "\n" +
                    "Kaldırma notu: 1.00 yap veya sıfırlama düğmesini kullan, şehri kaydet, sonra kaldır.\n" +
                    "Unutursan eski patikalar modlu hızda kalır, yeni patikalar vanilla oyun varsayılanını kullanır."
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.ResetToModDefaults)), "Mod varsayılanları" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.ResetToModDefaults)),
                    "Modun varsayılan ayar değerlerini uygular."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.ResetToVanilla)), "Oyun varsayılanları" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.ResetToVanilla)),
                    "Tüm kaydırıcıları **%100** yapar ve oyun varsayılanlarını (vanilla) geri yükler."
                },

                // Status lines
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.StatusSummary1)), "Bisiklet grubu" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.StatusSummary1)),
                    "Bisikletler ve elektrikli scooterlar.\n" +
                    "**Aktif** = mevcut şeridi var (hareket ediyor).\n" +
                    "**Toplam park** = yalnız otoparklar değil, her yerdeki tüm Parked durumlarını içerir."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.StatusSummary2)), "Araba grubu" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.StatusSummary2)),
                    "Sadece kişisel arabalar (Bisiklet grubu hariç).\n" +
                    "**Aktif** = mevcut şeridi var (hareket ediyor).\n" +
                    "**Park** = sadece otoparklar değil, tüm **ParkedCar**.\n" +
                    "Tarama sadece Options menüsü açıkken çalışır, şehir oynanışı sırasında değil; FPS derdi yok."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.StatusSummary3)), "Gizli park etmiş arabalar" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.StatusSummary3)),
                    "**OC sınırındaki toplam** = Şehir Dışı (OC) bağlantısında ParkedCar olan araba grubu araçları.\n" +
                    "Bazı şehirlerde Şehir Dışı bağlantısında parkta takılmış çok sayıda araba görülür.\n" +
                    "Gizli arabaların örnek dökümü için <Log hidden cars> kullan."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.LogBorderHiddenCars)), "Gizli arabaları günlüğe yaz" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.LogBorderHiddenCars)),
                    "**Logs/FastBikes.log** içine tek seferlik rapor yazar.\n" +
                    "Toplam + Bucket A/B/C dökümü ve örnek ID numaralarını içerir.\n" +
                    "Scene Explorer moduyla listelenen Vehicle varlık ID'lerine atlayıp incele."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.OpenLogFromStatus)), "Günlüğü aç" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.OpenLogFromStatus)),
                    "Varsa **Logs/FastBikes.log** dosyasını açar.\n" +
                    "Dosya henüz bulunamazsa onun yerine Logs klasörünü açar."
                },

                // Status fallback keys
                { "FAST_STATUS_NOT_LOADED",     "Durum yüklenmedi." },
                { "FAST_STATS_NOT_AVAIL",       "Şehir yok... ¯\\_(ツ)_/¯ ...İstatistik yok" },
                { "FAST_STATS_CARS_NOT_AVAIL",  "Veri için şehri birkaç dakika çalıştır." },

                // Status rows
                { "FAST_STATS_BIKES_ROW1", "{0} aktif | {1} bisiklet | {2} scooter | {3} / {4} park/toplam" },
                { "FAST_STATS_CARS_ROW2",  "{0} aktif | {1} park | {2} toplam | {3} römork" },

                // Row3 shows TOTAL OC hidden
                { "FAST_STATS_CARS_ROW3",  "{0} OC sınırında gizli | güncellendi {1}" },

                // About: Info
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.AboutName)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.AboutName)),     "Görünen ad." },
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.AboutVersion)), "Sürüm" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.AboutVersion)),  "Geçerli sürüm." },

                // Links
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.OpenParadoxMods)),  "Yazarın Paradox Mods sayfasını açar." },

                // Debug
                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.DumpBicyclePrefabs)), "Bisiklet debug raporu" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.DumpBicyclePrefabs)),
                    "<Normal oynanış için gerekmez>.\n" +
                    "Debug veya oyun yaması sonrası kontrol için tek seferlik ayrıntılı günlük raporu.\n" +
                    "Önce bir şehir yükle.\n" +
                    "Çıktı konumu: **Logs/FastBikes.log**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(FBSetting.OpenLogFromDebug)), "Günlüğü aç" },
                { m_Setting.GetOptionDescLocaleID(nameof(FBSetting.OpenLogFromDebug)),
                    "Varsa **Logs/FastBikes.log** dosyasını açar.\n" +
                    "Dosya henüz bulunamazsa onun yerine Logs klasörünü açar."
                }
            };
        }

        public void Unload( )
        {
        }
    }
}
