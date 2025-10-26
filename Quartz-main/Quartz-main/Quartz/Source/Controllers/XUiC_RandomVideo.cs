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

using System;

namespace Quartz
{
    public class XUiC_RandomVideo : XUiController
    {
        private const string TAG = "RandomVideo";

        private const char SPLITTER = ',';
        private string[] videos;
        private readonly Random rnd = new Random();

        public override void OnOpen()
        {
            base.OnOpen();
            RefreshBindings();
        }

        public override bool GetBindingValueInternal(ref string value, string bindingName)
        {
            switch (bindingName)
            {
                case "randomvideo":
                    value = getRandomVideo();
                    return true;
                default:
                    return base.GetBindingValueInternal(ref value, bindingName);
            }
        }

        public override bool ParseAttribute(string attribute, string value, XUiController parent)
        {
            if (attribute != null)
            {
                switch (attribute)
                {
                    case "videos":
                        parseVideos(value);
                        return true;
                    default:
                        return base.ParseAttribute(attribute, value, parent);
                }
            }
            return false;
        }

        private void parseVideos(string videoString)
        {
            if (string.IsNullOrEmpty(videoString))
            {
                return;
            }

            videos = videoString.Split(SPLITTER);
        }

        private string getRandomVideo()
        {
            if (videos == null)
            {
                return string.Empty;
            }
            string videoName = videos[rnd.Next(videos.Length)];
            videoName = videoName.Trim();
            Logging.Out(TAG, "Random Video: " + videoName);
            return videoName;
        }
    }
}