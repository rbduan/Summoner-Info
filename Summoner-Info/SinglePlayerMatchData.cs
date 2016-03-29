using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summoner_Info
{
    class SinglePlayerMatchData
    {
        private Collection<rawMatchData> matches = new Collection<rawMatchData>();
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

        public SinglePlayerMatchData(Collection<rawMatchData> matches, string name)
        {
            this.matches = matches;
            username = name;
        }



    }
}
