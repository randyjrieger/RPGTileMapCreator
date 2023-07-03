
namespace RPGTileMapCreator
{
    partial class Form_Map
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Panel_Palete = new System.Windows.Forms.Panel();
            this.openTileFolderDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openMapFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Canvas_Panel = new System.Windows.Forms.Panel();
            this.btnBottom = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.pnlCanvasBase = new System.Windows.Forms.Panel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblDefault = new System.Windows.Forms.TextBox();
            this.lblTileH = new System.Windows.Forms.Label();
            this.lblTileW = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMapH = new System.Windows.Forms.Label();
            this.lblMapW = new System.Windows.Forms.Label();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.btnWipeCanvas = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLoadMap = new System.Windows.Forms.Button();
            this.btnSaveMap = new System.Windows.Forms.Button();
            this.gbTileSets = new System.Windows.Forms.GroupBox();
            this.btnSaveTileSet = new System.Windows.Forms.Button();
            this.btnLoadTileSet = new System.Windows.Forms.Button();
            this.gbTiles = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnLoadTiles = new System.Windows.Forms.Button();
            this.gbResize = new System.Windows.Forms.GroupBox();
            this.btnResetTileSet = new System.Windows.Forms.Button();
            this.btnAddRowBottom = new System.Windows.Forms.Button();
            this.btnAddColumnLeft = new System.Windows.Forms.Button();
            this.btnAddColumnRight = new System.Windows.Forms.Button();
            this.btnAddRowTop = new System.Windows.Forms.Button();
            this.rbAdd = new System.Windows.Forms.RadioButton();
            this.rbDelete = new System.Windows.Forms.RadioButton();
            this.lblH = new System.Windows.Forms.Label();
            this.lblW = new System.Windows.Forms.Label();
            this.lblTileDim = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNewMap = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.Canvas_Panel.SuspendLayout();
            this.pnlCanvasBase.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.gbTileSets.SuspendLayout();
            this.gbTiles.SuspendLayout();
            this.gbResize.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Palete
            // 
            this.Panel_Palete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Panel_Palete.AutoScroll = true;
            this.Panel_Palete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Panel_Palete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Panel_Palete.Location = new System.Drawing.Point(675, 75);
            this.Panel_Palete.Name = "Panel_Palete";
            this.Panel_Palete.Size = new System.Drawing.Size(486, 504);
            this.Panel_Palete.TabIndex = 0;
            // 
            // openTileFolderDialog
            // 
            this.openTileFolderDialog.Filter = "JSON|*.json";
            // 
            // Canvas_Panel
            // 
            this.Canvas_Panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Canvas_Panel.BackColor = System.Drawing.Color.AntiqueWhite;
            this.Canvas_Panel.Controls.Add(this.btnBottom);
            this.Canvas_Panel.Controls.Add(this.btnRight);
            this.Canvas_Panel.Location = new System.Drawing.Point(0, 0);
            this.Canvas_Panel.Name = "Canvas_Panel";
            this.Canvas_Panel.Size = new System.Drawing.Size(669, 504);
            this.Canvas_Panel.TabIndex = 15;
            this.Canvas_Panel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Canvas_Panel_Scroll);
            this.Canvas_Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Panel_Paint);
            // 
            // btnBottom
            // 
            this.btnBottom.BackColor = System.Drawing.Color.Black;
            this.btnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnBottom.Location = new System.Drawing.Point(0, 494);
            this.btnBottom.Name = "btnBottom";
            this.btnBottom.Size = new System.Drawing.Size(659, 10);
            this.btnBottom.TabIndex = 19;
            this.btnBottom.Text = "button4";
            this.btnBottom.UseVisualStyleBackColor = false;
            this.btnBottom.Click += new System.EventHandler(this.btnLoadTiles_Click);
            // 
            // btnRight
            // 
            this.btnRight.BackColor = System.Drawing.Color.Black;
            this.btnRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRight.Location = new System.Drawing.Point(659, 0);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(10, 504);
            this.btnRight.TabIndex = 18;
            this.btnRight.Text = "button4";
            this.btnRight.UseVisualStyleBackColor = false;
            // 
            // pnlCanvasBase
            // 
            this.pnlCanvasBase.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCanvasBase.AutoScroll = true;
            this.pnlCanvasBase.AutoScrollMinSize = new System.Drawing.Size(669, 504);
            this.pnlCanvasBase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlCanvasBase.BackColor = System.Drawing.Color.Black;
            this.pnlCanvasBase.Controls.Add(this.Canvas_Panel);
            this.pnlCanvasBase.Location = new System.Drawing.Point(0, 75);
            this.pnlCanvasBase.Name = "pnlCanvasBase";
            this.pnlCanvasBase.Size = new System.Drawing.Size(669, 1015);
            this.pnlCanvasBase.TabIndex = 19;
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Controls.Add(this.lblDefault);
            this.pnlToolbar.Controls.Add(this.lblTileH);
            this.pnlToolbar.Controls.Add(this.lblTileW);
            this.pnlToolbar.Controls.Add(this.label4);
            this.pnlToolbar.Controls.Add(this.label5);
            this.pnlToolbar.Controls.Add(this.lblMapH);
            this.pnlToolbar.Controls.Add(this.lblMapW);
            this.pnlToolbar.Controls.Add(this.lblProjectName);
            this.pnlToolbar.Controls.Add(this.btnWipeCanvas);
            this.pnlToolbar.Controls.Add(this.button1);
            this.pnlToolbar.Controls.Add(this.btnLoadMap);
            this.pnlToolbar.Controls.Add(this.btnSaveMap);
            this.pnlToolbar.Controls.Add(this.gbTileSets);
            this.pnlToolbar.Controls.Add(this.gbResize);
            this.pnlToolbar.Controls.Add(this.lblH);
            this.pnlToolbar.Controls.Add(this.lblW);
            this.pnlToolbar.Controls.Add(this.lblTileDim);
            this.pnlToolbar.Controls.Add(this.label1);
            this.pnlToolbar.Controls.Add(this.btnNewMap);
            this.pnlToolbar.Location = new System.Drawing.Point(0, -1);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1165, 75);
            this.pnlToolbar.TabIndex = 20;
            // 
            // lblDefault
            // 
            this.lblDefault.Enabled = false;
            this.lblDefault.Location = new System.Drawing.Point(611, 40);
            this.lblDefault.MaxLength = 1;
            this.lblDefault.Name = "lblDefault";
            this.lblDefault.Size = new System.Drawing.Size(19, 23);
            this.lblDefault.TabIndex = 67;
            this.lblDefault.Text = "?";
            // 
            // lblTileH
            // 
            this.lblTileH.AutoSize = true;
            this.lblTileH.Location = new System.Drawing.Point(611, 14);
            this.lblTileH.Name = "lblTileH";
            this.lblTileH.Size = new System.Drawing.Size(10, 15);
            this.lblTileH.TabIndex = 65;
            this.lblTileH.Text = ".";
            // 
            // lblTileW
            // 
            this.lblTileW.AutoSize = true;
            this.lblTileW.Location = new System.Drawing.Point(545, 14);
            this.lblTileW.Name = "lblTileW";
            this.lblTileW.Size = new System.Drawing.Size(10, 15);
            this.lblTileW.TabIndex = 64;
            this.lblTileW.Text = ".";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(594, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 15);
            this.label4.TabIndex = 63;
            this.label4.Text = "H";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(520, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 15);
            this.label5.TabIndex = 62;
            this.label5.Text = "W";
            // 
            // lblMapH
            // 
            this.lblMapH.AutoSize = true;
            this.lblMapH.Location = new System.Drawing.Point(435, 14);
            this.lblMapH.Name = "lblMapH";
            this.lblMapH.Size = new System.Drawing.Size(10, 15);
            this.lblMapH.TabIndex = 61;
            this.lblMapH.Text = ".";
            // 
            // lblMapW
            // 
            this.lblMapW.AutoSize = true;
            this.lblMapW.Location = new System.Drawing.Point(364, 14);
            this.lblMapW.Name = "lblMapW";
            this.lblMapW.Size = new System.Drawing.Size(10, 15);
            this.lblMapW.TabIndex = 60;
            this.lblMapW.Text = ".";
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(114, 14);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(38, 15);
            this.lblProjectName.TabIndex = 59;
            this.lblProjectName.Text = "label2";
            // 
            // btnWipeCanvas
            // 
            this.btnWipeCanvas.BackColor = System.Drawing.Color.White;
            this.btnWipeCanvas.Location = new System.Drawing.Point(339, 39);
            this.btnWipeCanvas.Name = "btnWipeCanvas";
            this.btnWipeCanvas.Size = new System.Drawing.Size(100, 23);
            this.btnWipeCanvas.TabIndex = 33;
            this.btnWipeCanvas.Text = "Clear Map";
            this.btnWipeCanvas.UseVisualStyleBackColor = false;
            this.btnWipeCanvas.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RosyBrown;
            this.button1.Location = new System.Drawing.Point(230, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "Refresh Map";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            // 
            // btnLoadMap
            // 
            this.btnLoadMap.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnLoadMap.Location = new System.Drawing.Point(3, 37);
            this.btnLoadMap.Name = "btnLoadMap";
            this.btnLoadMap.Size = new System.Drawing.Size(104, 27);
            this.btnLoadMap.TabIndex = 58;
            this.btnLoadMap.Text = "Load Project";
            this.btnLoadMap.UseVisualStyleBackColor = false;
            this.btnLoadMap.Click += new System.EventHandler(this.btnLoadMap_Click);
            // 
            // btnSaveMap
            // 
            this.btnSaveMap.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSaveMap.Location = new System.Drawing.Point(113, 39);
            this.btnSaveMap.Name = "btnSaveMap";
            this.btnSaveMap.Size = new System.Drawing.Size(111, 23);
            this.btnSaveMap.TabIndex = 31;
            this.btnSaveMap.Text = "Save Project";
            this.btnSaveMap.UseVisualStyleBackColor = false;
            this.btnSaveMap.Visible = false;
            this.btnSaveMap.Click += new System.EventHandler(this.btnSaveMap_Click);
            // 
            // gbTileSets
            // 
            this.gbTileSets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gbTileSets.Controls.Add(this.btnSaveTileSet);
            this.gbTileSets.Controls.Add(this.btnLoadTileSet);
            this.gbTileSets.Controls.Add(this.gbTiles);
            this.gbTileSets.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbTileSets.Location = new System.Drawing.Point(684, 6);
            this.gbTileSets.Name = "gbTileSets";
            this.gbTileSets.Size = new System.Drawing.Size(177, 60);
            this.gbTileSets.TabIndex = 56;
            this.gbTileSets.TabStop = false;
            this.gbTileSets.Text = "Tile Sets";
            this.gbTileSets.Visible = false;
            // 
            // btnSaveTileSet
            // 
            this.btnSaveTileSet.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSaveTileSet.Location = new System.Drawing.Point(6, 37);
            this.btnSaveTileSet.Name = "btnSaveTileSet";
            this.btnSaveTileSet.Size = new System.Drawing.Size(81, 23);
            this.btnSaveTileSet.TabIndex = 14;
            this.btnSaveTileSet.Text = "Save";
            this.btnSaveTileSet.UseVisualStyleBackColor = false;
            this.btnSaveTileSet.Visible = false;
            this.btnSaveTileSet.Click += new System.EventHandler(this.btnSaveTileSet_Click);
            // 
            // btnLoadTileSet
            // 
            this.btnLoadTileSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLoadTileSet.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnLoadTileSet.Location = new System.Drawing.Point(6, 16);
            this.btnLoadTileSet.Name = "btnLoadTileSet";
            this.btnLoadTileSet.Size = new System.Drawing.Size(81, 23);
            this.btnLoadTileSet.TabIndex = 13;
            this.btnLoadTileSet.Text = "Load...";
            this.btnLoadTileSet.UseVisualStyleBackColor = false;
            this.btnLoadTileSet.Visible = false;
            this.btnLoadTileSet.Click += new System.EventHandler(this.btnLoadTileSet_Click);
            // 
            // gbTiles
            // 
            this.gbTiles.Controls.Add(this.button2);
            this.gbTiles.Controls.Add(this.btnLoadTiles);
            this.gbTiles.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbTiles.Location = new System.Drawing.Point(93, 0);
            this.gbTiles.Name = "gbTiles";
            this.gbTiles.Size = new System.Drawing.Size(118, 64);
            this.gbTiles.TabIndex = 57;
            this.gbTiles.TabStop = false;
            this.gbTiles.Text = "Tiles";
            this.gbTiles.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(6, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            // 
            // btnLoadTiles
            // 
            this.btnLoadTiles.BackColor = System.Drawing.Color.DarkOrange;
            this.btnLoadTiles.Location = new System.Drawing.Point(6, 16);
            this.btnLoadTiles.Name = "btnLoadTiles";
            this.btnLoadTiles.Size = new System.Drawing.Size(81, 23);
            this.btnLoadTiles.TabIndex = 15;
            this.btnLoadTiles.Text = "Load...";
            this.btnLoadTiles.UseVisualStyleBackColor = false;
            this.btnLoadTiles.Visible = false;
            this.btnLoadTiles.Click += new System.EventHandler(this.btnLoadTiles_Click);
            // 
            // gbResize
            // 
            this.gbResize.Controls.Add(this.btnResetTileSet);
            this.gbResize.Controls.Add(this.btnAddRowBottom);
            this.gbResize.Controls.Add(this.btnAddColumnLeft);
            this.gbResize.Controls.Add(this.btnAddColumnRight);
            this.gbResize.Controls.Add(this.btnAddRowTop);
            this.gbResize.Controls.Add(this.rbAdd);
            this.gbResize.Controls.Add(this.rbDelete);
            this.gbResize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbResize.Location = new System.Drawing.Point(862, 3);
            this.gbResize.Name = "gbResize";
            this.gbResize.Size = new System.Drawing.Size(300, 69);
            this.gbResize.TabIndex = 54;
            this.gbResize.TabStop = false;
            this.gbResize.Text = "Resize Map";
            this.gbResize.Visible = false;
            // 
            // btnResetTileSet
            // 
            this.btnResetTileSet.BackColor = System.Drawing.Color.White;
            this.btnResetTileSet.Location = new System.Drawing.Point(107, -3);
            this.btnResetTileSet.Name = "btnResetTileSet";
            this.btnResetTileSet.Size = new System.Drawing.Size(75, 23);
            this.btnResetTileSet.TabIndex = 31;
            this.btnResetTileSet.Text = "Reset";
            this.btnResetTileSet.UseVisualStyleBackColor = false;
            this.btnResetTileSet.Visible = false;
            this.btnResetTileSet.Click += new System.EventHandler(this.btnResetTileSet_Click);
            // 
            // btnAddRowBottom
            // 
            this.btnAddRowBottom.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAddRowBottom.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAddRowBottom.Location = new System.Drawing.Point(128, 38);
            this.btnAddRowBottom.Name = "btnAddRowBottom";
            this.btnAddRowBottom.Size = new System.Drawing.Size(100, 23);
            this.btnAddRowBottom.TabIndex = 43;
            this.btnAddRowBottom.Text = "Bottom Row";
            this.btnAddRowBottom.UseVisualStyleBackColor = false;
            this.btnAddRowBottom.Visible = false;
            this.btnAddRowBottom.Click += new System.EventHandler(this.btnAddRowBottom_Click);
            // 
            // btnAddColumnLeft
            // 
            this.btnAddColumnLeft.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAddColumnLeft.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAddColumnLeft.Location = new System.Drawing.Point(69, 17);
            this.btnAddColumnLeft.Name = "btnAddColumnLeft";
            this.btnAddColumnLeft.Size = new System.Drawing.Size(61, 46);
            this.btnAddColumnLeft.TabIndex = 42;
            this.btnAddColumnLeft.Text = "Left Column";
            this.btnAddColumnLeft.UseVisualStyleBackColor = false;
            this.btnAddColumnLeft.Visible = false;
            this.btnAddColumnLeft.Click += new System.EventHandler(this.btnAddColumnLeft_Click);
            // 
            // btnAddColumnRight
            // 
            this.btnAddColumnRight.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAddColumnRight.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAddColumnRight.Location = new System.Drawing.Point(225, 17);
            this.btnAddColumnRight.Name = "btnAddColumnRight";
            this.btnAddColumnRight.Size = new System.Drawing.Size(61, 46);
            this.btnAddColumnRight.TabIndex = 41;
            this.btnAddColumnRight.Text = "Right Column";
            this.btnAddColumnRight.UseVisualStyleBackColor = false;
            this.btnAddColumnRight.Visible = false;
            this.btnAddColumnRight.Click += new System.EventHandler(this.btnAddColumnRight_Click);
            // 
            // btnAddRowTop
            // 
            this.btnAddRowTop.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAddRowTop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAddRowTop.Location = new System.Drawing.Point(128, 19);
            this.btnAddRowTop.Name = "btnAddRowTop";
            this.btnAddRowTop.Size = new System.Drawing.Size(100, 23);
            this.btnAddRowTop.TabIndex = 40;
            this.btnAddRowTop.Text = "Top Row";
            this.btnAddRowTop.UseVisualStyleBackColor = false;
            this.btnAddRowTop.Visible = false;
            this.btnAddRowTop.Click += new System.EventHandler(this.btnAddRowTop_Click);
            // 
            // rbAdd
            // 
            this.rbAdd.AutoSize = true;
            this.rbAdd.Checked = true;
            this.rbAdd.Location = new System.Drawing.Point(12, 21);
            this.rbAdd.Name = "rbAdd";
            this.rbAdd.Size = new System.Drawing.Size(47, 19);
            this.rbAdd.TabIndex = 2;
            this.rbAdd.TabStop = true;
            this.rbAdd.Text = "Add";
            this.rbAdd.UseVisualStyleBackColor = true;
            this.rbAdd.Visible = false;
            // 
            // rbDelete
            // 
            this.rbDelete.AutoSize = true;
            this.rbDelete.Location = new System.Drawing.Point(12, 40);
            this.rbDelete.Name = "rbDelete";
            this.rbDelete.Size = new System.Drawing.Size(63, 19);
            this.rbDelete.TabIndex = 3;
            this.rbDelete.Text = "Delete";
            this.rbDelete.UseVisualStyleBackColor = true;
            this.rbDelete.Visible = false;
            // 
            // lblH
            // 
            this.lblH.AutoSize = true;
            this.lblH.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblH.Location = new System.Drawing.Point(413, 14);
            this.lblH.Name = "lblH";
            this.lblH.Size = new System.Drawing.Size(16, 15);
            this.lblH.TabIndex = 53;
            this.lblH.Text = "H";
            // 
            // lblW
            // 
            this.lblW.AutoSize = true;
            this.lblW.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblW.Location = new System.Drawing.Point(339, 14);
            this.lblW.Name = "lblW";
            this.lblW.Size = new System.Drawing.Size(19, 15);
            this.lblW.TabIndex = 52;
            this.lblW.Text = "W";
            // 
            // lblTileDim
            // 
            this.lblTileDim.AutoSize = true;
            this.lblTileDim.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTileDim.Location = new System.Drawing.Point(479, 14);
            this.lblTileDim.Name = "lblTileDim";
            this.lblTileDim.Size = new System.Drawing.Size(35, 15);
            this.lblTileDim.TabIndex = 49;
            this.lblTileDim.Text = "Tiles:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(545, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 47;
            this.label1.Text = "Empty Tile:";
            // 
            // btnNewMap
            // 
            this.btnNewMap.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnNewMap.Location = new System.Drawing.Point(3, 5);
            this.btnNewMap.Name = "btnNewMap";
            this.btnNewMap.Size = new System.Drawing.Size(104, 27);
            this.btnNewMap.TabIndex = 46;
            this.btnNewMap.Text = "New Project";
            this.btnNewMap.UseVisualStyleBackColor = false;
            this.btnNewMap.Click += new System.EventHandler(this.btnNewMap_Click);
            // 
            // Form_Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1164, 580);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlCanvasBase);
            this.Controls.Add(this.Panel_Palete);
            this.Name = "Form_Map";
            this.Text = "RPG Tile Map Creator";
            this.ResizeEnd += new System.EventHandler(this.Form_Map_ResizeEnd);
            this.Resize += new System.EventHandler(this.Form_Map_Resize);
            this.Canvas_Panel.ResumeLayout(false);
            this.pnlCanvasBase.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.gbTileSets.ResumeLayout(false);
            this.gbTiles.ResumeLayout(false);
            this.gbResize.ResumeLayout(false);
            this.gbResize.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Palete;
        private System.Windows.Forms.OpenFileDialog openTileFolderDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openMapFileDialog;
        private System.Windows.Forms.Panel Canvas_Panel;
        private System.Windows.Forms.Panel pnlCanvasBase;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnBottom;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.GroupBox gbTiles;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnLoadTiles;
        private System.Windows.Forms.GroupBox gbTileSets;
        private System.Windows.Forms.Button btnResetTileSet;
        private System.Windows.Forms.Button btnSaveTileSet;
        private System.Windows.Forms.Button btnLoadTileSet;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnWipeCanvas;
        private System.Windows.Forms.Button btnSaveMap;
        private System.Windows.Forms.GroupBox gbResize;
        private System.Windows.Forms.Button btnAddRowBottom;
        private System.Windows.Forms.Button btnAddColumnLeft;
        private System.Windows.Forms.Button btnAddColumnRight;
        private System.Windows.Forms.Button btnAddRowTop;
        private System.Windows.Forms.RadioButton rbAdd;
        private System.Windows.Forms.RadioButton rbDelete;
        private System.Windows.Forms.Label lblH;
        private System.Windows.Forms.Label lblW;
        private System.Windows.Forms.Label lblTileDim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNewMap;
        private System.Windows.Forms.Button btnLoadMap;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.Label lblTileH;
        private System.Windows.Forms.Label lblTileW;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMapH;
        private System.Windows.Forms.Label lblMapW;
        private System.Windows.Forms.TextBox lblDefault;
    }
}

