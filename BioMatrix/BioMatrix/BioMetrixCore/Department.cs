using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BioMetrix;
using System.Data.SqlClient;

namespace Snythite_Canteen
{
    public partial class Department : Form
    {
        public Department()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDepartment.Text = "";
            txtDepartmentCode.Text = "";
            txtDepartmentCode.Tag = "";
            LoadData();
            txtDepartmentCode.Enabled = true;
            txtDepartmentCode.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDepartmentCode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the department code");
                txtDepartmentCode.Focus();
                return;
            }
            if (txtDepartment.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the department name");
                txtDepartment.Focus();
                return;
            }


            string query = "SELECT 1 FROM Department WHERE Department_Code='" + txtDepartmentCode.Text.ToString() + "'";
            DataTable dt = new DataTable();
            dt = (DataTable)Connections.Instance.ShowDataInGridView(query);
            if (dt.Rows.Count > 0 && txtDepartmentCode.Enabled == true)
            {
                MessageBox.Show("Department code already exists");
                txtDepartmentCode.Focus();
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Do you want to save the entry?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Department";

                if (txtDepartmentCode.Enabled == true)
                {
                    cmd.Parameters.Add("@Department_Id", SqlDbType.Int).Value = null;
                }
                else
                {
                    cmd.Parameters.Add("@Department_Id", SqlDbType.Int).Value = txtDepartmentCode.Tag.ToString();
                }

                cmd.Parameters.Add("@Department_Code", SqlDbType.VarChar).Value = txtDepartmentCode.Text.Trim();
                cmd.Parameters.Add("@Department_Name", SqlDbType.VarChar).Value = txtDepartment.Text.Trim();
                cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = Connections.Instance.user_id;
               
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

        private void Department_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            GridView.DataSource = null;
            string query = "SELECT Department_Id,Department_Code,Department_Name FROM Department  WHERE Department_Name like '%" + txtSearch.Text.Trim() + "%' ORDER BY 3";
            GridView.DataSource = Connections.Instance.ShowDataInGridView(query);
            GridView.Columns[0].Visible = false;
           
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

      
        private void GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowno = e.RowIndex;
            txtDepartmentCode.Tag = GridView.Rows[rowno].Cells[0].Value.ToString();
            txtDepartmentCode.Text = GridView.Rows[rowno].Cells[1].Value.ToString();
            txtDepartment.Text = GridView.Rows[rowno].Cells[2].Value.ToString();
            txtDepartmentCode.Enabled = false;
            txtDepartment.Focus();
        }

        private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
