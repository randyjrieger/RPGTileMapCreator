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
//using System.Windows.Input.MouseButtonState;

namespace RPGTileMapCreator
{
    // TODO browse for files
    // TODO '?' as CONST
    // TODO use tilewidth/height - not 51
    public partial class Form_Map : Form
    {
        public Project ProjectInfo;
        private Canvas canvas;
        private Map map;

        PictureBox SelectedPaletteBox = new PictureBox();
        PictureBox formerSelected = new PictureBox();
        PaletteObject formerSelectedTileSet = new PaletteObject();
        PaletteObject selectedTileSet = new PaletteObject();
        PaletteObject defaultTileSet;
        TextBox txtMapCharacter = new TextBox();
        List<PaletteObject> tileSets;
        List<CanvasTile> canvasTiles = new List<CanvasTile>();
        // ReadyState readyState = ReadyState.None;

        protected bool clearCanvasFlag = false;
        protected int rows = 0;
        protected int columns = 0;



        public Form_Map()
        {
            ProjectInfo = new Project();
            ProjectInfo.TileWidth = 51;
            ProjectInfo.TileHeight = 51;

            InitializeComponent();
            Canvas_Panel.Width = 2000; Canvas_Panel.Height = 2000;

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
            Canvas_Panel.MouseDown += new MouseEventHandler(Canvas_Panel_MouseMove);

            // set Default Tileset
            defaultTileSet = new PaletteObject();
            defaultTileSet.tile = new PictureBox();
            defaultTileSet.tile.Image = Resource1._default;
            defaultTileSet.letter = lblDefault;
            pnlCanvasBase.AutoScroll = false;
            pnlCanvasBase.VerticalScroll.Enabled = true;
            pnlCanvasBase.VerticalScroll.Visible = true;
            pnlCanvasBase.HorizontalScroll.Enabled = true;
            pnlCanvasBase.HorizontalScroll.Visible = true;
            pnlCanvasBase.AutoScroll = true;

            Resizer();
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

            if (String.IsNullOrEmpty(letter.Text))
            {
                foreach (PictureBox p in Canvas_Panel.Controls.OfType<PictureBox>())
                {
                    if (p.Image == pb.tile.Image)
                    {
                        p.Image = null;
                    }
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
        public void Canvas_Panel_MouseMove(object sender, MouseEventArgs e)
        {
            /*
            if (e.Button == MouseButtons.Left && e.)
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
            }*/
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
            root.TileSettings = new TileSettings();
            root.TileSettings.Tiles = new List<Tile>();
            // root.TileSets[0].filePath = "c:\\temp\\tileset";

            foreach (PictureBox p in tileSets.Select(ts => ts.tile).ToList())
            {
                root.TileSettings.Tiles.Add(new Tile
                {
                    FileName = p.Name,
                    Character = p.Tag == null ? "" : p.Tag.ToString()
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

            var tileSetJson = JsonConvert.DeserializeObject<Root>(File.ReadAllText(@ProjectInfo.TileFolderPath));
        }

        private void btnLoadTiles_Click(object sender, EventArgs e)
        {
            //DialogResult result = folderBrowserDialog1.ShowDialog();

            //if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(ProjectInfo.TileFolderPath))
            //{
            //    ProjectInfo.TileFolderPath = folderBrowserDialog1.SelectedPath;
            //}

            LoadTiles();
        }

        private void LoadTiles()
        {
            int row = 0;
            int col = 0;
            PictureBox p;
            TextBox t;
            tileSets = new List<PaletteObject>();

            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
            {
                ProjectInfo.TileFolderPath = folderBrowserDialog1.SelectedPath;
            }

            DirectoryInfo DirInfo = new DirectoryInfo(ProjectInfo.TileFolderPath);

            var tileImageFiles = from f in DirInfo.EnumerateFiles()
                                 where f.Name.EndsWith(".png") || f.Name.EndsWith(".jpg")
                                 select f;

            foreach (var f in tileImageFiles)
            {
                p = new PictureBox();
                t = new TextBox();

                p.BackColor = Color.Ivory;
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                p.Width = ProjectInfo.TileWidth;
                p.Height = ProjectInfo.TileHeight;

                t.MaxLength = 1;
                t.Height = 23;

                p.Left = col * ProjectInfo.TileWidth;
                p.Top = row * ProjectInfo.TileHeight + row * t.Height;
                col++;
                if (col == 9)
                {
                    col = 0; row++;
                }

                p.Name = Path.GetFileName(f.Name);
                p.BorderStyle = BorderStyle.None;
                p.Image = Image.FromFile(f.FullName);

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

            UpdateFormState();
            Canvas_Panel.Controls.Add(txtMapCharacter);

        }
        private void btnLoadTileSet_Click(object sender, EventArgs e)
        {
            LoadTileSet();
        }

        private void LoadTileSet()
        {
            // reads path for tile configuration

            //  tileSets = new List<PaletteObject>();
            string tileSetPath = "";

            if (openTileFolderDialog.ShowDialog() == DialogResult.OK)
            {
                tileSetPath = @openTileFolderDialog.FileName;
                ProjectInfo.TileSetFile = openTileFolderDialog.FileName;
            }
            //  }
            var tileSetJson = JsonConvert.DeserializeObject<Root>(File.ReadAllText(tileSetPath));
            // var tileSetJson = JsonConvert.DeserializeObject<List<Tileset>>(File.ReadAllText(tileSetPath));

            // iterate through the tile list for those files and build tile selection pane
            // also assign characters to these tiles
            //     tileSets.Find(ts => ts.tile == tileSetJson)
            foreach (var ts in tileSetJson.TileSettings.Tiles)
            {
                if (!String.IsNullOrEmpty(ts.Character))
                {
                    var target = tileSets.Find(t => t.tile.Name == ts.FileName);
                    if (target != null)
                    {
                        target.letter.Text = ts.Character;
                        target.tile.Tag = ts.Character;
                    }

                }
                // search for tile and update letter
            }

            UpdateCanvas();
            //  readyState = ReadyState.TilesetLoaded;
            UpdateFormState();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (PaletteObject po in tileSets)
            {
                Panel_Palete.Controls.Remove(po.tile);
                Panel_Palete.Controls.Remove(po.letter);
            }

            // readyState = ReadyState.FormLoaded;
            UpdateFormState();
            WipeCanvas();

            tileSets.Clear();
            // readyState = ReadyState.FormLoaded;
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
            // txtMapName.Text = openMapFileDialog.FileName;

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

                        x = columns * ProjectInfo.TileWidth - ProjectInfo.TileWidth;
                        y = rows * ProjectInfo.TileHeight - ProjectInfo.TileHeight;

                        if (tileSets.Exists(t => t.letter.Text == s.ToString()))
                        {

                            canvasTile = new CanvasTile
                            {
                                Row = rows,
                                Col = columns,
                                TopLeftPoint = new Point(x, y),
                                BottomRightPoint = new Point(x + ProjectInfo.TileWidth, y + ProjectInfo.TileHeight),
                                Width = ProjectInfo.TileWidth,
                                Height = ProjectInfo.TileHeight,
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
                                BottomRightPoint = new Point(x + ProjectInfo.TileWidth, y + ProjectInfo.TileHeight),
                                Width = ProjectInfo.TileWidth,
                                Height = ProjectInfo.TileHeight,
                                TileImage = new Bitmap(defaultTileSet.tile.Image),
                                Character = (s == ' ' || s.ToString() == defaultTileSet.letter.Text.Substring(0, 1)) ? defaultTileSet.letter.Text.Substring(0, 1) : s.ToString()
                            };

                            canvasTiles.Add(canvasTile);
                        }
                    }
                }
                file.Close();
            }

            lblMapH.Text = rows.ToString();
            lblMapW.Text = columns.ToString();

            if (Canvas_Panel.Visible != true)
            {
                Canvas_Panel.Visible = true;
            }

            Canvas_Panel.Width = columns * ProjectInfo.TileWidth;
            Canvas_Panel.Height = rows * ProjectInfo.TileHeight;

            progressBar1.Visible = false;
            Canvas_Panel.Refresh();
        }

        private void btnLoadMap_Click(object sender, EventArgs e)
        {

            if (openMapFileDialog.ShowDialog() == DialogResult.OK)
            {

                var fileName = openMapFileDialog.FileName;
                ProjectInfo.MapFilePath = fileName;

                LoadMap(fileName);

                // readyState = ReadyState.MapLoaded;
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
                //pnlCanvasBase.AutoScroll = true; // add back?
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
            SaveProject();
        }

        private void SaveProject()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;
                string path = Path.GetFullPath(fileName);
                string shortFileName = Path.GetFileName(fileName);
                string projectFilePath = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\RPGTIleMapCreator\\" + shortFileName + "_" + DateTime.Now.ToString("yyyyMMddHHmmssFFF");
                ProjectInfo.ProjectFolder = projectFilePath;
                string projectFileName = projectFilePath + "\\" + shortFileName + ".rpg";
                string mapFileName = projectFilePath + "\\" + shortFileName + ".map";

                // Create Project Folder
                if (!Directory.Exists(projectFilePath))
                {
                    Directory.CreateDirectory(projectFilePath);
                }

                // Write The Project File
                ProjectFile pf = new ProjectFile
                {
                    ProjectFolder = ProjectInfo.ProjectFolder,
                    MapFile = ProjectInfo.MapFilePath,
                    TileFolder = ProjectInfo.TileFolderPath,
                    TileSettingsFile = ProjectInfo.TileSetFile
                };

                string projectJson = JsonConvert.SerializeObject(pf, Formatting.Indented);

                File.WriteAllText(projectFileName, projectJson);

                // Write The Map File
                string rowString = "";
                using (StreamWriter file = new System.IO.StreamWriter(mapFileName))
                {
                    if (!String.IsNullOrEmpty(fileName))
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
                                rowString += ct.Character != null ? ct.Character : ProjectInfo.EmptyTileCharacter;
                            }

                            file.WriteLine(rowString);
                        }
                    }

                    file.Close();
                }
            }


        }
        /*
        private void SaveProject()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ProjectInfo.ProjectFilePath = saveFileDialog1.FileName;
                //  txtMapName.Text = saveFileDialog1.FileName;

                using (StreamWriter file = new System.IO.StreamWriter(@ProjectInfo.ProjectFilePath))
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

                LoadMap(ProjectInfo.ProjectFilePath);


                //Canvas_Panel.Refresh();
            }
        }*/

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

