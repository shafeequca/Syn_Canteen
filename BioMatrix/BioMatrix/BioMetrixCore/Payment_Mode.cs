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
    public partial class Payment_Mode : Form
    {
        public Payment_Mode()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPaymentMode.Text = "";
            txtPaymentMode.Tag = "";
            txtDescription.Text = "";
            LoadData();
            txtPaymentMode.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPaymentMode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the payment mode");
                txtPaymentMode.Focus();
                return;
            }
            if (txtDescription.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the description");
                txtDescription.Focus();
                return;
            }


            string query = "SELECT 1 FROM Payment_Mode WHERE Payment_Mode='" + txtPaymentMode.Text.Trim().ToString() + "'";
            DataTable dt = new DataTable();
            dt = (DataTable)Connections.Instance.ShowDataInGridView(query);
            if (dt.Rows.Count > 0 && txtPaymentMode.Tag.ToString()=="")
            {
                MessageBox.Show("Payment Mode already exists");
                txtPaymentMode.Focus();
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Do you want to save the entry?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Payment_Mode";

                if (txtPaymentMode.Tag.ToString() == "")
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = null;
                }
                else
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = txtPaymentMode.Tag.ToString();
                }

                cmd.Parameters.Add("@Payment_Mode", SqlDbType.VarChar).Value = txtPaymentMode.Text.Trim();
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = txtDescription.Text.Trim();
                cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = Connections.Instance.user_id;

                Connections.Instance.OpenConection();
                Connections.Instance.ExecuteProcedure(cmd);

                btnClear_Click(null, null);

                Connections.Instance.CloseConnection();
                cmd.Dispose();

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Payment_Mode_Load(object sender, EventArgs e)
        {
            txtPaymentMode.Tag = "";
            LoadData();
        }
        private void LoadData()
        {
            GridView.DataSource = null;
            string query = "SELECT ID,Payment_Mode,Description FROM Payment_Mode WHERE Payment_Mode like '%" + txtSearch.Text.Trim() + "%' ORDER BY 3";
            GridView.DataSource = Connections.Instance.ShowDataInGridView(query);
            GridView.Columns[0].Visible = false;

        }

        private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int rowno = e.RowIndex;
            txtPaymentMode.Tag = GridView.Rows[rowno].Cells[0].Value.ToString();
            txtPaymentMode.Text = GridView.Rows[rowno].Cells[1].Value.ToString();
            txtDescription.Text = GridView.Rows[rowno].Cells[2].Value.ToString();
            txtPaymentMode.Focus();
        }

        
    }
}
