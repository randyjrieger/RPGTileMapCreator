
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
            this.SuspendLayout();
            // 
            // Panel_Palete
            // 
            this.Panel_Palete.AutoScroll = true;
            this.Panel_Palete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Panel_Palete.Location = new System.Drawing.Point(675, 78);
            this.Panel_Palete.Name = "Panel_Palete";
            this.Panel_Palete.Size = new System.Drawing.Size(486, 427);
            this.Panel_Palete.TabIndex = 0;
            // 
            // txtMapName
            // 
            this.txtMapName.Location = new System.Drawing.Point(754, 12);
            this.txtMapName.MaxLength = 1;
            this.txtMapName.Name = "txtMapName";
            this.txtMapName.Size = new System.Drawing.Size(100, 23);
            this.txtMapName.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(941, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(675, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Map Name:";
            // 
            // btnSaveTileSet
            // 
            this.btnSaveTileSet.Location = new System.Drawing.Point(1054, 41);
            this.btnSaveTileSet.Name = "btnSaveTileSet";
            this.btnSaveTileSet.Size = new System.Drawing.Size(83, 23);
            this.btnSaveTileSet.TabIndex = 4;
            this.btnSaveTileSet.Text = "Save Tile Set";
            this.btnSaveTileSet.UseVisualStyleBackColor = true;
            this.btnSaveTileSet.Click += new System.EventHandler(this.btnSaveTileSet_Click);
            // 
            // btnLoadMap
            // 
            this.btnLoadMap.Location = new System.Drawing.Point(860, 12);
            this.btnLoadMap.Name = "btnLoadMap";
            this.btnLoadMap.Size = new System.Drawing.Size(75, 23);
            this.btnLoadMap.TabIndex = 5;
            this.btnLoadMap.Text = "Load Map";
            this.btnLoadMap.UseVisualStyleBackColor = true;
            // 
            // btnLoadTileSet
            // 
            this.btnLoadTileSet.Location = new System.Drawing.Point(916, 41);
            this.btnLoadTileSet.Name = "btnLoadTileSet";
            this.btnLoadTileSet.Size = new System.Drawing.Size(100, 23);
            this.btnLoadTileSet.TabIndex = 12;
            this.btnLoadTileSet.Text = "Load Tile Set";
            this.btnLoadTileSet.UseVisualStyleBackColor = true;
            this.btnLoadTileSet.Click += new System.EventHandler(this.btnLoadTileSet_Click);
            // 
            // btnLoadTiles
            // 
            this.btnLoadTiles.Location = new System.Drawing.Point(675, 41);
            this.btnLoadTiles.Name = "btnLoadTiles";
            this.btnLoadTiles.Size = new System.Drawing.Size(100, 23);
            this.btnLoadTiles.TabIndex = 13;
            this.btnLoadTiles.Text = "Load Tiles";
            this.btnLoadTiles.UseVisualStyleBackColor = true;
            this.btnLoadTiles.Click += new System.EventHandler(this.btnLoadTiles_Click);
            // 
            // openTileFolderDialog
            // 
            this.openTileFolderDialog.Filter = "PNG|*.png|JPG|*.jpg";
            this.openTileFolderDialog.Multiselect = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(790, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Clear Tiles";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 504);
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
    }
}

