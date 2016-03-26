using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //MessageBox.Show(PythonTest.test());
            PythonTest.test2();
        }

    }
}
