using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleContactSystem
{
    public static class UIUtilities
    {
        public static void ClearControls(this Control.ControlCollection controlsCollection, int defaultSelectedIndex = 0)
        {
            foreach (Control control in controlsCollection)
            {
                switch (control)
                {
                    case TextBox textBox:
                        textBox.Text = string.Empty;
                        break;
                    case RadioButton radioButton:
                        radioButton.Checked = false;
                        break;
                    case CheckBox checkBox:
                        checkBox.Checked = false;
                        break;
                    case ComboBox combo:
                        combo.SelectedIndex = defaultSelectedIndex;
                        break;
                    case ListBox listBox:
                        listBox.SelectedIndex = defaultSelectedIndex;
                        break;
                    case GroupBox groupBox:
                        ClearControls(groupBox.Controls);
                        break;
                }
            }
        }


        public static void Bind(this ComboBox cmb, string displayMember, string valueMember, DataTable dataSource,
   bool addEmptyRow = false, string defaultEmptyRowText = "")
        {
            if (addEmptyRow)
            {
                AddEmptyRow(dataSource, displayMember, valueMember, defaultEmptyRowText);
            }

            cmb.DataSource = dataSource;
            cmb.ValueMember = valueMember;
            cmb.DisplayMember = displayMember;
        }

        public static void ClearChildControls(this Control control, int defaultSelectedIndex = 0)
        {
            ClearControls(control.Controls, defaultSelectedIndex); ;
        }

        //public static void AddEmptyRow(this DataTable dt, string emptyColumn, string nullColumn, string cmbDisplay)
        //{
        //    DataRow dr = dt.NewRow();
        //    dr[emptyColumn] = string.Empty;
        //    dr[emptyColumn] = cmbDisplay;
        //    dr[nullColumn] = DBNull.Value;
        //    dt.Rows.InsertAt(dr, 0);
        //}
        public static void AddEmptyRow(this DataTable dt, string emptyColumnName, string nullColumnName, string? emptyText = "", object? emptyValue = null)
        {
            if (emptyValue == null)
            {
                emptyValue = DBNull.Value;
            }

            DataRow dr = dt.NewRow();
            dr[nullColumnName] = emptyValue;
            dr[emptyColumnName] = emptyText;
            dt.Rows.InsertAt(dr, 0);
        }
        //public static void AddEmptyRow(this DataTable dt, string displayMember, string valueMember, string defaultText = "")
        //{
        //    DataRow dr = dt.NewRow();
        //    dr[displayMember] = defaultText;
        //    dr[valueMember] = DBNull.Value;
        //    dt.Rows.InsertAt(dr, 0);
        //}

        public static void DisplayParentStatusStripMessage(this Form form, string message)
        {
            DisplayParentStatusStripMessage(form, message, Color.Black);
        }

        public static void DisplayParentStatusStripMessage(Form form,string message, Color color)
        {

            frmMDIParent? parentMdi = form.MdiParent as frmMDIParent;

            if (parentMdi != null)
            {
                parentMdi.DisplayStatusMessage(message);
            }
        }
    }

    
}
