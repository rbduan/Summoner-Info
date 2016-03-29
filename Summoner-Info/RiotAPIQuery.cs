using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Net;

namespace Summoner_Info
{
    class RiotAPIQuery
    {

        private const string API_KEY = @"?api_key=bfbf03bb-ce02-434d-a86e-beed8a3602c6";
        private const string REQUEST_BASE = @"https://na.api.pvp.net/api/lol/na/";
        private const string SUMMONER_ID_BY_NAME = @"v1.4/summoner/by-name/";
        private const string RECENT_GAMES_BY_SID = @"v1.3/game/by-summoner/";




        private const string FILENAME = @"CollectRiotAPI.py";

        public static void getInfoFromServer(string name)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = Path.Combine(Environment.CurrentDirectory, FILENAME);
            processInfo.Arguments = name;
            Process query = Process.Start(processInfo);
        }

        public static int getIDByName(string name)
        {
            string lowercaseName = name.ToLower();
            string request = String.Concat(REQUEST_BASE, SUMMONER_ID_BY_NAME, lowercaseName, API_KEY);
            WebClient client = new WebClient();

            string response = client.DownloadString(request);

            dynamic dynResponse = JsonConvert.DeserializeObject(response);

            int sID = dynResponse[lowercaseName].id;

            Debug.WriteLine(sID);
            return sID;
        }

        public static Dictionary<int, int> getRecentMatchlistBySID(int sID)
        {
            Dictionary <int, int> recentMatchesWithChampionId = new Dictionary<int, int>();
            WebClient client = new WebClient();

            string request = String.Concat(REQUEST_BASE, RECENT_GAMES_BY_SID, sID, "/recent", API_KEY);
            string response = client.DownloadString(request);

            dynamic dynResponse = JsonConvert.DeserializeObject(response);

            dynamic games = dynResponse.games;

            foreach(var game in games)
            {
                recentMatchesWithChampionId.Add((int)game.gameId, (int)game.championId);
            }

            Debug.WriteLine(recentMatchesWithChampionId);

            return recentMatchesWithChampionId;
        }

        public static Dictionary<int, int> getRecentMatchlistByName(string name)
        {
            Dictionary<int, int> recentMatchesWithChampionId = new Dictionary<int, int>();

            int summonerID = RiotAPIQuery.getIDByName(name);
            recentMatchesWithChampionId = RiotAPIQuery.getRecentMatchlistBySID(summonerID);

            return recentMatchesWithChampionId;
        }


    }
}
