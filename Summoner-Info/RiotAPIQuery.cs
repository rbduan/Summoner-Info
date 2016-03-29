using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Net;
using System.Threading;

namespace Summoner_Info
{
    class RiotAPIQuery
    {

        private const string API_KEY = @"?api_key=bfbf03bb-ce02-434d-a86e-beed8a3602c6";
        private const string REQUEST_BASE = @"https://na.api.pvp.net/api/lol/na/";
        private const string SUMMONER_ID_BY_NAME = @"v1.4/summoner/by-name/";
        private const string RECENT_GAMES_BY_SID = @"v1.3/game/by-summoner/";
        private const string MATCH_BY_MATCH_ID = @"v2.2/match/";




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

            return sID;
        }

        /// <summary>
        /// look into using delegates to return 2 lists maybe? KV pairs makes sense for this atm so not urgent
        /// </summary>
        /// <param name="sID"></param>
        /// <returns></returns>
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

            return recentMatchesWithChampionId;
        }

        public static Dictionary<int, int> getRecentMatchlistByName(string name)
        {
            Dictionary<int, int> recentMatchesWithChampionId = new Dictionary<int, int>();

            int summonerID = RiotAPIQuery.getIDByName(name);
            recentMatchesWithChampionId = RiotAPIQuery.getRecentMatchlistBySID(summonerID);

            return recentMatchesWithChampionId;
        }

        public static Collection<rawMatchData> getMatchesByList(List<int> matchlist)
        {
            Collection<rawMatchData> matches = new Collection<rawMatchData>();

            foreach(int matchId in matchlist)
            {
                if (matchCached(matchId))
                    continue;
                else
                {
                    Debug.WriteLine("Downloading Match " + matchId);
                    downloadMatchByMatchId(matchId);
                    Thread.Sleep(1100);
                }                    
            }

            foreach(int matchId in matchlist)
            {
                rawMatchData tempMatch = JSONDeserializer.getMatchObjectFromJSonFileById(matchId);

                matches.Add(tempMatch);
            }

            return matches;
        }

        /// <summary>
        /// may be a better way of doing this idk
        /// </summary>
        /// <param name="matchlist"></param>
        /// <returns></returns>
        public static Dictionary<rawMatchData, int> getMatchesByDictionary(Dictionary<int, int> matchesWithCID)
        {
            List<int> matchIdList = new List<int>();
            Dictionary<rawMatchData, int> matchDataWithCID = new Dictionary<rawMatchData, int>();

            foreach (KeyValuePair<int, int> match in matchesWithCID)
                matchIdList.Add(match.Key);

            Collection<rawMatchData> matchDataList = getMatchesByList(matchIdList);

            foreach (rawMatchData match in matchDataList)
                matchDataWithCID.Add(match, matchesWithCID[match.matchId]);

            return matchDataWithCID;
        }

        private static void downloadMatchByMatchId(int id)
        {
            string request = String.Concat(REQUEST_BASE, MATCH_BY_MATCH_ID, id, API_KEY);
            string filepath = "" + Environment.CurrentDirectory + "\\matchCache\\" + id + ".txt";
            WebClient client = new WebClient();

            client.DownloadFile(request, filepath);            
        }

        private static bool matchCached(int matchId)
        {
            string filepath = "" + Environment.CurrentDirectory + "\\matchCache\\" + matchId + ".txt";

            if (File.Exists(filepath))
                return true;

            return false;
        }
    }
}
