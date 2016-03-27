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
    public partial class ScrollableMessageBox : Form
    {
        public ScrollableMessageBox()
        {
            InitializeComponent();
        }

        public void Show(string text, string caption)
        {
            ScrollableMessage.Text = text.Replace("\n", Environment.NewLine);
            this.Text = caption;
            ScrollableMessage.Select(0, 0);
            this.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
