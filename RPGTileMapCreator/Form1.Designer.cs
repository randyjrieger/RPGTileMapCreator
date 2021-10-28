
namespace RPGTileMapCreator
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveTileSet = new System.Windows.Forms.Button();
            this.btnLoadMap = new System.Windows.Forms.Button();
            this.btnLoadTileSet = new System.Windows.Forms.Button();
            this.btnLoadTiles = new System.Windows.Forms.Button();
            this.openTileFolderDialog = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openMapFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Canvas_Panel = new System.Windows.Forms.Panel();
            this.btnBottom = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.lblFavouriteTilesFolder = new System.Windows.Forms.Label();
            this.lblFavouriteTileSet = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Canvas_Panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Palete
            // 
            this.Panel_Palete.AutoScroll = true;
            this.Panel_Palete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Panel_Palete.Location = new System.Drawing.Point(675, 99);
            this.Panel_Palete.Name = "Panel_Palete";
            this.Panel_Palete.Size = new System.Drawing.Size(486, 406);
            this.Panel_Palete.TabIndex = 0;
            // 
            // txtMapName
            // 
            this.txtMapName.Location = new System.Drawing.Point(743, 69);
            this.txtMapName.MaxLength = 1;
            this.txtMapName.Name = "txtMapName";
            this.txtMapName.Size = new System.Drawing.Size(197, 23);
            this.txtMapName.TabIndex = 1;
            // 
            // btnSaveMap
            // 
            this.btnSaveMap.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSaveMap.Location = new System.Drawing.Point(1052, 69);
            this.btnSaveMap.Name = "btnSaveMap";
            this.btnSaveMap.Size = new System.Drawing.Size(100, 23);
            this.btnSaveMap.TabIndex = 2;
            this.btnSaveMap.Text = "Save Map";
            this.btnSaveMap.UseVisualStyleBackColor = false;
            this.btnSaveMap.Click += new System.EventHandler(this.btnSaveMap_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(675, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Map File:";
            // 
            // btnSaveTileSet
            // 
            this.btnSaveTileSet.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSaveTileSet.Location = new System.Drawing.Point(1052, 35);
            this.btnSaveTileSet.Name = "btnSaveTileSet";
            this.btnSaveTileSet.Size = new System.Drawing.Size(100, 23);
            this.btnSaveTileSet.TabIndex = 4;
            this.btnSaveTileSet.Text = "Save Tile Set";
            this.btnSaveTileSet.UseVisualStyleBackColor = false;
            this.btnSaveTileSet.Click += new System.EventHandler(this.btnSaveTileSet_Click);
            // 
            // btnLoadMap
            // 
            this.btnLoadMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLoadMap.Location = new System.Drawing.Point(946, 69);
            this.btnLoadMap.Name = "btnLoadMap";
            this.btnLoadMap.Size = new System.Drawing.Size(100, 23);
            this.btnLoadMap.TabIndex = 5;
            this.btnLoadMap.Text = "Load Map";
            this.btnLoadMap.UseVisualStyleBackColor = false;
            this.btnLoadMap.Click += new System.EventHandler(this.btnLoadMap_Click);
            // 
            // btnLoadTileSet
            // 
            this.btnLoadTileSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLoadTileSet.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnLoadTileSet.Location = new System.Drawing.Point(675, 38);
            this.btnLoadTileSet.Name = "btnLoadTileSet";
            this.btnLoadTileSet.Size = new System.Drawing.Size(100, 25);
            this.btnLoadTileSet.TabIndex = 12;
            this.btnLoadTileSet.Text = "Load Tile Set";
            this.btnLoadTileSet.UseVisualStyleBackColor = false;
            this.btnLoadTileSet.Click += new System.EventHandler(this.btnLoadTileSet_Click);
            // 
            // btnLoadTiles
            // 
            this.btnLoadTiles.BackColor = System.Drawing.Color.DarkOrange;
            this.btnLoadTiles.Location = new System.Drawing.Point(675, 3);
            this.btnLoadTiles.Name = "btnLoadTiles";
            this.btnLoadTiles.Size = new System.Drawing.Size(100, 29);
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
            this.button2.Location = new System.Drawing.Point(1052, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Clear Tiles";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1013, -9);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(604, 32);
            this.progressBar1.TabIndex = 16;
            this.progressBar1.Visible = false;
            // 
            // Canvas_Panel
            // 
            this.Canvas_Panel.AutoScroll = true;
            this.Canvas_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Canvas_Panel.Controls.Add(this.btnBottom);
            this.Canvas_Panel.Controls.Add(this.btnRight);
            this.Canvas_Panel.Controls.Add(this.progressBar1);
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
            // lblFavouriteTilesFolder
            // 
            this.lblFavouriteTilesFolder.AutoSize = true;
            this.lblFavouriteTilesFolder.Location = new System.Drawing.Point(781, 9);
            this.lblFavouriteTilesFolder.Name = "lblFavouriteTilesFolder";
            this.lblFavouriteTilesFolder.Size = new System.Drawing.Size(125, 15);
            this.lblFavouriteTilesFolder.TabIndex = 17;
            this.lblFavouriteTilesFolder.Text = "lblFavouriteTilesFolder";
            // 
            // lblFavouriteTileSet
            // 
            this.lblFavouriteTileSet.AutoSize = true;
            this.lblFavouriteTileSet.Location = new System.Drawing.Point(781, 43);
            this.lblFavouriteTileSet.Name = "lblFavouriteTileSet";
            this.lblFavouriteTileSet.Size = new System.Drawing.Size(103, 15);
            this.lblFavouriteTileSet.TabIndex = 18;
            this.lblFavouriteTileSet.Text = "lblFavouriteTileSet";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMinSize = new System.Drawing.Size(669, 504);
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.Canvas_Panel);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(669, 504);
            this.panel1.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 504);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblFavouriteTileSet);
            this.Controls.Add(this.lblFavouriteTilesFolder);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnLoadTiles);
            this.Controls.Add(this.btnSaveTileSet);
            this.Controls.Add(this.btnLoadTileSet);
            this.Controls.Add(this.btnLoadMap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveMap);
            this.Controls.Add(this.txtMapName);
            this.Controls.Add(this.Panel_Palete);
            this.Name = "Form1";
            this.Text = "RPG Tile Map Creator";
            this.Canvas_Panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Palete;
        private System.Windows.Forms.TextBox txtMapName;
        private System.Windows.Forms.Button btnSaveMap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveTileSet;
        private System.Windows.Forms.Button btnLoadMap;
        private System.Windows.Forms.Button btnLoadTileSet;
        private System.Windows.Forms.Button btnLoadTiles;
        private System.Windows.Forms.OpenFileDialog openTileFolderDialog;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openMapFileDialog;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel Canvas_Panel;
        private System.Windows.Forms.Label lblFavouriteTilesFolder;
        private System.Windows.Forms.Label lblFavouriteTileSet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnBottom;
    }
}

