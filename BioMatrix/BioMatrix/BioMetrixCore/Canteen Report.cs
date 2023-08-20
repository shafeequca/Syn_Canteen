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
using CrystalDecisions.Windows.Forms;
using Snythite_Canteen.DataSet;
using CrystalDecisions.CrystalReports.Engine;

namespace Snythite_Canteen
{
    public partial class Canteen_Report : Form
    {
        DataSet1 ds;
        string Source_Type;
        public Canteen_Report()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            crystalReportViewer2.Visible = false;
            GridView.Visible = true;

            if (cboMonthYear.SelectedIndex < 0 || cboMonthYear.Text.Trim() == "")
            {
                MessageBox.Show("Please select a mont and year");
                return;
            }

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Get_Canteen_Report";

            cmd.Parameters.Add("@Revision_Id", SqlDbType.Int).Value = cboMonthYear.SelectedValue.ToString();

            if (optAll.Checked==true)
            {
                cmd.Parameters.Add("@Report_Type", SqlDbType.VarChar).Value = "All";

            }
            else if (optEmployeeLevel.Checked == true)
            {
                cmd.Parameters.Add("@Report_Type", SqlDbType.VarChar).Value = "EmployeeLevel";
 
            }
           

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


            SqlParameter Breakfast_Rate = new SqlParameter("@Breakfast_Rate", SqlDbType.Decimal);
            Breakfast_Rate.Precision = 18;
            Breakfast_Rate.Scale = 2;
            Breakfast_Rate.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Breakfast_Rate);

