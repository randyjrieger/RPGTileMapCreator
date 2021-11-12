
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
            this.txtMapName = new System.Windows.Forms.TextBox();
            this.btnSaveMap = new System.Windows.Forms.Button();
            this.btnSaveTileSet = new System.Windows.Forms.Button();
            this.btnLoadMap = new System.Windows.Forms.Button();
            this.btnLoadTileSet = new System.Windows.Forms.Button();
            this.btnLoadTiles = new System.Windows.Forms.Button();
            this.openTileFolderDialog = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openMapFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Canvas_Panel = new System.Windows.Forms.Panel();
            this.btnBottom = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddRowTop = new System.Windows.Forms.Button();
            this.btnAddColumnRight = new System.Windows.Forms.Button();
            this.btnAddColumnLeft = new System.Windows.Forms.Button();
            this.btnAddRowBottom = new System.Windows.Forms.Button();
            this.btnWipeCanvas = new System.Windows.Forms.Button();
            this.btnNewMap = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDelete = new System.Windows.Forms.RadioButton();
            this.rbAdd = new System.Windows.Forms.RadioButton();
            this.lblFavouriteTileSet = new System.Windows.Forms.Label();
            this.lblFavouriteTilesFolder = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.btnResetTileSet = new System.Windows.Forms.Button();
            this.chkCopyMapFile = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDefaultChar = new System.Windows.Forms.TextBox();
            this.lblTileDim = new System.Windows.Forms.Label();
            this.txtW = new System.Windows.Forms.TextBox();
            this.txtH = new System.Windows.Forms.TextBox();
            this.lblW = new System.Windows.Forms.Label();
            this.lblH = new System.Windows.Forms.Label();
            this.Canvas_Panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Palete
            // 
            this.Panel_Palete.AutoScroll = true;
            this.Panel_Palete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Panel_Palete.Location = new System.Drawing.Point(675, 75);
            this.Panel_Palete.Name = "Panel_Palete";
            this.Panel_Palete.Size = new System.Drawing.Size(486, 504);
            this.Panel_Palete.TabIndex = 0;
            // 
            // txtMapName
            // 
            this.txtMapName.Location = new System.Drawing.Point(593, 5);
            this.txtMapName.MaxLength = 200;
            this.txtMapName.Name = "txtMapName";
            this.txtMapName.Size = new System.Drawing.Size(203, 23);
            this.txtMapName.TabIndex = 1;
            this.txtMapName.Visible = false;
            // 
            // btnSaveMap
            // 
            this.btnSaveMap.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSaveMap.Location = new System.Drawing.Point(487, 29);
            this.btnSaveMap.Name = "btnSaveMap";
            this.btnSaveMap.Size = new System.Drawing.Size(100, 23);
            this.btnSaveMap.TabIndex = 2;
            this.btnSaveMap.Text = "Save Map";
            this.btnSaveMap.UseVisualStyleBackColor = false;
            this.btnSaveMap.Visible = false;
            this.btnSaveMap.Click += new System.EventHandler(this.btnSaveMap_Click);
            // 
            // btnSaveTileSet
            // 
            this.btnSaveTileSet.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSaveTileSet.Location = new System.Drawing.Point(257, 29);
            this.btnSaveTileSet.Name = "btnSaveTileSet";
            this.btnSaveTileSet.Size = new System.Drawing.Size(100, 23);
            this.btnSaveTileSet.TabIndex = 4;
            this.btnSaveTileSet.Text = "Save Tile Set";
            this.btnSaveTileSet.UseVisualStyleBackColor = false;
            this.btnSaveTileSet.Visible = false;
            this.btnSaveTileSet.Click += new System.EventHandler(this.btnSaveTileSet_Click);
            // 
            // btnLoadMap
            // 
            this.btnLoadMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLoadMap.Location = new System.Drawing.Point(487, 2);
            this.btnLoadMap.Name = "btnLoadMap";
            this.btnLoadMap.Size = new System.Drawing.Size(100, 23);
            this.btnLoadMap.TabIndex = 5;
            this.btnLoadMap.Text = "Load Map";
            this.btnLoadMap.UseVisualStyleBackColor = false;
            this.btnLoadMap.Visible = false;
            this.btnLoadMap.Click += new System.EventHandler(this.btnLoadMap_Click);
            // 
            // btnLoadTileSet
            // 
            this.btnLoadTileSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLoadTileSet.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnLoadTileSet.Location = new System.Drawing.Point(257, 2);
            this.btnLoadTileSet.Name = "btnLoadTileSet";
            this.btnLoadTileSet.Size = new System.Drawing.Size(100, 23);
            this.btnLoadTileSet.TabIndex = 12;
            this.btnLoadTileSet.Text = "Load Tile Set";
            this.btnLoadTileSet.UseVisualStyleBackColor = false;
            this.btnLoadTileSet.Visible = false;
            this.btnLoadTileSet.Click += new System.EventHandler(this.btnLoadTileSet_Click);
            // 
            // btnLoadTiles
            // 
            this.btnLoadTiles.BackColor = System.Drawing.Color.DarkOrange;
            this.btnLoadTiles.Location = new System.Drawing.Point(0, 2);
            this.btnLoadTiles.Name = "btnLoadTiles";
            this.btnLoadTiles.Size = new System.Drawing.Size(100, 23);
            this.btnLoadTiles.TabIndex = 13;
            this.btnLoadTiles.Text = "Load Tiles";
            this.btnLoadTiles.UseVisualStyleBackColor = false;
            this.btnLoadTiles.Click += new System.EventHandler(this.btnLoadTiles_Click);
            // 
            // openTileFolderDialog
            // 
            this.openTileFolderDialog.Filter = "JSON|*.json";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(106, 29);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Clear Tiles";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 77);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(669, 20);
            this.progressBar1.TabIndex = 16;
            this.progressBar1.Visible = false;
            // 
            // Canvas_Panel
            // 
            this.Canvas_Panel.AutoScroll = true;
            this.Canvas_Panel.BackColor = System.Drawing.Color.Gainsboro;
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
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMinSize = new System.Drawing.Size(669, 504);
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.Canvas_Panel);
            this.panel1.Location = new System.Drawing.Point(0, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(669, 504);
            this.panel1.TabIndex = 19;
            // 
            // btnAddRowTop
            // 
            this.btnAddRowTop.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAddRowTop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAddRowTop.Location = new System.Drawing.Point(942, 12);
            this.btnAddRowTop.Name = "btnAddRowTop";
            this.btnAddRowTop.Size = new System.Drawing.Size(100, 23);
            this.btnAddRowTop.TabIndex = 20;
            this.btnAddRowTop.Text = "Top Row";
            this.btnAddRowTop.UseVisualStyleBackColor = false;
            this.btnAddRowTop.Visible = false;
            this.btnAddRowTop.Click += new System.EventHandler(this.btnAddRowTop_Click);
            // 
            // btnAddColumnRight
            // 
            this.btnAddColumnRight.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAddColumnRight.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAddColumnRight.Location = new System.Drawing.Point(1039, 37);
            this.btnAddColumnRight.Name = "btnAddColumnRight";
            this.btnAddColumnRight.Size = new System.Drawing.Size(100, 23);
            this.btnAddColumnRight.TabIndex = 21;
            this.btnAddColumnRight.Text = "Right Column";
            this.btnAddColumnRight.UseVisualStyleBackColor = false;
            this.btnAddColumnRight.Visible = false;
            this.btnAddColumnRight.Click += new System.EventHandler(this.btnAddColumnRight_Click);
            // 
            // btnAddColumnLeft
            // 
            this.btnAddColumnLeft.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAddColumnLeft.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAddColumnLeft.Location = new System.Drawing.Point(942, 38);
            this.btnAddColumnLeft.Name = "btnAddColumnLeft";
            this.btnAddColumnLeft.Size = new System.Drawing.Size(100, 23);
            this.btnAddColumnLeft.TabIndex = 22;
            this.btnAddColumnLeft.Text = "Left Column";
            this.btnAddColumnLeft.UseVisualStyleBackColor = false;
            this.btnAddColumnLeft.Visible = false;
            this.btnAddColumnLeft.Click += new System.EventHandler(this.btnAddColumnLeft_Click);
            // 
            // btnAddRowBottom
            // 
            this.btnAddRowBottom.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAddRowBottom.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAddRowBottom.Location = new System.Drawing.Point(1039, 12);
            this.btnAddRowBottom.Name = "btnAddRowBottom";
            this.btnAddRowBottom.Size = new System.Drawing.Size(100, 23);
            this.btnAddRowBottom.TabIndex = 23;
            this.btnAddRowBottom.Text = "Bottom Row";
            this.btnAddRowBottom.UseVisualStyleBackColor = false;
            this.btnAddRowBottom.Visible = false;
            this.btnAddRowBottom.Click += new System.EventHandler(this.btnAddRowBottom_Click);
            // 
            // btnWipeCanvas
            // 
            this.btnWipeCanvas.BackColor = System.Drawing.Color.White;
            this.btnWipeCanvas.Location = new System.Drawing.Point(696, 29);
            this.btnWipeCanvas.Name = "btnWipeCanvas";
            this.btnWipeCanvas.Size = new System.Drawing.Size(100, 23);
            this.btnWipeCanvas.TabIndex = 26;
            this.btnWipeCanvas.Text = "Clear Map";
            this.btnWipeCanvas.UseVisualStyleBackColor = false;
            this.btnWipeCanvas.Visible = false;
            this.btnWipeCanvas.Click += new System.EventHandler(this.btnWipeCanvas_Click);
            // 
            // btnNewMap
            // 
            this.btnNewMap.BackColor = System.Drawing.Color.OrangeRed;
            this.btnNewMap.Location = new System.Drawing.Point(0, 29);
            this.btnNewMap.Name = "btnNewMap";
            this.btnNewMap.Size = new System.Drawing.Size(100, 23);
            this.btnNewMap.TabIndex = 27;
            this.btnNewMap.Text = "New Map";
            this.btnNewMap.UseVisualStyleBackColor = false;
            this.btnNewMap.Click += new System.EventHandler(this.btnNewMap_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Controls.Add(this.rbDelete);
            this.groupBox1.Controls.Add(this.rbAdd);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(872, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(64, 51);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // rbDelete
            // 
            this.rbDelete.AutoSize = true;
            this.rbDelete.Location = new System.Drawing.Point(7, 31);
            this.rbDelete.Name = "rbDelete";
            this.rbDelete.Size = new System.Drawing.Size(58, 19);
            this.rbDelete.TabIndex = 1;
            this.rbDelete.Text = "Delete";
            this.rbDelete.UseVisualStyleBackColor = true;
            this.rbDelete.Visible = false;
            // 
            // rbAdd
            // 
            this.rbAdd.AutoSize = true;
            this.rbAdd.Checked = true;
            this.rbAdd.Location = new System.Drawing.Point(6, 9);
            this.rbAdd.Name = "rbAdd";
            this.rbAdd.Size = new System.Drawing.Size(47, 19);
            this.rbAdd.TabIndex = 0;
            this.rbAdd.TabStop = true;
            this.rbAdd.Text = "Add";
            this.rbAdd.UseVisualStyleBackColor = true;
            this.rbAdd.Visible = false;
            // 
            // lblFavouriteTileSet
            // 
            this.lblFavouriteTileSet.AutoSize = true;
            this.lblFavouriteTileSet.Location = new System.Drawing.Point(363, 7);
            this.lblFavouriteTileSet.Name = "lblFavouriteTileSet";
            this.lblFavouriteTileSet.Size = new System.Drawing.Size(103, 15);
            this.lblFavouriteTileSet.TabIndex = 18;
            this.lblFavouriteTileSet.Text = "lblFavouriteTileSet";
            this.lblFavouriteTileSet.Visible = false;
            // 
            // lblFavouriteTilesFolder
            // 
            this.lblFavouriteTilesFolder.AutoSize = true;
            this.lblFavouriteTilesFolder.Location = new System.Drawing.Point(106, 7);
            this.lblFavouriteTilesFolder.Name = "lblFavouriteTilesFolder";
            this.lblFavouriteTilesFolder.Size = new System.Drawing.Size(125, 15);
            this.lblFavouriteTilesFolder.TabIndex = 17;
            this.lblFavouriteTilesFolder.Text = "lblFavouriteTilesFolder";
            this.lblFavouriteTilesFolder.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RosyBrown;
            this.button1.Location = new System.Drawing.Point(593, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 29;
            this.button1.Text = "Update Map";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnResetTileSet
            // 
            this.btnResetTileSet.BackColor = System.Drawing.Color.White;
            this.btnResetTileSet.Location = new System.Drawing.Point(363, 29);
            this.btnResetTileSet.Name = "btnResetTileSet";
            this.btnResetTileSet.Size = new System.Drawing.Size(97, 23);
            this.btnResetTileSet.TabIndex = 30;
            this.btnResetTileSet.Text = "Reset Tile Set";
            this.btnResetTileSet.UseVisualStyleBackColor = false;
            this.btnResetTileSet.Visible = false;
            this.btnResetTileSet.Click += new System.EventHandler(this.btnResetTileSet_Click);
            // 
            // chkCopyMapFile
            // 
            this.chkCopyMapFile.AutoSize = true;
            this.chkCopyMapFile.Checked = true;
            this.chkCopyMapFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyMapFile.Location = new System.Drawing.Point(487, 53);
            this.chkCopyMapFile.Name = "chkCopyMapFile";
            this.chkCopyMapFile.Size = new System.Drawing.Size(231, 19);
            this.chkCopyMapFile.TabIndex = 31;
            this.chkCopyMapFile.Text = "Make New Copy With DateTime Stamp";
            this.chkCopyMapFile.UseVisualStyleBackColor = true;
            this.chkCopyMapFile.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 15);
            this.label1.TabIndex = 32;
            this.label1.Text = "Empty File Character:";
            // 
            // txtDefaultChar
            // 
            this.txtDefaultChar.Location = new System.Drawing.Point(384, 54);
            this.txtDefaultChar.MaxLength = 1;
            this.txtDefaultChar.Name = "txtDefaultChar";
            this.txtDefaultChar.Size = new System.Drawing.Size(19, 23);
            this.txtDefaultChar.TabIndex = 33;
            this.txtDefaultChar.Text = "?";
            // 
            // lblTileDim
            // 
            this.lblTileDim.AutoSize = true;
            this.lblTileDim.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTileDim.Location = new System.Drawing.Point(3, 57);
            this.lblTileDim.Name = "lblTileDim";
            this.lblTileDim.Size = new System.Drawing.Size(97, 15);
            this.lblTileDim.TabIndex = 34;
            this.lblTileDim.Text = "Tile Dimensions:";
            // 
            // txtW
            // 
            this.txtW.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtW.Location = new System.Drawing.Point(128, 54);
            this.txtW.MaxLength = 1;
            this.txtW.Name = "txtW";
            this.txtW.Size = new System.Drawing.Size(19, 23);
            this.txtW.TabIndex = 35;
            this.txtW.Text = "51";
            // 
            // txtH
            // 
            this.txtH.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtH.Location = new System.Drawing.Point(173, 54);
            this.txtH.MaxLength = 1;
            this.txtH.Name = "txtH";
            this.txtH.Size = new System.Drawing.Size(19, 23);
            this.txtH.TabIndex = 36;
            this.txtH.Text = "51";
            // 
            // lblW
            // 
            this.lblW.AutoSize = true;
            this.lblW.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblW.Location = new System.Drawing.Point(106, 56);
            this.lblW.Name = "lblW";
            this.lblW.Size = new System.Drawing.Size(19, 15);
            this.lblW.TabIndex = 37;
            this.lblW.Text = "W";
            // 
            // lblH
            // 
            this.lblH.AutoSize = true;
            this.lblH.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblH.Location = new System.Drawing.Point(150, 56);
            this.lblH.Name = "lblH";
            this.lblH.Size = new System.Drawing.Size(16, 15);
            this.lblH.TabIndex = 38;
            this.lblH.Text = "H";
            // 
            // Form_Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1164, 580);
            this.Controls.Add(this.lblH);
            this.Controls.Add(this.lblW);
            this.Controls.Add(this.txtH);
            this.Controls.Add(this.txtW);
            this.Controls.Add(this.lblTileDim);
            this.Controls.Add(this.txtDefaultChar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkCopyMapFile);
            this.Controls.Add(this.btnResetTileSet);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNewMap);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnWipeCanvas);
            this.Controls.Add(this.btnAddRowBottom);
            this.Controls.Add(this.btnAddColumnLeft);
            this.Controls.Add(this.btnAddColumnRight);
            this.Controls.Add(this.btnAddRowTop);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblFavouriteTileSet);
            this.Controls.Add(this.lblFavouriteTilesFolder);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnLoadTiles);
            this.Controls.Add(this.btnSaveTileSet);
            this.Controls.Add(this.btnLoadTileSet);
            this.Controls.Add(this.btnLoadMap);
            this.Controls.Add(this.btnSaveMap);
            this.Controls.Add(this.txtMapName);
            this.Controls.Add(this.Panel_Palete);
            this.Name = "Form_Map";
            this.Text = "RPG Tile Map Creator";
            this.Load += new System.EventHandler(this.Form_Map_Load);
            this.Canvas_Panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Palete;
        private System.Windows.Forms.TextBox txtMapName;
        private System.Windows.Forms.Button btnSaveMap;
        private System.Windows.Forms.Button btnSaveTileSet;
        private System.Windows.Forms.Button btnLoadMap;
        private System.Windows.Forms.Button btnLoadTileSet;
        private System.Windows.Forms.Button btnLoadTiles;
        private System.Windows.Forms.OpenFileDialog openTileFolderDialog;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openMapFileDialog;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel Canvas_Panel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnBottom;
        private System.Windows.Forms.Button btnAddRowTop;
        private System.Windows.Forms.Button btnAddColumnRight;
        private System.Windows.Forms.Button btnAddColumnLeft;
        private System.Windows.Forms.Button btnAddRowBottom;
        private System.Windows.Forms.Button btnWipeCanvas;
        private System.Windows.Forms.Button btnNewMap;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbDelete;
        private System.Windows.Forms.RadioButton rbAdd;
        private System.Windows.Forms.Label lblFavouriteTileSet;
        private System.Windows.Forms.Label lblFavouriteTilesFolder;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnResetTileSet;
        private System.Windows.Forms.CheckBox chkCopyMapFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDefaultChar;
        private System.Windows.Forms.Label lblTileDim;
        private System.Windows.Forms.TextBox txtW;
        private System.Windows.Forms.TextBox txtH;
        private System.Windows.Forms.Label lblW;
        private System.Windows.Forms.Label lblH;
    }
}

