using Newtonsoft.Json;
using RPGTileMapCreator.cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGTileMapCreator
{
    public partial class btnNewMap : Form
    {
        PictureBox SelectedPaletteBox = new PictureBox();
        PictureBox formerSelected = new PictureBox();
        PaletteObject formerSelectedTileSet = new PaletteObject();
        PaletteObject selectedTileSet = new PaletteObject();
        PaletteObject defaultTileSet;
        TextBox txtMapCharacter = new TextBox();
        List<PaletteObject> tileSets;
        List<CanvasTile> canvasTiles = new List<CanvasTile>();

        protected bool clearCanvasFlag = false;
        protected int tileWidth = 0;
        protected int tileHeight = 0;
        protected int rows = 0;
        protected int columns = 0;

        public btnNewMap()
        {
            TextBox t = new TextBox();

            InitializeComponent();
            Canvas_Panel.Width = 1000; Canvas_Panel.Height = 1000;
            lblFavouriteTilesFolder.Text = @"c:\temp\tiles";
            lblFavouriteTileSet.Text = @"c:\temp\lancer.json";

            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, Canvas_Panel, new object[] { true });

            Canvas_Panel.MouseDown += (s, args) =>
            {
                if (args.Button == MouseButtons.Right)
                {
                    CanvasPanel_Click(s, args, false, true);
                }
                else if (args.Button == MouseButtons.Left)
                {
                    CanvasPanel_Click(s, args, true, false);
                }
            };
        }

        public void CanvasPanel_Click(object sender, EventArgs e, bool leftClick, bool rightClick)
        {
            CanvasTile tileInPlay = null;
            MouseEventArgs me = (MouseEventArgs)e;

            if (leftClick)
            {
                //Return the CanvasTile where I clicked
                tileInPlay = ReturnTileClickedOn(me.Location.X, me.Location.Y);
          //      MessageBox.Show(String.Format("{0} {1}", tileInPlay.Row, tileInPlay.Col ));
               // if (tileInPlay == null)
                 //   MessageBox.Show(string.Format("Cannot find tile at LT X: {0} , Y: {1}", me.Location.X, me.Location.Y));
                if (tileInPlay != null)
                {
                    //MessageBox.Show(string.Format("Tile {0} at LT X: {1} , Y: {2}", tileInPlay.Character, me.Location.X, me.Location.Y));

                    if (selectedTileSet != null)
                    {
                        if (!String.IsNullOrEmpty(selectedTileSet.letter.Text))
                        {
                            tileInPlay.TileImage = selectedTileSet.tile.Image;
                            tileInPlay.Character = selectedTileSet.letter.Text;
                        }

                        Canvas_Panel.Refresh();
                    }
                }

            }

            if (rightClick)
            {
                MessageBox.Show(string.Format("RT X: {0} , Y: {1}", me.Location.X, me.Location.Y));
            }
        }

        public CanvasTile ReturnTileClickedOn(int x, int y)
        {
            CanvasTile foundTile = null;

            return foundTile = canvasTiles.Find(t => t.TopLeftPoint.X <= x 
                && t.BottomRightPoint.X > x 
                && t.TopLeftPoint.Y <= y 
                && t.BottomRightPoint.Y > y);
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

            if (tileSets.Count > 0)
            {
                defaultTileSet = tileSets.First(ts => ts.letter.Text.Length > 0);
               // defaultTileSet = tileSets[0];
            }
            //   Canvas_Panel.Visible = true;
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
            int x = 0;
            int y = 0;
            string line;
            Bitmap sourceBmp = null;
            CanvasTile canvasTile = null;

            if (openMapFileDialog.ShowDialog() == DialogResult.OK)
            {
                //var fileName = openMapFileDialog.FileName;
                var fileName = @"c:\temp\lancer.txt";
                var lineCount = File.ReadLines(@fileName).Count();
                txtMapName.Text = openMapFileDialog.FileName;

                progressBar1.Visible = true;
                progressBar1.Maximum = lineCount;
                //  canvasTiles = new List<CanvasTile>();

                using (StreamReader file = new System.IO.StreamReader(@fileName))
                {
                    canvasTiles.Clear();
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

                            x = columns * tileWidth - tileWidth;
                            y = rows * tileHeight - tileHeight;

                            canvasTile = new CanvasTile
                            {
                                Row = rows,
                                Col = columns,
                                TopLeftPoint = new Point(x, y),
                                BottomRightPoint = new Point(x + 51, y + 51),
                                Width = tileWidth,
                                Height = tileHeight,
                                TileImage = sourceBmp,
                                Character = s != ' ' ? s.ToString() : defaultTileSet.letter.Text.Substring(0,1)
                        };

                            canvasTiles.Add(canvasTile);
                        }
                    }
                    file.Close();
                }
                if (Canvas_Panel.Visible != true)
                {
                    Canvas_Panel.Visible = true;
                }

                Canvas_Panel.Width = columns * tileWidth;
                Canvas_Panel.Height = rows * tileHeight;

                progressBar1.Visible = false;
                Canvas_Panel.Refresh();
            }
        }


        private void Canvas_Panel_Paint(object sender, PaintEventArgs e)
        {
            Point loc;
            Rectangle rect;

            if (!clearCanvasFlag)
            {
                foreach (CanvasTile c in canvasTiles)
                {
                    loc = c.TopLeftPoint;
                    rect = new Rectangle(loc, new Size(c.Width, c.Height));
                    e.Graphics.DrawImage(c.TileImage, rect, 0, 0, c.Width, c.Height, GraphicsUnit.Pixel);
                }
                panel1.AutoScroll = true;
            }
            else
            {
                e.Graphics.Clear(Color.Gainsboro);
                Canvas_Panel.Size = new Size(669, 504);
                clearCanvasFlag = false;
            }
        }

        private void Canvas_Panel_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void btnSaveMap_Click(object sender, EventArgs e)
        {
            // List<CanvasTile> rowOfTiles = new List<CanvasTile>();
            string rowString = "";
            var fileName = @"c:\temp\lancer" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".txt";

            using (StreamWriter file = new System.IO.StreamWriter(@fileName))
            {
                if (!String.IsNullOrEmpty(txtMapName.Text))
                {
                    for (int row = 1; row <= rows; row++)
                    {
                        var rowOfTiles = from tile in canvasTiles
                                         where tile.Row == row
                                         orderby tile.Col ascending
                                         select tile;

                        rowString = "";
                        foreach (CanvasTile ct in rowOfTiles)
                        {   // need default
                            rowString += ct.Character != null ? ct.Character : ".";
                        }

                        file.WriteLine(rowString + Environment.NewLine);
                       // MessageBox.Show(rowString);
                    }
                    // Open Save Dialog - only txt files

                    // Get Folder and Filename choosen




                    // iterate through collection, row by row, building file



                    // nulls = space
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAddColumnRight_Click(object sender, EventArgs e)
        {
            CanvasTile ct = new CanvasTile();
            int x, y;

            if (rbAdd.Checked)
            {
                columns++;

                // Need to increase width of canvas
                Canvas_Panel.Width += tileWidth;

                // Add (# of rows) cells to screen on right top to bottom
                for (int r = 1; r <= rows; r++)
                {
                    x = columns * tileWidth - tileWidth;
                    y = r * tileHeight - tileHeight;

                    ct = new CanvasTile
                    {
                        Character = defaultTileSet.letter.Text,
                        TileImage = defaultTileSet.tile.Image,
                        Row = r,
                        Col = columns,
                        Width = tileWidth,
                        Height = tileHeight,
                        TopLeftPoint = new Point(x, y),
                        BottomRightPoint = new Point(x + 51, y + 51),
                    };

                    canvasTiles.Add(ct);
                }
            }

            else if (rbDelete.Checked)
            {
                List<CanvasTile> tilesToRemove = new List<CanvasTile>();
                // Need to increase width of canvas
                Canvas_Panel.Width -= tileWidth;

                foreach (CanvasTile nudgeTile in canvasTiles)
                {
                    if (nudgeTile.Col == columns)
                    {
                        tilesToRemove.Add(nudgeTile);
                    }
                }

                columns--;

                // remove those tiles in canvasTiles that are in tilesToRemove
                canvasTiles.RemoveAll(x => tilesToRemove.Contains(x));   
            }
            Canvas_Panel.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Save As dialog box

            // Saves a 1 x 1 with default Tile

            // Opens up on canvas

        }

        private void btnWipeCanvas_Click(object sender, EventArgs e)
        {
            WipeCanvas();
        }

        private void WipeCanvas()
        {
            clearCanvasFlag = true;
            canvasTiles.Clear();
            rows = 0;
            columns = 0;
            Canvas_Panel.Visible = false;
            selectedTileSet = null;
            Canvas_Panel.Refresh();
        }

        private void btnAddColumnLeft_Click(object sender, EventArgs e)
        {
            CanvasTile ct = new CanvasTile();
            int x, y;

            if (rbAdd.Checked)
            {
                columns++;

                // Need to increase width of canvas
                Canvas_Panel.Width += tileWidth;

                // Need to increase the column and location of all Tiles first
                foreach (CanvasTile nudgeTile in canvasTiles)
                {
                    nudgeTile.Col++;
                    nudgeTile.TopLeftPoint = new Point(nudgeTile.TopLeftPoint.X + tileWidth, nudgeTile.TopLeftPoint.Y);
                    nudgeTile.BottomRightPoint = new Point(nudgeTile.BottomRightPoint.X + tileWidth, nudgeTile.BottomRightPoint.Y);
                }

                // Add new column with column = 0;
                for (int r = 1; r <= rows; r++)
                {
                    x = 0;
                    y = r * tileHeight - tileHeight;

                    ct = new CanvasTile
                    {
                        Character = defaultTileSet.letter.Text,
                        TileImage = defaultTileSet.tile.Image,
                        Row = r,
                        Col = 1,
                        Width = tileWidth,
                        Height = tileHeight,
                        TopLeftPoint = new Point(x, y),
                        BottomRightPoint = new Point(x + 51, y + 51),
                    };

                    canvasTiles.Add(ct);
                }
            }

            else if (rbDelete.Checked)
            {
                columns--;

                List<CanvasTile> tilesToRemove = new List<CanvasTile>();
                // Need to increase width of canvas
                Canvas_Panel.Width -= tileWidth;

                foreach (CanvasTile nudgeTile in canvasTiles)
                {
                    if (nudgeTile.Col == 1)
                    {
                        tilesToRemove.Add(nudgeTile);
                    }
                }

                // remove those tiles in canvasTiles that are in tilesToRemove
                canvasTiles.RemoveAll(x => tilesToRemove.Contains(x));

                // Need to increase the column and location of all Tiles first
                foreach (CanvasTile nudgeTile in canvasTiles)
                {                  
                    nudgeTile.Col--;
                    nudgeTile.TopLeftPoint = new Point(nudgeTile.TopLeftPoint.X - tileWidth, nudgeTile.TopLeftPoint.Y);
                    nudgeTile.BottomRightPoint = new Point(nudgeTile.BottomRightPoint.X - tileWidth, nudgeTile.BottomRightPoint.Y);
                }

            }
            Canvas_Panel.Refresh();

        }

        private void btnAddRowBottom_Click(object sender, EventArgs e)
        {
            CanvasTile ct = new CanvasTile();
            int x, y;

            if (rbAdd.Checked)
            {
                rows++;

                // Need to increase width of canvas
                Canvas_Panel.Height += tileHeight;

                // Add (# of rows) cells to screen on right top to bottom
                for (int c = 1; c <= columns; c++)
                {
                    x = c * tileWidth - tileWidth;
                    y = rows * tileHeight - tileHeight;

                    ct = new CanvasTile
                    {
                        Character = defaultTileSet.letter.Text,
                        TileImage = defaultTileSet.tile.Image,
                        Row = rows,
                        Col = c,
                        Width = tileWidth,
                        Height = tileHeight,
                        TopLeftPoint = new Point(x, y),
                        BottomRightPoint = new Point(x + 51, y + 51),
                    };

                    canvasTiles.Add(ct);
                }
            }

            else if (rbDelete.Checked)
            {
                List<CanvasTile> tilesToRemove = new List<CanvasTile>();
                // Need to increase width of canvas
                Canvas_Panel.Height -= tileHeight;

                foreach (CanvasTile nudgeTile in canvasTiles)
                {
                    if (nudgeTile.Row == rows)
                    {
                        tilesToRemove.Add(nudgeTile);
                    }
                }

                rows--;

                // remove those tiles in canvasTiles that are in tilesToRemove
                canvasTiles.RemoveAll(x => tilesToRemove.Contains(x));
            }
            Canvas_Panel.Refresh();

        }

        private void btnAddRowTop_Click(object sender, EventArgs e)
        {
            CanvasTile ct = new CanvasTile();
            int x, y;

            if (rbAdd.Checked)
            {
                rows++;

                // Need to increase width of canvas
                Canvas_Panel.Height += tileHeight;

                // Need to increase the column and location of all Tiles first
                foreach (CanvasTile nudgeTile in canvasTiles)
                {
                    nudgeTile.Row++;
                    nudgeTile.TopLeftPoint = new Point(nudgeTile.TopLeftPoint.X, nudgeTile.TopLeftPoint.Y + tileHeight);
                    nudgeTile.BottomRightPoint = new Point(nudgeTile.BottomRightPoint.X, nudgeTile.BottomRightPoint.Y + tileHeight);
                }

                // Add (# of rows) cells to screen on right top to bottom
                for (int c = 1; c <= columns; c++)
                {
                    x = c * tileWidth - tileWidth;
                    y = 0;

                    ct = new CanvasTile
                    {
                        Character = defaultTileSet.letter.Text,
                        TileImage = defaultTileSet.tile.Image,
                        Row = 1,
                        Col = c,
                        Width = tileWidth,
                        Height = tileHeight,
                        TopLeftPoint = new Point(x, y),
                        BottomRightPoint = new Point(x + 51, y + 51),
                    };

                    canvasTiles.Add(ct);
                }
            }
            else if (rbDelete.Checked)
            {
                rows--;

                List<CanvasTile> tilesToRemove = new List<CanvasTile>();
                // Need to increase width of canvas
                Canvas_Panel.Height -= tileHeight;

                foreach (CanvasTile nudgeTile in canvasTiles)
                {
                    if (nudgeTile.Row == 1)
                    {
                        tilesToRemove.Add(nudgeTile);
                    }
                }

                // remove those tiles in canvasTiles that are in tilesToRemove
                canvasTiles.RemoveAll(x => tilesToRemove.Contains(x));

                // Need to increase the column and location of all Tiles first
                foreach (CanvasTile nudgeTile in canvasTiles)
                {
                    nudgeTile.Row--;
                    nudgeTile.TopLeftPoint = new Point(nudgeTile.TopLeftPoint.X, nudgeTile.TopLeftPoint.Y - tileHeight);
                    nudgeTile.BottomRightPoint = new Point(nudgeTile.BottomRightPoint.X, nudgeTile.BottomRightPoint.Y - tileHeight);
                }
            }

            Canvas_Panel.Refresh();


        }
    }
}
