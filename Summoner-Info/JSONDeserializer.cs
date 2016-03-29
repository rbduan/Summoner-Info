using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Summoner_Info
{
    class JSONDeserializer
    {
        public static rawMatchData getMatchObjectFromJSonFileByPath(string path)
        {
            String json = System.IO.File.ReadAllText(path);

            rawMatchData match = JsonConvert.DeserializeObject<rawMatchData>(json);

            return match;
        }

        public static rawMatchData getMatchObjectFromJSonFileById(int id)
        {
            string filepath = "" + Environment.CurrentDirectory + "\\matchCache\\" + id + ".txt";

            String json = System.IO.File.ReadAllText(filepath);

            rawMatchData match = JsonConvert.DeserializeObject<rawMatchData>(json);

            return match;
        }
    }
}
