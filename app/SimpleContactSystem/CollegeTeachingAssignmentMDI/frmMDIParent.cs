using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleContactSystem
{
    public partial class frmMDIParent : Form
    {
        private int childFormNumber = 0;

        public frmMDIParent()
        {
            InitializeComponent();
        }


        private void frmMDIParent_Load(object sender, EventArgs e)
        {
            Splash splash = new Splash();
            frmLogin login = new frmLogin();


            splash.ShowDialog();

            if (splash.DialogResult != DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                login.ShowDialog();
            }

            if (login.DialogResult != DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                this.Show();
            }
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form? childForm = null;

            //tool strip menu item is the top bar
            ToolStripItem? item = sender as ToolStripItem;

            if (item == null)
                return;

            switch (item.Tag?.ToString()?.ToLower())
            {
                case "contacts":
                    childForm = new frmContactDetails();
                    break;
                case "contactgroups":
                    childForm = new frmContactGroups();
                    break;
                case "browsecontacts":
                    childForm = new frmBrowseContacts();
                    break;
            }

            //if form is not empty
            if (childForm != null)
            {
                // Every form in the child form
                foreach (Form form in this.MdiChildren)
                {
                    //if same form is selected reactivate it
                    if (form.GetType() == childForm.GetType())
                    {
                        form.Activate();
                        return;
                    }
                }
                //make new form br created inside the MDI
                childForm.MdiParent = this;
                childForm.Show();
            }




            //Form childForm = new Form();
            //childForm.MdiParent = this;
            //childForm.Text = "Window " + childFormNumber++;
            //childForm.Show();
        }



        private void ShowNewFormTest(object sender)
        {

        }
        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }


        public void DisplayStatusMessage(string message)
        {
            DisplayStatusMessage(message, Color.Black);
        }

        public void DisplayStatusMessage(string message, Color color)
        {
            this.toolStripStatusLabel.Text = message;
            this.toolStripStatusLabel.ForeColor = color;
        }
    }
}
