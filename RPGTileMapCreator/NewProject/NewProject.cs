using RPGTileMapCreator.cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGTileMapCreator.NewProject
{

    public partial class NewProject : Form
    {
        public event EventHandler ProjectInfoReady;

        public Project ProjectInfo
        {
            get { return projectInfo; }
            set { projectInfo = value; }
        }

        private Project projectInfo;

        public NewProject()
        {
            InitializeComponent();
        }

        protected virtual void OnProjectInfoReady(EventArgs e)
        {
            EventHandler eh = ProjectInfoReady;
            if (eh != null)
            {
                eh(this, e);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            if (!AreMandatoryFieldsEntered())
            {
                return;
            }

            projectInfo = new Project
            {
                Name = txtProjectName.Text,
                MapFilePath = txtSaveFolder.Text,
                TileFolderPath = txtTileRepoFolder.Text,
                StartingWidth = int.Parse(txtWidth.Text),
                StartingHeight = int.Parse(txtHeight.Text)
            };

            OnProjectInfoReady(null);
        }

        public bool IsEmpty(string s)
        {
            return string.IsNullOrEmpty(s);
        }

        private bool AreMandatoryFieldsEntered()
        {
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
            }

            return true;
        }
    }
}
