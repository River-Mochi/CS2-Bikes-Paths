// <copyright file="BikesAndPathsSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// Detect actual ASL systems, with no assembly dependency or load-order requirement.
namespace BikesAndPaths
{
    using Unity.Entities;

    internal static class AslOwnership
    {
        internal static bool OwnsPaths(World? world) =>
            HasSystem(world, "RoadRailSpeeds.Systems.GlobalPathSpeedSystem");

        internal static bool OwnsBicycles(World? world) =>
            HasSystem(world, "RoadRailSpeeds.Systems.BicycleSpeedSystem");

        private static bool HasSystem(World? world, string typeName)
        {
            if (world == null || !world.IsCreated)
            {
                return false;
            }

            foreach (ComponentSystemBase system in world.Systems)
            {
                System.Type type = system.GetType();
                if (type.FullName == typeName && type.Assembly.GetName().Name == "RoadRailSpeeds")
                {
                    return true;
                }
            }

            return false;
        }
    }
}
