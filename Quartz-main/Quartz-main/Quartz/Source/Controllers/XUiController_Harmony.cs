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
using System;
using System.Runtime.CompilerServices;

[HarmonyPatch(typeof(XUiController))]
public static class XUiControllerPatch
{
    private const string TAG = "Error Reverse Patching XUiController method: ";

    [HarmonyReversePatch]
    [HarmonyPatch("Update")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Update(XUiController instance, float _dt)
    {
        // its a stub so it has no initial content
        throw new NotImplementedException(TAG + "Update()");
    }

    [HarmonyReversePatch]
    [HarmonyPatch("OnHovered")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void OnHovered(XUiController instance, bool _isOver)
    {
        // its a stub so it has no initial content
        throw new NotImplementedException(TAG + "OnHovered()");
    }
}