using System;
using Summoner_Info;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Summoner_Info
{
    class PlayerGameDataProcessing
    {

        private Collection<SingleGameInfo> games = new Collection<SingleGameInfo>();
        private string username;

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public PlayerGameDataProcessing(Collection<SingleGameInfo> games, string name)
        {
            this.games = games;
            username = name;
        }

        public int getTotalGames()
        {
            return games.Count;
        }

        public string getMostFrequentRole()
        {
            var groups = games.GroupBy(game => game.rolePlayed);
            int maxCount = groups.Max(g => g.Count());
            string mostFrequentRole = groups.First(g => g.Count() == maxCount).Key;

            return mostFrequentRole;
        }

        public int getNumberOfDifferentChamps()
        {
            var groups = games.GroupBy(game => game.champPlayed);
            int total = groups.Count();

            return total;
        }

        public double getAvgCsPerMinute()
        {
            return games.Average(game => game.csPerMin);
        }

        public double getAvgExpPerMinute()
        {
            return games.Average(game => game.expPerMin);
        }

        public double getAvgWardsPerMinute()
        {
            return games.Average(game => (games.Sum(gameWards => gameWards.wardsPlaced) / (games.Sum(gameTime => (double)gameTime.gameDurationInSeconds) / 60.0)));
        }

        public double getAvgKills()
        {
            return games.Average(game => game.kills);
        }

        public double getAvgDeaths()
        {
            return games.Average(game => game.deaths);
        }

        public double getAvgAssists()
        {
            return games.Average(game => game.assists);
        }

        public string getAvgKDA()
        {
            return "" + getAvgKills().ToString("N1") + "/" + getAvgDeaths().ToString("N1") + "/" + getAvgAssists().ToString("N1");
        }

        public double getWinrate()
        {
            double winCount = 0;

            foreach(SingleGameInfo game in games)
            {
                if (game.gameVictory == true)
                    winCount++;
            }

            return 100 * (winCount / (double)games.Count);
        }

        public double getFirstDragonRate()
        {
            double dragCount = 0;

            foreach (SingleGameInfo game in games)
            {
                if (game.firstDrag == true)
                    dragCount++;
            }

            return 100 * (dragCount / (double)games.Count);
        }

        public string getAllGamesInformation()
        {
            string info = "";
            int count = 1;

            foreach (SingleGameInfo game in games)
            {
                info += "MATCH " + count + "\n\n";
                info += game.ToString() + "\n\n\n";
                count++;
            }

            return info;
        }

    }
}
