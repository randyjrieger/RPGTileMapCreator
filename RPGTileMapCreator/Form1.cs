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
    public enum ReadyState
    {
        None,
        FormLoaded,
        TilesLoaded,
        TilesetLoaded,
        MapLoaded,
        NewMap
    };

    // TODO browse for files
    // TODO '?' as CONST
    // TODO use tilewidth/height - not 51
    public partial class Form_Map : Form
    {
        PictureBox SelectedPaletteBox = new PictureBox();
        PictureBox formerSelected = new PictureBox();
        PaletteObject formerSelectedTileSet = new PaletteObject();
        PaletteObject selectedTileSet = new PaletteObject();
        PaletteObject defaultTileSet;
        TextBox txtMapCharacter = new TextBox();
        List<PaletteObject> tileSets;
        List<CanvasTile> canvasTiles = new List<CanvasTile>();
        ReadyState readyState = ReadyState.None;

        protected bool clearCanvasFlag = false;
        protected int tileWidth = 0;
        protected int tileHeight = 0;
        protected int rows = 0;
        protected int columns = 0;



        public Form_Map()
        {
            InitializeComponent();
            Canvas_Panel.Width = 1000; Canvas_Panel.Height = 1000;

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

            // set Default Tileset
            defaultTileSet = new PaletteObject();
            defaultTileSet.letter = txtDefaultChar;
            defaultTileSet.tile = new PictureBox();
            defaultTileSet.tile.Image = Resource1._default;

            lblFavouriteTileSet.Text = "";
            lblFavouriteTilesFolder.Text = "";

            if( int.TryParse(txtW.Text, out int w))
            {
                tileWidth = w;
            }
            else
            {
                tileWidth = 51;
                txtW.Text = "51";
            }

            if (int.TryParse(txtH.Text, out int h))
            {
                tileHeight = h;
            }
            else
            {
                tileHeight = 51;
                txtH.Text = "51";
            }
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
                    foreach (PictureBox p in Canvas_Panel.Controls.OfType<PictureBox>())
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

            if (selectedTileSet != null)
            {
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
        }

        private void btnSaveTileSet_Click(object sender, EventArgs e)
        {
            List<PaletteDetails> palettes = new List<PaletteDetails>();

            // foreach (PictureBox p in Panel_Palete.Controls.OfType<PictureBox>())
            var root = new Root();
            root.tileSettings = new TileSettings();
            root.tileSettings.tilesets = new List<Tileset>();
            root.tileSettings.tileFilePath = "c:\\temp\\tileset";

            foreach (PictureBox p in tileSets.Select(ts => ts.tile).ToList())
            {
                root.tileSettings.tilesets.Add(new Tileset
                {
                    fileName = p.Name,
                    character = p.Tag == null ? "" : p.Tag.ToString()
                });
            }
            //TODO hardcoded path
            //TODO save in proper format - see btnLoadTileSet
            using (StreamWriter file = File.CreateText(@"c:\temp\tileset" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, root);
            }
        }

        private void btnResetTileSet_Click(object sender, EventArgs e)
        {
            foreach (PaletteObject ts in tileSets)
            {
                ts.letter.Text = "";
            }

            readyState = ReadyState.TilesLoaded;
            UpdateFormState();

            WipeCanvas();

        }
        private void btnLoadTiles_Click(object sender, EventArgs e)
        {
            int row = 0;
            int col = 0;
            PictureBox p;
            TextBox t;
            tileSets = new List<PaletteObject>();
            string tileFolder = "";

            DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
                {
                    tileFolder = folderBrowserDialog1.SelectedPath;
                }
         //   }
            //  DialogResult result = folderBrowserDialog1.ShowDialog();
            //   if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
            {
                //   DirectoryInfo DirInfo = new DirectoryInfo(@folderBrowserDialog1.SelectedPath);

                lblFavouriteTilesFolder.Text = tileFolder;
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
                    p.Width = tileWidth;
                    p.Height = tileHeight;

                    t.MaxLength = 1;
                    t.Height = 23;

                    p.Left = col * tileWidth;
                    p.Top = row * tileHeight + row * t.Height;
                    col++;
                    if (col == 9)
                    {
                        col = 0; row++;
                    }

                    p.Name = Path.GetFileName(f.Name);
                    p.BorderStyle = BorderStyle.None;
                    p.Image = Image.FromFile(f.FullName);
                  //  p.Width = p.Image.Width;
                  //  p.Height = p.Image.Height;

                   // tileHeight = p.Height;
                  //  tileWidth = p.Width;
                   // txtMapName.Text = tileWidth.ToString();

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

                readyState = ReadyState.TilesLoaded;
                UpdateFormState();
                Canvas_Panel.Controls.Add(txtMapCharacter);

                txtMapName.Focus();

            }
        }

        private void btnLoadTileSet_Click(object sender, EventArgs e)
        {
            // reads path for tile configuration

            //  tileSets = new List<PaletteObject>();
            string tileSetPath = "";

            //if (lblFavouriteTileSet.Text.Length > 0)
            //{
            //    tileSetPath = lblFavouriteTileSet.Text;
            //}
            //else
            //{
            if (openTileFolderDialog.ShowDialog() == DialogResult.OK)
                {
                    tileSetPath = @openTileFolderDialog.FileName;
                }
            //  }
            lblFavouriteTileSet.Text = tileSetPath;
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

            readyState = ReadyState.TilesetLoaded;
            UpdateFormState();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (PaletteObject po in tileSets)
            {
                Panel_Palete.Controls.Remove(po.tile);
                Panel_Palete.Controls.Remove(po.letter);
            }

            readyState = ReadyState.FormLoaded;
            UpdateFormState();
            WipeCanvas();

            tileSets.Clear();
            readyState = ReadyState.FormLoaded;
            UpdateFormState();
        }

        private void LoadMap(string fileName)
        {
            int x = 0;
            int y = 0;
            string line;
            Bitmap sourceBmp = null;
            CanvasTile canvasTile = null;

            var lineCount = File.ReadLines(@fileName).Count();
            txtMapName.Text = openMapFileDialog.FileName;

            progressBar1.Visible = true;
            progressBar1.Maximum = lineCount;

            if (tileSets == null)
            {
                tileSets = new List<PaletteObject>();
            }

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
                        else
                            sourceBmp = new Bitmap(defaultTileSet.tile.Image);

                        x = columns * tileWidth - tileWidth;
                        y = rows * tileHeight - tileHeight;

                        if (tileSets.Exists(t => t.letter.Text == s.ToString()))
                        {

                            canvasTile = new CanvasTile
                            {
                                Row = rows,
                                Col = columns,
                                TopLeftPoint = new Point(x, y),
                                BottomRightPoint = new Point(x + tileWidth, y + tileHeight),
                                Width = tileWidth,
                                Height = tileHeight,
                                TileImage = (s == ' ' || s.ToString() == defaultTileSet.letter.Text.Substring(0, 1)) ? new Bitmap(defaultTileSet.tile.Image) : sourceBmp,
                                Character = (s == ' ' || s.ToString() == defaultTileSet.letter.Text.Substring(0, 1)) ? defaultTileSet.letter.Text.Substring(0, 1) : s.ToString()
                            };

                            canvasTiles.Add(canvasTile);
                        }
                        else
                        {
                            canvasTile = new CanvasTile
                            {
                                Row = rows,
                                Col = columns,
                                TopLeftPoint = new Point(x, y),
                                BottomRightPoint = new Point(x + tileWidth, y + tileHeight),
                                Width = tileWidth,
                                Height = tileHeight,
                                TileImage = new Bitmap(defaultTileSet.tile.Image),
                                Character = (s == ' ' || s.ToString() == defaultTileSet.letter.Text.Substring(0, 1)) ? defaultTileSet.letter.Text.Substring(0, 1) : s.ToString()
                            };

                            canvasTiles.Add(canvasTile);
                        }
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

        private void btnLoadMap_Click(object sender, EventArgs e)
        {

            if (openMapFileDialog.ShowDialog() == DialogResult.OK)
            {

                var fileName = openMapFileDialog.FileName;

                LoadMap(fileName);

                readyState = ReadyState.MapLoaded;
                UpdateFormState();
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
                    if (c.Character == "x")
                    {
                        loc = c.TopLeftPoint;
                    }
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
            string fileName = txtMapName.Text;

            if (!chkCopyMapFile.Checked)
            {
                var result = MessageBox.Show("Do you want to save over your map file?", "Save Over Map File", MessageBoxButtons.YesNo);

                if (result != DialogResult.Yes)
                {
                    return;
                }
            }
            else
            {
                string path = Path.GetFullPath(fileName);
                fileName = path.Substring(0, fileName.Length - 4) + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".txt";
            }

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
                            rowString += ct.Character != null ? ct.Character : txtDefaultChar.Text;
                        }

                        file.WriteLine(rowString + Environment.NewLine);
                    }
                }

                file.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

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

            readyState = ReadyState.FormLoaded;
            UpdateFormState();
            Canvas_Panel.Refresh();
        }

        private void btnNewMap_Click(object sender, EventArgs e)
        {
            CanvasTile canvasTile = null;

            // Save As dialog box   
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileName = saveFileDialog1.FileName;
                txtMapName.Text = saveFileDialog1.FileName;

                using (StreamWriter file = new System.IO.StreamWriter(@fileName))
                {
                    canvasTiles.Clear();
                    // Saves a 1 x 1 with default Tile
                    file.Write(defaultTileSet.letter.Text.Substring(0, 1));
                    file.Close();
                }

                //Add single tile to CanvasTiles

                //Paint it
                canvasTiles.Clear();
                rows = 0;
                columns = 0;
                
                if (int.TryParse(txtW.Text, out int w))
                {
                    tileWidth = w;
                }
                else
                {
                    tileWidth = 51;
                    txtW.Text = "51";
                }

                if (int.TryParse(txtH.Text, out int h))
                {
                    tileHeight = h;
                }
                else
                {
                    tileHeight = 51;
                    txtH.Text = "51";
                }

                LoadMap(fileName);


                //    rows++;
                //    columns++;

                //    canvasTile = new CanvasTile
                //    {
                //        Row = rows,
                //        Col = columns,
                //        TopLeftPoint = new Point(x, y),
                //        BottomRightPoint = new Point(x + 51, y + 51),
                //        Width = tileWidth,
                //        Height = tileHeight,
                //        TileImage = defaultTileSet.tile.Image,
                //        Character = defaultTileSet.letter.Text.Substring(0, 1)
                //    };

                //    canvasTiles.Add(canvasTile);

                //    if (Canvas_Panel.Visible != true)
                //    {
                //        Canvas_Panel.Visible = true;
                //    }

                //    Canvas_Panel.Width = columns * tileWidth;
                //    Canvas_Panel.Height = rows * tileHeight;
                //}

                //Canvas_Panel.Refresh();
                readyState = ReadyState.NewMap;
                UpdateFormState();
            }
        }


        private void btnAddColumnRight_Click(object sender, EventArgs e)
        {
            CanvasTile ct = new CanvasTile();
            int x, y;

            if (rbAdd.Checked)
            {
                if (columns + 1 <= 100)
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
                            TileImage = new Bitmap(defaultTileSet.tile.Image),
                            Row = r,
                            Col = columns,
                            Width = tileWidth,
                            Height = tileHeight,
                            TopLeftPoint = new Point(x, y),
                            BottomRightPoint = new Point(x + tileWidth, y + tileHeight),
                        };

                        canvasTiles.Add(ct);
                    }
                }
            }

            else if (rbDelete.Checked)
            {
                if (columns - 1 >= 0)
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
            }
            Canvas_Panel.Refresh();
        }

        private void btnAddColumnLeft_Click(object sender, EventArgs e)
        {
            CanvasTile ct = new CanvasTile();
            int x, y;

            if (rbAdd.Checked)
            {
                if (columns + 1 <= 300)
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
                            TileImage = new Bitmap(defaultTileSet.tile.Image),
                            Row = r,
                            Col = 1,
                            Width = tileWidth,
                            Height = tileHeight,
                            TopLeftPoint = new Point(x, y),
                            BottomRightPoint = new Point(x + tileWidth, y + tileHeight),
                        };

                        canvasTiles.Add(ct);
                    }
                }

            }
            else if (rbDelete.Checked)
            {
                if (columns - 1 >= 0)
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

            }
            Canvas_Panel.Refresh();

        }

        private void btnAddRowBottom_Click(object sender, EventArgs e)
        {
            CanvasTile ct = new CanvasTile();
            int x, y;

            if (rbAdd.Checked)
            {
                if (rows + 1 <= 300)
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
                            TileImage = new Bitmap(defaultTileSet.tile.Image),
                            Row = rows,
                            Col = c,
                            Width = tileWidth,
                            Height = tileHeight,
                            TopLeftPoint = new Point(x, y),
                            BottomRightPoint = new Point(x + tileWidth, y + tileHeight),
                        };

                        canvasTiles.Add(ct);
                    }
                }
            }

            else if (rbDelete.Checked)
            {
                if (rows - 1 >= 0)
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

        }

        private void btnAddRowTop_Click(object sender, EventArgs e)
        {
            CanvasTile ct = new CanvasTile();
            int x, y;

            if (rbAdd.Checked)
            {
                if (rows + 1 <= 100)
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
                            TileImage = new Bitmap(defaultTileSet.tile.Image),
                            Row = 1,
                            Col = c,
                            Width = tileWidth,
                            Height = tileHeight,
                            TopLeftPoint = new Point(x, y),
                            BottomRightPoint = new Point(x + tileWidth, y + tileHeight),
                        };

                        canvasTiles.Add(ct);
                    }
                }
            }
            else if (rbDelete.Checked)
            {
                if (rows - 1 >= 0)
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
            }
            Canvas_Panel.Refresh();
        }

        private void Form_Map_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Maximum = tileSets.Count;
            progressBar1.Value = 0;

            foreach (var ts in tileSets)
            {
                progressBar1.Value++;

                foreach (var ct in canvasTiles.FindAll(ct => ct.Character == ts.letter.Text))
                {
                    ct.TileImage = ts.tile.Image;
                }
            }

            if (Canvas_Panel.Visible != true)
            {
                Canvas_Panel.Visible = true;
            }

            progressBar1.Visible = false;

            readyState = ReadyState.FormLoaded;
            UpdateFormState();
            Canvas_Panel.Refresh();
        }

        public void UpdateFormState()
        {
            switch (readyState)
            {
                case ReadyState.FormLoaded:
                    btnNewMap.Visible = true;
                    btnLoadTiles.Visible = true;
                    lblFavouriteTilesFolder.Text = "";
                    lblFavouriteTilesFolder.Visible = false;
                    lblFavouriteTileSet.Text = "";
                    btnLoadTileSet.Visible = false;
                    btnSaveTileSet.Visible = false;
                    lblFavouriteTileSet.Visible = false;
                    button2.Visible = false; // clear tiles
                    btnLoadMap.Visible = false;
                    btnSaveMap.Visible = false;
                    button1.Visible = false;  // clear map
                    btnWipeCanvas.Visible = false;
                    btnResetTileSet.Visible = false; // reset tileset
                    btnAddColumnLeft.Visible = false;
                    btnAddColumnRight.Visible = false;
                    btnAddRowBottom.Visible = false;
                    btnAddRowTop.Visible = false;
                    rbAdd.Visible = false;
                    rbDelete.Visible = false;
                    chkCopyMapFile.Visible = false;
                    txtMapName.Visible = false;
                    break;

            /*    case ReadyState.TilesLoaded:
                    btnNewMap.Visible = true;
                    btnLoadTiles.Visible = true;
                    btnLoadTileSet.Visible = true;
                    btnSaveTileSet.Visible = false;
                    lblFavouriteTilesFolder.Visible = true;
                    lblFavouriteTileSet.Text = "";
                    button2.Visible = true; // clear tiles
                    btnLoadMap.Visible = false;
                    btnSaveMap.Visible = false;
                    button1.Visible = false;  // clear map
                    btnWipeCanvas.Visible = false;
                    btnResetTileSet.Visible = false; // reset tileset
                    btnAddColumnLeft.Visible = false;
                    btnAddColumnRight.Visible = false;
                    btnAddRowBottom.Visible = false;
                    btnAddRowTop.Visible = false;
                    rbAdd.Visible = false;
                    rbDelete.Visible = false;
                    chkCopyMapFile.Visible = false;
                    txtMapCharacter.Visible = false;
                    txtMapCharacter.Left = 0;
                    txtMapCharacter.Top = 0;
                    txtMapName.Visible = false;
                    break;*/

                case ReadyState.TilesetLoaded : case ReadyState.TilesLoaded:
                    btnNewMap.Visible = true;
                    btnLoadTiles.Visible = true;
                    btnLoadTileSet.Visible = true;
                    btnSaveTileSet.Visible = true;
                    lblFavouriteTilesFolder.Visible = true;
                    lblFavouriteTileSet.Visible = true;
                    lblFavouriteTilesFolder.Text = "";
                    button2.Visible = true; // clear tiles
                    btnLoadMap.Visible = true;
                    btnSaveMap.Visible = false;
                    button1.Visible = false;  // clear map
                    btnWipeCanvas.Visible = false;
                    btnResetTileSet.Visible = true; // reset tileset
                    btnAddColumnLeft.Visible = false;
                    btnAddColumnRight.Visible = false;
                    btnAddRowBottom.Visible = false;
                    btnAddRowTop.Visible = false;
                    rbAdd.Visible = false;
                    rbDelete.Visible = false;
                    chkCopyMapFile.Visible = false;
                    txtMapName.Visible = false;
                    break;

                case ReadyState.MapLoaded:
                    btnNewMap.Visible = true;
                    btnLoadTiles.Visible = true;
                    btnLoadTileSet.Visible = true;
                    btnSaveTileSet.Visible = true;
                    lblFavouriteTileSet.Visible = true;
                    btnLoadMap.Visible = true;
                    btnSaveMap.Visible = true;
                    button1.Visible = true;  // clear map
                    btnWipeCanvas.Visible = true;
                    btnResetTileSet.Visible = true; // reset tileset
                    btnAddColumnLeft.Visible = true;
                    btnAddColumnRight.Visible = true;
                    btnAddRowBottom.Visible = true;
                    btnAddRowTop.Visible = true;
                    rbAdd.Visible = true;
                    rbDelete.Visible = true;
                    chkCopyMapFile.Visible = true;
                    txtMapName.Visible = true;
                    break;

                case ReadyState.NewMap:
                    btnNewMap.Visible = true;
                    btnLoadTiles.Visible = true;
                    btnLoadTileSet.Visible = false;
                    btnSaveTileSet.Visible = false;
                    lblFavouriteTileSet.Visible = false;
                    btnLoadMap.Visible = true;
                    btnSaveMap.Visible = true;
                    button1.Visible = true;  // clear map
                    btnWipeCanvas.Visible = true;
                    btnResetTileSet.Visible = false; // reset tileset
                    btnAddColumnLeft.Visible = true;
                    btnAddColumnRight.Visible = true;
                    btnAddRowBottom.Visible = true;
                    btnAddRowTop.Visible = true;
                    rbAdd.Visible = true;
                    rbDelete.Visible = true;
                    chkCopyMapFile.Visible = true;
                    txtMapName.Visible = true;
                    break;

                default:
                    btnNewMap.Visible = true;
                    btnLoadTiles.Visible = true;
                    lblFavouriteTilesFolder.Text = "";
                    lblFavouriteTilesFolder.Visible = false;
                    lblFavouriteTileSet.Text = "";
                    btnLoadTileSet.Visible = false;
                    btnSaveTileSet.Visible = false;
                    lblFavouriteTileSet.Visible = false;
                    button2.Visible = false; // clear tiles
                    btnLoadMap.Visible = false;
                    btnSaveMap.Visible = false;
                    button1.Visible = false;  // clear map
                    btnWipeCanvas.Visible = false;
                    btnResetTileSet.Visible = false; // reset tileset
                    btnAddColumnLeft.Visible = false;
                    btnAddColumnRight.Visible = false;
                    btnAddRowBottom.Visible = false;
                    btnAddRowTop.Visible = false;
                    rbAdd.Visible = false;
                    rbDelete.Visible = false;
                    chkCopyMapFile.Visible = false;
            lblFavouriteTilesFolder.Text = "";

                    break;

            }

        }

    }
}