            SqlParameter Lunch_Rate = new SqlParameter("@Lunch_Rate", SqlDbType.Decimal);
            Lunch_Rate.Precision = 18;
            Lunch_Rate.Scale = 2;
            Lunch_Rate.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Lunch_Rate);

            SqlParameter Chapathi_Rate = new SqlParameter("@Chapathi_Rate", SqlDbType.Decimal);
            Chapathi_Rate.Precision = 18;
            Chapathi_Rate.Scale = 2;
            Chapathi_Rate.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Chapathi_Rate);

            SqlParameter Dinner_Rate = new SqlParameter("@Dinner_Rate", SqlDbType.Decimal);
            Dinner_Rate.Precision = 18;
            Dinner_Rate.Scale = 2;
            Dinner_Rate.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Dinner_Rate);

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


            Connections.Instance.OpenConection();
            cmd.Connection = Connections.Instance.con;
            //Connections.Instance.ExecuteProcedure(cmd);

            dt.Load(cmd.ExecuteReader());
            GridView.DataSource = dt;


            lblBreakfastCount.Text = cmd.Parameters["@Breakfast_Count"].Value.ToString();
            lblBreakfastAmount.Text = cmd.Parameters["@Breakfast_Amount"].Value.ToString();

            lblChapathiCount.Text = cmd.Parameters["@Chapathi_Count"].Value.ToString();
            lblChapathiAmount.Text = cmd.Parameters["@Chapathi_Amount"].Value.ToString();

            lblDinnerCount.Text = cmd.Parameters["@Dinner_Count"].Value.ToString();
            lblDinnerAmount.Text = cmd.Parameters["@Dinner_Amount"].Value.ToString();


            lblLunchCount.Text = cmd.Parameters["@Lunch_Count"].Value.ToString();
            lblLunchAmount.Text = cmd.Parameters["@Lunch_Amount"].Value.ToString();


            lblBreakfastRate.Text = cmd.Parameters["@Breakfast_Rate"].Value.ToString();
            lbllunchRate.Text = cmd.Parameters["@Lunch_Rate"].Value.ToString();


            lblChapathiRate.Text = cmd.Parameters["@Chapathi_Rate"].Value.ToString();
            lblDinnerRate.Text = cmd.Parameters["@Dinner_Rate"].Value.ToString();

            dt.Dispose();
            GridView.Columns[0].Visible = false;
            GridView.Columns[1].Visible = false;
            GridView.Columns[2].Visible = false;
            GridView.Columns[3].Visible = false;
            GridView.Columns[4].Visible = false;
            GridView.Columns[5].Visible = false;
            GridView.Columns[6].Visible = false;
            GridView.Columns[7].Visible = false;
            GridView.Columns[8].Visible = false;
            GridView.Columns[9].Visible = false;
        }

        private void Canteen_Report_Load(object sender, EventArgs e)
        {
            ds = new DataSet1();
            Source_Type = System.Configuration.ConfigurationSettings.AppSettings["Source_Type"];

            RevisionData();
            DepartmentData();
            PaymentModeData();
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
            if (cboMonthYear.SelectedIndex > -1)
            {
                try
                {
                    cboEmployeeId.DataSource = null;
                    string query = "SELECT DISTINCT E.Employee_Id,E.Employee_Code FROM Employee E JOIN Revision_Details D ON D.Employee_Id=E.Employee_Id WHERE D.Revision_ID='" + cboMonthYear.SelectedValue + "' ORDER BY 2";
                    cboEmployeeId.DataSource = Connections.Instance.ShowDataInGridView(query);
                    cboEmployeeId.DisplayMember = "Employee_Code";
                    cboEmployeeId.ValueMember = "Employee_Id";
                    cboEmployeeId.SelectedIndex = -1;
                    cboEmployeeId.Text = "";
                }
                catch (Exception ex)
                { cboEmployeeId.DataSource = null; }
            }

        }
        private void RevisionData()
        {
            cboMonthYear.DataSource = null;
            string query = "SELECT Revision_Id,Month_Year FROM Revision ORDER BY Revision_Id DESC";
            cboMonthYear.DataSource = Connections.Instance.ShowDataInGridView(query);
            cboMonthYear.DisplayMember = "Month_Year";
            cboMonthYear.ValueMember = "Revision_Id";
            cboMonthYear.SelectedIndex = -1;
            cboMonthYear.Text = "";
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


        private void btnPrint_Click(object sender, EventArgs e)
        {
            btnShow_Click(null, null);
            if (GridView.Rows.Count == 0)
            {
                MessageBox.Show("No records found to print");
                return;
            }
            //string Query = "SELECT ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS SlNo, v.Vehicle_Type,v.Vehicle_Number,y.Entry_Time,y.Exit_Time,y.Payment_start_time,y.payment_end_time,f.slab_name,CONVERT(DECIMAL(18,2),y.Base_Amount) AS Slab_Amount,CONVERT(DECIMAL(18,2),isnull(y.Additional_Amount,'0')) AS Additional_Amount,CONVERT(DECIMAL(18,2),(y.Base_Amount+y.Additional_Amount)) AS Total,CASE WHEN Reference_Id IS NOT NULL THEN 'Re-Entry' ELSE '' END AS Remarks FROM yard_entry y JOIN vehicle v on v.vehicle_id=y.vehicle_id JOIN Fee_Slab f on f.Fee_Slab_Id=y.Fee_Slab_Id WHERE y.exit_time>='" + dtFrom.Value.ToString("yyyy-MM-dd HH:mm:00") + "' and y.exit_time<='" + dtTo.Value.ToString("yyyy-MM-dd HH:mm:00") + "' AND y.yard_id=" + yard_id + "";
            crystalReportViewer2.Visible = true;
            crystalReportViewer2.ToolPanelView = ToolPanelViewType.None;
            crystalReportViewer2.Width = GridView.Width;
            crystalReportViewer2.Height = GridView.Height;
            crystalReportViewer2.Top = GridView.Top;
            crystalReportViewer2.Left = GridView.Left;

            GridView.Visible = false;

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Get_Canteen_Report";

            cmd.Parameters.Add("@Revision_Id", SqlDbType.Int).Value = cboMonthYear.SelectedValue.ToString();

            if (optAll.Checked == true)
            {
                cmd.Parameters.Add("@Report_Type", SqlDbType.VarChar).Value = "All";

            }
            else if (optEmployeeLevel.Checked == true)
            {
                cmd.Parameters.Add("@Report_Type", SqlDbType.VarChar).Value = "EmployeeLevel";

            }


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

            SqlParameter Breakfast_Rate = new SqlParameter("@Breakfast_Rate", SqlDbType.Decimal);
            Breakfast_Rate.Precision = 18;
            Breakfast_Rate.Scale = 2;
            Breakfast_Rate.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Breakfast_Rate);

            SqlParameter Lunch_Rate = new SqlParameter("@Lunch_Rate", SqlDbType.Decimal);
            Lunch_Rate.Precision = 18;
            Lunch_Rate.Scale = 2;
            Lunch_Rate.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Lunch_Rate);

            SqlParameter Chapathi_Rate = new SqlParameter("@Chapathi_Rate", SqlDbType.Decimal);
            Chapathi_Rate.Precision = 18;
            Chapathi_Rate.Scale = 2;
            Chapathi_Rate.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Chapathi_Rate);

            SqlParameter Dinner_Rate = new SqlParameter("@Dinner_Rate", SqlDbType.Decimal);
            Dinner_Rate.Precision = 18;
            Dinner_Rate.Scale = 2;
            Dinner_Rate.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Dinner_Rate);

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


            Connections.Instance.OpenConection();
            cmd.Connection = Connections.Instance.con;
            //Connections.Instance.ExecuteProcedure(cmd);


            dt.Load(cmd.ExecuteReader());


            ds.Tables["CanteenReport"].Clear();
            ds.Tables["CanteenReport"].Merge(dt);
            string reportFileName;
            if (optAll.Checked == true)
            {
                reportFileName = System.Configuration.ConfigurationSettings.AppSettings["CanteenReportAll"];
            }
            else
            {
                reportFileName = System.Configuration.ConfigurationSettings.AppSettings["CanteenReportEmployee"];
            }
            ReportDocument cryRpt = new ReportDocument();


            cryRpt.Load(System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString() + reportFileName);
            if (optAll.Checked == true)
            {
                if (cryRpt.DataDefinition.FormulaFields.Count > 0)
                {
                    if (cboDepartment.SelectedIndex > -1)
                    {
                        cryRpt.DataDefinition.FormulaFields[0].Text = "'" + cboDepartment.Text + "'";
                    }
                    else
                    {
                        cryRpt.DataDefinition.FormulaFields[0].Text = "'All'";

                    }

                    if (cboPaymentMode.SelectedIndex > -1)
                    {
                        cryRpt.DataDefinition.FormulaFields[1].Text = "'" + cboPaymentMode.Text + "'";
                    }
                    else
                    {
                        cryRpt.DataDefinition.FormulaFields[1].Text = "'All'";

                    }
                }
            }
            cryRpt.SetDataSource(ds);
            cryRpt.Refresh();
            //cryRpt.PrintToPrinter(1, true, 0, 0);

            crystalReportViewer2.ReportSource = cryRpt;
            crystalReportViewer2.Refresh();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            crystalReportViewer2.Visible = false;
            cboMonthYear.SelectedIndex = -1;
            cboMonthYear.Text = "";
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
            lblBreakfastAmount.Text = "0";
            lblBreakfastCount.Text = "0";
            lblChapathiAmount.Text = "0";
            lblChapathiCount.Text = "0";
            lblDinnerAmount.Text = "0";
            lblDinnerCount.Text = "0";
            lblLunchAmount.Text = "0";
            lblLunchCount.Text = "0";

            lblBreakfastRate.Text = "0";
            lbllunchRate.Text = "0";

            lblChapathiRate.Text = "0";

            lblDinnerRate.Text = "0";
            GridView.Visible = true;
            GridView.DataSource = null;

            optAll.Checked = true;
        }

        private void cboMonthYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmployeeData();
        }
    }
}
