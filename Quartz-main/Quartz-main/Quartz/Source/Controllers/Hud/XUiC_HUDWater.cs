﻿/*Copyright 2023 Christopher Beda

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

   http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.*/

using Quartz.Hud;

namespace Quartz
{
    public class XUiC_HUDWater : XUiC_HUDStatbar
    {

        protected override float GetCurrentStat()
        {
            return LocalPlayer.Stats.Water.Value;
        }

        protected override float GetMaxStat()
        {
            return LocalPlayer.Stats.Water.Max;
        }

        protected override float GetModifiedMax()
        {
            return LocalPlayer.Stats.Water.ModifiedMax;
        }

        protected override float GetStatUIPercentage()
        {
            return LocalPlayer.Stats.Water.ValuePercentUI;
        }
    }
}
