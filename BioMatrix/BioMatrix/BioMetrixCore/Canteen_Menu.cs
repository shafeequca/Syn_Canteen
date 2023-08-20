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
    public partial class Canteen_Menu : Form
    {
        public Canteen_Menu()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DTFrom.Value = DateTime.Today;
            DTTo.Value = DateTime.Today;
            chkActive.Checked = true;
            LoadData();
            DTFrom.Tag = "";
        }

        private void Canteen_Menu_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            GridView.DataSource = null;
            string query = "SELECT Menu_Id,Is_Active,Time_From AS Time_From_H,Time_To AS Time_To_H,Menu_Code,RIGHT(CONVERT(VARCHAR(20),Time_From,100),7) Time_From,RIGHT(CONVERT(VARCHAR(20),Time_To,100),7) Time_To FROM Canteen_Menu Order By 1";
            GridView.DataSource = Connections.Instance.ShowDataInGridView(query);
            GridView.Columns[0].Visible = false;
            GridView.Columns[1].Visible = false;
            GridView.Columns[2].Visible = false;
            GridView.Columns[3].Visible = false;

        }

        private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowno = e.RowIndex;
                DTFrom.Tag = GridView.Rows[rowno].Cells[0].Value.ToString();
                if (GridView.Rows[rowno].Cells[1].Value.ToString() == "1")
                {
                    chkActive.Checked = true;
                }
                else
                {
                    chkActive.Checked = false;
                }
                DTFrom.Value = Convert.ToDateTime(GridView.Rows[rowno].Cells[2].Value.ToString());
                DTTo.Value = Convert.ToDateTime(GridView.Rows[rowno].Cells[3].Value.ToString());

            }
            catch (Exception ex)
            { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DTFrom.Tag.ToString() == "")
            {
                MessageBox.Show("Please select a menu");
                return;
            }


            DialogResult dialogResult = MessageBox.Show("Do you want to save the entry?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Canteen_Menu";

                cmd.Parameters.Add("@DTFrom", SqlDbType.DateTime).Value = DTFrom.Value;
                cmd.Parameters.Add("@DTTo", SqlDbType.DateTime).Value = DTTo.Value;
                cmd.Parameters.Add("@Menu_ID", SqlDbType.Int).Value = DTFrom.Tag.ToString();

                if (chkActive.Checked == true)
                {
                    cmd.Parameters.Add("@Is_Active", SqlDbType.Decimal).Value = 1;
                }
                else
                {
                    cmd.Parameters.Add("@Is_Active", SqlDbType.Decimal).Value = 0;
                }

                cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = Connections.Instance.user_id;


                Connections.Instance.OpenConection();
                Connections.Instance.ExecuteProcedure(cmd);

                btnClear_Click(null, null);

                Connections.Instance.CloseConnection();
                cmd.Dispose();
            }
        }
    }
}