            // readyState = ReadyState.FormLoaded;
            UpdateFormState();
            Canvas_Panel.Refresh();
        }
        /// <summary>
        /// Creating a New Project
        /// </summary>
        #region NewProject
        private void btnNewMap_Click(object sender, EventArgs e)
        {
            Wizard newWizard = new Wizard();
            //subscribe
            newWizard.ProjectInfoReady += new EventHandler<EventArgs>(NewProject_ProjectInfoReady);
            newWizard.TopLevel = true;

            // ProjectInfo = newProjectForm.ProjectInfo;
            newWizard.ShowDialog();

            // unsubscribe
            newWizard.ProjectInfoReady -= NewProject_ProjectInfoReady;
            newWizard.Dispose();
            newWizard = null;

            // Display Canvas, Show Map With Dimensions

            // Load and Display Tiles

            // Clear State
            FreshMap();

            // Reset UI
            UpdateCanvas();

            // Change ReadyState
            // readyState = ReadyState.NewMap;
            // Update UI
            //  UpdateFormState();

            btnNewMap.Visible = true;
            btnLoadTiles.Visible = true;
            btnLoadTileSet.Visible = false;
            btnSaveTileSet.Visible = false;
            btnSaveMap.Visible = true;
            button1.Visible = true;  // clear map
            btnWipeCanvas.Visible = true;
            btnResetTileSet.Visible = false; // reset tileset

            gbTiles.Visible = true;
            gbTileSets.Visible = false;

            gbResize.Visible = true;
            btnAddColumnLeft.Visible = true;
            btnAddColumnRight.Visible = true;
            btnAddRowBottom.Visible = true;
            btnAddRowTop.Visible = true;
            rbAdd.Visible = true;
            rbDelete.Visible = true;

        }

