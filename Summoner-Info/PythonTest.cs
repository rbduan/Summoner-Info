using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting;
using System.IO;
using System.Diagnostics;

namespace Summoner_Info
{
    class PythonTest
    {
        private const string FILENAME = @"CollectRiotAPI.py";

        public static void test2()
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = Path.Combine(Environment.CurrentDirectory, FILENAME);
            Process process = Process.Start(start);
        }
    }
}
