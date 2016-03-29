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
        public static Collection<rawMatchData> DeserializeMatchesFromJSonFile(string path)
        {
            Collection<rawMatchData> matches = new Collection<rawMatchData>();

            String json = System.IO.File.ReadAllText(path);

            char[] separatingChars = { '^' };

            String[] indivMatches = json.Split(separatingChars); //array of strings where every element is a single game, hopefully with a single player only


            foreach (string match in indivMatches) //parse each game string
            {
                rawMatchData tempMatch = JsonConvert.DeserializeObject<rawMatchData>(json);

                matches.Add(tempMatch);
            }

            return matches;
        }
    }
}
