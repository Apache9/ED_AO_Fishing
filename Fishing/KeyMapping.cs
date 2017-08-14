using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Runtime.InteropServices;

namespace Fishing
{
    class KeyMapping
    {
        [DllImport("user32.dll")]
        static extern UInt16 VkKeyScan(char ch);

        [DllImport("user32.dll")]
        static extern UInt32 MapVirtualKey(UInt32 uCode, UInt32 uMapType);


        private const string CONFIG_FILE = "config.ini";

        private const char CONFIG_SPLITTER = '=';

        private const String CONFIG_NAME_KEYBOARD = "Keyboard";

        private const UInt32 MAPVK_VK_TO_VSC = 0;

        private readonly Microsoft.DirectX.DirectInput.Key[] controlKeys;

        public static KeyMapping load(string gameInstallDirectory)
        {
            string configFile = gameInstallDirectory + Path.DirectorySeparatorChar + CONFIG_FILE;
            string controlKeysConfigString = null;
            foreach (string s in File.ReadLines(configFile))
            {
                string[] split = s.Split(CONFIG_SPLITTER);
                if (split[0].Equals(CONFIG_NAME_KEYBOARD))
                {
                    controlKeysConfigString = split[1];
                    break;
                }
            }
            Microsoft.DirectX.DirectInput.Key[] controlKeys = new Microsoft.DirectX.DirectInput.Key[controlKeysConfigString.Length / 2];
            for (int i = 0; i < controlKeysConfigString.Length; i += 2)
            {
                char ascii = (char)Convert.ToInt16(controlKeysConfigString.Substring(i, 2), 16);
                UInt32 vk = (UInt32)(VkKeyScan(ascii) & 0xFF);
                controlKeys[i / 2] = (Microsoft.DirectX.DirectInput.Key)MapVirtualKey(vk, MAPVK_VK_TO_VSC);

            }
            return new KeyMapping(controlKeys);
        }

        private KeyMapping(Microsoft.DirectX.DirectInput.Key[] controlKeys)
        {
            this.controlKeys = controlKeys;
        }

        private const int BUTTON2_INDEX = 0;

        private const int BUTTION_UP_INDEX = 11;

        private const int BUTTION_DOWN_INDEX = 13;

        public Microsoft.DirectX.DirectInput.Key Button2 { get => controlKeys[BUTTON2_INDEX]; }
        public Microsoft.DirectX.DirectInput.Key ButtonUp { get => controlKeys[BUTTION_UP_INDEX]; }
        public Microsoft.DirectX.DirectInput.Key ButtonDown { get => controlKeys[BUTTION_DOWN_INDEX]; }
    }
}
