﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Summoner_Info
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new UserInterface());

            //test code for random stuff

            RiotAPIQuery.getMatchesByDictionary(RiotAPIQuery.getRecentMatchlistByName("swag4lyfe"));


        }
    }
}
