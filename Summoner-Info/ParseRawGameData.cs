using System;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summoner_Info
  {
    struct SingleGameInfo
    {
        public string rolePlayed { get; set; }
        public bool gameVictory { get; set; }
        public int champPlayed { get; set; }
        public double csPerMin { get; set; }
        public double expPerMin { get; set; }
        public double wardsPlaced { get; set; }
        public int gameDurationInSeconds { get; set; }
        public bool firstDrag { get; set; }
        public double kills { get; set; }
        public double deaths { get; set; }
        public double assists { get; set; }

        public override string ToString()
        {
            string info = "";

            if (gameVictory == true)
                info += "VICTORY\n";
            else
                info += "DEFEAT\n";

            info += "Game Duration:   " + gameDurationInSeconds/60 + ":" + gameDurationInSeconds%60 + "\n";
            info += "Role played:   " + rolePlayed + "\n";

            if (firstDrag == true)
                info += "First Dragon:   TRUE\n";
            else
                info += "First Dragon:   FALSE\n";

            info += "Champion Played:   " + champPlayed +"\n";
            info += "K/D/A:   " + kills + "/" + deaths + "/" + assists + "\n";
            info += "CS per minute:   " + csPerMin.ToString("N1") + "\n";
            info += "EXP per minute:   " + expPerMin.ToString("N1") + "\n";
            info += "Wards placed:   " + wardsPlaced + "\n";

            return info;
        }
    }

    class ParseRawGameData
    {

        public static Collection<SingleGameInfo> ParseJSonTextFile(string name)
        {
            Collection<SingleGameInfo> games = new Collection<SingleGameInfo>();
            String path = "" + Environment.CurrentDirectory + "\\" + name + ".txt";

            //while loop that parses the .txt file looking for string attributes and their associated values

            String allText = System.IO.File.ReadAllText(path);

            char[] separatingChars = { '^' };

            String[] indivGames = allText.Split(separatingChars); //array of strings where every element is a single game, hopefully with a single player only


            foreach(string game in indivGames) //parse each game string
            {
                SingleGameInfo tempGame = new SingleGameInfo();

                tempGame.kills = getKills(game);
                tempGame.deaths = getDeaths(game);
                tempGame.assists = getAssists(game);
                tempGame.rolePlayed = getRolePlayed(game);
                tempGame.gameVictory = matchVictory(game);
                tempGame.wardsPlaced = getTotalWardsPlaced(game);
                tempGame.gameDurationInSeconds = getMatchDurationInSeconds(game);
                tempGame.firstDrag = firstDrag(game);
                tempGame.csPerMin = getCsPerMinute(game);
                tempGame.expPerMin = getExpPerMinute(game);
                tempGame.champPlayed = getChampPlayed(game);

                games.Add(tempGame);
            }

            return games;
        }

        private static double getKills(string matchInfo)
        {
            double kills = Double.Parse(getValue("\"kills\"", matchInfo));

            return kills;
        }

        private static double getDeaths(string matchInfo)
        {
            double deaths = Double.Parse(getValue("\"deaths\"", matchInfo));

            return deaths;
        }

        private static double getAssists(string matchInfo)
        {
            double assists = Double.Parse(getValue("\"deaths\"", matchInfo));

            return assists;
        }

        private static double getTotalWardsPlaced(string matchInfo)
        {
            double wards = Double.Parse(getValue("\"wardsPlaced\"", matchInfo));

            return wards;
        }

        private static int getMatchDurationInSeconds(string matchInfo)
        {
            int duration = Int32.Parse(getValue("\"matchDuration\"", matchInfo));

            return duration;
        }

        private static string getRolePlayed(string matchInfo)
        {
            string role = "";

            int textPosition = matchInfo.IndexOf("\"role\"") + 9;
            role = matchInfo.Substring(textPosition, matchInfo.IndexOf("\"", textPosition) - textPosition);

            return role;
        }

        private static bool matchVictory(string matchInfo)
        {
            bool victory = Boolean.Parse(getValue("\"winner\"", matchInfo));

            return victory;
        }

        private static bool firstDrag(string matchInfo)
        {
            bool drag = Boolean.Parse(getValue("\"firstDragon\"", matchInfo));

            return drag;
        }

        private static int getChampPlayed(string matchInfo)
        {
            int banPosition = matchInfo.IndexOf("\"bans\"");
            string noBans = matchInfo.Remove(banPosition, matchInfo.IndexOf("]", banPosition) - banPosition);

            int champion = Int32.Parse(getValue("\"championId\"", noBans));

            return champion;
        }

        private static double getCsPerMinute(string matchInfo)
        {
            List<Double> CsPerMin  = new List<Double>();

            int beginPosition = matchInfo.IndexOf("\"creepsPerMinDeltas\"");
            int endPosition = matchInfo.IndexOf("}", beginPosition);

            int stringPointer = beginPosition;

            while(stringPointer < endPosition)
            {
                int num;
                if(Int32.TryParse("" + matchInfo.ElementAt(stringPointer), out num))
                {
                    int endDelimiter = matchInfo.IndexOf(",", stringPointer);

                    if(endDelimiter < endPosition)
                        CsPerMin.Add(Double.Parse(matchInfo.Substring(stringPointer, endDelimiter - stringPointer)));
                    else
                        CsPerMin.Add(Double.Parse(matchInfo.Substring(stringPointer, endPosition - stringPointer)));

                    stringPointer = endDelimiter;
                }
                stringPointer++;
            }

            double average = CsPerMin.Average();

            return average;
        }

        private static double getExpPerMinute(string matchInfo)
        {
            List<Double> ExpPerMin = new List<Double>();

            int beginPosition = matchInfo.IndexOf("\"xpPerMinDeltas\"");
            int endPosition = matchInfo.IndexOf("}", beginPosition);

            int stringPointer = beginPosition;

            while (stringPointer < endPosition)
            {
                int num;
                if (Int32.TryParse("" + matchInfo.ElementAt(stringPointer), out num))
                {
                    int endDelimiter = matchInfo.IndexOf(",", stringPointer);

                    if (endDelimiter < endPosition)
                        ExpPerMin.Add(Double.Parse(matchInfo.Substring(stringPointer, endDelimiter - stringPointer)));
                    else
                        ExpPerMin.Add(Double.Parse(matchInfo.Substring(stringPointer, endPosition - stringPointer)));

                    stringPointer = endDelimiter;
                }
                stringPointer++;
            }

            double average = ExpPerMin.Average();

            return average;
        }

        private static string getValue(string valueToFind, string dataString)
        {
            string value = "";

            int textPosition = dataString.IndexOf(" ", dataString.IndexOf(valueToFind));

            int comma = dataString.IndexOf(",", textPosition);
            int endBracket = dataString.IndexOf("}", textPosition);

            if (comma == -1)
                comma = 99999;
            else if (endBracket == -1)
                endBracket = 99999;
            int endDelimiter = Math.Min(comma, endBracket);

            value = dataString.Substring(textPosition, endDelimiter - textPosition);

            return value;
        }

    }
}
