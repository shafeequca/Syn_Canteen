using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BioMetrix;

namespace Snythite_Canteen
{
    public partial class Admin_Menu : Form
    {
        string Source_Type;
        public Admin_Menu()
        {
            InitializeComponent();
        }

        private void Admin_Menu_Load(object sender, EventArgs e)
        {
           // Connections.Instance.user_id = "0";
            Connections.Instance.OpenConection();
            Source_Type = System.Configuration.ConfigurationSettings.AppSettings["Source_Type"];
            if (Source_Type != "1")
            {
                employeeToolStripMenuItem.Enabled = false;
                departmentToolStripMenuItem.Enabled = false;
                paymentModeToolStripMenuItem.Enabled = false;
                menuToolStripMenuItem.Enabled = false;
                revisionToolStripMenuItem.Enabled = false;
            }
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee frm = new Employee();
            frm.MdiParent = this;
            frm.Show();
        }

        private void revisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Revision frm = new Revision();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Canteen_Menu frm = new Canteen_Menu();
            frm.MdiParent = this;
            frm.Show();
        }

        private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Department frm = new Department();
            frm.MdiParent = this;
            frm.Show();
        }

        private void paymentModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment_Mode frm = new Payment_Mode();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Transactions frm = new Transactions();
            frm.MdiParent = this;
            frm.Show();
        }

        private void revisionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Canteen_Report frm = new Canteen_Report();
            frm.MdiParent = this;
            frm.Show();
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Canteen_Transaction frm = new Canteen_Transaction();
            frm.MdiParent = this;
            frm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
