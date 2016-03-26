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

        public static dynamic test()
        {
            string path = Path.Combine(Environment.CurrentDirectory, FILENAME);

            Microsoft.Scripting.Hosting.ScriptEngine py = Python.CreateEngine();
            Microsoft.Scripting.Hosting.ScriptScope s = py.CreateScope();

            py.ExecuteFile(path, s);

            return path;
        }
    }
}
