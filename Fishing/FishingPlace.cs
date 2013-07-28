using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace Fishing
{
    class FishingPlace
    {
        private const string CONFIG_FILE = "place.ini";

        private const char CONFIG_SPLITTER = '=';

        private const char RECT_PARAM_SPLITTER = ',';

        private readonly Dictionary<string, Rectangle> name2Rect = new Dictionary<string, Rectangle>();

        public FishingPlace()
        {
            foreach (string s in File.ReadLines(CONFIG_FILE))
            {
                string[] split = s.Split(CONFIG_SPLITTER);
                string[] rectParam = split[1].Split(RECT_PARAM_SPLITTER);
                name2Rect.Add(split[0], new Rectangle(Convert.ToInt32(rectParam[0]), Convert.ToInt32(rectParam[1]), Convert.ToInt32(rectParam[2]), Convert.ToInt32(rectParam[3])));
            }
        }

        public IEnumerable<string> allPlace()
        {
            return name2Rect.Keys.AsEnumerable();
        }

        public Rectangle getRect(string place)
        {
            return name2Rect[place];
        }
    }
}
