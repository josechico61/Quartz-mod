﻿/*Copyright 2022 Christopher Beda

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

   http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.*/

using HarmonyLib;
using Quartz;
using Quartz.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[HarmonyPatch(typeof(XUi))]
public static class XUiPatch
{
    private const string TAG = "Error Reverse Patching XUiController method: ";

    [HarmonyPrefix]
    [HarmonyPatch("GetUIFontByName")]
    public static bool GetUIFontByName(ref NGUIFont __result, string _name, bool _showWarning = true)
    {

        __result = FontManager.GetNGUIFontByName(_name);

        if (__result == null && _showWarning)
        {
            Log.Warning("XUi font not found: " + _name + ", from: " + StackTraceUtility.ExtractStackTrace());
            Logging.Inform("Defaulting to vanilla font");

            __result = FontManager.GetVanillaFont();
        }

        return false;
    }

    [HarmonyPostfix]
    [HarmonyPatch("LoadAsync")]
    public static IEnumerator LoadAsync(IEnumerator __result, XUi __instance, List<string> windowGroupSubset = null)
    {
        Dictionary<string, XUiFromXml.StyleData> styles = XUiFromXml.styles;
        yield return FontManager.LoadFonts(__instance);
        yield return __result;
        yield break;
    }
}