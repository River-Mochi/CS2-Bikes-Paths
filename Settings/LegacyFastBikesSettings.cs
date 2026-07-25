// <copyright file="LegacyFastBikesSettings.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Settings/LegacyFastBikesSettings.cs
// Purpose: Read the old FastBikes settings shape during migration.

namespace BikesAndPaths
{
    // Plain data class: no ModSetting registration or FileLocation.
    // Names and defaults must match FastBikes 1.1.3.
    // Only the values actually carried forward are declared; the old file's Stiffness/Damping keys
    // are ignored, since the decoder skips JSON keys with no matching member.
    internal sealed class LegacyFastBikesSettings
    {
        public bool EnableFastBikes { get; set; } = true;

        public float SpeedScalar { get; set; } = 2.0f;

        public float PathSpeedScalar { get; set; } = 2.0f;
    }
}
