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
using Snythite_Canteen.DataSet;
using CrystalDecisions.CrystalReports.Engine;

namespace BioMetrixCore
{
    public partial class Menu : Form
    {
        DataSet1 ds;
        DeviceManipulator manipulator = new DeviceManipulator();
        public ZkemClient objZkeeper;
        private bool isDeviceConnected = false;

        public string IPAddress;
        public string PortNumber;
        public string MachineNumber;
        public int FingerRetryCount;
        public string source;
        int i;
        public bool IsDeviceConnected
        {
            get { return isDeviceConnected; }
            set
            {
                isDeviceConnected = value;
                if (isDeviceConnected)
                {
                    lblStatus.Text = "The device is connected !!";
                }
                else
                {
                    lblStatus.Text = "The device is diconnected !!";
                    objZkeeper.Disconnect();
                }
            }
        }
        public Menu()
        {
            InitializeComponent();
        }
        private void RaiseDeviceEvent(object sender, string actionType)
        {
            switch (actionType)
            {
                case UniversalStatic.acx_Disconnect:
                    {
                        lblStatus.Text ="The device is switched off";
                        break;
                    }

                default:
                    break;
            }

        }
        private void RaiseAttendance(string EnrollNumber)
        {
            txtEmployeeCode.Text = EnrollNumber;
            txtEmployeeCode_KeyPress(null, new KeyPressEventArgs(Convert.ToChar(13)));
        
        }
        private void Connect()
        {
           
     
            try
            {
                this.Cursor = Cursors.WaitCursor;
                lblStatus.Text =string.Empty;

                if (IsDeviceConnected)
                {
                    IsDeviceConnected = false;
                    this.Cursor = Cursors.Default;

                    return;
                }

                string ipAddress = IPAddress;
                string port = PortNumber;
                if (ipAddress == string.Empty || port == string.Empty)
                    throw new Exception("The Device IP Address and Port is mandotory !!");

                int portNumber = 4370;
                if (!int.TryParse(port, out portNumber))
                    throw new Exception("Not a valid port number");

                bool isValidIpA = UniversalStatic.ValidateIP(ipAddress);
                if (!isValidIpA)
                    throw new Exception("The Device IP is invalid !!");

                isValidIpA = UniversalStatic.PingTheDevice(ipAddress);
                if (!isValidIpA)
                    throw new Exception("The device at " + ipAddress + ":" + port + " did not respond!!");

                objZkeeper = new ZkemClient(RaiseDeviceEvent);
                objZkeeper = new ZkemClient(RaiseAttendance);
                IsDeviceConnected = objZkeeper.Connect_Net(ipAddress, portNumber);

                if (IsDeviceConnected)
                {
                    string deviceInfo = manipulator.FetchDeviceInfo(objZkeeper, int.Parse(MachineNumber));
             
                }

            }
            catch (Exception ex)
            {
                if (i < FingerRetryCount)
                {
                    i = i + 1;
                    Connect();
                }
                else 
                lblStatus.Text= ex.Message;
            }
            this.Cursor = Cursors.Default;
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            if (System.Configuration.ConfigurationSettings.AppSettings["App_Type"] == "Security")
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
            IPAddress = System.Configuration.ConfigurationSettings.AppSettings["Fingerprint-IP"];
            PortNumber = System.Configuration.ConfigurationSettings.AppSettings["Fingerprint-Port"];

            MachineNumber = System.Configuration.ConfigurationSettings.AppSettings["FingerPrint-Machine"]; ;

            i = 0;

            FingerRetryCount = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["FingerRetryCount"]);

            source = System.Configuration.ConfigurationSettings.AppSettings["Source"].ToString();

            Connections.Instance.user_id = "0";
            Connect();
            get_Menu();
            ds = new DataSet1();
            txtEmployeeCode.Focus();
                       
        }
        private void get_Menu()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Get_Canteen_Menu";

