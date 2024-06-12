using System.Data;
using System.Diagnostics;
using System.Timers;

namespace SimpleContactSystem
{


    public partial class frmContactDetails : Form
    {
        #region Private Fields

        private int currentId;
        private int firstId;
        private int lastId;
        private int? nextId;
        private int? previousId;
        private int rowNumber;
        private FormState currentState;

        #endregion
        public frmContactDetails()
        {
            InitializeComponent();
        }

        #region Event Handler


        private void frmCourses_Load(object sender, EventArgs e)
        {
            LoadGroups();
            LoadFirstCourse();
            SetState(FormState.View);
          
        }

        private void Navigation_Handler(object sender, EventArgs e)
        {
            LoadContactGroups(currentId);

            if (sender == btnFirst)
            {
                currentId = firstId;
            }
            else if (sender == btnLast)
            {
                currentId = lastId;
            }
            else if (sender == btnNext)
            {
                if (nextId != null)
                    currentId = nextId.Value;
                else
                    MessageBox.Show("The last  is currently displayed");

            }
            else if (sender == btnPrevious)
            {
                if (previousId != null)
                    currentId = previousId.Value;
                else
                    MessageBox.Show("The first  is currently displayed");
            }
            else
            {
                return;
            }

            LoadCurrentPosition();
            DisplayCurrentContact();

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetState(FormState.Add);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Contact?", "Are you sure",
               MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DeleteContact();
                LoadFirstCourse();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentState == FormState.View)
                {
                    SetState(FormState.Edit);
                }
                else
                {
                    if (ValidateChildren())
                    {
                        if (txtContactId.Text == string.Empty)
                        {
                            //add course
                            CreateContact();
                            LoadFirstCourse();
                        }
                        else
                        {
                            //edit courses
                            UpdateContact();

                        }

                        SetState(FormState.View);
                    }

                    else
                    {
                        MessageBox.Show("please resolve your validation error ");
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetState(FormState.View);
            DisplayCurrentContact();
        }

        #endregion

        #region FormState
        private void SetState(FormState state)
        {
            currentState = state;
            LoadState(state);
        }

        private void LoadState(FormState state)
        {
            if (state == FormState.View)
            {
                btnAdd.Enabled = true;
                btnCancel.Enabled = false;
                btnDelete.Enabled = true;
                btnSave.Text = "Edit";
                InputsReadOnly(true);
                NavigationButtonManagement();
            }
            else
            {
                btnAdd.Enabled = false;
                btnCancel.Enabled = true;
                btnDelete.Enabled = false;
                btnSave.Text = "Save";
                InputsReadOnly(false);

                //clearing the form when on add 
                if (state == FormState.Add)
                {
                    //UIUtilities.ClearControls(grpCourses.Controls);
                    grpCourses.Controls.ClearControls();
                }
                DisableNavigation();
            }
        }

        private void InputsReadOnly(bool readOnly)
        {
            txtContactName.ReadOnly = readOnly;
            txtPhoneNumber.ReadOnly = readOnly;
            txtEmail.ReadOnly = readOnly;
            txtDescription.ReadOnly = readOnly;
            txtAddress.ReadOnly = readOnly;
        }



        #endregion

        #region Load Data

        private void LoadFirstCourse()
        {
            currentId = GetFirstContactId();
            LoadCurrentPosition();
            DisplayCurrentContact();
            LoadContactGroups(currentId);


        }


        private void LoadGroups()
        {
            // SQL query to select all groups ordered by GroupName
            string sql = "SELECT GroupId, GroupName FROM Groups ORDER BY GroupName";

            // Retrieve the data from the database
            DataTable dtGroups = DataAccess.GetData(sql);

            // Clear existing items
            clbGroups.Items.Clear();

            // Add groups to the CheckedListBox
            foreach (DataRow row in dtGroups.Rows)
            {
                clbGroups.Items.Add(new GroupItem
                {
                    GroupId = Convert.ToInt32(row["GroupId"]),
                    GroupName = row["GroupName"].ToString()
                }, false);
            }
            LoadContactGroups(currentId);
        }



        private void LoadContactGroups(int contactId)
        {
            // First, clear any previously checked items
            for (int i = 0; i < clbGroups.Items.Count; i++)
            {
                clbGroups.SetItemChecked(i, false);
            }

            // Get the groups associated with the selected contact
            string sql = $@"SELECT GroupId FROM ContactGroups WHERE ContactId = {contactId}";
            DataTable dtContactGroups = DataAccess.GetData(sql);

            // Check the items in the CheckedListBox that match the contact's groups
            foreach (DataRow row in dtContactGroups.Rows)
            {
                int groupId = (int)row["GroupId"];
                for (int i = 0; i < clbGroups.Items.Count; i++)
                {
                    dynamic item = clbGroups.Items[i];
                    if (item.GroupId == groupId)
                    {
                        clbGroups.SetItemChecked(i, true);
                        break;
                    }
                }
            }
        }


        private void LoadCurrentPosition()
        {
            DataRow positionInfoRow = GetPositionDataRow(currentId);
            LoadPositionInfo(positionInfoRow);
            NavigationButtonManagement();

        }

        private void LoadPositionInfo(DataRow contactRow)
        {
            int contactCount = Convert.ToInt32(contactRow["ContactCount"]);
            currentId = Convert.ToInt32(contactRow["ContactId"]);
            firstId = Convert.ToInt32(contactRow["FirstContactId"]);
            lastId = Convert.ToInt32(contactRow["LastContactId"]);
            rowNumber = Convert.ToInt32(contactRow["RowNumber"]);

            nextId = contactRow["NextContactId"] != DBNull.Value ?
                Convert.ToInt32(contactRow["NextContactId"]) : (int?)null;

            previousId = contactRow["PreviousContactId"] != DBNull.Value ?
                Convert.ToInt32(contactRow["PreviousContactId"]) : (int?)null;

            this.DisplayParentStatusStripMessage($"Display Count {rowNumber} out of {contactCount}");
        }


        #endregion

        #region Navigation Management

        private void DisableNavigation()
        {
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            btnFirst.Enabled = false;
            btnLast.Enabled = false;
        }

        private void NavigationButtonManagement()
        {
            btnPrevious.Enabled = previousId != null;
            btnNext.Enabled = nextId != null;

            btnFirst.Enabled = currentId != firstId;
            btnLast.Enabled = currentId != lastId;
        }

        #endregion

        #region Display DataRow

        private void DisplayCurrentContact()
        {
            DataRow currentContactRow = GetContactDataRow(currentId);
            if (currentContactRow != null)
            {
                DisplayContact(currentContactRow);
            }
            else
            {
                // Handle the case where the contact with the current ID doesn't exist
                MessageBox.Show("Contact not found.");
            }
        }

        private void DisplayContact(DataRow selectedContact)
        {
            txtContactId.Text = selectedContact["ContactId"].ToString();
            txtContactName.Text = selectedContact["ContactName"].ToString();
            txtPhoneNumber.Text = selectedContact["PhoneNumber"].ToString();
            txtEmail.Text = selectedContact["Email"].ToString();
            txtAddress.Text = selectedContact["Address"].ToString();
            txtDescription.Text = selectedContact["Description"].ToString();
        }


        #endregion

        #region Send Data

        private void UpdateContact()
        {
            // Build the SQL update command using the values from the text boxes.
            string sqlUpdateContact = $@"
    UPDATE Contacts
    SET ContactName = '{txtContactName.Text.Trim()}',
        PhoneNumber = '{txtPhoneNumber.Text.Trim()}',
        Email = '{txtEmail.Text.Trim()}',
        Address = '{txtAddress.Text.Trim()}',
        Description = '{txtDescription.Text.Trim()}'
    WHERE ContactId = {txtContactId.Text}";

            // This line is for debugging purposes and does not affect the application.
            Debug.WriteLine(sqlUpdateContact);

            // Execute the SQL update command and get the number of affected rows.
            int rowsAffected = DataAccess.SendData(sqlUpdateContact);

            // Display a message to the user based on the number of affected rows.
            if (rowsAffected == 0)
            {
                MessageBox.Show("The database reported no rows affected, meaning the changes weren't sent.");
            }
            else if (rowsAffected == 1)
            {
                MessageBox.Show("Contact updated successfully.");
            }
            else
            {
                // This condition should not normally occur but handles unexpected cases.
                MessageBox.Show("Something went wrong, please verify.");
            }

            UpdateContactGroups(currentId);
        }


        private void UpdateContactGroups(int contactId)
        {
            // First, delete the current groups for the contact
            string sqlDelete = $@"DELETE FROM ContactGroups WHERE ContactId = {contactId}";
            DataAccess.SendData(sqlDelete);

            // Insert the selected groups
            foreach (var item in clbGroups.CheckedItems)
            {
                dynamic group = item;
                int groupId = group.GroupId;
                string sqlInsert = $@"INSERT INTO ContactGroups (ContactId, GroupId) VALUES ({contactId}, {groupId})";
                DataAccess.SendData(sqlInsert);
            }
        }


        private void CreateContact()
        {
            string contactName = txtContactName.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string email = txtEmail.Text.Trim();
            string address = txtAddress.Text.Trim();
            string description = txtDescription.Text.Trim();

            // Prepare SQL command to insert contact
            string sqlInsertContact = $@"
        INSERT INTO Contacts
        (
            ContactName,
            PhoneNumber,
            Email,
            Address,
            Description
        )
        VALUES
        (
            '{contactName}',
            '{phoneNumber}',
            '{email}',
            '{address}',
            '{description}'
        );
        SELECT SCOPE_IDENTITY();"; // This retrieves the ID of the newly inserted contact

            try
            {
                // Insert the contact and retrieve its ID
                int contactId = Convert.ToInt32(DataAccess.GetValue(sqlInsertContact));

                // If the contact was successfully inserted, associate it with selected groups
                if (contactId > 0)
                {
                    foreach (var selectedGroup in GetSelectedGroups())
                    {
                        // Prepare SQL command to insert contact-group association
                        string sqlInsertContactGroup = $@"
                    INSERT INTO ContactGroups (ContactId, GroupId)
                    VALUES ({contactId}, {selectedGroup});";

                        // Insert the contact-group association
                        DataAccess.SendData(sqlInsertContactGroup);
                    }

                    MessageBox.Show("Contact created.");
                }
                else
                {
                    MessageBox.Show("Failed to create contact.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while creating the contact: {ex.Message}");
            }
        }

        // Method to retrieve selected groups from UI (example implementation)
        // Method to retrieve selected group IDs from a CheckedListBox
        private List<int> GetSelectedGroups()
        {
            List<int> selectedGroups = new List<int>();

            // Loop through each checked item in the CheckedListBox
            foreach (var itemIndex in clbGroups.CheckedIndices)
            {
                // Get the checked item
                var checkedItem = clbGroups.Items[(int)itemIndex];

                // Assuming each item's Tag property contains the group ID
                if (checkedItem is DataRowView rowView)
                {
                    // Adjust the following line based on how your DataRowView is structured
                    int groupId = Convert.ToInt32(rowView["GroupId"]);
                    selectedGroups.Add(groupId);
                }
            }

            return selectedGroups;
        }




        private void DeleteContact()
        {
            string contactId = txtContactId.Text;

            string sqlDeleteContactGroups = $"DELETE FROM ContactGroups WHERE ContactId = {contactId}";
            string sqlDeleteContact = $"DELETE FROM Contacts WHERE ContactId = {contactId}";

            try
            {
                // Delete associated contact groups first
                DataAccess.SendData(sqlDeleteContactGroups);

                // Then delete the contact
                int rowsAffected = DataAccess.SendData(sqlDeleteContact);

                if (rowsAffected == 1)
                {
                    MessageBox.Show("Contact was deleted.");
                }
                else
                {
                    MessageBox.Show("The database reported no rows affected.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the contact: {ex.Message}");
            }
        }



        #endregion

        #region Get Data Row

        private int GetFirstContactId()
        {
            int id = Convert.ToInt32(DataAccess.GetValue("SELECT TOP (1) ContactId FROM Contacts"));
            return id;
        }


        private DataRow GetContactDataRow(int id)
        {
            string sqlContactById = $"SELECT * FROM Contacts WHERE ContactId = {id}";

            DataTable dt = DataAccess.GetData(sqlContactById);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            else
            {
                return null; // Return null if no contact with the specified ID is found
            }
        }


        private DataRow GetPositionDataRow(int id)
        {
            string sqlNav = $@"
        SELECT 
        (SELECT COUNT(1) FROM Contacts) AS contactCount,
        ContactId,
        (
            SELECT TOP(1) ContactId AS FirstContactId FROM Contacts ORDER BY ContactId
        ) AS FirstContactId,
        q.PreviousContactId,
        q.NextContactId,
        (
            SELECT TOP(1) ContactId AS LastContactId FROM Contacts ORDER BY ContactId DESC
        ) AS LastContactId,
        q.RowNumber
        FROM
        (
            SELECT ContactId, ContactName,
            LEAD(ContactId) OVER(ORDER BY ContactId) AS NextContactId,
            LAG(ContactId) OVER(ORDER BY ContactId) AS PreviousContactId,
            ROW_NUMBER() OVER(ORDER BY ContactId) AS 'RowNumber'
            FROM Contacts
        ) AS q
        WHERE q.ContactId = {id}
        ORDER BY q.ContactName";

            DataTable dt = DataAccess.GetData(sqlNav);

            return dt.Rows[0];
        }


        #endregion


        #region Validation

        //fix error and make sure fields are filled before uyou move to the next
        private void txt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string? errMsg = null;

            // Validate required fields
            if (txt.Text == string.Empty)
            {
                errMsg = $"{txt.Tag} is required.";
                e.Cancel = true;
            }
            else if (txt == txtPhoneNumber)
            {
                // Validate phone number is numeric
                if (!IsNumeric(txt.Text))
                {
                    errMsg = $"{txt.Tag} must be numeric.";
                    e.Cancel = true;
                }
            }
            else if (txt == txtEmail)
            {
                // Validate email format
                if (!IsValidEmail(txt.Text))
                {
                    errMsg = $"{txt.Tag} must be a valid email address.";
                    e.Cancel = true;
                }
            }

            errorProvider.SetError(txt, errMsg);
        }

        private bool IsNumeric(string value)
        {
            // Remove non-numeric characters and check if the resulting string is numeric
            string numericOnly = new string(value.Where(char.IsDigit).ToArray());
            return long.TryParse(numericOnly, out _);
        }


        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        private void clbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentId > 0) // Ensure currentId is a valid integer
            {
                int contactId = currentId; 
                DataRow contactDataRow = GetContactDataRow(contactId);
                if (contactDataRow != null)
                {
                    DisplayContact(contactDataRow);
                    LoadContactGroups(contactId); // Load and check the contact's groups
                }
            }
        }






    }


    public class GroupItem
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public override string ToString()
        {
            return GroupName;
        }
    }
}
