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
    public partial class Transactions : Form
    {
        string Source_Type;
        public Transactions()
        {
            InitializeComponent();
        }

        private void Transactions_Load(object sender, EventArgs e)
        {
            DTTime.Tag = "";
            Source_Type = System.Configuration.ConfigurationSettings.AppSettings["Source_Type"];
            MenuLoad();
            SourceLoad();
            LoadData();

           

        }
        private void MenuLoad()
        {
            GridView.DataSource = null;
            string query = "select Menu_ID,Menu_Caption from Canteen_Menu";
            cboMenu.DataSource = Connections.Instance.ShowDataInGridView(query);
            cboMenu.DisplayMember = "Menu_Caption";
            cboMenu.ValueMember = "Menu_ID";
            cboMenu.SelectedIndex = -1;
            cboMenu.Text = "";

        }
        private void SourceLoad()
        {
           
            GridView.DataSource = null;
            string query = "select Source_ID,Source from source";
            if (Source_Type != "1")
            {
                query = "select Source_ID,Source from source WHERE Source='"+ System.Configuration.ConfigurationSettings.AppSettings["Source"].ToString() + "'";
            }
            cboSource.DataSource = Connections.Instance.ShowDataInGridView(query);
            cboSource.DisplayMember = "Source";
            cboSource.ValueMember = "Source";
            cboSource.SelectedIndex = -1;
            cboSource.Text = "";

        }
        private void LoadData()
        {
            GridView.DataSource = null;
            string query = "select top 1000 Transaction_Id,E.Employee_ID,CM.Menu_ID,E.Employee_Code,E.Employee_Name,T.Transaction_Time,CM.Menu_Caption AS Menu,T.Source from Canteen_Transaction T JOIN Canteen_Menu CM ON CM.Menu_ID=T.Menu_ID JOIN Employee E ON E.Employee_Id=T.Employee_ID WHERE T.Transaction_Id LIKE '%"+ txtSearch.Text.Trim() +"%' ORDER BY Transaction_Time DESC";
            GridView.DataSource = Connections.Instance.ShowDataInGridView(query);
            //GridView.Columns[0].Visible = false;
            GridView.Columns[1].Visible = false;
            GridView.Columns[2].Visible = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtEmployeeCode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the employee number");
                txtEmployeeCode.Focus();
                return;
            }
            if (lblEmployee.Text.Trim() == "")
            {
                MessageBox.Show("Please select a valid employee");
                txtEmployeeCode.Focus();
                return;
            }
            if (cboMenu.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a menu");
                cboMenu.Focus();
                return;
            }
            if (cboSource.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a source");
                cboSource.Focus();
                return;
            }
            if (txtTransactionID.Text.Trim() == "" && txtNoOfEntries.Text.Trim() == "" || txtNoOfEntries.Text.Trim() == "0")
            {
                MessageBox.Show("Please enter the number of entries");
                txtNoOfEntries.Focus();
                return;
            }
            
            string query = "SELECT 1 FROM revision WHERE DTFrom<='" + DTTime.Value.ToString("yyyy/MM/dd 00:00:00") +"' AND DTTo>='" + DTTime.Value.ToString("yyyy/MM/dd 23:59:59") + "'";
            DataTable dt = new DataTable();
            dt = (DataTable)Connections.Instance.ShowDataInGridView(query);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Revision already completed in this date");
                return;
            }
            else if (DTTime.Tag.ToString()!="")
            {
                query = "SELECT 1 FROM revision WHERE DTFrom<='" + Convert.ToDateTime(DTTime.Tag.ToString()).ToString("yyyy/MM/dd 00:00:00") + "' AND DTTo>='" + Convert.ToDateTime(DTTime.Tag.ToString()).ToString("yyyy/MM/dd 23:59:59") + "'";
                dt.Clear();
                dt = (DataTable)Connections.Instance.ShowDataInGridView(query);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Date can not be changed. Revision already completed");
                    return;
                }
 
            }

          

            DialogResult dialogResult = MessageBox.Show("Do you want to save the entry?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Canteen_Transaction";
                cmd.Parameters.Add("@Employee_Id", SqlDbType.Int).Value = txtEmployeeCode.Tag.ToString();

                cmd.Parameters.Add("@Menu_Id", SqlDbType.Int).Value = cboMenu.SelectedValue;

                cmd.Parameters.Add("@source", SqlDbType.VarChar).Value = cboSource.SelectedValue;

                cmd.Parameters.Add("@Is_Delete", SqlDbType.TinyInt).Value = "0";
                if (txtNoOfEntries.Text.Trim() == "")
                {
                    cmd.Parameters.Add("@No_Of_Entries", SqlDbType.Int).Value = 0;
                }
                else
                {
                    cmd.Parameters.Add("@No_Of_Entries", SqlDbType.Int).Value = txtNoOfEntries.Text.Trim();
                }
                cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = Connections.Instance.user_id;
                if (txtTransactionID.Text.Trim() != "")
                {
                    cmd.Parameters.Add("@Transaction_Time", SqlDbType.DateTime).Value = DTTime.Value;

                    cmd.Parameters.Add("@Transaction_Id", SqlDbType.Int).Value = txtTransactionID.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@Transaction_Time", SqlDbType.DateTime).Value = DTTime.Value.ToString("yyyy/MM/dd");

                    cmd.Parameters.Add("@Transaction_Id", SqlDbType.Int).Value = null;
                }

                cmd.Parameters.Add("@Transaction_Id_Out", SqlDbType.Int);
                cmd.Parameters["@Transaction_Id_Out"].Direction = ParameterDirection.Output;


                Connections.Instance.OpenConection();
                Connections.Instance.ExecuteProcedure(cmd);

                btnClear_Click(null, null);

                Connections.Instance.CloseConnection();
                cmd.Dispose();

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtTransactionID.Text.Trim() == "")
            {
                MessageBox.Show("Select a transaction for delete");
                return;
            }

            string query = "SELECT 1 FROM revision WHERE DTFrom<='" + DTTime.Value.ToString("yyyy/MM/dd 00:00:00") + "' AND DTTo>='" + DTTime.Value.ToString("yyyy/MM/dd 23:59:59") + "'";
            DataTable dt = new DataTable();
            dt = (DataTable)Connections.Instance.ShowDataInGridView(query);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Revision already completed. Can not be delete the transaction");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Do you want to delete the transaction?", "", MessageBoxButtons.YesNo);
              if (dialogResult == DialogResult.Yes)
              {

                  SqlCommand cmd = new SqlCommand();
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.CommandText = "SP_Canteen_Transaction";
                  cmd.Parameters.Add("@Employee_Id", SqlDbType.Int).Value = txtEmployeeCode.Tag.ToString();

                  cmd.Parameters.Add("@Transaction_Id", SqlDbType.Int).Value = txtTransactionID.Text.ToString();

                  cmd.Parameters.Add("@Menu_Id", SqlDbType.Int).Value = cboMenu.SelectedValue;
                  cmd.Parameters.Add("@Is_Delete", SqlDbType.TinyInt).Value = "1";
                  cmd.Parameters.Add("@No_Of_Entries", SqlDbType.Int).Value = "0";
                  cmd.Parameters.Add("@Transaction_Time", SqlDbType.DateTime).Value = DTTime.Value.ToString("yyyy/MM/dd"); 
                  cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = Connections.Instance.user_id;

                  cmd.Parameters.Add("@Transaction_Id_Out", SqlDbType.Int);
                  cmd.Parameters["@Transaction_Id_Out"].Direction = ParameterDirection.Output;

                  Connections.Instance.OpenConection();
                  Connections.Instance.ExecuteProcedure(cmd);

                  btnClear_Click(null, null);

                  Connections.Instance.CloseConnection();
                  cmd.Dispose();
              }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTransactionID.Text = "";
            txtEmployeeCode.Text = "";
            lblEmployee.Text = "";
            txtSearch.Text = "";
            //DTTime.Value = DateTime.Today;
            DTTime.Tag = "";
            cboMenu.SelectedIndex = -1;
            cboSource.SelectedIndex = -1;
            txtNoOfEntries.Text = "";
            LoadData();
            cboMenu.Text = "";
            cboSource.Text = "";
            txtEmployeeCode.Focus();
           
           
        }

        private void txtTransactionID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmployeeCode_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void txtEmployeeCode_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
                cboMenu.Focus();
        }

        private void txtEmployeeCode_Leave(object sender, EventArgs e)
        {
            string query = "SELECT Employee_ID,Employee_Name FROM Employee WHERE Employee_Code='" + txtEmployeeCode.Text.ToString() + "'";
            DataTable dt = new DataTable();
            dt = (DataTable)Connections.Instance.ShowDataInGridView(query);
            txtEmployeeCode.Tag = "";
            lblEmployee.Text = "";
            if (dt.Rows.Count > 0)
            {
                txtEmployeeCode.Tag = dt.Rows[0][0].ToString();
                lblEmployee.Text = dt.Rows[0][1].ToString();
            }
        }

        private void lblEmployee_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowno = e.RowIndex;
                txtTransactionID.Text = GridView.Rows[rowno].Cells[0].Value.ToString();
                txtEmployeeCode.Tag = GridView.Rows[rowno].Cells[1].Value.ToString();
                cboMenu.SelectedValue = GridView.Rows[rowno].Cells[2].Value.ToString();
                txtEmployeeCode.Text = GridView.Rows[rowno].Cells[3].Value.ToString();
                lblEmployee.Text = GridView.Rows[rowno].Cells[4].Value.ToString();
                DTTime.Value = Convert.ToDateTime(GridView.Rows[rowno].Cells[5].Value.ToString());
                DTTime.Tag = Convert.ToDateTime(GridView.Rows[rowno].Cells[5].Value.ToString());
                cboSource.SelectedValue = GridView.Rows[rowno].Cells[7].Value.ToString();
            }
            catch (Exception ex)
            { }
        }

        private void txtNoOfEntries_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtNoOfEntries_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
                btnSave_Click(null,null);
            else if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
