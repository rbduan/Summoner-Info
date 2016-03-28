using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Summoner_Info
{
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
        }

        private void retrieveInput_Click(object sender, EventArgs e)
        {
            string name = nameInput.Text;
            string filepath = "" + Environment.CurrentDirectory + "\\" + name + ".txt";

            if (File.Exists(filepath))
                ;
            else
            {
                RiotAPIQuery.getInfoFromServer(name);
                ////////PLEASE REPLACE LATER
                Thread.Sleep(45000);
            }

            if(new FileInfo(filepath).Length == 0)
                MessageBox.Show("No Ranked Data available for " + name + "\n", "Player Info", MessageBoxButtons.OK);
            else
            {
                Collection<SingleGameInfo> playerGames = ParseRawGameData.ParseJSonTextFile(name);

                PlayerGameDataProcessing singlePlayer = new PlayerGameDataProcessing(playerGames, name);

                string playerData = buildPlayerDataString(singlePlayer);

                DialogResult results = MessageBox.Show(playerData, "Player Info", MessageBoxButtons.YesNo);

                if (results == DialogResult.Yes)
                {
                    ScrollableMessageBox matchHistory = new ScrollableMessageBox();
                    matchHistory.Show(singlePlayer.getAllGamesInformation(), name + "'s Match History");
                }
                else { }
            }            

        }

        private string buildPlayerDataString(PlayerGameDataProcessing player)
        {
            string user = player.Username;
            string playerData = "";

            playerData += "Here are some cumulative stats from " + user + "'s last " + player.getTotalGames() + " ranked games: \n\n";
            playerData += "Winrate: " + player.getWinrate().ToString("N1") + "%\n";
            playerData += "Average K/D/A: " + player.getAvgKDA() + "\n";
            playerData += "Most frequent role: " + player.getMostFrequentRole() + "\n";
            playerData += "Average CS/minute: " + player.getAvgCsPerMinute().ToString("N1") + "\n";
            playerData += "Average EXP/minute: " + player.getAvgExpPerMinute().ToString("N1") + "\n";
            playerData += "Average Wards/minute: " + player.getAvgWardsPerMinute().ToString("N1") + "\n";
            playerData += "First Dragon Rate: " + player.getFirstDragonRate().ToString("N1") + "%\n";
            playerData += "Number of different champions played: " + player.getNumberOfDifferentChamps() + "\n\n\n";

            playerData += "Would you like to view more detailed statistics for each game?\n";


            return playerData;
        }

    }
}
