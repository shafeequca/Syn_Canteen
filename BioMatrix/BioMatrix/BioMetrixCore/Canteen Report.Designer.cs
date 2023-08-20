namespace Snythite_Canteen
{
    partial class Canteen_Report
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
            this.optAll = new System.Windows.Forms.RadioButton();
            this.optEmployeeLevel = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.cboPaymentMode = new System.Windows.Forms.ComboBox();
            this.cboEmployeeId = new System.Windows.Forms.ComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblBreakfastCount = new System.Windows.Forms.Label();
            this.lblLunchCount = new System.Windows.Forms.Label();
            this.lblChapathiCount = new System.Windows.Forms.Label();
            this.lblDinnerCount = new System.Windows.Forms.Label();
            this.lblDinnerAmount = new System.Windows.Forms.Label();
            this.lblChapathiAmount = new System.Windows.Forms.Label();
            this.lblLunchAmount = new System.Windows.Forms.Label();
            this.lblBreakfastAmount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboMonthYear = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblDinnerRate = new System.Windows.Forms.Label();
            this.lblChapathiRate = new System.Windows.Forms.Label();
            this.lbllunchRate = new System.Windows.Forms.Label();
            this.lblBreakfastRate = new System.Windows.Forms.Label();
            this.cboSource = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.crystalReportViewer2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // GridView
            // 
            this.GridView.AllowUserToAddRows = false;
            this.GridView.AllowUserToDeleteRows = false;
            this.GridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridView.BackgroundColor = System.Drawing.Color.White;
            this.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView.Location = new System.Drawing.Point(12, 179);
            this.GridView.Name = "GridView";
            this.GridView.ReadOnly = true;
            this.GridView.RowHeadersVisible = false;
            this.GridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridView.Size = new System.Drawing.Size(938, 399);
            this.GridView.TabIndex = 1;
            // 
            // optAll
            // 
            this.optAll.AutoSize = true;
            this.optAll.Checked = true;
            this.optAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optAll.ForeColor = System.Drawing.Color.White;
            this.optAll.Location = new System.Drawing.Point(12, 12);
            this.optAll.Name = "optAll";
            this.optAll.Size = new System.Drawing.Size(83, 20);
            this.optAll.TabIndex = 2;
            this.optAll.TabStop = true;
            this.optAll.Text = "Summary";
            this.optAll.UseVisualStyleBackColor = true;
            // 
            // optEmployeeLevel
            // 
            this.optEmployeeLevel.AutoSize = true;
            this.optEmployeeLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optEmployeeLevel.ForeColor = System.Drawing.Color.White;
            this.optEmployeeLevel.Location = new System.Drawing.Point(126, 12);
            this.optEmployeeLevel.Name = "optEmployeeLevel";
            this.optEmployeeLevel.Size = new System.Drawing.Size(124, 20);
            this.optEmployeeLevel.TabIndex = 3;
            this.optEmployeeLevel.Text = "Employee Level";
            this.optEmployeeLevel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Month& Year";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(256, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 19);
            this.label2.TabIndex = 94;
            this.label2.Text = "Department";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 19);
            this.label3.TabIndex = 95;
            this.label3.Text = "Payment Mode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(256, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 19);
            this.label4.TabIndex = 96;
            this.label4.Text = "Employee ID";
            // 
            // cboDepartment
            // 
            this.cboDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(354, 41);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(123, 21);
            this.cboDepartment.TabIndex = 97;
            // 
            // cboPaymentMode
            // 
            this.cboPaymentMode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPaymentMode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPaymentMode.FormattingEnabled = true;
            this.cboPaymentMode.Location = new System.Drawing.Point(126, 73);
            this.cboPaymentMode.Name = "cboPaymentMode";
            this.cboPaymentMode.Size = new System.Drawing.Size(124, 21);
            this.cboPaymentMode.TabIndex = 98;
            // 
            // cboEmployeeId
            // 
            this.cboEmployeeId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboEmployeeId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEmployeeId.FormattingEnabled = true;
            this.cboEmployeeId.Location = new System.Drawing.Point(354, 73);
            this.cboEmployeeId.Name = "cboEmployeeId";
            this.cboEmployeeId.Size = new System.Drawing.Size(123, 21);
            this.cboEmployeeId.TabIndex = 99;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(126, 135);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(105, 38);
            this.btnPrint.TabIndex = 102;
            this.btnPrint.Text = "&Print Preview";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(243, 135);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(105, 38);
            this.btnReset.TabIndex = 101;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(12, 135);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(105, 38);
            this.btnShow.TabIndex = 100;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(491, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 19);
            this.label5.TabIndex = 104;
            this.label5.Text = "Breakfast";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(491, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 19);
            this.label6.TabIndex = 105;
            this.label6.Text = "Lunch";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(491, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 19);
            this.label7.TabIndex = 106;
            this.label7.Text = "Chapathi";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(491, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 19);
            this.label8.TabIndex = 107;
            this.label8.Text = "Dinner";
            // 
            // lblBreakfastCount
            // 
            this.lblBreakfastCount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreakfastCount.ForeColor = System.Drawing.Color.White;
            this.lblBreakfastCount.Location = new System.Drawing.Point(703, 34);
            this.lblBreakfastCount.Name = "lblBreakfastCount";
            this.lblBreakfastCount.Size = new System.Drawing.Size(91, 19);
            this.lblBreakfastCount.TabIndex = 108;
            this.lblBreakfastCount.Text = "0";
            this.lblBreakfastCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblLunchCount
            // 
            this.lblLunchCount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLunchCount.ForeColor = System.Drawing.Color.White;
            this.lblLunchCount.Location = new System.Drawing.Point(703, 71);
            this.lblLunchCount.Name = "lblLunchCount";
            this.lblLunchCount.Size = new System.Drawing.Size(91, 19);
            this.lblLunchCount.TabIndex = 109;
            this.lblLunchCount.Text = "0";
            this.lblLunchCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblChapathiCount
            // 
            this.lblChapathiCount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChapathiCount.ForeColor = System.Drawing.Color.White;
            this.lblChapathiCount.Location = new System.Drawing.Point(703, 107);
            this.lblChapathiCount.Name = "lblChapathiCount";
            this.lblChapathiCount.Size = new System.Drawing.Size(91, 19);
            this.lblChapathiCount.TabIndex = 110;
            this.lblChapathiCount.Text = "0";
            this.lblChapathiCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDinnerCount
            // 
            this.lblDinnerCount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDinnerCount.ForeColor = System.Drawing.Color.White;
            this.lblDinnerCount.Location = new System.Drawing.Point(703, 144);
            this.lblDinnerCount.Name = "lblDinnerCount";
            this.lblDinnerCount.Size = new System.Drawing.Size(91, 19);
            this.lblDinnerCount.TabIndex = 111;
            this.lblDinnerCount.Text = "0";
            this.lblDinnerCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDinnerAmount
            // 
            this.lblDinnerAmount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDinnerAmount.ForeColor = System.Drawing.Color.White;
            this.lblDinnerAmount.Location = new System.Drawing.Point(817, 145);
            this.lblDinnerAmount.Name = "lblDinnerAmount";
            this.lblDinnerAmount.Size = new System.Drawing.Size(91, 19);
            this.lblDinnerAmount.TabIndex = 115;
            this.lblDinnerAmount.Text = "0";
            this.lblDinnerAmount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblChapathiAmount
            // 
            this.lblChapathiAmount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChapathiAmount.ForeColor = System.Drawing.Color.White;
            this.lblChapathiAmount.Location = new System.Drawing.Point(817, 108);
            this.lblChapathiAmount.Name = "lblChapathiAmount";
            this.lblChapathiAmount.Size = new System.Drawing.Size(91, 19);
            this.lblChapathiAmount.TabIndex = 114;
            this.lblChapathiAmount.Text = "0";
            this.lblChapathiAmount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblLunchAmount
            // 
            this.lblLunchAmount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLunchAmount.ForeColor = System.Drawing.Color.White;
            this.lblLunchAmount.Location = new System.Drawing.Point(817, 72);
            this.lblLunchAmount.Name = "lblLunchAmount";
            this.lblLunchAmount.Size = new System.Drawing.Size(91, 19);
            this.lblLunchAmount.TabIndex = 113;
            this.lblLunchAmount.Text = "0";
            this.lblLunchAmount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblBreakfastAmount
            // 
            this.lblBreakfastAmount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreakfastAmount.ForeColor = System.Drawing.Color.White;
            this.lblBreakfastAmount.Location = new System.Drawing.Point(817, 35);
            this.lblBreakfastAmount.Name = "lblBreakfastAmount";
            this.lblBreakfastAmount.Size = new System.Drawing.Size(91, 19);
            this.lblBreakfastAmount.TabIndex = 112;
            this.lblBreakfastAmount.Text = "0";
            this.lblBreakfastAmount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(703, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 19);
            this.label9.TabIndex = 116;
            this.label9.Text = "Count";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(817, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 19);
            this.label10.TabIndex = 117;
            this.label10.Text = "Total";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboMonthYear
            // 
            this.cboMonthYear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMonthYear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMonthYear.FormattingEnabled = true;
            this.cboMonthYear.Location = new System.Drawing.Point(126, 43);
            this.cboMonthYear.Name = "cboMonthYear";
            this.cboMonthYear.Size = new System.Drawing.Size(124, 21);
            this.cboMonthYear.TabIndex = 118;
            this.cboMonthYear.SelectedIndexChanged += new System.EventHandler(this.cboMonthYear_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(602, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 19);
            this.label11.TabIndex = 123;
            this.label11.Text = "Rate";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDinnerRate
            // 
            this.lblDinnerRate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDinnerRate.ForeColor = System.Drawing.Color.White;
            this.lblDinnerRate.Location = new System.Drawing.Point(602, 144);
            this.lblDinnerRate.Name = "lblDinnerRate";
            this.lblDinnerRate.Size = new System.Drawing.Size(91, 19);
            this.lblDinnerRate.TabIndex = 122;
            this.lblDinnerRate.Text = "0";
            this.lblDinnerRate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblChapathiRate
            // 
            this.lblChapathiRate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChapathiRate.ForeColor = System.Drawing.Color.White;
            this.lblChapathiRate.Location = new System.Drawing.Point(602, 107);
            this.lblChapathiRate.Name = "lblChapathiRate";
            this.lblChapathiRate.Size = new System.Drawing.Size(91, 19);
            this.lblChapathiRate.TabIndex = 121;
            this.lblChapathiRate.Text = "0";
            this.lblChapathiRate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbllunchRate
            // 
            this.lbllunchRate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllunchRate.ForeColor = System.Drawing.Color.White;
            this.lbllunchRate.Location = new System.Drawing.Point(602, 71);
            this.lbllunchRate.Name = "lbllunchRate";
            this.lbllunchRate.Size = new System.Drawing.Size(91, 19);
            this.lbllunchRate.TabIndex = 120;
            this.lbllunchRate.Text = "0";
            this.lbllunchRate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblBreakfastRate
            // 
            this.lblBreakfastRate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreakfastRate.ForeColor = System.Drawing.Color.White;
            this.lblBreakfastRate.Location = new System.Drawing.Point(602, 34);
            this.lblBreakfastRate.Name = "lblBreakfastRate";
            this.lblBreakfastRate.Size = new System.Drawing.Size(91, 19);
            this.lblBreakfastRate.TabIndex = 119;
            this.lblBreakfastRate.Text = "0";
            this.lblBreakfastRate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboSource
            // 
            this.cboSource.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSource.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSource.FormattingEnabled = true;
            this.cboSource.Location = new System.Drawing.Point(126, 105);
            this.cboSource.Name = "cboSource";
            this.cboSource.Size = new System.Drawing.Size(124, 21);
            this.cboSource.TabIndex = 125;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(12, 107);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 19);
            this.label12.TabIndex = 124;
            this.label12.Text = "Source";
            // 
            // crystalReportViewer2
            // 
            this.crystalReportViewer2.ActiveViewIndex = -1;
            this.crystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer2.Location = new System.Drawing.Point(16, 179);
            this.crystalReportViewer2.Name = "crystalReportViewer2";
            this.crystalReportViewer2.Size = new System.Drawing.Size(150, 150);
            this.crystalReportViewer2.TabIndex = 126;
            this.crystalReportViewer2.Visible = false;
            // 
            // Canteen_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(965, 590);
            this.Controls.Add(this.crystalReportViewer2);
            this.Controls.Add(this.cboSource);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblDinnerRate);
            this.Controls.Add(this.lblChapathiRate);
            this.Controls.Add(this.lbllunchRate);
            this.Controls.Add(this.lblBreakfastRate);
            this.Controls.Add(this.cboMonthYear);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblDinnerAmount);
            this.Controls.Add(this.lblChapathiAmount);
            this.Controls.Add(this.lblLunchAmount);
            this.Controls.Add(this.lblBreakfastAmount);
            this.Controls.Add(this.lblDinnerCount);
            this.Controls.Add(this.lblChapathiCount);
            this.Controls.Add(this.lblLunchCount);
            this.Controls.Add(this.lblBreakfastCount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.cboEmployeeId);
            this.Controls.Add(this.cboPaymentMode);
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.optEmployeeLevel);
            this.Controls.Add(this.optAll);
            this.Controls.Add(this.GridView);
            this.Name = "Canteen_Report";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Canteen Report";
            this.Load += new System.EventHandler(this.Canteen_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GridView;
        private System.Windows.Forms.RadioButton optAll;
        private System.Windows.Forms.RadioButton optEmployeeLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.ComboBox cboPaymentMode;
        private System.Windows.Forms.ComboBox cboEmployeeId;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnShow;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblBreakfastCount;
        private System.Windows.Forms.Label lblLunchCount;
        private System.Windows.Forms.Label lblChapathiCount;
        private System.Windows.Forms.Label lblDinnerCount;
        private System.Windows.Forms.Label lblDinnerAmount;
        private System.Windows.Forms.Label lblChapathiAmount;
        private System.Windows.Forms.Label lblLunchAmount;
        private System.Windows.Forms.Label lblBreakfastAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboMonthYear;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblDinnerRate;
        private System.Windows.Forms.Label lblChapathiRate;
        private System.Windows.Forms.Label lbllunchRate;
        private System.Windows.Forms.Label lblBreakfastRate;
        private System.Windows.Forms.ComboBox cboSource;
        private System.Windows.Forms.Label label12;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer2;
    }
}