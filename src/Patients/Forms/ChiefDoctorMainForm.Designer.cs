namespace Patients.Forms;

partial class ChiefDoctorMainForm
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


    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        pnlFilter = new Panel();
        lblReportType = new Label();
        cmbReportType = new ComboBox();
        lblStartDate = new Label();
        dtpStartDate = new DateTimePicker();
        lblEndDate = new Label();
        dtpEndDate = new DateTimePicker();
        lblLimit = new Label();
        numLimit = new NumericUpDown();
        btnGenerate = new Button();
        pnlDescription = new Panel();
        txtReportDescription = new TextBox();
        dgvReport = new DataGridView();
        pnlBottom = new Panel();
        btnLogout = new Button();
        btnPrint = new Button();
        pnlFilter.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numLimit).BeginInit();
        pnlDescription.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
        pnlBottom.SuspendLayout();
        SuspendLayout();
        // 
        // pnlFilter
        // 
        pnlFilter.Controls.Add(lblReportType);
        pnlFilter.Controls.Add(cmbReportType);
        pnlFilter.Controls.Add(lblStartDate);
        pnlFilter.Controls.Add(dtpStartDate);
        pnlFilter.Controls.Add(lblEndDate);
        pnlFilter.Controls.Add(dtpEndDate);
        pnlFilter.Controls.Add(lblLimit);
        pnlFilter.Controls.Add(numLimit);
        pnlFilter.Controls.Add(btnGenerate);
        pnlFilter.Dock = DockStyle.Top;
        pnlFilter.Location = new Point(0, 0);
        pnlFilter.Name = "pnlFilter";
        pnlFilter.Size = new Size(800, 50);
        pnlFilter.TabIndex = 3;
        // 
        // lblReportType
        // 
        lblReportType.AutoSize = true;
        lblReportType.Location = new Point(10, 16);
        lblReportType.Name = "lblReportType";
        lblReportType.Size = new Size(42, 15);
        lblReportType.TabIndex = 0;
        lblReportType.Text = "Отчёт:";
        // 
        // cmbReportType
        // 
        cmbReportType.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbReportType.Location = new Point(55, 13);
        cmbReportType.Name = "cmbReportType";
        cmbReportType.Size = new Size(160, 23);
        cmbReportType.TabIndex = 1;
        // 
        // lblStartDate
        // 
        lblStartDate.AutoSize = true;
        lblStartDate.Location = new Point(225, 16);
        lblStartDate.Name = "lblStartDate";
        lblStartDate.Size = new Size(18, 15);
        lblStartDate.TabIndex = 2;
        lblStartDate.Text = "С:";
        // 
        // dtpStartDate
        // 
        dtpStartDate.Format = DateTimePickerFormat.Short;
        dtpStartDate.Location = new Point(245, 13);
        dtpStartDate.Name = "dtpStartDate";
        dtpStartDate.Size = new Size(95, 23);
        dtpStartDate.TabIndex = 3;
        // 
        // lblEndDate
        // 
        lblEndDate.AutoSize = true;
        lblEndDate.Location = new Point(348, 16);
        lblEndDate.Name = "lblEndDate";
        lblEndDate.Size = new Size(26, 15);
        lblEndDate.TabIndex = 4;
        lblEndDate.Text = "По:";
        // 
        // dtpEndDate
        // 
        dtpEndDate.Format = DateTimePickerFormat.Short;
        dtpEndDate.Location = new Point(375, 13);
        dtpEndDate.Name = "dtpEndDate";
        dtpEndDate.Size = new Size(95, 23);
        dtpEndDate.TabIndex = 5;
        // 
        // lblLimit
        // 
        lblLimit.AutoSize = true;
        lblLimit.Location = new Point(480, 16);
        lblLimit.Name = "lblLimit";
        lblLimit.Size = new Size(46, 15);
        lblLimit.TabIndex = 6;
        lblLimit.Text = "Лимит:";
        // 
        // numLimit
        // 
        numLimit.Location = new Point(530, 13);
        numLimit.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numLimit.Name = "numLimit";
        numLimit.Size = new Size(55, 23);
        numLimit.TabIndex = 7;
        numLimit.Value = new decimal(new int[] { 10, 0, 0, 0 });
        // 
        // btnGenerate
        // 
        btnGenerate.Location = new Point(600, 11);
        btnGenerate.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
        btnGenerate.Name = "btnGenerate";
        btnGenerate.Size = new Size(188, 25);
        btnGenerate.TabIndex = 8;
        btnGenerate.Text = "Сформировать";
        btnGenerate.Click += btnGenerate_Click;
        // 
        // pnlDescription
        // 
        pnlDescription.Controls.Add(txtReportDescription);
        pnlDescription.Dock = DockStyle.Top;
        pnlDescription.Location = new Point(0, 50);
        pnlDescription.Name = "pnlDescription";
        pnlDescription.Size = new Size(800, 45);
        pnlDescription.TabIndex = 2;
        // 
        // txtReportDescription
        // 
        txtReportDescription.Dock = DockStyle.Fill;
        txtReportDescription.Location = new Point(0, 0);
        txtReportDescription.Multiline = true;
        txtReportDescription.Name = "txtReportDescription";
        txtReportDescription.ReadOnly = true;
        txtReportDescription.Size = new Size(800, 45);
        txtReportDescription.TabIndex = 0;
        // 
        // dgvReport
        // 
        dgvReport.AllowUserToAddRows = false;
        dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvReport.Dock = DockStyle.Fill;
        dgvReport.Location = new Point(0, 95);
        dgvReport.Name = "dgvReport";
        dgvReport.ReadOnly = true;
        dgvReport.Size = new Size(800, 310);
        dgvReport.TabIndex = 0;
        // 
        // pnlBottom
        // 
        pnlBottom.Controls.Add(btnLogout);
        pnlBottom.Controls.Add(btnPrint);
        pnlBottom.Dock = DockStyle.Bottom;
        pnlBottom.Dock = DockStyle.Bottom;
        pnlBottom.Height = 45;
        pnlBottom.Location = new Point(0, 405);
        pnlBottom.Name = "pnlBottom";
        pnlBottom.Size = new Size(800, 45);
        pnlBottom.TabIndex = 1;
        // 
        // btnLogout
        // 
        btnLogout.Dock = DockStyle.Left;
        btnLogout.Margin = new Padding(30, 30, 30, 30);
        btnLogout.Name = "btnLogout";
        btnLogout.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
        btnLogout.Location = new Point(12, 11);
        btnLogout.Size = new Size(90, 23);
        btnLogout.TabIndex = 0;
        btnLogout.Text = "Выйти";
        btnLogout.Click += btnLogout_Click;
        // 
        // btnPrint
        // 
        btnPrint.Dock = DockStyle.Right;
        btnPrint.Margin = new Padding(30, 30, 30, 30);
        btnPrint.Name = "btnPrint";
        btnPrint.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
        btnPrint.Location = new Point(pnlBottom.Width - 102, 11); 
        btnPrint.Location = new Point(pnlBottom.Width - 90 - 12, 11);
        btnPrint.Size = new Size(90, 23); 
        btnPrint.TabIndex = 1;
        btnPrint.Text = "Напечатать";
        btnPrint.Click += btnPrint_Click;
        // 
        // ChiefDoctorMainForm
        // 
        ClientSize = new Size(820, 450);
        MinimumSize = ClientSize;
        Controls.Add(dgvReport);
        Controls.Add(pnlBottom);
        Controls.Add(pnlDescription);
        Controls.Add(pnlFilter);
        Name = "ChiefDoctorMainForm";
        pnlFilter.ResumeLayout(false);
        pnlFilter.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numLimit).EndInit();
        pnlDescription.ResumeLayout(false);
        pnlDescription.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
        pnlBottom.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Panel pnlFilter;
    private System.Windows.Forms.Label lblReportType;
    private System.Windows.Forms.ComboBox cmbReportType;
    private System.Windows.Forms.Label lblStartDate;
    private System.Windows.Forms.DateTimePicker dtpStartDate;
    private System.Windows.Forms.Label lblEndDate;
    private System.Windows.Forms.DateTimePicker dtpEndDate;
    private System.Windows.Forms.Label lblLimit;
    private System.Windows.Forms.NumericUpDown numLimit;
    private System.Windows.Forms.Button btnGenerate;

    private System.Windows.Forms.Panel pnlDescription;
    private System.Windows.Forms.TextBox txtReportDescription;

    private System.Windows.Forms.DataGridView dgvReport;

    private System.Windows.Forms.Panel pnlBottom;
    private System.Windows.Forms.Button btnLogout;
    private System.Windows.Forms.Button btnPrint;
}