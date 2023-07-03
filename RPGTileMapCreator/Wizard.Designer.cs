
namespace RPGTileMapCreator
{
    partial class Wizard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Wizard));
            this.wiz01_intro = new AdvancedWizardControl.WizardPages.AdvancedWizardPage();
            this.wiz02_tiles = new AdvancedWizardControl.WizardPages.AdvancedWizardPage();
            this.wiz03_charset = new AdvancedWizardControl.WizardPages.AdvancedWizardPage();
            this.pnlProjectDetails = new System.Windows.Forms.Panel();
            this.pnlWizTiles = new System.Windows.Forms.Panel();
            this.btnTileFolder = new System.Windows.Forms.Button();
            this.txtTileRepoPath = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTileHeight = new System.Windows.Forms.TextBox();
            this.txtTileWidth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDefaultChar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblH = new System.Windows.Forms.Label();
            this.lblW = new System.Windows.Forms.Label();
            this.txtMapHeight = new System.Windows.Forms.TextBox();
            this.txtMapWidth = new System.Windows.Forms.TextBox();
            this.btnWizNext = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.openFolderDialog = new System.Windows.Forms.OpenFileDialog();
            this.openRootFolderDialog = new System.Windows.Forms.OpenFileDialog();
            this.lblNewSaveFolder = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkCopyTiles = new System.Windows.Forms.CheckBox();
            this.pnlProjectDetails.SuspendLayout();
            this.pnlWizTiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // wiz01_intro
            // 
            this.wiz01_intro.Header = true;
            this.wiz01_intro.HeaderBackgroundColor = System.Drawing.Color.White;
            this.wiz01_intro.HeaderFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.wiz01_intro.HeaderImage = ((System.Drawing.Image)(resources.GetObject("wiz01_intro.HeaderImage")));
            this.wiz01_intro.HeaderImageVisible = true;
            this.wiz01_intro.HeaderTitle = "Welcome to Advanced Wizard";
            this.wiz01_intro.Location = new System.Drawing.Point(0, 0);
            this.wiz01_intro.Name = "wiz01_intro";
            this.wiz01_intro.PreviousPage = 0;
            this.wiz01_intro.Size = new System.Drawing.Size(200, 100);
            this.wiz01_intro.SubTitle = "Your page description goes here";
            this.wiz01_intro.SubTitleFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.wiz01_intro.TabIndex = 0;
            // 
            // wiz02_tiles
            // 
            this.wiz02_tiles.Header = true;
            this.wiz02_tiles.HeaderBackgroundColor = System.Drawing.Color.White;
            this.wiz02_tiles.HeaderFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.wiz02_tiles.HeaderImage = ((System.Drawing.Image)(resources.GetObject("wiz02_tiles.HeaderImage")));
            this.wiz02_tiles.HeaderImageVisible = true;
            this.wiz02_tiles.HeaderTitle = "Welcome to Advanced Wizard";
            this.wiz02_tiles.Location = new System.Drawing.Point(0, 0);
            this.wiz02_tiles.Name = "wiz02_tiles";
            this.wiz02_tiles.PreviousPage = 0;
            this.wiz02_tiles.Size = new System.Drawing.Size(200, 100);
            this.wiz02_tiles.SubTitle = "Your page description goes here";
            this.wiz02_tiles.SubTitleFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.wiz02_tiles.TabIndex = 0;
            // 
            // wiz03_charset
            // 
            this.wiz03_charset.Header = true;
            this.wiz03_charset.HeaderBackgroundColor = System.Drawing.Color.White;
            this.wiz03_charset.HeaderFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.wiz03_charset.HeaderImage = ((System.Drawing.Image)(resources.GetObject("wiz03_charset.HeaderImage")));
            this.wiz03_charset.HeaderImageVisible = true;
            this.wiz03_charset.HeaderTitle = "Welcome to Advanced Wizard";
            this.wiz03_charset.Location = new System.Drawing.Point(0, 0);
            this.wiz03_charset.Name = "wiz03_charset";
            this.wiz03_charset.PreviousPage = 0;
            this.wiz03_charset.Size = new System.Drawing.Size(200, 100);
            this.wiz03_charset.SubTitle = "Your page description goes here";
            this.wiz03_charset.SubTitleFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.wiz03_charset.TabIndex = 0;
            // 
            // pnlProjectDetails
            // 
            this.pnlProjectDetails.BackColor = System.Drawing.SystemColors.Info;
            this.pnlProjectDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProjectDetails.Controls.Add(this.pnlWizTiles);
            this.pnlProjectDetails.Controls.Add(this.txtProjectName);
            this.pnlProjectDetails.Controls.Add(this.label8);
            this.pnlProjectDetails.Controls.Add(this.label7);
            this.pnlProjectDetails.Controls.Add(this.label5);
            this.pnlProjectDetails.Controls.Add(this.label6);
            this.pnlProjectDetails.Controls.Add(this.txtTileHeight);
            this.pnlProjectDetails.Controls.Add(this.txtTileWidth);
            this.pnlProjectDetails.Controls.Add(this.label3);
            this.pnlProjectDetails.Controls.Add(this.label2);
            this.pnlProjectDetails.Controls.Add(this.txtDefaultChar);
            this.pnlProjectDetails.Controls.Add(this.label1);
            this.pnlProjectDetails.Controls.Add(this.lblH);
            this.pnlProjectDetails.Controls.Add(this.lblW);
            this.pnlProjectDetails.Controls.Add(this.txtMapHeight);
            this.pnlProjectDetails.Controls.Add(this.txtMapWidth);
            this.pnlProjectDetails.Location = new System.Drawing.Point(12, 2);
            this.pnlProjectDetails.Name = "pnlProjectDetails";
            this.pnlProjectDetails.Size = new System.Drawing.Size(420, 180);
            this.pnlProjectDetails.TabIndex = 3;
            // 
            // pnlWizTiles
            // 
            this.pnlWizTiles.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlWizTiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlWizTiles.Controls.Add(this.chkCopyTiles);
            this.pnlWizTiles.Controls.Add(this.lblNewSaveFolder);
            this.pnlWizTiles.Controls.Add(this.label4);
            this.pnlWizTiles.Controls.Add(this.btnTileFolder);
            this.pnlWizTiles.Controls.Add(this.txtTileRepoPath);
            this.pnlWizTiles.Controls.Add(this.label9);
            this.pnlWizTiles.Controls.Add(this.label13);
            this.pnlWizTiles.Location = new System.Drawing.Point(79, 52);
            this.pnlWizTiles.Name = "pnlWizTiles";
            this.pnlWizTiles.Size = new System.Drawing.Size(420, 180);
            this.pnlWizTiles.TabIndex = 80;
            this.pnlWizTiles.Visible = false;
            // 
            // btnTileFolder
            // 
            this.btnTileFolder.Location = new System.Drawing.Point(302, 61);
            this.btnTileFolder.Name = "btnTileFolder";
            this.btnTileFolder.Size = new System.Drawing.Size(44, 23);
            this.btnTileFolder.TabIndex = 82;
            this.btnTileFolder.Text = "...";
            this.btnTileFolder.UseVisualStyleBackColor = true;
            this.btnTileFolder.Click += new System.EventHandler(this.btnTileFolder_Click);
            // 
            // txtTileRepoPath
            // 
            this.txtTileRepoPath.Location = new System.Drawing.Point(108, 62);
            this.txtTileRepoPath.Name = "txtTileRepoPath";
            this.txtTileRepoPath.Size = new System.Drawing.Size(188, 23);
            this.txtTileRepoPath.TabIndex = 80;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(32, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(235, 15);
            this.label9.TabIndex = 78;
            this.label9.Text = "The local folder where tile images are saved";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 15);
            this.label13.TabIndex = 69;
            this.label13.Text = "Tile Repo:";
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(112, 13);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.PlaceholderText = "Enter Name For Project";
            this.txtProjectName.Size = new System.Drawing.Size(238, 23);
            this.txtProjectName.TabIndex = 78;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 15);
            this.label8.TabIndex = 77;
            this.label8.Text = "Tile Dimensions:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(112, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 15);
            this.label7.TabIndex = 76;
            this.label7.Text = "This can be changed after creation";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(196, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 74;
            this.label5.Text = "height";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(112, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 73;
            this.label6.Text = "width";
            // 
            // txtTileHeight
            // 
            this.txtTileHeight.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtTileHeight.Enabled = false;
            this.txtTileHeight.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTileHeight.Location = new System.Drawing.Point(243, 130);
            this.txtTileHeight.MaxLength = 1;
            this.txtTileHeight.Name = "txtTileHeight";
            this.txtTileHeight.Size = new System.Drawing.Size(28, 23);
            this.txtTileHeight.TabIndex = 72;
            this.txtTileHeight.Text = "51";
            // 
            // txtTileWidth
            // 
            this.txtTileWidth.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtTileWidth.Enabled = false;
            this.txtTileWidth.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTileWidth.Location = new System.Drawing.Point(155, 130);
            this.txtTileWidth.MaxLength = 1;
            this.txtTileWidth.Name = "txtTileWidth";
            this.txtTileWidth.Size = new System.Drawing.Size(27, 23);
            this.txtTileWidth.TabIndex = 71;
            this.txtTileWidth.Text = "51";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 70;
            this.label3.Text = "Map Size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 69;
            this.label2.Text = "Project Name:";
            // 
            // txtDefaultChar
            // 
            this.txtDefaultChar.Location = new System.Drawing.Point(112, 99);
            this.txtDefaultChar.MaxLength = 1;
            this.txtDefaultChar.Name = "txtDefaultChar";
            this.txtDefaultChar.Size = new System.Drawing.Size(25, 23);
            this.txtDefaultChar.TabIndex = 68;
            this.txtDefaultChar.Text = "?";
            this.txtDefaultChar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 67;
            this.label1.Text = "Empty Tile:";
            // 
            // lblH
            // 
            this.lblH.AutoSize = true;
            this.lblH.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblH.Location = new System.Drawing.Point(196, 52);
            this.lblH.Name = "lblH";
            this.lblH.Size = new System.Drawing.Size(41, 15);
            this.lblH.TabIndex = 66;
            this.lblH.Text = "height";
            // 
            // lblW
            // 
            this.lblW.AutoSize = true;
            this.lblW.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblW.Location = new System.Drawing.Point(112, 52);
            this.lblW.Name = "lblW";
            this.lblW.Size = new System.Drawing.Size(37, 15);
            this.lblW.TabIndex = 64;
            this.lblW.Text = "width";
            // 
            // txtMapHeight
            // 
            this.txtMapHeight.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMapHeight.Location = new System.Drawing.Point(243, 49);
            this.txtMapHeight.MaxLength = 3;
            this.txtMapHeight.Name = "txtMapHeight";
            this.txtMapHeight.Size = new System.Drawing.Size(28, 23);
            this.txtMapHeight.TabIndex = 63;
            this.txtMapHeight.Text = "1";
            // 
            // txtMapWidth
            // 
            this.txtMapWidth.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMapWidth.Location = new System.Drawing.Point(155, 49);
            this.txtMapWidth.MaxLength = 3;
            this.txtMapWidth.Name = "txtMapWidth";
            this.txtMapWidth.Size = new System.Drawing.Size(35, 23);
            this.txtMapWidth.TabIndex = 62;
            this.txtMapWidth.Text = "1";
            // 
            // btnWizNext
            // 
            this.btnWizNext.Location = new System.Drawing.Point(357, 188);
            this.btnWizNext.Name = "btnWizNext";
            this.btnWizNext.Size = new System.Drawing.Size(75, 23);
            this.btnWizNext.TabIndex = 4;
            this.btnWizNext.Text = "&Next >";
            this.btnWizNext.UseVisualStyleBackColor = true;
            this.btnWizNext.Click += new System.EventHandler(this.btnWizNext_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(276, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "< &Back";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // openFolderDialog
            // 
            this.openFolderDialog.FileName = "openFileDialog1";
            // 
            // openRootFolderDialog
            // 
            this.openRootFolderDialog.FileName = "openFileDialog2";
            // 
            // lblNewSaveFolder
            // 
            this.lblNewSaveFolder.AutoSize = true;
            this.lblNewSaveFolder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblNewSaveFolder.Location = new System.Drawing.Point(108, 27);
            this.lblNewSaveFolder.Name = "lblNewSaveFolder";
            this.lblNewSaveFolder.Size = new System.Drawing.Size(210, 15);
            this.lblNewSaveFolder.TabIndex = 89;
            this.lblNewSaveFolder.Text = "A project subfolder will be created here";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(8, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 88;
            this.label4.Text = "Save Folder:";
            // 
            // chkCopyTiles
            // 
            this.chkCopyTiles.AutoSize = true;
            this.chkCopyTiles.Location = new System.Drawing.Point(108, 129);
            this.chkCopyTiles.Name = "chkCopyTiles";
            this.chkCopyTiles.Size = new System.Drawing.Size(158, 19);
            this.chkCopyTiles.TabIndex = 90;
            this.chkCopyTiles.Text = "Copy Tiles To Save Folder";
            this.chkCopyTiles.UseVisualStyleBackColor = true;
            // 
            // Wizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 216);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnWizNext);
            this.Controls.Add(this.pnlProjectDetails);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Wizard";
            this.Text = "New Project";
            this.pnlProjectDetails.ResumeLayout(false);
            this.pnlProjectDetails.PerformLayout();
            this.pnlWizTiles.ResumeLayout(false);
            this.pnlWizTiles.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private AdvancedWizardControl.WizardPages.AdvancedWizardPage wiz01_intro;
        private AdvancedWizardControl.WizardPages.AdvancedWizardPage wiz02_tiles;
        private AdvancedWizardControl.WizardPages.AdvancedWizardPage wiz03_charset;
        private System.Windows.Forms.Panel pnlProjectDetails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDefaultChar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblH;
        private System.Windows.Forms.Label lblW;
        private System.Windows.Forms.TextBox txtH;
        private System.Windows.Forms.TextBox txtW;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnWizNext;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Panel pnlWizTiles;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTileHeight;
        private System.Windows.Forms.TextBox txtTileWidth;
        private System.Windows.Forms.TextBox txtMapHeight;
        private System.Windows.Forms.TextBox txtMapWidth;
        private System.Windows.Forms.Button btnTileFolder;
        private System.Windows.Forms.TextBox txtTileRepoPath;
        private System.Windows.Forms.OpenFileDialog openFolderDialog;
        private System.Windows.Forms.OpenFileDialog openRootFolderDialog;
        private System.Windows.Forms.Label lblNewSaveFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkCopyTiles;
    }
}