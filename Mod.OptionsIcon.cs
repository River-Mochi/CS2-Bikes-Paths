// <copyright file="Mod.OptionsIcon.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

namespace BikesAndPaths
{
    using System;
    using System.IO;
    using Colossal.UI;
    using CS2Shared.RiverMochi;
    using UnityEngine;

    public sealed partial class Mod
    {
        private const string kRetirementIconHost = "bikesandpaths-options";
        private const string kRetirementIconFile = "retirement-heart.svg";
        private const string kRetirementIconResource = "BikesAndPaths.Resources.retirement-heart.svg";

        private UISystem? m_RetirementIconUI;

        private void RegisterRetirementIcon()
        {
            try
            {
                UISystem? uiSystem = UIManager.defaultUISystem;
                if (uiSystem == null)
                {
                    LogUtils.Warn($"{ModTag} Retirement icon: UI system unavailable.");
                    return;
                }

                using Stream? resource = typeof(Mod).Assembly.GetManifestResourceStream(kRetirementIconResource);
                if (resource == null)
                {
                    LogUtils.Warn($"{ModTag} Retirement icon: embedded SVG missing.");
                    return;
                }

                // Extract the embedded image once at load. The DLL carries it in both local and PDX builds.
                string directory = Path.Combine(Application.temporaryCachePath, ModId, "Options");
                Directory.CreateDirectory(directory);
                string filePath = Path.Combine(directory, kRetirementIconFile);
                using (FileStream output = File.Create(filePath))
                {
                    resource.CopyTo(output);
                }

                uiSystem.AddHostLocation(kRetirementIconHost, directory, shouldWatch: false);
                m_RetirementIconUI = uiSystem;
            }
            catch (Exception exception)
            {
                LogUtils.Warn($"{ModTag} Retirement icon unavailable: {exception.Message}");
            }
        }

        private void UnregisterRetirementIcon()
        {
            if (m_RetirementIconUI == null)
            {
                return;
            }

            try
            {
                m_RetirementIconUI.RemoveHostLocation(kRetirementIconHost);
            }
            catch (Exception exception)
            {
                LogUtils.Warn($"{ModTag} Retirement icon cleanup: {exception.Message}");
            }
            finally
            {
                m_RetirementIconUI = null;
            }
        }
    }
}
