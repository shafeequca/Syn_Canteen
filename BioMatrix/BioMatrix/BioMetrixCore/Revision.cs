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
    public partial class Revision : Form
    {
        public Revision()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cboMonth.Tag = "";
            DTFrom.Value = DateTime.Today;
            DTTo.Value = DateTime.Today;
            txtBreakfast.Text = "";
            txtLunch.Text = "";
            txtChapthi.Text = "";
            txtDinner.Text = "";
            lblBreakfastAmount.Text = "0";
            lblBreakFastCount.Text = "0";
            lblChapathiAmount.Text = "0";
            lblChapathiCount.Text = "0";
            lblDinnerAmount.Text = "0";
            lblDinnerCount.Text = "0";
            lblLunchAmount.Text = "0";
            lblLunchCount.Text = "0";
            cboMonth.Text = "";
            cboYear.Text = "";
            txtSearch.Text = "";
            Data();
            txtBreakfast.Focus();

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Transaction_Process";

            if (txtBreakfast.Text.Trim() == "")
            {
                cmd.Parameters.Add("@Breakfast", SqlDbType.Decimal).Value = 0;
            }
            else
            {
                cmd.Parameters.Add("@Breakfast", SqlDbType.Decimal).Value = txtBreakfast.Text;
            }
            if (txtLunch.Text.Trim() == "")
            {
                cmd.Parameters.Add("@Lunch", SqlDbType.Decimal).Value = 0;
            }
            else
            {
                cmd.Parameters.Add("@Lunch", SqlDbType.Decimal).Value = txtLunch.Text;
            }

            if (txtChapthi.Text.Trim() == "")
            {
                cmd.Parameters.Add("@Chapathi", SqlDbType.Decimal).Value = 0;
            }
            else
            {
                cmd.Parameters.Add("@Chapathi", SqlDbType.Decimal).Value = txtChapthi.Text;
            }

            if (txtDinner.Text.Trim() == "")
            {
                cmd.Parameters.Add("@Dinner", SqlDbType.Decimal).Value = 0;
            }
            else
            {
                cmd.Parameters.Add("@Dinner", SqlDbType.Decimal).Value = txtDinner.Text;
            }
            cmd.Parameters.Add("@DTFrom", SqlDbType.DateTime).Value = DTFrom.Value.ToString("yyyy/MM/dd 00:00:00");
            cmd.Parameters.Add("@DTTo", SqlDbType.DateTime).Value = DTTo.Value.ToString("yyyy/MM/dd 23:59:59");


            SqlParameter Breakfast_Count = new SqlParameter("@Breakfast_Count", SqlDbType.Int);
            Breakfast_Count.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Breakfast_Count);

            SqlParameter Lunch_Count = new SqlParameter("@Lunch_Count", SqlDbType.Int);
            Lunch_Count.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Lunch_Count);

            SqlParameter Chapathi_Count = new SqlParameter("@Chapathi_Count", SqlDbType.Int);
            Chapathi_Count.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Chapathi_Count);

            SqlParameter Dinner_Count = new SqlParameter("@Dinner_Count", SqlDbType.Int);
            Dinner_Count.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Dinner_Count);


            SqlParameter Breakfast_Amount = new SqlParameter("@Breakfast_Amount", SqlDbType.Decimal);
            Breakfast_Amount.Precision = 18;
            Breakfast_Amount.Scale = 2;
            Breakfast_Amount.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Breakfast_Amount);

            SqlParameter Lunch_Amount = new SqlParameter("@Lunch_Amount", SqlDbType.Decimal);
            Lunch_Amount.Precision = 18;
            Lunch_Amount.Scale = 2;
            Lunch_Amount.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Lunch_Amount);

            SqlParameter Chapathi_Amount = new SqlParameter("@Chapathi_Amount", SqlDbType.Decimal);
            Chapathi_Amount.Precision = 18;
            Chapathi_Amount.Scale = 2;
            Chapathi_Amount.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Chapathi_Amount);

            SqlParameter Dinner_Amount = new SqlParameter("@Dinner_Amount", SqlDbType.Decimal);
            Dinner_Amount.Precision = 18;
            Dinner_Amount.Scale = 2;
            Dinner_Amount.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Dinner_Amount);

            SqlParameter Total_Amount = new SqlParameter("@Total_Amount", SqlDbType.Decimal);
            Total_Amount.Precision = 18;
            Total_Amount.Scale = 2;
            Total_Amount.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Total_Amount);

            Connections.Instance.OpenConection();
            Connections.Instance.ExecuteProcedure(cmd);

            lblBreakFastCount.Text = cmd.Parameters["@Breakfast_Count"].Value.ToString();
            lblBreakfastAmount.Text = cmd.Parameters["@Breakfast_Amount"].Value.ToString();

            lblLunchCount.Text = cmd.Parameters["@Lunch_Count"].Value.ToString();
            lblLunchAmount.Text = cmd.Parameters["@Lunch_Amount"].Value.ToString();

            lblChapathiCount.Text = cmd.Parameters["@Chapathi_Count"].Value.ToString();
            lblChapathiAmount.Text = cmd.Parameters["@Chapathi_Amount"].Value.ToString();

            lblDinnerCount.Text = cmd.Parameters["@Dinner_Count"].Value.ToString();
            lblDinnerAmount.Text = cmd.Parameters["@Dinner_Amount"].Value.ToString();

            lblTotal.Text = cmd.Parameters["@Total_Amount"].Value.ToString();

            Connections.Instance.OpenConection();
            Connections.Instance.ExecuteProcedure(cmd);

           
            Connections.Instance.CloseConnection();
            cmd.Dispose();

        }

        private void Revision_Load(object sender, EventArgs e)
        {
            Data();
        }
        private void Data()
        {
            GridView.DataSource = null;
            string query = "SELECT Revision_Id,Month_Year,DTFrom,DTTo,Breakfast,Lunch,Chapathi,Dinner,Breakfast_Count,Lunch_Count,Chapathi_Count,Dinner_Count,Breakfast_Amount,Lunch_Amount,Chapathi_Amount,Dinner_Amount FROM Revision WHERE Month_Year like '%" + txtSearch.Text.Trim() + "%' ORDER BY 1 DESC";
            GridView.DataSource = Connections.Instance.ShowDataInGridView(query);
            GridView.Columns[0].Visible = false;
            GridView.Columns[4].Visible = false;
            GridView.Columns[5].Visible = false;
            GridView.Columns[6].Visible = false;
            GridView.Columns[7].Visible = false;
            GridView.Columns[8].Visible = false;
            GridView.Columns[9].Visible = false;
            GridView.Columns[10].Visible = false;
            GridView.Columns[11].Visible = false;
            GridView.Columns[12].Visible = false;
            GridView.Columns[13].Visible = false;
            GridView.Columns[14].Visible = false;
            GridView.Columns[15].Visible = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboMonth.Text.Trim() == "")
            {
                MessageBox.Show("Please select a month");
                cboMonth.Focus();
                return;
            }
            if (cboYear.Text.Trim() == "")
            {
                MessageBox.Show("Please select a year");
                cboYear.Focus();
                return;
            }
            btnCalculate_Click(null, null);


            string query = "SELECT 1 FROM Revision WHERE Month_Year='" + cboMonth.Text.ToString() + "-" + cboYear.Text.ToString() + "'";
            DataTable dt = new DataTable();
            dt = (DataTable)Connections.Instance.ShowDataInGridView(query);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Month & Year Already Exists");
                return;
            }

            query = "SELECT 1 FROM revision WHERE (DTFrom<='" + DTFrom.Value.ToString("yyyy/MM/dd 00:00:00") + "' AND DTTo>='" + DTFrom.Value.ToString("yyyy/MM/dd 23:59:59") + "') OR (DTFrom<='" + DTTo.Value.ToString("yyyy/MM/dd 00:00:00") + "' AND DTTo>='" + DTTo.Value.ToString("yyyy/MM/dd 23:59:59") + "')";
            dt.Clear();
           
            dt = (DataTable)Connections.Instance.ShowDataInGridView(query);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Revision already completed in the date");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Do you want to save the entry?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Revision";

                if (txtBreakfast.Text.Trim() == "")
                {
                    cmd.Parameters.Add("@Breakfast", SqlDbType.Decimal).Value = 0;
                }
                else
                {
                    cmd.Parameters.Add("@Breakfast", SqlDbType.Decimal).Value = txtBreakfast.Text;
                }
                if (txtLunch.Text.Trim() == "")
                {
                    cmd.Parameters.Add("@Lunch", SqlDbType.Decimal).Value = 0;
                }
                else
                {
                    cmd.Parameters.Add("@Lunch", SqlDbType.Decimal).Value = txtLunch.Text;
                }

                if (txtChapthi.Text.Trim() == "")
                {
                    cmd.Parameters.Add("@Chapathi", SqlDbType.Decimal).Value = 0;
                }
                else
                {
                    cmd.Parameters.Add("@Chapathi", SqlDbType.Decimal).Value = txtChapthi.Text;
                }

                if (txtDinner.Text.Trim() == "")
                {
                    cmd.Parameters.Add("@Dinner", SqlDbType.Decimal).Value = 0;
                }
                else
                {
                    cmd.Parameters.Add("@Dinner", SqlDbType.Decimal).Value = txtDinner.Text;
                }
                cmd.Parameters.Add("@DTFrom", SqlDbType.DateTime).Value = DTFrom.Value.ToString("yyyy/MM/dd 00:00:00");
                cmd.Parameters.Add("@DTTo", SqlDbType.DateTime).Value = DTTo.Value.ToString("yyyy/MM/dd 23:59:59");

                if (lblBreakFastCount.Text.Trim() == "")
                {
                    cmd.Parameters.Add("@Breakfast_Count", SqlDbType.Decimal).Value = 0;
                }
                else
                {
                    cmd.Parameters.Add("@Breakfast_Count", SqlDbType.Decimal).Value = lblBreakFastCount.Text;
                }
                if (lblBreakfastAmount.Text.Trim() == "")
                {
                    cmd.Parameters.Add("@Breakfast_Amount", SqlDbType.Decimal).Value = 0;
                }
                else
                {
                    cmd.Parameters.Add("@Breakfast_Amount", SqlDbType.Decimal).Value = lblBreakfastAmount.Text;
                }

                if (lblLunchCount.Text.Trim() == "")
                {
                    cmd.Parameters.Add("@Lunch_Count", SqlDbType.Decimal).Value = 0;
                }
                else
                {
                    cmd.Parameters.Add("@Lunch_Count", SqlDbType.Decimal).Value = lblLunchCount.Text;
                }
                if (lblLunchAmount.Text.Trim() == "")
                {
                    cmd.Parameters.Add("@Lunch_Amount", SqlDbType.Decimal).Value = 0;
                }
                else
                {
                    cmd.Parameters.Add("@Lunch_Amount", SqlDbType.Decimal).Value = lblLunchAmount.Text;
                }


                if (lblChapathiCount.Text.Trim() == "")
                {
                    cmd.Parameters.Add("@Chapathi_Count", SqlDbType.Decimal).Value = 0;
                }
                else
                {
                    cmd.Parameters.Add("@Chapathi_Count", SqlDbType.Decimal).Value = lblChapathiCount.Text;
                }
                if (lblChapathiAmount.Text.Trim() == "")
                {
                    cmd.Parameters.Add("@Chapathi_Amount", SqlDbType.Decimal).Value = 0;
                }
                else
                {
                    cmd.Parameters.Add("@Chapathi_Amount", SqlDbType.Decimal).Value = lblChapathiAmount.Text;
                }

                if (lblDinnerCount.Text.Trim() == "")
                {
                    cmd.Parameters.Add("@Dinner_Count", SqlDbType.Decimal).Value = 0;
                }
                else
                {
                    cmd.Parameters.Add("@Dinner_Count", SqlDbType.Decimal).Value = lblDinnerCount.Text;
                }
                if (lblDinnerAmount.Text.Trim() == "")
                {
                    cmd.Parameters.Add("@Dinner_Amount", SqlDbType.Decimal).Value = 0;
                }
                else
                {
                    cmd.Parameters.Add("@Dinner_Amount", SqlDbType.Decimal).Value = lblDinnerAmount.Text;
                }

                cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = Connections.Instance.user_id;

                cmd.Parameters.Add("@Month_Year", SqlDbType.VarChar).Value = cboMonth.Text+"-"+cboYear.Text  ;

                Connections.Instance.OpenConection();
                Connections.Instance.ExecuteProcedure(cmd);

                btnClear_Click(null, null);

                Connections.Instance.CloseConnection();
                cmd.Dispose();

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Data();
        }

        private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowno = e.RowIndex;
            cboMonth.Tag = GridView.Rows[rowno].Cells[0].Value.ToString();
            cboMonth.Text =  GridView.Rows[rowno].Cells[1].Value.ToString().Split('-').First().ToString();
            cboYear.Text = GridView.Rows[rowno].Cells[1].Value.ToString().Split('-').Last().ToString();

            DTFrom.Value =Convert.ToDateTime(GridView.Rows[rowno].Cells[2].Value.ToString());
            DTTo.Value = Convert.ToDateTime(GridView.Rows[rowno].Cells[3].Value.ToString());
            txtBreakfast.Text = GridView.Rows[rowno].Cells[4].Value.ToString();
            txtLunch.Text = GridView.Rows[rowno].Cells[5].Value.ToString();
            txtChapthi.Text = GridView.Rows[rowno].Cells[6].Value.ToString();
            txtDinner.Text = GridView.Rows[rowno].Cells[7].Value.ToString();
            lblBreakFastCount.Text = GridView.Rows[rowno].Cells[8].Value.ToString();
            lblLunchCount.Text = GridView.Rows[rowno].Cells[9].Value.ToString();
            lblChapathiCount.Text = GridView.Rows[rowno].Cells[10].Value.ToString();
            lblDinnerCount.Text = GridView.Rows[rowno].Cells[11].Value.ToString();
            lblBreakfastAmount.Text = GridView.Rows[rowno].Cells[12].Value.ToString();
            lblLunchAmount.Text = GridView.Rows[rowno].Cells[13].Value.ToString();
            lblChapathiAmount.Text = GridView.Rows[rowno].Cells[14].Value.ToString();
            lblDinnerAmount.Text = GridView.Rows[rowno].Cells[15].Value.ToString();


        }

        private void txtBreakfast_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtBreakfast_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
                txtLunch.Focus();
            else if (!((Char.IsDigit(e.KeyChar)==true || (e.KeyChar == (char)Keys.Back)) || (e.KeyChar == (char)46)))
                e.Handled = true;
        }

        private void txtLunch_TextChanged1(object sender, EventArgs e)
        {

        }
        private void txtLunch_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
                txtChapthi.Focus();
            else if (!((Char.IsDigit(e.KeyChar) == true || (e.KeyChar == (char)Keys.Back)) || (e.KeyChar == (char)46)))
                e.Handled = true;
        }

        private void txtChapthi_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtChapthi_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
                txtDinner.Focus();
            else if (!((Char.IsDigit(e.KeyChar) == true || (e.KeyChar == (char)Keys.Back)) || (e.KeyChar == (char)46)))
                e.Handled = true;
        }

        private void txtDinner_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtDinner_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
                btnCalculate_Click(null,null);
            else if (!((Char.IsDigit(e.KeyChar) == true || (e.KeyChar == (char)Keys.Back)) || (e.KeyChar == (char)46)))
                e.Handled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cboMonth.Tag.ToString()== "")
            {
                MessageBox.Show("Please select a revision for delete");
                return;
            }
          
            DialogResult dialogResult = MessageBox.Show("Do you want to delete the revision?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Revision_Delete";


                cmd.Parameters.Add("@Revision_Id", SqlDbType.Int).Value = cboMonth.Tag.ToString();

                Connections.Instance.OpenConection();
                Connections.Instance.ExecuteProcedure(cmd);

                btnClear_Click(null, null);

                Connections.Instance.CloseConnection();
                cmd.Dispose();

            }
        }

    }
}
