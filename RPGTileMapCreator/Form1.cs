using Newtonsoft.Json;
using RPGTileMapCreator.cls;
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
        PaletteObject formerSelectedTileSet = new PaletteObject();
        PaletteObject selectedTileSet = new PaletteObject();
        
        TextBox txtMapCharacter = new TextBox();
        List<PaletteObject> tileSets;
        List<CanvasTile> canvasTiles = new List<CanvasTile>();

        protected int tileWidth = 0;
        protected int tileHeight = 0;

        public Form1()
        {
            PictureBox p;
            TextBox t = new TextBox();

            InitializeComponent();

            lblFavouriteTilesFolder.Text = @"c:\temp\tiles";
            lblFavouriteTileSet.Text = @"c:\temp\lancer.json";
            //openTileFolderDialog = new OpenFileDialog();

            //PictureBox p;
            //TextBox t = new TextBox();

            //for (int i = 1; i <= 10; i++)
            //{
            //    for (int j = 1; j <= 10; j++)
            //    {
            //        p = new PictureBox();

            //        p.BackColor = Color.Ivory;
            //        p.SizeMode = PictureBoxSizeMode.StretchImage;
            //        p.Width = 51;
            //        p.Height = 51;
            //        p.Left = 51 * i - 51;
            //        p.Top = 51 * j - 51;
            //        p.Name = p.Left.ToString() + "_" + p.Top.ToString();
            //        p.BorderStyle = BorderStyle.FixedSingle;
            //        p.MouseDown += (s, args) =>
            //        {
            //            if (args.Button == MouseButtons.Right)
            //            {
            //                CanvasBox_RightClick(s, args);
            //            }
            //            else if (args.Button == MouseButtons.Left)
            //            {
            //                CanvasBox_Click(s, args);
            //            }
            //        };
            //        //  p.DragOver += new EventHandler(CanvasBox_DragOver);
            //        this.Controls.Add(p);
            //    }
            //}

            ////int row = 0;
            ////int col = 0;
            ////foreach (string s in Directory.GetFiles(@"C:\git\thievesGuild\ThievesGuild\ThievesGuild\Resources\tiles"))
            ////{
            ////    p = new PictureBox();
            ////    t = new TextBox();

            ////    p.BackColor = Color.Ivory;
            ////    p.SizeMode = PictureBoxSizeMode.StretchImage;
            ////    p.Width = 51;
            ////    p.Height = 51;

            ////    t.MaxLength = 1;
            ////    t.Height = 23;
            ////    t.Width = p.Width;

            ////    p.Left = col * 51;
            ////    p.Top = row * 51 + row * t.Height;
            ////    col++;
            ////    if (col == 9)
            ////    {
            ////        col = 0; row++;
            ////    }

            ////    p.Name = Path.GetFileName(s);
            ////    p.BorderStyle = BorderStyle.None;
            ////    p.Image = Image.FromFile(s);
            ////    p.Click += new EventHandler(PaletteBox_Click);
            ////    Panel_Palete.Controls.Add(p);

            ////    t.Left = p.Left;
            ////    t.Top = p.Top + p.Height;
            ////    t.Tag = p.Name;
            ////    t.Leave += new EventHandler(LetterBox_LostFocus);
            ////    t.Enter += new EventHandler(LetterBox_Enter);
            ////    t.TextChanged += new EventHandler(LetterBox_TextChanged);
            ////    Panel_Palete.Controls.Add(t);

            ////    tileSets.Add(new PaletteObject(p, t));
            ////}

            //txtMapCharacter.Visible = false;
            //txtMapCharacter.Left = 0;
            //txtMapCharacter.Top = 0;
            //this.Controls.Add(txtMapCharacter);

            //txtMapName.Focus();
        }
      
        public void CanvasBox_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            p.Image = selectedTileSet.tile.Image;
            p.Tag = selectedTileSet.tile.Tag;

            if ((selectedTileSet.tile.Tag == null) || (selectedTileSet.tile.Tag.ToString().Length == 0))
            {
                p.Image = null;
            }
            else
            {
                p.Tag = selectedTileSet.tile.Tag;
            }

            // must update the CanvasTile list
            // locate canvas tile by location
            // update character
        }

        public void CanvasBox_RightClick(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            p.Tag = null;
            p.Image = null;
        }

        public void LetterBox_LostFocus(object sender, EventArgs e)
        {
            TextBox letter = (TextBox)sender;
            PaletteObject pb = tileSets.Find(p => p.letter == letter);
            if (pb != null)
            {
                pb.tile.Tag = letter.Text;
            }
            // Can only be one
          /*  if (tileSets.Count(p => p.letter == letter) > 1)
            {
                DialogResult dialogResult = MessageBox.Show("This character assignment already exists.", "Character Already Used", MessageBoxButtons.OK);
                pb.letter.Text = "";
                pb.tile.Tag = null;
            }*/

            if (String.IsNullOrEmpty(letter.Text))
            {
              DialogResult dialogResult = MessageBox.Show("There is no character for this tile. If you leave it blank, these tiles will be removed from canvas. Proceed?", "You Goofed!", MessageBoxButtons.YesNo);
               
                if (dialogResult == DialogResult.Yes)
                {
                    foreach(PictureBox p in Canvas_Panel.Controls.OfType<PictureBox>())
                    {
                        if (p.Image == pb.tile.Image)
                        {
                            p.Image = null;
                        }

                        // must update the CanvasTile list
                        // locate canvas tile by location
                        // update character
                    }
                }
                else
                {
                    letter.Focus(); 
                }
            }
        }

        public void LetterBox_Enter(object sender, EventArgs e)
        {
            PaletteObject tileSet;
            TextBox l = (TextBox)sender;
            l.BackColor = Color.Yellow;

            // Reset FormerSelectedTileSet
            if (formerSelectedTileSet.tile != null)
            {
                formerSelectedTileSet.letter.BackColor = Color.White;
                formerSelectedTileSet.tile.BorderStyle = BorderStyle.None;
                formerSelectedTileSet.tile.Tag = formerSelectedTileSet.letter.Text;
            }

            tileSet = tileSets.Find(p => p.letter == l);

            // Make this the ne FormerSelectedTileSet
            if (tileSet != null)
            {
                tileSet.letter.BackColor = Color.Yellow;
                formerSelectedTileSet = tileSet;
                selectedTileSet = tileSet;
                selectedTileSet.tile.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        public void PaletteBox_Click(object sender, EventArgs e)
        {
            PaletteObject tileSet;
            PictureBox p = (PictureBox)sender;
            p.BorderStyle = BorderStyle.Fixed3D;

            // Reset FormerSelectedTileSet
            if (formerSelectedTileSet.tile != null)
            {
                formerSelectedTileSet.letter.BackColor = Color.White;
                formerSelectedTileSet.tile.BorderStyle = BorderStyle.None;
                formerSelectedTileSet.tile.Tag = formerSelectedTileSet.letter.Text;
            }
            // Find this TileSet
            tileSet = tileSets.Find(s => s.tile == p);

            // Make this the ne FormerSelectedTileSet
            if (tileSet != null)
            {
                tileSet.letter.BackColor = Color.Yellow;
                formerSelectedTileSet = tileSet;
                selectedTileSet = tileSet;
            }
        }

        public void PaletteBox_LostFocus(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            p.BorderStyle = BorderStyle.FixedSingle;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {


            foreach (PaletteObject p in tileSets)
            {

            }
        }

        //private void btnWriteFile_Click(object sender, EventArgs e)
        //{
        //    PictureBox p;
        //    PaletteObject po;

        //    foreach (Control c in this.Controls)
        //    {
        //        if (c is PictureBox)
        //        {
        //            p = (PictureBox)c;
        //            if (p.Tag != null)
        //            {
        //                if (p.Tag.ToString().Length > 0) {
        //                    p.BorderStyle = BorderStyle.None;
        //                }
        //            }
        //            else if (p.Tag == null)
        //            {
        //                po = tileSets.Find(c => c.tile.Image == p.Image && p.Tag != null);
        //                if (po != null)
        //                {
        //                    if (po.tile.Tag.ToString().Length > 0)
        //                    {
        //                        p.BorderStyle = BorderStyle.None;
        //                        p.Tag = po.tile.Tag;
        //                    }
                            
        //                }

        //                if (p.Tag == null)
        //                    p.BorderStyle = BorderStyle.Fixed3D;
        //            }
        //            else if (p.Tag.ToString().Length > 0)
        //            {
        //                po = tileSets.Find(c => c.tile.Name == p.Name && p.Tag.ToString().Length > 0);
        //                if (po != null)
        //                {
        //                    p.BorderStyle = BorderStyle.None;
        //                    p.Tag = po.tile.Tag;
        //                }

        //                if (p.Tag == null)
        //                    p.BorderStyle = BorderStyle.Fixed3D;
        //            }
        //        }
        //    }
        //}

        private void LetterBox_TextChanged(object sender, EventArgs e)
        {
            TextBox activeTextBox = (TextBox)sender;

            if (selectedTileSet.tile != null)
            {
                try
                {
                    selectedTileSet.tile.Tag = activeTextBox.Text;
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void btnSaveTileSet_Click(object sender, EventArgs e)
        {
            List<PaletteDetails> palettes = new List<PaletteDetails>();

           // foreach (PictureBox p in Panel_Palete.Controls.OfType<PictureBox>())
           
            foreach (PictureBox p in tileSets.Select(ts => ts.tile).ToList())
                {
                palettes.Add(new PaletteDetails
                {
                    fileName = p.Name,
                    filePath = p.ImageLocation,
                    character = p.Tag == null ? "" : p.Tag.ToString()
                });
            }


         //   File.WriteAllText(@"c:\temp\tileset.json", JsonConvert.SerializeObject(palettes));
            using (StreamWriter file = File.CreateText(@"c:\temp\tileset.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, palettes);
            }
        }

        private void btnLoadTiles_Click(object sender, EventArgs e)
        {
            int row = 0;
            int col = 0;
            PictureBox p;
            TextBox t;
            tileSets = new List<PaletteObject>();
            string tileFolder = "";

            if (lblFavouriteTilesFolder.Text.Length > 0)
            {
                tileFolder = lblFavouriteTilesFolder.Text;
            }
            else
            {
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
                {
                    tileFolder = folderBrowserDialog1.SelectedPath;
                }
            }
          //  DialogResult result = folderBrowserDialog1.ShowDialog();
         //   if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
            {
             //   DirectoryInfo DirInfo = new DirectoryInfo(@folderBrowserDialog1.SelectedPath);
                DirectoryInfo DirInfo = new DirectoryInfo(tileFolder);

                var tileImageFiles = from f in DirInfo.EnumerateFiles()
                                     where f.Name.EndsWith(".png") || f.Name.EndsWith(".jpg")
                                     select f;

                foreach (var f in tileImageFiles)
                {
                    p = new PictureBox();
                    t = new TextBox();

                    p.BackColor = Color.Ivory;
                    p.SizeMode = PictureBoxSizeMode.StretchImage;
                   // p.Width = 51;
                   // p.Height = 51;

                    t.MaxLength = 1;
                    t.Height = 23;

                    p.Left = col * 51;
                    p.Top = row * 51 + row * t.Height;
                    col++;
                    if (col == 9)
                    {
                        col = 0; row++;
                    }

                    p.Name = Path.GetFileName(f.Name);
                    p.BorderStyle = BorderStyle.None;
                    p.Image = Image.FromFile(f.FullName);
                    p.Width = p.Image.Width;
                    p.Height = p.Image.Height;

                    tileHeight = p.Height;
                    tileWidth = p.Width;
                    txtMapName.Text = tileWidth.ToString();
                    
                    p.Click += new EventHandler(PaletteBox_Click);
                    Panel_Palete.Controls.Add(p);

                    t.Left = p.Left;
                    t.Top = p.Top + p.Height;
                    t.Tag = p.Name;
                    t.Width = p.Width;
                    t.Height = p.Width;
                    t.Leave += new EventHandler(LetterBox_LostFocus);
                    t.Enter += new EventHandler(LetterBox_Enter);
                    t.TextChanged += new EventHandler(LetterBox_TextChanged);

                    Panel_Palete.Controls.Add(t);

                    tileSets.Add(new PaletteObject(p, t));
                }



                txtMapCharacter.Visible = false;
                txtMapCharacter.Left = 0;
                txtMapCharacter.Top = 0;
                Canvas_Panel.Controls.Add(txtMapCharacter);

                txtMapName.Focus(); 

            }
        }

        private void btnLoadTileSet_Click(object sender, EventArgs e)
        {
            // reads path for tile configuration

            //  tileSets = new List<PaletteObject>();
            string tileSetPath = "";

            if (lblFavouriteTileSet.Text.Length > 0)
            {
                tileSetPath = lblFavouriteTileSet.Text;
            }
            else
            {
                if (openTileFolderDialog.ShowDialog() == DialogResult.OK)
                {
                    tileSetPath = @openTileFolderDialog.FileName;
                }
            }
            // if (openTileFolderDialog.ShowDialog() == DialogResult.OK)
            {               
              //  var tileSetJson = JsonConvert.DeserializeObject<Root>(File.ReadAllText(@openTileFolderDialog.FileName));
                var tileSetJson = JsonConvert.DeserializeObject<Root>(File.ReadAllText(tileSetPath));

                // iterate through the tile list for those files and build tile selection pane
                // also assign characters to these tiles
                //     tileSets.Find(ts => ts.tile == tileSetJson)
                foreach (var ts in tileSetJson.tileSettings.tilesets)
                {
                    if (!String.IsNullOrEmpty(ts.character))
                    {
                        var target = tileSets.Find(t => t.tile.Name == ts.fileName);
                        if (target != null)
                        {
                            target.letter.Text = ts.character;
                            target.tile.Tag = ts.character;
                        }

                    }
                    // search for tile and update letter
                }
            }

            Canvas_Panel.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (PaletteObject po in tileSets)
            {
                Panel_Palete.Controls.Remove(po.tile);
                Panel_Palete.Controls.Remove(po.letter);
            }
            tileSets.Clear();
        }

        private void btnLoadMap_Click(object sender, EventArgs e)
        {
            int rows = 0;
            int columns = 0;
            string line;
            PictureBox p;

            if (openMapFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileName = openMapFileDialog.FileName;
                var lineCount = File.ReadLines(@fileName).Count();
                progressBar1.Visible = true;
                progressBar1.Maximum = lineCount;

                using (StreamReader file = new System.IO.StreamReader(@fileName))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        rows++;
                        columns = 0;
                        progressBar1.Value = rows;
                        // read each character in the line
                        foreach (char s in line)
                        {
                            var selectedTileSet = tileSets.Find(t => t.letter.Text == s.ToString());
                            columns++;
                            // create canvas PalleteObject and place
                            // check character and fill in PO with tile and character

                            p = new PictureBox();
                            if (selectedTileSet != null)
                                p.Image = selectedTileSet.tile.Image; 
                            p.BackColor = Color.Ivory;
                            p.SizeMode = PictureBoxSizeMode.StretchImage;
                            p.Width = tileWidth;
                            p.Height = tileHeight;
                            p.Left = tileWidth * columns - tileWidth;
                            p.Top = tileHeight * rows - tileHeight;
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
                            Canvas_Panel.Controls.Add(p);

                        }
                    }
                    file.Close();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rows = 0;
            int columns = 0;
            string line;
            PictureBox p;

            if (openMapFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileName = openMapFileDialog.FileName;
                var lineCount = File.ReadLines(@fileName).Count();
                progressBar1.Visible = true;
                progressBar1.Maximum = lineCount;

                using (StreamReader file = new System.IO.StreamReader(@fileName))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        rows++;
                        columns = 0;
                        progressBar1.Value = rows;
                        // read each character in the line
                        foreach (char s in line)
                        {
                            var selectedTileSet = tileSets.Find(t => t.letter.Text == s.ToString());
                            columns++;
                            // create canvas PalleteObject and place
                            // check character and fill in PO with tile and character

                            p = new PictureBox();
                            if (selectedTileSet != null)
                                p.Image = selectedTileSet.tile.Image;
                            p.BackColor = Color.Ivory;
                            p.SizeMode = PictureBoxSizeMode.StretchImage;
                            p.Width = tileWidth;
                            p.Height = tileHeight;
                            p.Left = tileWidth * columns - tileWidth;
                            p.Top = tileHeight * rows - tileHeight;
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
                            Canvas_Panel.Controls.Add(p);

                        }
                    }
                    file.Close();
                }
            }
            Canvas_Panel.Refresh();
        }

        private void Canvas_Panel_Paint(object sender, PaintEventArgs e)
        {
            int x = 0;
            int y = 0;
            int rows = 0;
            int columns = 0;
            string line;
            Point loc;
            Rectangle rect;
            Bitmap sourceBmp = null;

           // if (openMapFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileName = @"c:\temp\lancer.txt";
                var lineCount = File.ReadLines(@fileName).Count();
                progressBar1.Visible = true;
                progressBar1.Maximum = lineCount;

                using (StreamReader file = new System.IO.StreamReader(@fileName))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        rows++;
                        columns = 0;
                        progressBar1.Value = rows;
                        // read each character in the line
                        foreach (char s in line)
                        {
                            progressBar1.Value = rows;
                            var selectedTileSet = tileSets.Find(t => t.letter.Text == s.ToString());
                            columns++;
                            if (selectedTileSet != null)
                                sourceBmp = new Bitmap(selectedTileSet.tile.Image);

                            x = columns * tileWidth;
                            y = rows * tileHeight;

                            loc = new Point(x, y);
                            rect = new Rectangle(loc, new Size(tileWidth, tileHeight));
                            e.Graphics.DrawImage(sourceBmp, rect, 0, 0, tileWidth, tileHeight, GraphicsUnit.Pixel);

                        }
                    }
                    file.Close();
                }
            }
        }

        private void Canvas_Panel_Paint3(object sender, PaintEventArgs e)
        {
            int x = 0;
            int y = 0;

            Point loc;
           // Graphics G;
            Rectangle rect;

            Bitmap sourceBmp = null;
            sourceBmp = new Bitmap(Image.FromFile(@"c:\temp\tiles\grass.jpg"));
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    x = i * 51;
                    y = j * 51;

                    loc = new Point(x, y);
                    rect = new Rectangle(loc, new Size(51, 51));
                    e.Graphics.DrawImage(sourceBmp, rect, 0, 0, 51, 51, GraphicsUnit.Pixel);
                }
            }
        }
    }
}