        void NewProject_ProjectInfoReady(object sender, EventArgs e)
        {
            Wizard newProjectForm = sender as Wizard;
            if (newProjectForm != null)
            {
                ProjectInfo = newProjectForm.ProjectInfo;
                lblProjectName.Text = ProjectInfo.Name;
                lblDefault.Text = ProjectInfo.EmptyTileCharacter;
                lblMapW.Text = ProjectInfo.StartingWidth.ToString();
                lblMapH.Text = ProjectInfo.StartingHeight.ToString();
                lblTileW.Text = ProjectInfo.TileWidth.ToString();
                lblTileH.Text = ProjectInfo.TileHeight.ToString();
            }
            newProjectForm.Close();

        }
        #endregion

        private void FreshMap()
        {
            int x = 0;
            int y = 0;
            Bitmap sourceBmp = null;
            CanvasTile canvasTile = null;

            var lineCount = ProjectInfo.StartingHeight;

            progressBar1.Visible = true;
            progressBar1.Maximum = lineCount;

            if (tileSets == null)
            {
                tileSets = new List<PaletteObject>();
            }

            canvasTiles.Clear();
            for (int j = 1; j <= ProjectInfo.StartingHeight; j++)
            {
                rows++;
                columns = 0;
                progressBar1.Value = rows;
                for (int i = 1; i <= ProjectInfo.StartingWidth; i++)
                {
                    progressBar1.Value = rows;
                    columns++;
                    sourceBmp = new Bitmap(defaultTileSet.tile.Image);

                    x = columns * ProjectInfo.TileWidth - ProjectInfo.TileWidth;
                    y = rows * ProjectInfo.TileHeight - ProjectInfo.TileHeight;

                    canvasTile = new CanvasTile
                    {
                        Row = rows,
                        Col = columns,
                        TopLeftPoint = new Point(x, y),
                        BottomRightPoint = new Point(x + ProjectInfo.TileWidth, y + ProjectInfo.TileHeight),
                        Width = ProjectInfo.TileWidth,
                        Height = ProjectInfo.TileHeight,
                        TileImage = new Bitmap(defaultTileSet.tile.Image),
                        Character = defaultTileSet.letter.Text.Substring(0, 1)
                    };

                    canvasTiles.Add(canvasTile);
                }
            }

            if (Canvas_Panel.Visible != true)
            {
                Canvas_Panel.Visible = true;
            }

            Canvas_Panel.Width = columns * ProjectInfo.TileWidth;
            Canvas_Panel.Height = rows * ProjectInfo.TileHeight;

            progressBar1.Visible = false;
            Canvas_Panel.Refresh();
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
                    Canvas_Panel.Width += ProjectInfo.TileWidth;

                    // Add (# of rows) cells to screen on right top to bottom
                    for (int r = 1; r <= rows; r++)
                    {
                        x = columns * ProjectInfo.TileWidth - ProjectInfo.TileWidth;
                        y = r * ProjectInfo.TileHeight - ProjectInfo.TileHeight;

                        ct = new CanvasTile
                        {
                            Character = defaultTileSet.letter.Text,
                            TileImage = new Bitmap(defaultTileSet.tile.Image),
                            Row = r,
                            Col = columns,
                            Width = ProjectInfo.TileWidth,
                            Height = ProjectInfo.TileHeight,
                            TopLeftPoint = new Point(x, y),
                            BottomRightPoint = new Point(x + ProjectInfo.TileWidth, y + ProjectInfo.TileHeight),
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
                    Canvas_Panel.Width -= ProjectInfo.TileWidth;

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
                    Canvas_Panel.Width += ProjectInfo.TileWidth;

                    // Need to increase the column and location of all Tiles first
                    foreach (CanvasTile nudgeTile in canvasTiles)
                    {
                        nudgeTile.Col++;
                        nudgeTile.TopLeftPoint = new Point(nudgeTile.TopLeftPoint.X + ProjectInfo.TileWidth, nudgeTile.TopLeftPoint.Y);
                        nudgeTile.BottomRightPoint = new Point(nudgeTile.BottomRightPoint.X + ProjectInfo.TileWidth, nudgeTile.BottomRightPoint.Y);
                    }

                    // Add new column with column = 0;
                    for (int r = 1; r <= rows; r++)
                    {
                        x = 0;
                        y = r * ProjectInfo.TileHeight - ProjectInfo.TileHeight;

                        ct = new CanvasTile
                        {
                            Character = defaultTileSet.letter.Text,
                            TileImage = new Bitmap(defaultTileSet.tile.Image),
                            Row = r,
                            Col = 1,
                            Width = ProjectInfo.TileWidth,
                            Height = ProjectInfo.TileHeight,
                            TopLeftPoint = new Point(x, y),
                            BottomRightPoint = new Point(x + ProjectInfo.TileWidth, y + ProjectInfo.TileHeight),
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
                    Canvas_Panel.Width -= ProjectInfo.TileWidth;

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
                        nudgeTile.TopLeftPoint = new Point(nudgeTile.TopLeftPoint.X - ProjectInfo.TileWidth, nudgeTile.TopLeftPoint.Y);
                        nudgeTile.BottomRightPoint = new Point(nudgeTile.BottomRightPoint.X - ProjectInfo.TileWidth, nudgeTile.BottomRightPoint.Y);
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
                    Canvas_Panel.Height += ProjectInfo.TileHeight;

                    // Add (# of rows) cells to screen on right top to bottom
                    for (int c = 1; c <= columns; c++)
                    {
                        x = c * ProjectInfo.TileWidth - ProjectInfo.TileWidth;
                        y = rows * ProjectInfo.TileHeight - ProjectInfo.TileHeight;

                        ct = new CanvasTile
                        {
                            Character = defaultTileSet.letter.Text,
                            TileImage = new Bitmap(defaultTileSet.tile.Image),
                            Row = rows,
                            Col = c,
                            Width = ProjectInfo.TileWidth,
                            Height = ProjectInfo.TileHeight,
                            TopLeftPoint = new Point(x, y),
                            BottomRightPoint = new Point(x + ProjectInfo.TileWidth, y + ProjectInfo.TileHeight),
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
                    Canvas_Panel.Height -= ProjectInfo.TileHeight;

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
                    Canvas_Panel.Height += ProjectInfo.TileHeight;

                    // Need to increase the column and location of all Tiles first
                    foreach (CanvasTile nudgeTile in canvasTiles)
                    {
                        nudgeTile.Row++;
                        nudgeTile.TopLeftPoint = new Point(nudgeTile.TopLeftPoint.X, nudgeTile.TopLeftPoint.Y + ProjectInfo.TileHeight);
                        nudgeTile.BottomRightPoint = new Point(nudgeTile.BottomRightPoint.X, nudgeTile.BottomRightPoint.Y + ProjectInfo.TileHeight);
                    }

                    // Add (# of rows) cells to screen on right top to bottom
                    for (int c = 1; c <= columns; c++)
                    {
                        x = c * ProjectInfo.TileWidth - ProjectInfo.TileWidth;
                        y = 0;

                        ct = new CanvasTile
                        {
                            Character = defaultTileSet.letter.Text,
                            TileImage = new Bitmap(defaultTileSet.tile.Image),
                            Row = 1,
                            Col = c,
                            Width = ProjectInfo.TileWidth,
                            Height = ProjectInfo.TileHeight,
                            TopLeftPoint = new Point(x, y),
                            BottomRightPoint = new Point(x + ProjectInfo.TileWidth, y + ProjectInfo.TileHeight),
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
                    Canvas_Panel.Height -= ProjectInfo.TileHeight;

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
                        nudgeTile.TopLeftPoint = new Point(nudgeTile.TopLeftPoint.X, nudgeTile.TopLeftPoint.Y - ProjectInfo.TileHeight);
                        nudgeTile.BottomRightPoint = new Point(nudgeTile.BottomRightPoint.X, nudgeTile.BottomRightPoint.Y - ProjectInfo.TileHeight);
                    }
                }
            }
            Canvas_Panel.Refresh();
        }
        #region Resize
        /// <summary>
        /// The following event, when linked to Resize, will know when the window is maximized, restored or minimized
        /// </summary>
        FormWindowState LastWindowState = FormWindowState.Minimized;
        private void Form_Map_Resize(object sender, EventArgs e)
        {

            // When window state changes
            if (WindowState != LastWindowState)
            {
                LastWindowState = WindowState;


                if (WindowState == FormWindowState.Maximized)
                {
                    // MessageBox.Show("Max");
                    Resizer();
                }
                else if (WindowState == FormWindowState.Normal)
                {
                    // MessageBox.Show("Restored");
                    Resizer();
                }
                else if (WindowState == FormWindowState.Minimized)
                {
                    // MessageBox.Show("Min");
                    Resizer();
                }
            }

        }
        private void Resizer()
        {
            // Canvas_Panel.Visible = false; //temp

            int canvasbaseWidth = pnlCanvasBase.Size.Width;
            int canvasbaseHeight = pnlCanvasBase.Size.Height;

            int tilepanelWidth = Panel_Palete.Size.Width;
            int tilepanelHeight = Panel_Palete.Size.Height;

            pnlCanvasBase.Width = this.Width - Panel_Palete.Width;
            pnlCanvasBase.Height = this.Height - 150;
            pnlCanvasBase.Location = new Point(0, 75);

            Panel_Palete.Height = pnlCanvasBase.Height;
            Panel_Palete.Location = new Point(pnlCanvasBase.Width, 75);

            // txtMapName.Visible = true;
            // txtMapName.Text = string.Format("{0} {1} {2} {3} {4} {5}",
            //      this.Width.ToString(), this.Height.ToString(),
            //     canvasbaseWidth.ToString(), canvasbaseHeight.ToString(),
            //      tilepanelWidth.ToString(), tilepanelHeight.ToString());


            return;
        }

        /// <summary>
        /// Called when the window is moved on the screen OR resized with the cursor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Map_ResizeEnd(object sender, EventArgs e)
        {
            // MessageBox.Show("ResizeEnd");
            Resizer();

        }

        #endregion
        private void button1_Click_1(object sender, EventArgs e)
        {
            UpdateCanvas();
        }

        public void UpdateCanvas()
        {

            progressBar1.Visible = true;
            /*progressBar1.Maximum = tileSets.Count;
            progressBar1.Value = 0;*/

            foreach (var ts in tileSets)
            {
                // progressBar1.Value++;

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

            Canvas_Panel.Refresh();
        }
        public void UpdateFormState()
        {
            btnNewMap.Visible = true;
            btnLoadTiles.Visible = true;
            btnLoadTileSet.Visible = true;
            btnSaveTileSet.Visible = true;
            button2.Visible = true; // clear tiles
                                    // btnLoadMap.Visible = true;
            btnSaveMap.Visible = true;
            button1.Visible = true;
            btnWipeCanvas.Visible = true;
            btnResetTileSet.Visible = true; // reset tileset
                                            // txtMapName.Visible = true;

            //  gbMap.Visible = true;
            gbTiles.Visible = true;

            gbTileSets.Visible = true;
            gbResize.Visible = true;
            btnAddColumnLeft.Visible = true;
            btnAddColumnRight.Visible = true;
            btnAddRowBottom.Visible = true;
            btnAddRowTop.Visible = true;
            rbAdd.Visible = true;
            rbDelete.Visible = true;
            /*
            switch (readyState)
            {
                case ReadyState.FormLoaded:
                    btnNewMap.Visible = true;
                    btnLoadTiles.Visible = true;               
                    txtMapName.Visible = false;
                    btnLoadMap.Visible = true;
                    gbMap.Visible = true;
                    gbTiles.Visible = false;
                    gbTileSets.Visible = false;

                    gbResize.Visible = true;
                    btnAddColumnLeft.Visible = true;
                    btnAddColumnRight.Visible = true;
                    btnAddRowBottom.Visible = true;
                    btnAddRowTop.Visible = true;
                    rbAdd.Visible = true;
                    rbDelete.Visible = true;

                    break;
                case ReadyState.TilesLoaded:
                    btnNewMap.Visible = true;
                    btnLoadTiles.Visible = true;
                    btnLoadTileSet.Visible = true;
                    btnSaveTileSet.Visible = true;
                    button2.Visible = true; // clear tiles
                    btnLoadMap.Visible = true;
                    btnSaveMap.Visible = true;
                    button1.Visible = true;
                    btnWipeCanvas.Visible = true;
                    btnResetTileSet.Visible = true; // reset tileset
                    btnAddColumnLeft.Visible = true;
                    btnAddColumnRight.Visible = true;
                    btnAddRowBottom.Visible = true;
                    btnAddRowTop.Visible = true;
                    rbAdd.Visible = true;
                    rbDelete.Visible = true;
                    txtMapName.Visible = true;

                    gbMap.Visible = true;
                    gbTiles.Visible = true;
                    gbTileSets.Visible = true;
                    gbResize.Visible = true;
                    break;

                case ReadyState.TilesetLoaded :
                    btnNewMap.Visible = true;
                    btnLoadTiles.Visible = true;
                    btnLoadTileSet.Visible = true;
                    btnSaveTileSet.Visible = true;
                    button2.Visible = true; // clear tiles
                    btnLoadMap.Visible = true;
                    btnSaveMap.Visible = true;
                    button1.Visible = true;  
                    btnWipeCanvas.Visible = true;
                    btnResetTileSet.Visible = true; // reset tileset
                    txtMapName.Visible = true;

                    gbMap.Visible = true;
                    gbTiles.Visible = true;

                    gbTileSets.Visible = true;
                    gbResize.Visible = true;
                    btnAddColumnLeft.Visible = true;
                    btnAddColumnRight.Visible = true;
                    btnAddRowBottom.Visible = true;
                    btnAddRowTop.Visible = true;
                    rbAdd.Visible = true;
                    rbDelete.Visible = true;
                    break;

                case ReadyState.MapLoaded:
                    btnNewMap.Visible = true;
                    btnLoadTiles.Visible = true;
                    btnLoadTileSet.Visible = true;
                    btnSaveTileSet.Visible = true;
                    btnLoadMap.Visible = true;
                    btnSaveMap.Visible = true;
                    button1.Visible = true;  // clear map
                    btnWipeCanvas.Visible = true;
                    btnResetTileSet.Visible = true; // reset tileset
                    txtMapName.Visible = true;

                    gbMap.Visible = true;
                    gbTiles.Visible = true;
                    gbTileSets.Visible = false;

                    gbResize.Visible = true;
                    btnAddColumnLeft.Visible = true;
                    btnAddColumnRight.Visible = true;
                    btnAddRowBottom.Visible = true;
                    btnAddRowTop.Visible = true;
                    rbAdd.Visible = true;
                    rbDelete.Visible = true;
                    break;

                case ReadyState.NewMap:
                    btnNewMap.Visible = true;
                    btnLoadTiles.Visible = true;
                    btnLoadTileSet.Visible = false;
                    btnSaveTileSet.Visible = false;
                    btnLoadMap.Visible = true;
                    btnSaveMap.Visible = true;
                    button1.Visible = true;  // clear map
                    btnWipeCanvas.Visible = true;
                    btnResetTileSet.Visible = false; // reset tileset
                    txtMapName.Visible = true;

                    gbMap.Visible = true;
                    gbTiles.Visible = true;
                    gbTileSets.Visible = false;

                    gbResize.Visible = true;
                    btnAddColumnLeft.Visible = true;
                    btnAddColumnRight.Visible = true;
                    btnAddRowBottom.Visible = true;
                    btnAddRowTop.Visible = true;
                    rbAdd.Visible = true;
                    rbDelete.Visible = true;
                    break;

                default:
                    btnNewMap.Visible = true;
                    btnLoadTiles.Visible = true;
                    btnLoadTileSet.Visible = false;
                    btnSaveTileSet.Visible = false;
                    button2.Visible = false; // clear tiles
                    btnLoadMap.Visible = false;
                    btnSaveMap.Visible = false;
                    button1.Visible = false;  // clear map
                    btnWipeCanvas.Visible = false;
                    btnResetTileSet.Visible = false; // reset tileset

                    gbResize.Visible = true;
                    btnAddColumnLeft.Visible = true;
                    btnAddColumnRight.Visible = true;
                    btnAddRowBottom.Visible = true;
                    btnAddRowTop.Visible = true;
                    rbAdd.Visible = true;
                    rbDelete.Visible = true;
                    break;
            }
            */
        }
    }
}
