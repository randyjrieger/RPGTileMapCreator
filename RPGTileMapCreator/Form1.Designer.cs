
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
            this.button1 = new System.Windows.Forms.Button();
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
            this.lblFavouriteTilesFolder = new System.Windows.Forms.Label();
            this.lblFavouriteTileSet = new System.Windows.Forms.Label();
            this.Canvas_Panel.SuspendLayout();
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
            this.txtMapName.Location = new System.Drawing.Point(743, 74);
            this.txtMapName.MaxLength = 1;
            this.txtMapName.Name = "txtMapName";
            this.txtMapName.Size = new System.Drawing.Size(145, 23);
            this.txtMapName.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1004, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Save Map";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(675, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Map File:";
            // 
            // btnSaveTileSet
            // 
            this.btnSaveTileSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSaveTileSet.Location = new System.Drawing.Point(772, 51);
            this.btnSaveTileSet.Name = "btnSaveTileSet";
            this.btnSaveTileSet.Size = new System.Drawing.Size(100, 23);
            this.btnSaveTileSet.TabIndex = 4;
            this.btnSaveTileSet.Text = "Save Tile Set";
            this.btnSaveTileSet.UseVisualStyleBackColor = false;
            this.btnSaveTileSet.Click += new System.EventHandler(this.btnSaveTileSet_Click);
            // 
            // btnLoadMap
            // 
            this.btnLoadMap.Location = new System.Drawing.Point(898, 73);
            this.btnLoadMap.Name = "btnLoadMap";
            this.btnLoadMap.Size = new System.Drawing.Size(100, 23);
            this.btnLoadMap.TabIndex = 5;
            this.btnLoadMap.Text = "Load Map";
            this.btnLoadMap.UseVisualStyleBackColor = true;
            this.btnLoadMap.Click += new System.EventHandler(this.btnLoadMap_Click);
            // 
            // btnLoadTileSet
            // 
            this.btnLoadTileSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnLoadTileSet.Location = new System.Drawing.Point(946, 26);
            this.btnLoadTileSet.Name = "btnLoadTileSet";
            this.btnLoadTileSet.Size = new System.Drawing.Size(100, 23);
            this.btnLoadTileSet.TabIndex = 12;
            this.btnLoadTileSet.Text = "Load Tile Set";
            this.btnLoadTileSet.UseVisualStyleBackColor = false;
            this.btnLoadTileSet.Click += new System.EventHandler(this.btnLoadTileSet_Click);
            // 
            // btnLoadTiles
            // 
            this.btnLoadTiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnLoadTiles.Location = new System.Drawing.Point(946, 3);
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
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button2.Location = new System.Drawing.Point(675, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Clear Tiles";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1110, 69);
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
            this.progressBar1.Size = new System.Drawing.Size(676, 32);
            this.progressBar1.TabIndex = 16;
            this.progressBar1.Visible = false;
            // 
            // Canvas_Panel
            // 
            this.Canvas_Panel.AutoScroll = true;
            this.Canvas_Panel.Controls.Add(this.progressBar1);
            this.Canvas_Panel.Location = new System.Drawing.Point(2, 3);
            this.Canvas_Panel.Name = "Canvas_Panel";
            this.Canvas_Panel.Size = new System.Drawing.Size(676, 502);
            this.Canvas_Panel.TabIndex = 15;
            this.Canvas_Panel.Visible = false;
            this.Canvas_Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Panel_Paint);
            // 
            // lblFavouriteTilesFolder
            // 
            this.lblFavouriteTilesFolder.AutoSize = true;
            this.lblFavouriteTilesFolder.Location = new System.Drawing.Point(685, 10);
            this.lblFavouriteTilesFolder.Name = "lblFavouriteTilesFolder";
            this.lblFavouriteTilesFolder.Size = new System.Drawing.Size(125, 15);
            this.lblFavouriteTilesFolder.TabIndex = 17;
            this.lblFavouriteTilesFolder.Text = "lblFavouriteTilesFolder";
            // 
            // lblFavouriteTileSet
            // 
            this.lblFavouriteTileSet.AutoSize = true;
            this.lblFavouriteTileSet.Location = new System.Drawing.Point(685, 30);
            this.lblFavouriteTileSet.Name = "lblFavouriteTileSet";
            this.lblFavouriteTileSet.Size = new System.Drawing.Size(103, 15);
            this.lblFavouriteTileSet.TabIndex = 18;
            this.lblFavouriteTileSet.Text = "lblFavouriteTileSet";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 504);
            this.Controls.Add(this.lblFavouriteTileSet);
            this.Controls.Add(this.lblFavouriteTilesFolder);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Canvas_Panel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnLoadTiles);
            this.Controls.Add(this.btnSaveTileSet);
            this.Controls.Add(this.btnLoadTileSet);
            this.Controls.Add(this.btnLoadMap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtMapName);
            this.Controls.Add(this.Panel_Palete);
            this.Name = "Form1";
            this.Text = "RPG Tile Map Creator";
            this.Canvas_Panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Palete;
        private System.Windows.Forms.TextBox txtMapName;
        private System.Windows.Forms.Button button1;
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
    }
}

