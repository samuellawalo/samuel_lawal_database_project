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
    public partial class frmBrowseContacts : Form
    {
        public frmBrowseContacts()
        {
            InitializeComponent();
        }



        private void LoadContacts()
        {
            string sql = $@"SELECT * FROM Groups ORDER BY GroupName";

            DataTable dtGroups = DataAccess.GetData(sql);

            cmbGroups.Bind("GroupName", "GroupId", dtGroups, addEmptyRow: true, defaultEmptyRowText: "-- Select a Group --");
        }

        private void frmBrowseContacts_Load(object sender, EventArgs e)
        {
            dgvContacts.Visible = false;
            LoadContacts();
        }

        private void btnBrowseContact_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbGroups.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please select a group.");
                    return;
                }

                int groupId = Convert.ToInt32(cmbGroups.SelectedValue);
                string sql = $@"SELECT Contacts.ContactId, Contacts.ContactName, Contacts.PhoneNumber, Contacts.Email, Contacts.Description, Contacts.Address
                       FROM Contacts
                       INNER JOIN ContactGroups ON Contacts.ContactId = ContactGroups.ContactId
                       WHERE ContactGroups.GroupId = {groupId}";

                DataTable dtContacts = DataAccess.GetData(sql);

                if (dtContacts.Rows.Count > 0)
                {
                    dgvContacts.Visible = true;
                    dgvContacts.DataSource = dtContacts;
                    dgvContacts.ReadOnly = true;
                    dgvContacts.AutoResizeColumns();
                    dgvContacts.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    dgvContacts.DataSource = null;
                    dgvContacts.Visible = false;
                    MessageBox.Show("There were no contacts found in the selected group.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

    }
}
}