            Connections.Instance.OpenConection();
            cmd.Connection = Connections.Instance.con;
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetValue(1).ToString().ToUpper() == "BREAKFAST")
                {
                    BreakFast.Text = reader.GetValue(2).ToString();
                    BreakFast.Tag = reader.GetValue(0).ToString();
               
                }
                else if (reader.GetValue(1).ToString().ToUpper() == "LUNCH")
                {
                    Lunch.Text = reader.GetValue(2).ToString();
                    Lunch.Tag = reader.GetValue(0).ToString();
                    
                }
                else if (reader.GetValue(1).ToString().ToUpper() == "CHAPATHI")
                {
                    Chapathi.Text = reader.GetValue(2).ToString();
                    Chapathi.Tag = reader.GetValue(0).ToString();
                   
                }
                else if (reader.GetValue(1).ToString().ToUpper() == "DINNER")
                {
                    Dinner.Text = reader.GetValue(2).ToString();
                    Dinner.Tag = reader.GetValue(0).ToString();
                    
                }
                else if (reader.GetValue(1).ToString().ToUpper() == "DINNER-CHAPATHI")
                {
                    DinnerChapathi.Text = reader.GetValue(2).ToString();
                    DinnerChapathi.Tag = reader.GetValue(0).ToString();

                }
            }
            reader.Close();
            cmd.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt");

            
        }

        private int Add_Canteen_Transaction(string Menu_Id)
        {
            if (txtEmployeeCode.Text == "" || txtEmployeeCode.Tag.ToString() == "")
            {
                return 0;
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Canteen_Transaction";

            cmd.Parameters.Add("@Employee_Id", SqlDbType.Int).Value = txtEmployeeCode.Tag;
            cmd.Parameters.Add("@Menu_Id", SqlDbType.Int).Value = Menu_Id;
            cmd.Parameters.Add("@Is_Delete", SqlDbType.Int).Value = "0";
            cmd.Parameters.Add("@No_Of_Entries", SqlDbType.Int).Value = "1";
            cmd.Parameters.Add("@Transaction_Time", SqlDbType.DateTime).Value = null;
            cmd.Parameters.Add("@Transaction_Id", SqlDbType.Int).Value = null;
            cmd.Parameters.Add("@User_ID", SqlDbType.Int).Value = Connections.Instance.user_id;

            cmd.Parameters.Add("@source", SqlDbType.VarChar).Value = source;

            cmd.Parameters.Add("@Transaction_Id_Out", SqlDbType.Int);
            cmd.Parameters["@Transaction_Id_Out"].Direction = ParameterDirection.Output;

            Connections.Instance.OpenConection();
            Connections.Instance.ExecuteProcedure(cmd);

            return Convert.ToInt32(cmd.Parameters["@Transaction_Id_Out"].Value.ToString());

        }

        private void BreakFast_Click(object sender, EventArgs e)
        {
            try
            {
                BreakFast.Enabled = false;
                int Transaction_id = Add_Canteen_Transaction(BreakFast.Tag.ToString());

                PrintSlip(Transaction_id, "Breakfast");

                Clear_Click(null, null);
            }
            catch (Exception ex)
            { }
        }

        private void PrintSlip(int Transaction_id,string Canteen_Menu)
        {
            //return;
            string reportFileName = System.Configuration.ConfigurationSettings.AppSettings["ReceiptSlip"];

            System.Data.DataColumn Transaction_Id = new System.Data.DataColumn("Transaction_Id", typeof(System.Int32));
            Transaction_Id.DefaultValue = Transaction_id;

            System.Data.DataColumn Employee_Code = new System.Data.DataColumn("Employee_Code", typeof(System.String));
            Employee_Code.DefaultValue = txtEmployeeCode.Text;

            System.Data.DataColumn Employee_Name = new System.Data.DataColumn("Employee_Name", typeof(System.String));
            Employee_Name.DefaultValue = txtEmployeeName.Text;

            System.Data.DataColumn Menu = new System.Data.DataColumn("Menu", typeof(System.String));
            Menu.DefaultValue = Canteen_Menu;

            System.Data.DataColumn User = new System.Data.DataColumn("User", typeof(System.String));
            User.DefaultValue = System.Configuration.ConfigurationSettings.AppSettings["System"];

            DataTable dt = new DataTable();
            dt.Columns.Add(Transaction_Id);
            dt.Columns.Add(Employee_Code);
            dt.Columns.Add(Employee_Name);
            dt.Columns.Add(Menu);
            dt.Columns.Add(User);

            DataRow toInsert = dt.NewRow();

            dt.Rows.InsertAt(toInsert, 0);


            ds.Tables["CanteenSlip"].Clear();
            ds.Tables["CanteenSlip"].Merge(dt);

            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString() + reportFileName);
            cryRpt.SetDataSource(ds);
            cryRpt.Refresh();
            cryRpt.PrintToPrinter(1, true, 0, 0);
            cryRpt.Close();
            cryRpt.Dispose();
            dt.Dispose();
            
        }

        private void Lunch_Click(object sender, EventArgs e)
        {
            try
            {
                Lunch.Enabled = false;
                int Transaction_id = Add_Canteen_Transaction(Lunch.Tag.ToString());
                PrintSlip(Transaction_id, "Lunch");
                Clear_Click(null, null);
            }
            catch (Exception ex)
            { }
        }

        private void Chapathi_Click(object sender, EventArgs e)
        {
            try
            {
                Chapathi.Enabled = false;
                int Transaction_id = Add_Canteen_Transaction(Chapathi.Tag.ToString());
                PrintSlip(Transaction_id, "Chapathi");
                Clear_Click(null, null);
            }
            catch (Exception ex)
            { }
        }

        private void Dinner_Click(object sender, EventArgs e)
        {
            
            try
            {
                Dinner.Enabled = false;
                int Transaction_id = Add_Canteen_Transaction(Dinner.Tag.ToString());
                PrintSlip(Transaction_id, "Dinner");
                Clear_Click(null, null);
            }
            catch (Exception ex)
            { }
        }

        private void Clear_Click(object sender, EventArgs e)
        {

            ReportDocument cryRpt = new ReportDocument();
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString() + "\\Reports\\rptVisit.rpt";
            cryRpt.Load(System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString() + "\\Reports\\rptVisit.rpt");
            cryRpt.DataDefinition.FormulaFields[1].Text = "'D:\\Screenshot135405.jpg'";

            cryRpt.Refresh();
            cryRpt.PrintToPrinter(1, true, 0, 0);
            cryRpt.Close();
            cryRpt.Dispose();



            BreakFast.BackColor = Color.White;
            Lunch.BackColor = Color.White;
            Chapathi.BackColor = Color.White;
            DinnerChapathi.BackColor = Color.White;
            Dinner.BackColor = Color.White;
            txtEmployeeCode.Text = "";
            txtEmployeeCode.Tag = "";
            txtEmployeeName.Text = "";
            txtEmployeeName.Tag = "";
            BreakFast.Enabled = false;
            Lunch.Enabled = false;
            Chapathi.Enabled = false;
            DinnerChapathi.Enabled = false;
            Dinner.Enabled = false;
            timer2.Enabled = false;
            txtEmployeeCode.Focus();
        }

        private void txtEmployeeCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                timer2.Enabled = true;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_Employee";

                cmd.Parameters.Add("@Employee_Code", SqlDbType.VarChar).Value = txtEmployeeCode.Text.Trim();
                
                cmd.Parameters.Add("@Employee_Id", SqlDbType.Int);
                cmd.Parameters["@Employee_Id"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@Employee_Name", SqlDbType.VarChar,100);
                cmd.Parameters["@Employee_Name"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@Department_Name", SqlDbType.VarChar, 100);
                cmd.Parameters["@Department_Name"].Direction = ParameterDirection.Output;

                Connections.Instance.OpenConection();
                Connections.Instance.ExecuteProcedure(cmd);

                txtEmployeeCode.Tag = cmd.Parameters["@Employee_Id"].Value.ToString();
                txtEmployeeName.Text = cmd.Parameters["@Employee_Name"].Value.ToString();
                txtEmployeeName.Tag = cmd.Parameters["@Department_Name"].Value.ToString();

                ////////////////////////////////////////////////////////////////////////////

                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandText = "Get_Canteen_Menu_Employee";

                if (cmd.Parameters["@Employee_Id"].Value.ToString() == "")
                {
                    MessageBox.Show ("Employee details not found");
                    txtEmployeeName.Text = "";
                    txtEmployeeCode.Tag = "";
                    txtEmployeeCode.Focus();
                    return;
                }

                cmd1.Parameters.Add("@Employee_Id", SqlDbType.Int).Value = txtEmployeeCode.Tag.ToString();

                BreakFast.ForeColor = Color.Black;
                BreakFast.Enabled = false;

                Lunch.ForeColor = Color.Black;
                Lunch.Enabled = false;

                Chapathi.ForeColor = Color.Black;
                Chapathi.Enabled = false;

                Dinner.ForeColor = Color.Black;
                Dinner.Enabled = false;

                DinnerChapathi.ForeColor = Color.Black;
                DinnerChapathi.Enabled = false;

                string Direct_Print = System.Configuration.ConfigurationSettings.AppSettings["Direct_Print"].ToString();

                Connections.Instance.OpenConection();
                cmd1.Connection = Connections.Instance.con;
                SqlDataReader reader;
                reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    
                    if (reader.GetValue(1).ToString().ToUpper() == "BREAKFAST")
                    {
                        BreakFast.Tag = reader.GetValue(0).ToString();
                        if (Direct_Print == "YES")
                        {
                            BreakFast_Click(null, null);
                        }
                        else
                        {
                            BreakFast.BackColor = Color.LawnGreen;
                            BreakFast.ForeColor = Color.Red;
                            BreakFast.Enabled = true;
                        }
                    }
                    else if (reader.GetValue(1).ToString().ToUpper() == "LUNCH")
                    {
                        Lunch.Tag = reader.GetValue(0).ToString();

                        if (Direct_Print == "YES")
                        {
                            Lunch_Click(null, null);
                        }
                        else
                        {
                            Lunch.BackColor = Color.LawnGreen;
                            Lunch.ForeColor = Color.Red;
                            Lunch.Enabled = true;
                        }

                        
                    }
                    else if (reader.GetValue(1).ToString().ToUpper() == "CHAPATHI")
                    {
                        Chapathi.Tag = reader.GetValue(0).ToString();

                        if (Direct_Print == "YES")
                        {
                            Chapathi_Click(null, null);
                        }
                        else
                        {

                            Chapathi.BackColor = Color.LawnGreen;
                            Chapathi.ForeColor = Color.Red;
                            Chapathi.Enabled = true;
                        }
                    }
                    else if (reader.GetValue(1).ToString().ToUpper() == "DINNER")
                    {
                        Dinner.Tag = reader.GetValue(0).ToString();

                        if (Direct_Print == "YES")
                        {
                            Dinner_Click(null, null);
                        }
                        else
                        {
                            Dinner.BackColor = Color.LawnGreen;
                            Dinner.ForeColor = Color.Red;
                            Dinner.Enabled = true;
                        }
                    }
                    else if (reader.GetValue(1).ToString().ToUpper() == "DINNER-CHAPATHI")
                    {
                        DinnerChapathi.Tag = reader.GetValue(0).ToString();

                        if (Direct_Print == "YES")
                        {
                            DinnerChapathi_Click(null, null);
                        }
                        else
                        {
                            DinnerChapathi.BackColor = Color.LawnGreen;
                            DinnerChapathi.ForeColor = Color.Red;
                            DinnerChapathi.Enabled = true;
                        }
                    }
                }
                reader.Close();
                cmd.Dispose();
                cmd1.Dispose();
               
            }

        }

        private void txtEmployeeCode_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           
            if (txtEmployeeCode.Text!="")
            Clear_Click(null, null);
            
           
        }

        private void DinnerChapathi_Click(object sender, EventArgs e)
        {
            try
            {
                DinnerChapathi.Enabled = false;
                int Transaction_id = Add_Canteen_Transaction(DinnerChapathi.Tag.ToString());
                PrintSlip(Transaction_id, "Dinner-Chapathi");
                Clear_Click(null, null);
            }
            catch (Exception ex)
            { }
        }
    }
}
