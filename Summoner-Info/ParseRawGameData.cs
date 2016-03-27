using System;
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
            info += "CS per minute:   " + csPerMin + "\n";
            info += "EXP per minute:   " + expPerMin + "\n";
            info += "Wards placed:   " + wardsPlaced + "\n";

            return info;
        }
    }

    class ParseRawGameData
    {

        public static Collection<SingleGameInfo> ParseJSonTextFile(string path)
        {
            Collection<SingleGameInfo> sample = new Collection<SingleGameInfo>();

            for(int i = 0; i < 6; i++)
            {
                SingleGameInfo temp = new SingleGameInfo();

                temp.gameVictory = true;
                temp.kills = i;
                temp.deaths = i + 1;
                temp.assists = i + 2;
                temp.rolePlayed = "SOLO";
                temp.csPerMin = i * 5;
                temp.expPerMin = i * 10;
                temp.wardsPlaced = i + 2;
                temp.gameDurationInSeconds = 2000;
                temp.firstDrag = false;
                temp.champPlayed = 1;

                sample.Add(temp);

            }

            for (int i = 0; i < 3; i++)
            {
                SingleGameInfo temp = new SingleGameInfo();

                temp.gameVictory = false;
                temp.kills = i;
                temp.deaths = i + 1;
                temp.assists = i + 2;
                temp.rolePlayed = "DUO";
                temp.csPerMin = i * 5;
                temp.expPerMin = i * 10;
                temp.wardsPlaced = i + 2;
                temp.gameDurationInSeconds = 2000;
                temp.firstDrag = true;
                temp.champPlayed = 2;

                sample.Add(temp);
            }

            return sample;
        }
    }
}
