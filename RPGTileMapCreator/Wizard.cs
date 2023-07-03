using Newtonsoft.Json;
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

        public ProjectFile project;

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
                // create folder under c:\..profile
                string projectFilePath = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\RPGTIleMapCreator\\" + txtProjectName.Text + "_" + DateTime.Now.ToString("yyyyMMddHHmmssFFF");

                Directory.CreateDirectory(projectFilePath);

                int rows = int.Parse(txtMapHeight.Text);
                int cols = int.Parse(txtMapWidth.Text);
                int tileWidth = int.Parse(txtTileWidth.Text);
                int tileHeight = int.Parse(txtTileHeight.Text);

                // save map file - all ?s
                //File.Create(projectFilePath + "\\" + txtProjectName.Text + ".rpg");

                // create json for file
                project = new ProjectFile
                {
                    ProjectFolder = projectFilePath,
                    MapFile = projectFilePath + "\\" + txtProjectName.Text + ".map",
                    TileFolder = projectFilePath + "\\tiles",
                    TileSettingsFile = projectFilePath + "\\tilesettings.json",
                    ProjectName = txtProjectName.Text,
                    EmptyTileCharacter = txtDefaultChar.Text,
                    StartingWidth = rows,
                    StartingHeight = cols,
                    TileWidth = tileWidth,
                    TileHeight = tileHeight
                };

                using (StreamWriter file = File.CreateText(projectFilePath + "\\" + txtProjectName.Text + ".rpg"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, project);
                }

                // Create map file
                using (StreamWriter streamWeaver = new StreamWriter(project.MapFile))
                {
                    for (int i = 0; i < rows; i++)
                    {
                        streamWeaver.WriteLine(CraftNewLine(rows));

                    }
                }

                // tile settings - blank
                File.Create(project.TileSettingsFile);

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
                // show save folder in label
                // create blank tilesetting file

                // if chkTilesCopy - copy tiles folder to save folder
                // update the rpg file

                if (chkCopyTiles.Checked)
                {
                    Directory.CreateDirectory(project.TileFolder);

                    //Copy all the files & Replaces any files with the same name
                    foreach (string newFile in Directory.GetFiles(txtTileRepoPath.Text, "*.*", SearchOption.AllDirectories))
                    {
                        File.Copy(newFile, project.TileFolder + "\\" + Path.GetFileName(newFile));
                    }
                }
                else
                {
                    project.TileFolder = txtTileRepoPath.Text;
                }

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

        private string CraftNewLine(int width)
        {
            string returnLine = "";

            for (int i = 1; i < width; i++)
            {
                returnLine += txtDefaultChar.Text;
            }

            return returnLine;
        }
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (pnlWizTiles.Visible)
        //    {
        //        pnlWizTiles.Visible = false;
        //        pnlProjectDetails.Visible = true;
        //        pnlProjectDetails.BringToFront();
        //        button1.Text = "< &Back";
        //    }

        //}

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
            }
        }
    }
}
