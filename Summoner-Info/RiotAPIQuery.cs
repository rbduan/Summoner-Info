using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Summoner_Info
{
    class RiotAPIQuery
    {
        private const string FILENAME = @"CollectRiotAPI.py";

        public static void getInfoFromServer(string name)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = Path.Combine(Environment.CurrentDirectory, FILENAME);
            processInfo.Arguments = name;
            Process query = Process.Start(processInfo);
        }
    }
}
