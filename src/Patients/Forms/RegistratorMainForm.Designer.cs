namespace Patients.Forms;

partial class RegistratorMainForm
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
        pnlHeader = new Panel();
        btnLogout = new Button();
        lblWelcome = new Label();
        pnlSearch = new Panel();
        btnResetSearch = new Button();
        btnSearch = new Button();
        txtSearchCardNumber = new TextBox();
        lblSearch = new Label();
        dgvPatients = new DataGridView();
        colId = new DataGridViewTextBoxColumn();
        colCardNumber = new DataGridViewTextBoxColumn();
        colFullName = new DataGridViewTextBoxColumn();
        colBirthDate = new DataGridViewTextBoxColumn();
        colGender = new DataGridViewTextBoxColumn();
        colPhone = new DataGridViewTextBoxColumn();
        colPolicyNumber = new DataGridViewTextBoxColumn();
        pnlFooter = new Panel();
        btnCreateAppointment = new Button();
        btnCreatePatient = new Button();
        pnlHeader.SuspendLayout();
        pnlSearch.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
        pnlFooter.SuspendLayout();
        SuspendLayout();
        // 
        // pnlHeader
        // 
        pnlHeader.Controls.Add(btnLogout);
        pnlHeader.Controls.Add(lblWelcome);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Size = new Size(950, 50);
        pnlHeader.TabIndex = 0;
        // 
        // btnLogout
        // 
        btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnLogout.Location = new Point(830, 12);
        btnLogout.Name = "btnLogout";
        btnLogout.Size = new Size(108, 28);
        btnLogout.TabIndex = 1;
        btnLogout.Text = "Выйти";
        btnLogout.UseVisualStyleBackColor = true;
        btnLogout.Click += btnLogout_Click;
        // 
        // lblWelcome
        // 
        lblWelcome.AutoSize = true;
        lblWelcome.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblWelcome.Location = new Point(15, 18);
        lblWelcome.Name = "lblWelcome";
        lblWelcome.Size = new Size(123, 15);
        lblWelcome.TabIndex = 0;
        lblWelcome.Text = "Добро пожаловать...";
        // 
        // pnlSearch
        // 
        pnlSearch.Controls.Add(btnResetSearch);
        pnlSearch.Controls.Add(btnSearch);
        pnlSearch.Controls.Add(txtSearchCardNumber);
        pnlSearch.Controls.Add(lblSearch);
        pnlSearch.Dock = DockStyle.Top;
        pnlSearch.Location = new Point(0, 50);
        pnlSearch.Name = "pnlSearch";
        pnlSearch.Size = new Size(950, 45);
        pnlSearch.TabIndex = 1;
        // 
        // btnResetSearch
        // 
        btnResetSearch.Location = new Point(440, 10);
        btnResetSearch.Name = "btnResetSearch";
        btnResetSearch.Size = new Size(90, 25);
        btnResetSearch.TabIndex = 3;
        btnResetSearch.Text = "Сбросить";
        btnResetSearch.UseVisualStyleBackColor = true;
        btnResetSearch.Click += btnResetSearch_Click;
        // 
        // btnSearch
        // 
        btnSearch.Location = new Point(340, 10);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new Size(90, 25);
        btnSearch.TabIndex = 2;
        btnSearch.Text = "Найти";
        btnSearch.UseVisualStyleBackColor = true;
        btnSearch.Click += btnSearch_Click;
        // 
        // txtSearchCardNumber
        // 
        txtSearchCardNumber.Location = new Point(135, 11);
        txtSearchCardNumber.Name = "txtSearchCardNumber";
        txtSearchCardNumber.Size = new Size(190, 23);
        txtSearchCardNumber.TabIndex = 1;
        // 
        // lblSearch
        // 
        lblSearch.AutoSize = true;
        lblSearch.Location = new Point(15, 15);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new Size(114, 15);
        lblSearch.TabIndex = 0;
        lblSearch.Text = "Поиск по № карты:";
        // 
        // dgvPatients
        // 
        dgvPatients.AllowUserToAddRows = false;
        dgvPatients.AllowUserToDeleteRows = false;
        dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvPatients.Columns.AddRange(new DataGridViewColumn[] { colId, colCardNumber, colFullName, colBirthDate, colGender, colPhone, colPolicyNumber });
        dgvPatients.Dock = DockStyle.Fill;
        dgvPatients.Location = new Point(0, 95);
        dgvPatients.MultiSelect = false;
        dgvPatients.Name = "dgvPatients";
        dgvPatients.ReadOnly = true;
        dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPatients.Size = new Size(950, 395);
        dgvPatients.TabIndex = 2;
        dgvPatients.SelectionChanged += dgvPatients_SelectionChanged;
        dgvPatients.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgvPatients_CellDoubleClick);
        // 
        // colId
        // 
        colId.DataPropertyName = "Id";
        colId.HeaderText = "ID";
        colId.Name = "colId";
        colId.ReadOnly = true;
        colId.Visible = false;
        // 
        // colCardNumber
        // 
        colCardNumber.DataPropertyName = "CardNumber";
        colCardNumber.FillWeight = 80F;
        colCardNumber.HeaderText = "№ Медкарты";
        colCardNumber.Name = "colCardNumber";
        colCardNumber.ReadOnly = true;
        // 
        // colFullName
        // 
        colFullName.DataPropertyName = "FullName";
        colFullName.FillWeight = 160F;
        colFullName.HeaderText = "ФИО Пациента";
        colFullName.Name = "colFullName";
        colFullName.ReadOnly = true;
        // 
        // colBirthDate
        // 
        colBirthDate.DataPropertyName = "BirthDateFormatted";
        colBirthDate.FillWeight = 70F;
        colBirthDate.HeaderText = "Дата рожд.";
        colBirthDate.Name = "colBirthDate";
        colBirthDate.ReadOnly = true;
        // 
        // colGender
        // 
        colGender.DataPropertyName = "Gender";
        colGender.FillWeight = 50F;
        colGender.HeaderText = "Пол";
        colGender.Name = "colGender";
        colGender.ReadOnly = true;
        // 
        // colPhone
        // 
        colPhone.DataPropertyName = "Phone";
        colPhone.FillWeight = 90F;
        colPhone.HeaderText = "Телефон";
        colPhone.Name = "colPhone";
        colPhone.ReadOnly = true;
        // 
        // colPolicyNumber
        // 
        colPolicyNumber.DataPropertyName = "PolicyNumber";
        colPolicyNumber.FillWeight = 110F;
        colPolicyNumber.HeaderText = "№ Полиса ОМС";
        colPolicyNumber.Name = "colPolicyNumber";
        colPolicyNumber.ReadOnly = true;
        // 
        // pnlFooter
        // 
        pnlFooter.Controls.Add(btnCreateAppointment);
        pnlFooter.Controls.Add(btnCreatePatient);
        pnlFooter.Dock = DockStyle.Bottom;
        pnlFooter.Location = new Point(0, 490);
        pnlFooter.Name = "pnlFooter";
        pnlFooter.Size = new Size(950, 60);
        pnlFooter.TabIndex = 3;
        // 
        // btnCreateAppointment
        // 
        btnCreateAppointment.Enabled = false;
        btnCreateAppointment.Location = new Point(220, 14);
        btnCreateAppointment.Name = "btnCreateAppointment";
        btnCreateAppointment.Size = new Size(185, 32);
        btnCreateAppointment.TabIndex = 1;
        btnCreateAppointment.Text = "Назначить приём";
        btnCreateAppointment.UseVisualStyleBackColor = true;
        btnCreateAppointment.Click += btnCreateAppointment_Click;
        // 
        // btnCreatePatient
        // 
        btnCreatePatient.Location = new Point(15, 14);
        btnCreatePatient.Name = "btnCreatePatient";
        btnCreatePatient.Size = new Size(185, 32);
        btnCreatePatient.TabIndex = 0;
        btnCreatePatient.Text = "+ Новый пациент";
        btnCreatePatient.UseVisualStyleBackColor = true;
        btnCreatePatient.Click += btnCreatePatient_Click;
        // 
        // RegistratorMainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(950, 550);
        Controls.Add(dgvPatients);
        Controls.Add(pnlFooter);
        Controls.Add(pnlSearch);
        Controls.Add(pnlHeader);
        MinimumSize = new Size(800, 500);
        Name = "RegistratorMainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "АРМ Регистратора";
        Load += RegistratorMainForm_Load;
        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        pnlSearch.ResumeLayout(false);
        pnlSearch.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
        pnlFooter.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlHeader;
    private Label lblWelcome;
    private Button btnLogout;
    private Panel pnlSearch;
    private Label lblSearch;
    private TextBox txtSearchCardNumber;
    private Button btnSearch;
    private Button btnResetSearch;
    private DataGridView dgvPatients;
    private Panel pnlFooter;
    private Button btnCreatePatient;
    private Button btnCreateAppointment;
    private DataGridViewTextBoxColumn colId;
    private DataGridViewTextBoxColumn colCardNumber;
    private DataGridViewTextBoxColumn colFullName;
    private DataGridViewTextBoxColumn colBirthDate;
    private DataGridViewTextBoxColumn colGender;
    private DataGridViewTextBoxColumn colPhone;
    private DataGridViewTextBoxColumn colPolicyNumber;
}