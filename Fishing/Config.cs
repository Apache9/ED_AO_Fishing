using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Fishing
{
    class Config
    {
        private const string CONFIG_FILE = "config.ini";

        private const char CONFIG_SPLITTER = '=';

        private Dictionary<string, string> conf = new Dictionary<string, string>();

        public Config()
        {
            if (!File.Exists(CONFIG_FILE))
            {
                return;
            }
            foreach (string s in File.ReadLines(CONFIG_FILE))
            {
                string[] split = s.Split(CONFIG_SPLITTER);
                conf.Add(split[0], split[1]);
            }
        }

        public const String CONFIG_GAME_INSTALL_PATH = "GameInstallPath";

        public const String CONFIG_CAPTURE_INTERVAL = "CaptureInterval";

        public const String CONFIG_MAX_WAIT = "MaxWait";

        public string getGameInstallPath()
        {
            return getProperty(CONFIG_GAME_INSTALL_PATH);
        }

        public int getCaptureInterval()
        {
            return Convert.ToInt32(getProperty(CONFIG_CAPTURE_INTERVAL));
        }

        public int getMaxWait()
        {
            return Convert.ToInt32(getProperty(CONFIG_MAX_WAIT));
        }
        public string getProperty(string configName)
        {
            return conf[configName];
        }

        public void setProperty(string configName, string configValue)
        {
            conf[configName] = configValue;
        }

        public void save()
        {
            using (StreamWriter writer = new StreamWriter(CONFIG_FILE))
            {
                foreach (KeyValuePair<string, string> pair in conf.AsEnumerable())
                {
                    writer.WriteLine(pair.Key + CONFIG_SPLITTER + pair.Value);
                }
                writer.Close();
            }
        }
    }
}
