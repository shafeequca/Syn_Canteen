namespace Snythite_Canteen
{
    partial class Employee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GridView = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtEmployeeNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.cboPayment = new System.Windows.Forms.ComboBox();
            this.chkBreakFast = new System.Windows.Forms.CheckBox();
            this.chkLunch = new System.Windows.Forms.CheckBox();
            this.chkChapathi = new System.Windows.Forms.CheckBox();
            this.chkDinner = new System.Windows.Forms.CheckBox();
            this.DTBreakfast = new System.Windows.Forms.DateTimePicker();
            this.ChkBreakFastRestrict = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ChkLunchRestrict = new System.Windows.Forms.CheckBox();
            this.DTLunch = new System.Windows.Forms.DateTimePicker();
            this.ChkChapathiRestrict = new System.Windows.Forms.CheckBox();
            this.DTChapathi = new System.Windows.Forms.DateTimePicker();
            this.ChkDinnerRestrict = new System.Windows.Forms.CheckBox();
            this.DTDinner = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.chkDinnerChapathi = new System.Windows.Forms.CheckBox();
            this.ChkDinnerChapathiRestrict = new System.Windows.Forms.CheckBox();
            this.DTDinnerChapathi = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // GridView
            // 
            this.GridView.AllowUserToAddRows = false;
            this.GridView.AllowUserToDeleteRows = false;
            this.GridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridView.BackgroundColor = System.Drawing.Color.White;
            this.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView.Location = new System.Drawing.Point(452, 12);
            this.GridView.Name = "GridView";
            this.GridView.ReadOnly = true;
            this.GridView.RowHeadersVisible = false;
            this.GridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridView.Size = new System.Drawing.Size(512, 328);
            this.GridView.TabIndex = 0;
            this.GridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellClick);
            this.GridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellContentClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(452, 362);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(512, 23);
            this.txtSearch.TabIndex = 12;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // txtEmployeeNo
            // 
            this.txtEmployeeNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeNo.Location = new System.Drawing.Point(103, 22);
            this.txtEmployeeNo.Name = "txtEmployeeNo";
            this.txtEmployeeNo.Size = new System.Drawing.Size(98, 23);
            this.txtEmployeeNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Employee";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeName.Location = new System.Drawing.Point(207, 22);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(220, 23);
            this.txtEmployeeName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(21, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Department";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(207, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Payment Mode";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(23, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Menu";
            // 
            // cboDepartment
            // 
            this.cboDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(103, 63);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(98, 21);
            this.cboDepartment.TabIndex = 3;
            // 
            // cboPayment
            // 
            this.cboPayment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPayment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPayment.FormattingEnabled = true;
            this.cboPayment.Location = new System.Drawing.Point(305, 60);
            this.cboPayment.Name = "cboPayment";
            this.cboPayment.Size = new System.Drawing.Size(122, 21);
            this.cboPayment.TabIndex = 4;
            // 
            // chkBreakFast
            // 
            this.chkBreakFast.AutoSize = true;
            this.chkBreakFast.Checked = true;
            this.chkBreakFast.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBreakFast.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBreakFast.ForeColor = System.Drawing.Color.White;
            this.chkBreakFast.Location = new System.Drawing.Point(26, 171);
            this.chkBreakFast.Name = "chkBreakFast";
            this.chkBreakFast.Size = new System.Drawing.Size(80, 20);
            this.chkBreakFast.TabIndex = 5;
            this.chkBreakFast.Text = "Breakfast";
            this.chkBreakFast.UseVisualStyleBackColor = true;
            // 
            // chkLunch
            // 
            this.chkLunch.AutoSize = true;
            this.chkLunch.Checked = true;
            this.chkLunch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLunch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLunch.ForeColor = System.Drawing.Color.White;
            this.chkLunch.Location = new System.Drawing.Point(26, 207);
            this.chkLunch.Name = "chkLunch";
            this.chkLunch.Size = new System.Drawing.Size(60, 20);
            this.chkLunch.TabIndex = 6;
            this.chkLunch.Text = "Lunch";
            this.chkLunch.UseVisualStyleBackColor = true;
            // 
            // chkChapathi
            // 
            this.chkChapathi.AutoSize = true;
            this.chkChapathi.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkChapathi.ForeColor = System.Drawing.Color.White;
            this.chkChapathi.Location = new System.Drawing.Point(26, 242);
            this.chkChapathi.Name = "chkChapathi";
            this.chkChapathi.Size = new System.Drawing.Size(77, 20);
            this.chkChapathi.TabIndex = 7;
            this.chkChapathi.Text = "Chapathi";
            this.chkChapathi.UseVisualStyleBackColor = true;
            // 
            // chkDinner
            // 
            this.chkDinner.AutoSize = true;
            this.chkDinner.Checked = true;
            this.chkDinner.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDinner.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDinner.ForeColor = System.Drawing.Color.White;
            this.chkDinner.Location = new System.Drawing.Point(26, 278);
            this.chkDinner.Name = "chkDinner";
            this.chkDinner.Size = new System.Drawing.Size(64, 20);
            this.chkDinner.TabIndex = 8;
            this.chkDinner.Text = "Dinner";
            this.chkDinner.UseVisualStyleBackColor = true;
            // 
            // DTBreakfast
            // 
            this.DTBreakfast.Enabled = false;
            this.DTBreakfast.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTBreakfast.Location = new System.Drawing.Point(163, 170);
            this.DTBreakfast.Name = "DTBreakfast";
            this.DTBreakfast.Size = new System.Drawing.Size(136, 20);
            this.DTBreakfast.TabIndex = 19;
            // 
            // ChkBreakFastRestrict
            // 
            this.ChkBreakFastRestrict.AutoSize = true;
            this.ChkBreakFastRestrict.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkBreakFastRestrict.ForeColor = System.Drawing.Color.White;
            this.ChkBreakFastRestrict.Location = new System.Drawing.Point(361, 173);
            this.ChkBreakFastRestrict.Name = "ChkBreakFastRestrict";
            this.ChkBreakFastRestrict.Size = new System.Drawing.Size(15, 14);
            this.ChkBreakFastRestrict.TabIndex = 20;
            this.ChkBreakFastRestrict.UseVisualStyleBackColor = true;
            this.ChkBreakFastRestrict.CheckedChanged += new System.EventHandler(this.ChkBreakFastRestrict_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(315, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Time Restriction";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(160, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 16);
            this.label6.TabIndex = 22;
            this.label6.Text = "Restriction Time";
            // 
            // ChkLunchRestrict
            // 
            this.ChkLunchRestrict.AutoSize = true;
            this.ChkLunchRestrict.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkLunchRestrict.ForeColor = System.Drawing.Color.White;
            this.ChkLunchRestrict.Location = new System.Drawing.Point(361, 210);
            this.ChkLunchRestrict.Name = "ChkLunchRestrict";
            this.ChkLunchRestrict.Size = new System.Drawing.Size(15, 14);
            this.ChkLunchRestrict.TabIndex = 24;
            this.ChkLunchRestrict.UseVisualStyleBackColor = true;
            this.ChkLunchRestrict.CheckedChanged += new System.EventHandler(this.ChkLunchRestrict_CheckedChanged);
            // 
            // DTLunch
            // 
            this.DTLunch.Enabled = false;
            this.DTLunch.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTLunch.Location = new System.Drawing.Point(163, 207);
            this.DTLunch.Name = "DTLunch";
            this.DTLunch.Size = new System.Drawing.Size(136, 20);
            this.DTLunch.TabIndex = 23;
            // 
            // ChkChapathiRestrict
            // 
            this.ChkChapathiRestrict.AutoSize = true;
            this.ChkChapathiRestrict.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkChapathiRestrict.ForeColor = System.Drawing.Color.White;
            this.ChkChapathiRestrict.Location = new System.Drawing.Point(361, 245);
            this.ChkChapathiRestrict.Name = "ChkChapathiRestrict";
            this.ChkChapathiRestrict.Size = new System.Drawing.Size(15, 14);
            this.ChkChapathiRestrict.TabIndex = 26;
            this.ChkChapathiRestrict.UseVisualStyleBackColor = true;
            this.ChkChapathiRestrict.CheckedChanged += new System.EventHandler(this.ChkChapathiRestrict_CheckedChanged);
            // 
            // DTChapathi
            // 
            this.DTChapathi.Enabled = false;
            this.DTChapathi.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTChapathi.Location = new System.Drawing.Point(163, 242);
            this.DTChapathi.Name = "DTChapathi";
            this.DTChapathi.Size = new System.Drawing.Size(136, 20);
            this.DTChapathi.TabIndex = 25;
            // 
            // ChkDinnerRestrict
            // 
            this.ChkDinnerRestrict.AutoSize = true;
            this.ChkDinnerRestrict.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkDinnerRestrict.ForeColor = System.Drawing.Color.White;
            this.ChkDinnerRestrict.Location = new System.Drawing.Point(361, 281);
            this.ChkDinnerRestrict.Name = "ChkDinnerRestrict";
            this.ChkDinnerRestrict.Size = new System.Drawing.Size(15, 14);
            this.ChkDinnerRestrict.TabIndex = 28;
            this.ChkDinnerRestrict.UseVisualStyleBackColor = true;
            this.ChkDinnerRestrict.CheckedChanged += new System.EventHandler(this.ChkDinnerRestrict_CheckedChanged);
            // 
            // DTDinner
            // 
            this.DTDinner.Enabled = false;
            this.DTDinner.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTDinner.Location = new System.Drawing.Point(163, 278);
            this.DTDinner.Name = "DTDinner";
            this.DTDinner.Size = new System.Drawing.Size(136, 20);
            this.DTDinner.TabIndex = 27;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(25, 354);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 34);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(114, 355);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 34);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(203, 355);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 34);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActive.ForeColor = System.Drawing.Color.White;
            this.chkActive.Location = new System.Drawing.Point(23, 100);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(75, 20);
            this.chkActive.TabIndex = 30;
            this.chkActive.Text = "Is Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // chkDinnerChapathi
            // 
            this.chkDinnerChapathi.AutoSize = true;
            this.chkDinnerChapathi.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDinnerChapathi.ForeColor = System.Drawing.Color.White;
            this.chkDinnerChapathi.Location = new System.Drawing.Point(26, 314);
            this.chkDinnerChapathi.Name = "chkDinnerChapathi";
            this.chkDinnerChapathi.Size = new System.Drawing.Size(118, 20);
            this.chkDinnerChapathi.TabIndex = 31;
            this.chkDinnerChapathi.Text = "Dinner Chapathi";
            this.chkDinnerChapathi.UseVisualStyleBackColor = true;
            // 
            // ChkDinnerChapathiRestrict
            // 
            this.ChkDinnerChapathiRestrict.AutoSize = true;
            this.ChkDinnerChapathiRestrict.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkDinnerChapathiRestrict.ForeColor = System.Drawing.Color.White;
            this.ChkDinnerChapathiRestrict.Location = new System.Drawing.Point(361, 320);
            this.ChkDinnerChapathiRestrict.Name = "ChkDinnerChapathiRestrict";
            this.ChkDinnerChapathiRestrict.Size = new System.Drawing.Size(15, 14);
            this.ChkDinnerChapathiRestrict.TabIndex = 33;
            this.ChkDinnerChapathiRestrict.UseVisualStyleBackColor = true;
            this.ChkDinnerChapathiRestrict.CheckedChanged += new System.EventHandler(this.ChkDinnerChapathiRestrict_CheckedChanged);
            // 
            // DTDinnerChapathi
            // 
            this.DTDinnerChapathi.Enabled = false;
            this.DTDinnerChapathi.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTDinnerChapathi.Location = new System.Drawing.Point(163, 317);
            this.DTDinnerChapathi.Name = "DTDinnerChapathi";
            this.DTDinnerChapathi.Size = new System.Drawing.Size(136, 20);
            this.DTDinnerChapathi.TabIndex = 32;
            // 
            // Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(987, 429);
            this.Controls.Add(this.ChkDinnerChapathiRestrict);
            this.Controls.Add(this.DTDinnerChapathi);
            this.Controls.Add(this.chkDinnerChapathi);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ChkDinnerRestrict);
            this.Controls.Add(this.DTDinner);
            this.Controls.Add(this.ChkChapathiRestrict);
            this.Controls.Add(this.DTChapathi);
            this.Controls.Add(this.ChkLunchRestrict);
            this.Controls.Add(this.DTLunch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ChkBreakFastRestrict);
            this.Controls.Add(this.DTBreakfast);
            this.Controls.Add(this.chkDinner);
            this.Controls.Add(this.chkChapathi);
            this.Controls.Add(this.chkLunch);
            this.Controls.Add(this.chkBreakFast);
            this.Controls.Add(this.cboPayment);
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmployeeNo);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.GridView);
            this.Name = "Employee";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee";
            this.Load += new System.EventHandler(this.Employee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GridView;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtEmployeeNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.ComboBox cboPayment;
        private System.Windows.Forms.CheckBox chkBreakFast;
        private System.Windows.Forms.CheckBox chkLunch;
        private System.Windows.Forms.CheckBox chkChapathi;
        private System.Windows.Forms.CheckBox chkDinner;
        private System.Windows.Forms.DateTimePicker DTBreakfast;
        private System.Windows.Forms.CheckBox ChkBreakFastRestrict;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ChkLunchRestrict;
        private System.Windows.Forms.DateTimePicker DTLunch;
        private System.Windows.Forms.CheckBox ChkChapathiRestrict;
        private System.Windows.Forms.DateTimePicker DTChapathi;
        private System.Windows.Forms.CheckBox ChkDinnerRestrict;
        private System.Windows.Forms.DateTimePicker DTDinner;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.CheckBox chkDinnerChapathi;
        private System.Windows.Forms.CheckBox ChkDinnerChapathiRestrict;
        private System.Windows.Forms.DateTimePicker DTDinnerChapathi;
    }
}