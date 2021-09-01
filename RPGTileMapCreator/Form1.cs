using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGTileMapCreator
{
    public partial class Form1 : Form
    {
        PictureBox SelectedPaletteBox = new PictureBox();
        PictureBox formerSelected = new PictureBox();

        public Form1()
        {
            PictureBox p;
            InitializeComponent();

            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    p = new PictureBox();

                    p.BackColor = Color.Ivory;
                    p.SizeMode = PictureBoxSizeMode.StretchImage;
                    p.Width = 51;
                    p.Height = 51;
                    p.Left = 51 * i - 51;
                    p.Top = 51 * j - 51;
                    p.Name = p.Left.ToString() + "_" + p.Top.ToString();
                    p.BorderStyle = BorderStyle.FixedSingle;
                    p.MouseDown += (s, args) =>
                    {
                        if (args.Button == MouseButtons.Right)
                        {
                            CanvasBox_RightClick(s, args);
                        }
                        else if (args.Button == MouseButtons.Left)
                        {
                            CanvasBox_Click(s, args);
                        }
                    };
                    //  p.DragOver += new EventHandler(CanvasBox_DragOver);
                    this.Controls.Add(p);
                }
            }

            int row = 0;
            int col = 0;
            foreach (string s in Directory.GetFiles(@"C:\git\thievesGuild\ThievesGuild\ThievesGuild\Resources\tiles"))
            {
                p = new PictureBox();

                p.BackColor = Color.Ivory;
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                p.Width = 51;
                p.Height = 51;

                p.Left = col * 51;
                p.Top = row * 51;
                col++;
                if (col == 8)
                {
                    col = 0; row++;
                }


                p.Name = Path.GetFileName(s);
                p.BorderStyle = BorderStyle.None;
                p.Image = Image.FromFile(s);
                p.Click += new EventHandler(PaletteBox_Click);
                Panel_Palete.Controls.Add(p);
            }

        }
        public void CanvasBox_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            p.Image = SelectedPaletteBox.Image;
            p.Tag = SelectedPaletteBox.Tag;
        }

        public void CanvasBox_RightClick(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            p.Tag = null;
            p.Image = null;
        }

        public void PaletteBox_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            formerSelected.BorderStyle = BorderStyle.None;

            p.BorderStyle = BorderStyle.Fixed3D;
            textBox1.Text = (string) p.Tag;
            textBox1.Focus();
            SelectedPaletteBox = p;
            formerSelected = p;
        }
        public void PaletteBox_LostFocus(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            p.BorderStyle = BorderStyle.FixedSingle;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            SelectedPaletteBox.Tag = (string) textBox1.Text;
            textBox1.Text = "";
        }

        private void btnWriteFile_Click(object sender, EventArgs e)
        {
            string s = "";
            foreach (PictureBox p in this.Controls)
            {
                if (p.Tag != null)
                    s = s + ((string)p.Tag);

                MessageBox.Show(s);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          //  SelectedPaletteBox.Tag = (string)textBox1.Text;
        }
    }
}
