using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BioMetrix;

namespace Snythite_Canteen
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtEmployeeNo.Text.Trim()=="")
            {
                MessageBox.Show("Please enter the employee number");
                txtEmployeeNo.Focus();
                return;
            }
            if (txtEmployeeName.Text.Trim()=="")
            {
                MessageBox.Show("Please enter the employee name");
                txtEmployeeNo.Focus();
                return;
            }
            if (cboDepartment.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a department");
                cboDepartment.SelectedIndex = -1;
                cboDepartment.Focus();
                return;
            }
             if (cboPayment.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a payment method");
                cboPayment.SelectedIndex = -1;
                cboPayment.Focus();
                return;
            }

             string query = "SELECT 1 FROM Employee WHERE Employee_Code='" + txtEmployeeNo.Text.ToString() + "'";
             DataTable dt = new DataTable();
             dt = (DataTable)Connections.Instance.ShowDataInGridView(query);
             if (dt.Rows.Count > 0 && txtEmployeeNo.Enabled ==true )
             {
                 MessageBox.Show("Employee number already exists");
                 txtEmployeeNo.Focus();
                 return;
             }

            DialogResult dialogResult = MessageBox.Show("Do you want to save the entry?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Employee";

                if (txtEmployeeNo.Enabled == true)
                {
                    cmd.Parameters.Add("@Employee_Id", SqlDbType.Int).Value = null;
                }
                else
                {
                    cmd.Parameters.Add("@Employee_Id", SqlDbType.Int).Value = txtEmployeeNo.Tag.ToString();
                }

                cmd.Parameters.Add("@Employee_Code", SqlDbType.VarChar).Value = txtEmployeeNo.Text.Trim();
                cmd.Parameters.Add("@Employee_Name", SqlDbType.VarChar).Value = txtEmployeeName.Text.Trim();
                cmd.Parameters.Add("@Department_ID", SqlDbType.Int).Value = cboDepartment.SelectedValue;
                cmd.Parameters.Add("@Payment_Mode_ID", SqlDbType.Int).Value = cboPayment.SelectedValue;

                if (chkActive.Checked == true)
                {
                    cmd.Parameters.Add("@Is_Active", SqlDbType.TinyInt).Value = 1;
                }
                else
                {
                    cmd.Parameters.Add("@Is_Active", SqlDbType.TinyInt).Value = 0;
                }

                cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = Connections.Instance.user_id;

                cmd.Parameters.Add("@Is_Delete", SqlDbType.TinyInt).Value = 0;
                if (chkBreakFast.Checked == true)
                {
                    cmd.Parameters.Add("@BreakFast_Enabled", SqlDbType.TinyInt).Value = 1;
                }
                else
                {
                    cmd.Parameters.Add("@BreakFast_Enabled", SqlDbType.TinyInt).Value = 0; 
                }
                if (chkLunch.Checked == true)
                {
                    cmd.Parameters.Add("@Lunch_Enabled", SqlDbType.TinyInt).Value = 1;
                }
                else
                {
                    cmd.Parameters.Add("@Lunch_Enabled", SqlDbType.TinyInt).Value = 0;
                }

                if (chkChapathi.Checked == true)
                {
                    cmd.Parameters.Add("@Chapathi_Enabled", SqlDbType.TinyInt).Value = 1;
                }
                else
                {
                    cmd.Parameters.Add("@Chapathi_Enabled", SqlDbType.TinyInt).Value = 0;
                }

                if (chkDinner.Checked == true)
                {
                    cmd.Parameters.Add("@Dinner_Enabled", SqlDbType.TinyInt).Value = 1;
                }
                else
                {
                    cmd.Parameters.Add("@Dinner_Enabled", SqlDbType.TinyInt).Value = 0;
                }
                if (chkDinnerChapathi.Checked == true)
                {
                    cmd.Parameters.Add("@Dinner_Chapathi_Enabled", SqlDbType.TinyInt).Value = 1;
                }
                else
                {
                    cmd.Parameters.Add("@Dinner_Chapathi_Enabled", SqlDbType.TinyInt).Value = 0;
                }

                if (ChkBreakFastRestrict.Checked == true)
                {
                    cmd.Parameters.Add("@BreakFast_RestrictTime", SqlDbType.DateTime).Value = DTBreakfast.Value;
                }
                else
                {
                    cmd.Parameters.Add("@BreakFast_RestrictTime", SqlDbType.DateTime).Value = null;
                }

                if (ChkLunchRestrict.Checked == true)
                {
                    cmd.Parameters.Add("@Lunch_RestrictTime", SqlDbType.DateTime).Value = DTLunch.Value;
                }
                else
                {
                    cmd.Parameters.Add("@Lunch_RestrictTime", SqlDbType.DateTime).Value = null;
                }

                if (ChkChapathiRestrict.Checked == true)
                {
                    cmd.Parameters.Add("@Chapathi_RestrictTime", SqlDbType.DateTime).Value = DTChapathi.Value;
                }
                else
                {
                    cmd.Parameters.Add("@Chapathi_RestrictTime", SqlDbType.DateTime).Value = null;
                }

                if (ChkDinnerRestrict.Checked == true)
                {
                    cmd.Parameters.Add("@Dinner_RestrictTime", SqlDbType.DateTime).Value = DTDinner.Value;
                }
                else
                {
                    cmd.Parameters.Add("@Dinner_RestrictTime", SqlDbType.DateTime).Value = null;
                }

                if (ChkDinnerChapathiRestrict.Checked == true)
                {
                    cmd.Parameters.Add("@Dinner_Chapathi_RestrictTime", SqlDbType.DateTime).Value = DTDinner.Value;
                }
                else
                {
                    cmd.Parameters.Add("@Dinner_Chapathi_RestrictTime", SqlDbType.DateTime).Value = null;
                }

                Connections.Instance.OpenConection();
                Connections.Instance.ExecuteProcedure(cmd);

                btnClear_Click(null, null);

                Connections.Instance.CloseConnection();
                cmd.Dispose();

            }
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEmployeeNo.Enabled = true;
            txtEmployeeNo.Text = "";
            txtEmployeeName.Text = "";
            txtEmployeeNo.Tag = "";
            cboDepartment.Text = "";
            cboDepartment.SelectedIndex = -1;
            cboPayment.Text = "";
            cboPayment.SelectedIndex = -1;
            chkBreakFast.Checked = true;
            chkLunch.Checked = true;
            chkDinner.Checked = true;
            chkDinnerChapathi.Checked = false;
            chkChapathi.Checked = false;

            ChkBreakFastRestrict.Checked = false;
            ChkLunchRestrict.Checked = false;
            ChkDinnerRestrict.Checked = false;
            ChkDinnerChapathiRestrict.Checked = false;
            ChkChapathiRestrict.Checked = false;

            DTBreakfast.Enabled = false;
            DTChapathi.Enabled = false;
            DTLunch.Enabled = false;
            DTDinner.Enabled = false;
            DTDinnerChapathi.Enabled = false;
            txtSearch.Text = "";
            EmployeeData();
            txtEmployeeNo.Focus();
        }

        private void ChkBreakFastRestrict_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkBreakFastRestrict.Enabled == true)
            {
                DTBreakfast.Enabled = true;
            }
            else
            {
                DTBreakfast.Enabled = false;
            }
        }

        private void ChkLunchRestrict_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkLunchRestrict.Enabled == true)
            {
                DTLunch.Enabled = true;
            }
            else
            {
                DTLunch.Enabled = false;
            }
        }

        private void ChkChapathiRestrict_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkChapathiRestrict.Enabled == true)
            {
                DTChapathi.Enabled = true;
            }
            else
            {
                DTChapathi.Enabled = false;
            }
        }

        private void ChkDinnerRestrict_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDinnerRestrict.Enabled == true)
            {
                DTDinner.Enabled = true;
            }
            else
            {
                DTDinner.Enabled = false;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            EmployeeData();
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {

        }

        private void Employee_Load(object sender, EventArgs e)
        {
            EmployeeData();
            DepartmentData();
            PaymentModeData();
        }

        private void EmployeeData()
        {
            GridView.DataSource = null;
            string query = "SELECT Employee_Id,Employee_Code,Employee_Name,D.Department_Id,D.Department_Code,P.ID,Payment_Mode,E.IS_Active FROM Employee E JOIN Department D ON D.Department_Id=E.Department_ID JOIN Payment_Mode P ON P.ID=E.Payment_Mode_Id WHERE E.Employee_Code LIKE '" + txtSearch.Text.Trim() + "%' OR E.Employee_Name like '%" + txtSearch.Text.Trim() + "%' ORDER BY 3";
            GridView.DataSource = Connections.Instance.ShowDataInGridView(query);
            GridView.Columns[0].Visible = false;
            GridView.Columns[3].Visible = false;
            GridView.Columns[5].Visible = false;
            GridView.Columns[6].Visible = false;
            GridView.Columns[7].Visible = false;
            
        }
        private void DepartmentData()
        {
            cboDepartment.DataSource = null;
            string query = "SELECT Department_ID,Department_Code FROM Department ORDER BY Department_Name";
            cboDepartment.DataSource = Connections.Instance.ShowDataInGridView(query);
            cboDepartment.DisplayMember = "Department_Code";
            cboDepartment.ValueMember = "Department_ID";
            cboDepartment.SelectedIndex = -1;
            cboDepartment.Text = "";
        }
        private void PaymentModeData()
        {
            cboPayment.DataSource = null;
            string query = "SELECT ID,Payment_Mode FROM Payment_Mode ORDER BY Payment_Mode";
            cboPayment.DataSource = Connections.Instance.ShowDataInGridView(query);
            cboPayment.DisplayMember = "Payment_Mode";
            cboPayment.ValueMember = "ID";
            cboPayment.SelectedIndex = -1;
            cboPayment.Text = "";
        }

        private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowno = e.RowIndex;
            txtEmployeeNo.Tag = GridView.Rows[rowno].Cells[0].Value.ToString();
            txtEmployeeNo.Text = GridView.Rows[rowno].Cells[1].Value.ToString();
            txtEmployeeName.Text = GridView.Rows[rowno].Cells[2].Value.ToString();
            cboDepartment.SelectedValue = GridView.Rows[rowno].Cells[3].Value.ToString();
            cboPayment.SelectedValue = GridView.Rows[rowno].Cells[5].Value.ToString();
            txtEmployeeNo.Enabled = false;

            if (GridView.Rows[rowno].Cells[7].Value.ToString() == "1")
            {
                chkActive.Checked = true;
            }
            else
            {
                chkActive.Checked = false;
            }

            string query = "SELECT MM.Is_Active,CASE WHEN MM.Time_Restriction IS NULL THEN 0 ELSE 1 END Restriction_Enabled, MM.Time_Restriction FROM Canteen_Menu_Mapping MM JOIN Canteen_Menu M ON M.Menu_Id=MM.Menu_Id WHERE MM.Employee_Id='" + txtEmployeeNo.Tag.ToString() + "' AND M.Menu_Code='BreakFast'";
            DataTable dt = new DataTable();
            dt = (DataTable)Connections.Instance.ShowDataInGridView(query);
            if (dt.Rows[0][0].ToString() == "1")
            {
                chkBreakFast.Checked = true;
            }
            else
            {
                chkBreakFast.Checked = false;

            }

            if (dt.Rows[0][1].ToString() == "1")
            {
                ChkBreakFastRestrict.Checked = true;
                DTBreakfast.Value = Convert.ToDateTime(dt.Rows[0][2].ToString());
                DTBreakfast.Enabled = true;

            }
            else
            {
                ChkBreakFastRestrict.Checked = false;
                DTBreakfast.Enabled = false;
            }

            dt.Clear();
            query = "SELECT MM.Is_Active,CASE WHEN MM.Time_Restriction IS NULL THEN 0 ELSE 1 END Restriction_Enabled, MM.Time_Restriction FROM Canteen_Menu_Mapping MM JOIN Canteen_Menu M ON M.Menu_Id=MM.Menu_Id WHERE MM.Employee_Id='" + txtEmployeeNo.Tag.ToString() + "' AND M.Menu_Code='Lunch'";
            dt = (DataTable)Connections.Instance.ShowDataInGridView(query);
            if (dt.Rows[0][0].ToString() == "1")
            {
                chkLunch.Checked = true;
            }
            else
            {
                chkLunch.Checked = false;

            }

            if (dt.Rows[0][1].ToString() == "1")
            {
                ChkLunchRestrict.Checked = true;
                DTLunch.Value = Convert.ToDateTime(dt.Rows[0][2].ToString());
                DTLunch.Enabled = true;

            }
            else
            {
                ChkLunchRestrict.Checked = false;
                DTLunch.Enabled = false;
            }


            query = "SELECT MM.Is_Active,CASE WHEN MM.Time_Restriction IS NULL THEN 0 ELSE 1 END Restriction_Enabled,MM.Time_Restriction FROM Canteen_Menu_Mapping MM JOIN Canteen_Menu M ON M.Menu_Id=MM.Menu_Id WHERE MM.Employee_Id='" + txtEmployeeNo.Tag.ToString() + "' AND M.Menu_Code='Chapathi'";
            dt.Clear();
            dt = (DataTable)Connections.Instance.ShowDataInGridView(query);

            if (dt.Rows[0][0].ToString() == "1")
            {
                chkChapathi.Checked = true;
            }
            else
            {
                chkChapathi.Checked = false;

            }

            if (dt.Rows[0][1].ToString() == "1")
            {
                ChkChapathiRestrict.Checked = true;
                DTChapathi.Value = Convert.ToDateTime(dt.Rows[0][2].ToString());
                DTChapathi.Enabled = true;

            }
            else
            {
                ChkChapathiRestrict.Checked = false;
                DTChapathi.Enabled = false;
            }

            query = "SELECT MM.Is_Active,CASE WHEN MM.Time_Restriction IS NULL THEN 0 ELSE 1 END Restriction_Enabled,MM.Time_Restriction FROM Canteen_Menu_Mapping MM JOIN Canteen_Menu M ON M.Menu_Id=MM.Menu_Id WHERE MM.Employee_Id='" + txtEmployeeNo.Tag.ToString() + "' AND M.Menu_Code='DINNER'";
            dt.Clear();
            dt = (DataTable)Connections.Instance.ShowDataInGridView(query);

            if (dt.Rows[0][0].ToString() == "1")
            {
                chkDinner.Checked = true;
            }
            else
            {
                chkDinner.Checked = false;

            }

            if (dt.Rows[0][1].ToString() == "1")
            {
                ChkDinnerRestrict.Checked = true;
                DTDinner.Value = Convert.ToDateTime(dt.Rows[0][2].ToString());
                DTDinner.Enabled = true;
            }
            else
            {
                ChkDinnerRestrict.Checked = false;
                DTDinner.Enabled = false;
            }


            query = "SELECT MM.Is_Active,CASE WHEN MM.Time_Restriction IS NULL THEN 0 ELSE 1 END Restriction_Enabled,MM.Time_Restriction FROM Canteen_Menu_Mapping MM JOIN Canteen_Menu M ON M.Menu_Id=MM.Menu_Id WHERE MM.Employee_Id='" + txtEmployeeNo.Tag.ToString() + "' AND M.Menu_Code='DINNER-CHAPATHI'";
            dt.Clear();
            dt = (DataTable)Connections.Instance.ShowDataInGridView(query);

            if (dt.Rows[0][0].ToString() == "1")
            {
                chkDinnerChapathi.Checked = true;
            }
            else
            {
                chkDinnerChapathi.Checked = false;

            }

            if (dt.Rows[0][1].ToString() == "1")
            {
                ChkDinnerChapathiRestrict.Checked = true;
                DTDinnerChapathi.Value = Convert.ToDateTime(dt.Rows[0][2].ToString());
                DTDinnerChapathi.Enabled = true;
            }
            else
            {
                ChkDinnerChapathiRestrict.Checked = false;
                DTDinnerChapathi.Enabled = false;
            }




        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (txtEmployeeNo.Enabled == true)
            {
                MessageBox.Show("Please select an employee to delete");
                txtEmployeeNo.Focus();
                return;
            }
           

            DialogResult dialogResult = MessageBox.Show("Do you want to delete the employee?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Employee";

                cmd.Parameters.Add("@Employee_Id", SqlDbType.Int).Value = txtEmployeeNo.Tag.ToString();


                cmd.Parameters.Add("@Employee_Code", SqlDbType.VarChar).Value = null;
                cmd.Parameters.Add("@Employee_Name", SqlDbType.VarChar).Value = null;
                cmd.Parameters.Add("@Department_ID", SqlDbType.Int).Value = null;
                cmd.Parameters.Add("@Payment_Mode_ID", SqlDbType.Int).Value = null;

                cmd.Parameters.Add("@Is_Active", SqlDbType.TinyInt).Value = null;

                cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = 0;// Connections.Instance.user_id;

                cmd.Parameters.Add("@Is_Delete", SqlDbType.TinyInt).Value = 1;

                cmd.Parameters.Add("@BreakFast_Enabled", SqlDbType.TinyInt).Value = null;


                cmd.Parameters.Add("@Lunch_Enabled", SqlDbType.TinyInt).Value = null;

                cmd.Parameters.Add("@Chapathi_Enabled", SqlDbType.TinyInt).Value = null;

                cmd.Parameters.Add("@Dinner_Enabled", SqlDbType.TinyInt).Value = null;

                cmd.Parameters.Add("@Dinner_Chapathi_Enabled", SqlDbType.TinyInt).Value = null;

                cmd.Parameters.Add("@BreakFast_RestrictTime", SqlDbType.DateTime).Value = null;

                cmd.Parameters.Add("@Lunch_RestrictTime", SqlDbType.DateTime).Value = null;

                cmd.Parameters.Add("@Chapathi_RestrictTime", SqlDbType.DateTime).Value = null;

                cmd.Parameters.Add("@Dinner_RestrictTime", SqlDbType.DateTime).Value = null;

                cmd.Parameters.Add("@Dinner_Chapathi_RestrictTime", SqlDbType.DateTime).Value = null;


                Connections.Instance.OpenConection();
                Connections.Instance.ExecuteProcedure(cmd);

                btnClear_Click(null, null);

                Connections.Instance.CloseConnection();
                cmd.Dispose();

            }
        }

        private void ChkDinnerChapathiRestrict_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkBreakFastRestrict.Enabled == true)
            {
                DTDinnerChapathi.Enabled = true;
            }
            else
            {
                DTDinnerChapathi.Enabled = false;
            }
        }
    }
}
