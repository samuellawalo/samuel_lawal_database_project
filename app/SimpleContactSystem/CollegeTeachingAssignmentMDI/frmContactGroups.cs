using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleContactSystem
{
    public partial class frmContactGroups : Form
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
        public frmContactGroups()
        {
            InitializeComponent();
        }

        private void frmContactGroups_Load(object sender, EventArgs e)
        {
            LoadFirstGroup();
            SetState(FormState.View);
        }


        #region Event Handler

        private void Navigation_Handler(object sender, EventArgs e)
        {
            
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
            DisplayCurrentGroup();

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetState(FormState.Add);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Group?", "Are you sure",
               MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DeleteGroup();
                LoadFirstGroup();
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
                        if (txtGroupId.Text == string.Empty)
                        {
                            // Add group
                            CreateGroup();
                            LoadFirstGroup();
                        }
                        else
                        {
                            // Edit group
                            UpdateGroup();
                        }

                        SetState(FormState.View);
                    }
                    else
                    {
                        MessageBox.Show("Please resolve your validation errors.");
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
            DisplayCurrentGroup();
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
            txtGroupName.ReadOnly = readOnly;
            txtDescription.ReadOnly = readOnly;
            txtMaxContacts.ReadOnly = readOnly;
        }
        #endregion


        #region Load Data

        private void LoadFirstGroup()
        {
            currentId = GetFirstGroupId();
            LoadCurrentPosition();
            DisplayCurrentGroup();
        }

        private void LoadCurrentPosition()
        {
            DataRow positionInfoRow = GetPositionDataRow(currentId);
            LoadPositionInfo(positionInfoRow);
            NavigationButtonManagement();

        }

        private void LoadPositionInfo(DataRow groupRow)
        {
            int groupCount = Convert.ToInt32(groupRow["GroupCount"]);
            currentId = Convert.ToInt32(groupRow["GroupId"]);
            firstId = Convert.ToInt32(groupRow["FirstGroupId"]);
            lastId = Convert.ToInt32(groupRow["LastGroupId"]);
            rowNumber = Convert.ToInt32(groupRow["RowNumber"]);

            nextId = groupRow["NextGroupId"] != DBNull.Value ?
                Convert.ToInt32(groupRow["NextGroupId"]) : (int?)null;

            previousId = groupRow["PreviousGroupId"] != DBNull.Value ?
                Convert.ToInt32(groupRow["PreviousGroupId"]) : (int?)null;

            this.DisplayParentStatusStripMessage($"Displaying group {rowNumber} out of {groupCount}");
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

        private void DisplayCurrentGroup()
        {
            DataRow currentGroupRow = GetGroupDataRow(currentId);
            if (currentGroupRow != null)
            {
                DisplayGroup(currentGroupRow);
            }
            else
            {
                // Handle the case where the group with the current ID doesn't exist
                MessageBox.Show("Group not found.");
            }
        }

        private void DisplayGroup(DataRow selectedGroup)
        {
            txtGroupId.Text = selectedGroup["GroupId"].ToString();
            txtGroupName.Text = selectedGroup["GroupName"].ToString();
            txtDescription.Text = selectedGroup["Description"].ToString();
            txtMaxContacts.Text = selectedGroup["MaxContacts"].ToString();
        }

        #endregion



        #region Send Data

        private void UpdateGroup()
        {
            // Build the SQL update command using the values from the text boxes.
            string sqlUpdateGroup = $@"
    UPDATE Groups
    SET GroupName = '{txtGroupName.Text.Trim()}',
        Description = '{txtDescription.Text.Trim()}',
        MaxContacts = {txtMaxContacts.Text.Trim()}
    WHERE GroupId = {txtGroupId.Text}";

            // This line is for debugging purposes and does not affect the application.
            Debug.WriteLine(sqlUpdateGroup);

            // Execute the SQL update command and get the number of affected rows.
            int rowsAffected = DataAccess.SendData(sqlUpdateGroup);

            // Display a message to the user based on the number of affected rows.
            if (rowsAffected == 0)
            {
                MessageBox.Show("The database reported no rows affected, meaning the changes weren't sent.");
            }
            else if (rowsAffected == 1)
            {
                MessageBox.Show("Group updated successfully.");
            }
            else
            {
                // This condition should not normally occur but handles unexpected cases.
                MessageBox.Show("Something went wrong, please verify.");
            }
        }


        private void CreateGroup()
        {
            string sqlInsertGroup = $@"
    INSERT INTO Groups
    (
        GroupName,
        Description,
        MaxContacts
    )
    VALUES
    (
        '{txtGroupName.Text.Trim()}',
        '{txtDescription.Text.Trim()}',
        {txtMaxContacts.Text.Trim()}
    )";

            int rowsAffected = DataAccess.SendData(sqlInsertGroup);

            if (rowsAffected == 1)
            {
                MessageBox.Show("Group created.");
            }
            else
            {
                MessageBox.Show("The database reported no rows affected.");
            }
        }


        private void DeleteGroup()
        {
            string groupId = txtGroupId.Text;
            int contactGroups = Convert.ToInt32(DataAccess.GetValue($"SELECT COUNT(1) FROM ContactGroups WHERE GroupId = {groupId}"));

            if (contactGroups == 0)
            {
                string sqlDelete = $"DELETE FROM Groups WHERE GroupId = {groupId}";

                int rowsAffected = DataAccess.SendData(sqlDelete);

                if (rowsAffected == 1)
                {
                    MessageBox.Show("Group was deleted.");
                }
                else
                {
                    MessageBox.Show("The database reported no rows affected.");
                }
            }
            else
            {
                MessageBox.Show("This group could not be deleted because it still has contacts assigned to it.");
            }
        }

        #endregion

        #region Get Data Row

        private int GetFirstGroupId()
        {
            int id = Convert.ToInt32(DataAccess.GetValue("SELECT TOP (1) GroupId FROM Groups ORDER BY GroupName"));
            return id;
        }


        private DataRow GetGroupDataRow(int id)
        {
            string sqlGroupById = $"SELECT * FROM Groups WHERE GroupId = {id}";

            DataTable dt = DataAccess.GetData(sqlGroupById);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            else
            {
                return null; // Return null if no group with the specified ID is found
            }
        }


        private DataRow GetPositionDataRow(int id)
        {
            string sqlNav = $@"
SELECT 
(SELECT COUNT(1) FROM Groups) AS groupCount,
GroupId,
(
    SELECT TOP(1) GroupId AS FirstGroupId FROM Groups ORDER BY GroupName
) AS FirstGroupId,
q.PreviousGroupId,
q.NextGroupId,
(
    SELECT TOP(1) GroupId AS LastGroupId FROM Groups ORDER BY GroupName DESC
) AS LastGroupId,
q.RowNumber
FROM
(
    SELECT GroupId, GroupName,
    LEAD(GroupId) OVER(ORDER BY GroupName) AS NextGroupId,
    LAG(GroupId) OVER(ORDER BY GroupName) AS PreviousGroupId,
    ROW_NUMBER() OVER(ORDER BY GroupName) AS 'RowNumber'
    FROM Groups
) AS q
WHERE q.GroupId = {id}
ORDER BY q.GroupName";

            DataTable dt = DataAccess.GetData(sqlNav);

            return dt.Rows[0];
        }


        #endregion

        #region Validation

        // Validate and ensure that fields are filled before moving to the next
        private void txt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string? errMsg = null;

            if (txt.Text == string.Empty)
            {
                errMsg = $"{txt.Tag} is required.";
                e.Cancel = true;
            }
            else if (sender == txtMaxContacts)
            {
                if (!IsNumeric(txt.Text))
                {
                    errMsg = $"{txt.Tag} must be numeric.";
                    e.Cancel = true;
                }
            }

          //  errorProvider.SetError(txt, errMsg);
        }

        // Check if a string value is numeric
        private bool IsNumeric(string value)
        {
            return int.TryParse(value, out _);
        }

        #endregion

    }
}
