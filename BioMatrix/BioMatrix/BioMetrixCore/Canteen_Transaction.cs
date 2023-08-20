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
using System.Globalization;

namespace Snythite_Canteen
{
    public partial class Canteen_Transaction : Form
    {
        string Source_Type;
        public Canteen_Transaction()
        {
            InitializeComponent();
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DeleteItem_Click);

        }
        private void DeleteItem_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            if (item.Name == "Delete")
            {
                int rowcount = 0;

                rowcount = GridView.SelectedRows.Count;

                DialogResult dialogResult = MessageBox.Show("Do you want to delete the transactions?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes && rowcount>0)
                {
                    for (int i = 0; i < rowcount; i++)
                    {
                        int rowno = GridView.SelectedRows[i].Index;
                        //DateTime dtt = DateTime.Parse("22-01-2022 00:00:00");

                        string dateString = GridView.Rows[rowno].Cells[8].Value.ToString();// "22/01/2022";
                        string format = "dd/mm/yyyy";

                        DateTime dateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
                        string DTFrom = dateTime.ToString("yyyy/mm/dd 00:00:00");
                        string DTTo = dateTime.ToString("yyyy/mm/dd 23:59:59");
                       
                        //string query = "SELECT 1 FROM revision WHERE DTFrom<='" + GridView.Rows[rowno].Cells[5].Value.ToString("yyyy/MM/dd 00:00:00") + "' AND DTTo>='" + GridView.Rows[rowno].Cells[5].Value.ToString("yyyy/MM/dd 23:59:59") + "'";
                        string query = "SELECT 1 FROM revision WHERE DTFrom<='" + DTFrom + "' AND DTTo>='" + DTTo + "'";
                        DataTable dt = new DataTable();
                        dt = (DataTable)Connections.Instance.ShowDataInGridView(query);
                        if (dt.Rows.Count == 0)
                        {
                            query = "delete from Canteen_Transaction where Transaction_Id='" + GridView.Rows[rowno].Cells[1].Value.ToString() + "'";
                          
                            Connections.Instance.ExecuteQueries(query);
                        }

                    }

                }
                btnShow_Click(null, null);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtFrom.Value = DateTime.Today;
            dtTo.Value = DateTime.Today;
            cboDepartment.SelectedIndex = -1;
            cboEmployeeId.SelectedIndex = -1;
            cboPaymentMode.SelectedIndex = -1;

            if (cboSource.Items.Count > 0 && Source_Type != "1")
            {
                cboSource.SelectedIndex = 0;
            }
            else
            {
                cboSource.SelectedIndex = -1;
                cboSource.Text = "";
            }

            cboDepartment.Text = "";
            cboEmployeeId.Text = "";
            cboPaymentMode.Text = "";
            lblBreakfastCount.Text = "0";
            lblChapathiCount.Text = "0";
            lblDinnerCount.Text = "0";
            lblLunchCount.Text = "0";
            lblDinnerChapathiCount.Text = "0";

            GridView.DataSource = null;

        }

        private void Canteen_Transaction_Load(object sender, EventArgs e)
        {
            Source_Type = System.Configuration.ConfigurationSettings.AppSettings["Source_Type"];
            DepartmentData();
            PaymentModeData();
            EmployeeData();
            SourceLoad();
        }
        private void SourceLoad()
        {
            GridView.DataSource = null;
            string query = "select Source_ID,Source from source";
            if (Source_Type != "1")
            {
                query = "select Source_ID,Source from source WHERE Source='" + System.Configuration.ConfigurationSettings.AppSettings["Source"].ToString() + "'";
            }
            cboSource.DataSource = Connections.Instance.ShowDataInGridView(query);
            cboSource.DisplayMember = "Source";
            cboSource.ValueMember = "Source";
            if (cboSource.Items.Count > 0 && Source_Type != "1")
            {
                cboSource.SelectedIndex = 0;
            }
            else
            {
                cboSource.SelectedIndex = -1;
                cboSource.Text = "";
            }

        }

        private void EmployeeData()
        {
           
            cboEmployeeId.DataSource = null;
            string query = "SELECT Employee_Id,Employee_Code FROM Employee ORDER BY 2";
            cboEmployeeId.DataSource = Connections.Instance.ShowDataInGridView(query);
            cboEmployeeId.DisplayMember = "Employee_Code";
            cboEmployeeId.ValueMember = "Employee_Id";
            cboEmployeeId.SelectedIndex = -1;
            cboEmployeeId.Text = "";
               
            

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
            cboPaymentMode.DataSource = null;
            string query = "SELECT ID,Payment_Mode FROM Payment_Mode ORDER BY Payment_Mode";
            cboPaymentMode.DataSource = Connections.Instance.ShowDataInGridView(query);
            cboPaymentMode.DisplayMember = "Payment_Mode";
            cboPaymentMode.ValueMember = "ID";
            cboPaymentMode.SelectedIndex = -1;
            cboPaymentMode.Text = "";
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Get_Canteen_Transaction";

            cmd.Parameters.Add("@DTFrom", SqlDbType.DateTime).Value = dtFrom.Value.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@DTTo", SqlDbType.DateTime).Value = dtTo.Value.ToString("yyyy-MM-dd");


            if (cboDepartment.SelectedIndex >= 0 && cboDepartment.Text != "")
            {
                cmd.Parameters.Add("@Department_ID", SqlDbType.Int).Value = cboDepartment.SelectedValue.ToString();
            }
            else
            {
                cmd.Parameters.Add("@Department_ID", SqlDbType.Int).Value = null;
            }

            if (cboPaymentMode.SelectedIndex >= 0 && cboPaymentMode.Text != "")
            {
                cmd.Parameters.Add("@Payment_Mode_ID", SqlDbType.Int).Value = cboPaymentMode.SelectedValue.ToString();
            }
            else
            {
                cmd.Parameters.Add("@Payment_Mode_ID", SqlDbType.Int).Value = null;
            }

            if (cboEmployeeId.SelectedIndex >= 0 && cboEmployeeId.Text != "")
            {
                cmd.Parameters.Add("@Employee_ID", SqlDbType.Int).Value = cboEmployeeId.SelectedValue.ToString();
            }
            else
            {
                cmd.Parameters.Add("@Employee_ID", SqlDbType.Int).Value = null;
            }
            if (cboSource.SelectedIndex >= 0 && cboSource.Text != "")
            {
                cmd.Parameters.Add("@Source", SqlDbType.VarChar).Value = cboSource.SelectedValue.ToString();
            }
            else
            {
                cmd.Parameters.Add("@Source", SqlDbType.VarChar).Value = null;
            }

            SqlParameter Breakfast_Count = new SqlParameter("@Breakfast_Count", SqlDbType.Int);
            //Breakfast_Count.Precision = 18;
            // Breakfast_Count.Scale = 2;
            Breakfast_Count.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Breakfast_Count);

            SqlParameter Lunch_Count = new SqlParameter("@Lunch_Count", SqlDbType.Int);
            //Breakfast_Count.Precision = 18;
            // Breakfast_Count.Scale = 2;
            Lunch_Count.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Lunch_Count);

