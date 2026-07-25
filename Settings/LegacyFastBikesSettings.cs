// <copyright file="LegacyFastBikesSettings.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Settings/LegacyFastBikesSettings.cs
// Purpose: Read-only shape of the old FastBikes.coc, used once to carry values into BPSetting.
// Transitional: delete together with Mod.Migration.cs in a later release.

namespace BikesAndPaths
{
    // Plain class on purpose - NOT a ModSetting:
    //  * It is only ever filled by AssetDatabase.LoadSettings<T>(name, Action<T, SourceMeta>), the
    //    read-only overload. That overload does `new T()` + JSON.WriteInto and never assigns
    //    SettingAsset.Fragment.source, so this type can never become a save target.
    //  * A ModSetting subclass would also register itself in ModSetting.instances under the same mod
    //    id as BPSetting and overwrite it.
    // No [FileLocation] either: the lookup is by settings section name ("FastBikes"), not by path.
    //
    // Property names must match the OLD JSON keys exactly, and the initializers must match the OLD
    // mod defaults: only non-default values were serialized, so a key missing from the file has to
    // fall back to what the old mod treated as default.
    internal sealed class LegacyFastBikesSettings
    {
        public bool EnableFastBikes { get; set; } = true;

        public float SpeedScalar { get; set; } = 2.0f;

        public float StiffnessScalar { get; set; } = 1.50f;

        public float DampingScalar { get; set; } = 1.50f;

        public float PathSpeedScalar { get; set; } = 2.0f;
    }
}
