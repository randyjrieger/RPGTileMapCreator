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
    public partial class Wizard : Form
    {
        public event EventHandler<EventArgs> ProjectInfoReady;

        public Project ProjectInfo
        {
            get { return projectInfo; }
            set { projectInfo = value; }
        }

        private Project projectInfo;

        public Wizard()
        {
            InitializeComponent();

            pnlProjectDetails.Location = new Point(12, 2);
            pnlProjectDetails.Visible = true;
            foreach (Control c in pnlProjectDetails.Controls)
            {
                c.Visible = true;
            }
            pnlWizTiles.Parent = this;
            pnlWizTiles.Location = new Point(12, 2);
            pnlWizTiles.Visible = false;
            foreach (Control c in pnlWizTiles.Controls)
            {
                c.Visible = false;
            }
            pnlProjectDetails.BringToFront();
            // PanelVisible(pnlProjectDetails);
        }

        private bool AreMandatoryFieldsEntered()
        {/*
            if (IsEmpty(txtProjectName.Text))
            {
                MessageBox.Show("Project Name must be entered");
                return false;
            }
            else if (IsEmpty(txtSaveFolder.Text))
            {
                MessageBox.Show("Save Folder must be entered");
                return false;
            }
            else if (IsEmpty(txtTileRepoFolder.Text))
            {
                MessageBox.Show("Tile Repository Folder must be entered");
                return false;
            }
            else if (IsEmpty(txtWidth.Text))
            {
                MessageBox.Show("Map Starting Width must be entered");
                return false;
            }
            else if (IsEmpty(txtHeight.Text))
            {
                MessageBox.Show("Map Starting Height must be entered");
                return false;
            }
            else if (IsEmpty(txtTileRepoFolder.Text))
            {
                MessageBox.Show("Tile Repository Folder must be entered");
                return false;
            }*/

            return true;
        }

        protected virtual void OnProjectInfoReady(EventArgs e)
        {
            EventHandler<EventArgs> eh = ProjectInfoReady;
            if (eh != null)
            {
                eh(this, e);
            }
        }

        private void btnWizNext_Click(object sender, EventArgs e)
        {
            if (pnlProjectDetails.Visible)
            {
                pnlProjectDetails.Visible = false;
                foreach (Control c in pnlProjectDetails.Controls)
                {
                    c.Visible = false;
                }

                pnlWizTiles.Visible = true;
                foreach (Control c in pnlWizTiles.Controls)
                {
                    c.Visible = true;
                }
                pnlWizTiles.BringToFront();
                pnlWizTiles.Location = new Point(12, 2);
                btnWizNext.Text = "&Create";
            }
            else if (pnlWizTiles.Visible)
            {
                /*
                if (!AreMandatoryFieldsEntered())
                {
                    return;
                }*/

                projectInfo = new Project
                {
                    ProjectName = txtProjectName.Text,
                    ProjectFolder = txtProjectName.Text,
                    TileFolderPath = txtTileRepoPath.Text,
                    StartingWidth = int.Parse(txtMapWidth.Text),
                    StartingHeight = int.Parse(txtMapHeight.Text),
                    EmptyTileCharacter = txtDefaultChar.Text,
                    TileWidth = 51,
                    TileHeight = 51
                };

                OnProjectInfoReady(e);
                this.Close();
            }
            /*


            if (wiz01_intro.Visible)
            {
                wiz02_tiles.Visible = true;
                wiz01_intro.Visible = false;

            }
            else if (wiz02_tiles.Visible)
            {
                wiz03_charset.Visible = true;
                wiz02_tiles.Visible = false;

            }
            else if (wiz03_charset.Visible)
            {
                this.Close();

            }
            */
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (pnlWizTiles.Visible)
            {
                pnlWizTiles.Visible = false;
                pnlProjectDetails.Visible = true;
                pnlProjectDetails.BringToFront();
                button1.Text = "< &Back";
            }

        }

        private void btnTileFolder_Click(object sender, EventArgs e)
        {
            string tileRepoFolder = "";

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    tileRepoFolder = fbd.SelectedPath;
                }

                txtTileRepoPath.Text = tileRepoFolder;
            }
        }

        private void btnRootFolder_Click(object sender, EventArgs e)
        {
            string projectFolder = "";

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    projectFolder = fbd.SelectedPath;
                }

                txtRootFolder.Text = projectFolder;
            }
        }
    }
}