            SqlParameter Chapathi_Count = new SqlParameter("@Chapathi_Count", SqlDbType.Int);
            //Breakfast_Count.Precision = 18;
            // Breakfast_Count.Scale = 2;
            Chapathi_Count.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Chapathi_Count);

            SqlParameter Dinner_Count = new SqlParameter("@Dinner_Count", SqlDbType.Int);
            //Breakfast_Count.Precision = 18;
            // Breakfast_Count.Scale = 2;
            Dinner_Count.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Dinner_Count);

            SqlParameter Dinner_Chapathi_Count = new SqlParameter("@Dinner_Chapathi_Count", SqlDbType.Int);
            //Breakfast_Count.Precision = 18;
            // Breakfast_Count.Scale = 2;
            Dinner_Chapathi_Count.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Dinner_Chapathi_Count);

             Connections.Instance.OpenConection();
            cmd.Connection = Connections.Instance.con;
            //Connections.Instance.ExecuteProcedure(cmd);

            dt.Load(cmd.ExecuteReader());
            GridView.DataSource = dt;
            GridView.Columns[8].Visible = false;


            lblBreakfastCount.Text = cmd.Parameters["@Breakfast_Count"].Value.ToString();
          

            lblChapathiCount.Text = cmd.Parameters["@Chapathi_Count"].Value.ToString();

            lblDinnerCount.Text = cmd.Parameters["@Dinner_Count"].Value.ToString();

            lblLunchCount.Text = cmd.Parameters["@Lunch_Count"].Value.ToString();

            lblDinnerChapathiCount.Text = cmd.Parameters["@Dinner_Chapathi_Count"].Value.ToString();

            dt.Dispose();
            //GridView.Columns[0].Visible = false;
            //GridView.Columns[1].Visible = false;
            //GridView.Columns[2].Visible = false;
            //GridView.Columns[3].Visible = false;
            //GridView.Columns[4].Visible = false;
            //GridView.Columns[5].Visible = false;
            //GridView.Columns[6].Visible = false;
            //GridView.Columns[7].Visible = false;
            //GridView.Columns[8].Visible = false;
            //GridView.Columns[9].Visible = false;
        }

       
    }
}
