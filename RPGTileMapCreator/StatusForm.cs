using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGTileMapCreator
{
    public partial class StatusForm : Form
    {
        public StatusForm()
        {
            InitializeComponent();

            lblStatus.Text = "";
        }

        public void UpdateStatusMessage(string s)
        {
            lblStatus.Text = s;
        }

        public void StartStatusBar(int max)
        {
            progressBar1.Visible = true;
            progressBar1.Maximum = max;
        }

        public void IncrementStatusBar()
        {
            if (progressBar1.Value + 1 <= progressBar1.Maximum)
            {
                Application.DoEvents();
                progressBar1.Value++;
            }
            //if (progressBar1.Value == 50)
            //{
            //    System.Diagnostics.Debugger.Break();
            //}
        }
    }
}
