// <copyright file="LocaleTR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleTR.cs
// Purpose: Turkish entries for BikesAndPaths.

namespace BikesAndPaths
{
    using System.Collections.Generic;  // IEnumerable, Dictionary, KeyValuePair
    using Colossal;                    // IDictionarySource, IDictionaryEntryError

    public sealed class LocaleTR : IDictionarySource
    {
        private readonly BPSetting m_Setting;

        public LocaleTR(BPSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(BPSetting.ActionsTab), "İşlemler" },
                { m_Setting.GetOptionTabLocaleID(BPSetting.AboutTab),   "Hakkında" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsSpeedGrp),      "Hız" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsStabilityGrp),  "Stabilite" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsResetGrp),      "Sıfırla" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsPathSpeedGrp),  "Patikalar" },

                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutInfoGrp),  "Mod bilgisi" },
                { m_Setting.GetOptionGroupLocaleID(BPSetting.AboutLinksGrp), "Bağlantılar" },

                // Retirement notice
                { m_Setting.GetOptionGroupLocaleID(BPSetting.ActionsMigrationGrp), "ASL" },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.MigrationText)),
                    "❤️ Bikes + Paths artık geliştirilmiyor.\n\n" +
                    "Bu modu kullandığın için teşekkürler! Tüm özellikler artık Adjust All Speed Limits (ASL) içinde. Bisiklet ve yaya yolları için gelişmiş şehir içi paneli var. Aşağıdaki düğmeyle ASL'ye geçebilirsin.\n\n" +
                    "B+P'yi istediğin zaman kaldırabilirsin. Oyun varsayılanlarına hemen dönmek için sıfırlama düğmesini kullan, işlemin bitmesini bekle ve şehri kaydet. Bu isteğe bağlıdır.\n\n" +
                    "Teşekkürler, River-mochi"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AslMigrationText)),
                    "❤️ Bikes + Paths artık geliştirilmiyor.\n\n" +
                    "Bu modu kullandığın için teşekkürler! Tüm özellikler artık Adjust All Speed Limits (ASL) içinde. Bisiklet ve yaya yolları için gelişmiş şehir içi paneli var.\n\n" +
                    "ASL hız ayarlarını zaten yönetiyor. B+P'yi sıfırlama yapmadan kaldırabilirsin.\n\n" +
                    "Teşekkürler, River-mochi"
                },

                // Master toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "Bikes + Paths'i etkinleştir" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.EnableBikesAndPaths)), "B+P'yi açar veya kapatır. Kapatınca ASL'nin yönetmediği değerler varsayılana döner." },

                // Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.SpeedScalar)), "Bisiklet & scooter hızı" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.SpeedScalar)),
                    "**Maksimum hızı ölçekler**.\n" +
                    "Yüksek hızda daha az ani kalkış ve panik fren görünümü için hızlanma + fren yumuşatma hesabı kullanır.\n" +
                    "**0.30 = oyun varsayılanının %30'u**\n" +
                    "**1.00 = oyun varsayılanı**\n" +
                    "Not: yol sınırları ve oyun koşulları yine de geçerlidir."
                },

                // Stability
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.StiffnessScalar)), "Sertlik" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.StiffnessScalar)),
    //                "**Sallanma genliği** için çarpan.\n" +
    //                "**Daha yüksek = daha az yatma**.\n" +
    //                "**Daha düşük = daha çok sallanma**.\n" +
    //                "Öneri: yüksek hız stabilitesi için 1.25–1.75."
    //            },
    //
    //            { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.DampingScalar)), "Sönümleme" },
    //            { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.DampingScalar)),
    //                "Daha yüksek = daha hızlı durulur (daha az salınım).\n" +
    //                "**1.00 = oyun varsayılanı**\n" +
    //                "Öneri: yüksek hız stabilitesi için 1.25–2.00."
    //            },

                // Path Speed
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "ALL Speed Limits on Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenAllSpeedLimits)), "Paradox Mods'ta Adjust All Speed Limits sayfasını açar." },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.PathSpeedScalar)), "Patika hız sınırı" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.PathSpeedScalar)),
                    "**Patika** hız sınırlarını ölçekler (patikalar yol değildir).\n" +
                    "**1.00 = oyun varsayılanı**\n" +
                    "Etkiler: bisiklet yolları, ayrılmış yaya+bisiklet yolları ve yaya patikaları.\n" +
                    "\n" +
                    "İsteğe bağlı: modu kaldırmadan önce oyun varsayılanlarına dön ve kaydet. Aksi halde mevcut yollar değiştirilen sınırları koruyabilir."
                },

                // Reset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToModDefaults)), "Mod varsayılanları" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToModDefaults)),
                    "Modun varsayılan ayar değerlerini uygular."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.ResetToVanilla)), "Oyun varsayılanlarına dön" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.ResetToVanilla)),
                    "Tüm kaydırıcıları **%100** yapar ve oyun varsayılanlarını (vanilla) geri yükler."
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
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutName)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutName)),     "Görünen ad." },
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.AboutVersion)), "Sürüm" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.AboutVersion)),  "Geçerli sürüm." },

                // Links
                { m_Setting.GetOptionLabelLocaleID(nameof(BPSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(BPSetting.OpenParadoxMods)),  "Yazarın Paradox Mods sayfasını açar." },

            };
        }

        public void Unload( )
        {
        }
    }
}

