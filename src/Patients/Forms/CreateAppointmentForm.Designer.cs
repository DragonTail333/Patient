namespace Patients.Forms;

partial class CreateAppointmentForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        pnlPatientHeader = new Panel();
        lblPatientInfo = new Label();
        grpDoctorSelection = new GroupBox();
        dgvDoctors = new DataGridView();
        colDoctorId = new DataGridViewTextBoxColumn();
        colDoctorFullName = new DataGridViewTextBoxColumn();
        colSpecialty = new DataGridViewTextBoxColumn();
        colRoomNumber = new DataGridViewTextBoxColumn();
        colPhone = new DataGridViewTextBoxColumn();
        cmbSpecialty = new ComboBox();
        lblSpecialty = new Label();
        grpDateTimeSelection = new GroupBox();
        cmbTimeSlot = new ComboBox();
        lblTimeSlot = new Label();
        dtpAppointmentDate = new DateTimePicker();
        lblAppointmentDate = new Label();
        pnlFooter = new Panel();
        lblError = new Label();
        btnSave = new Button();
        btnCancel = new Button();
        pnlPatientHeader.SuspendLayout();
        grpDoctorSelection.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvDoctors).BeginInit();
        grpDateTimeSelection.SuspendLayout();
        pnlFooter.SuspendLayout();
        SuspendLayout();
        // 
        // pnlPatientHeader
        // 
        pnlPatientHeader.BackColor = SystemColors.ControlLight;
        pnlPatientHeader.Controls.Add(lblPatientInfo);
        pnlPatientHeader.Dock = DockStyle.Top;
        pnlPatientHeader.Location = new Point(0, 0);
        pnlPatientHeader.Name = "pnlPatientHeader";
        pnlPatientHeader.Size = new Size(684, 45);
        pnlPatientHeader.TabIndex = 0;
        // 
        // lblPatientInfo
        // 
        lblPatientInfo.AutoSize = true;
        lblPatientInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblPatientInfo.Location = new Point(15, 12);
        lblPatientInfo.Name = "lblPatientInfo";
        lblPatientInfo.Size = new Size(209, 19);
        lblPatientInfo.TabIndex = 0;
        lblPatientInfo.Text = "Пациент: Загрузка данных...";
        // 
        // grpDoctorSelection
        // 
        grpDoctorSelection.Controls.Add(dgvDoctors);
        grpDoctorSelection.Controls.Add(cmbSpecialty);
        grpDoctorSelection.Controls.Add(lblSpecialty);
        grpDoctorSelection.Location = new Point(12, 55);
        grpDoctorSelection.Name = "grpDoctorSelection";
        grpDoctorSelection.Size = new Size(660, 280);
        grpDoctorSelection.TabIndex = 1;
        grpDoctorSelection.TabStop = false;
        grpDoctorSelection.Text = "1. Выбор врача";
        // 
        // dgvDoctors
        // 
        dgvDoctors.AllowUserToAddRows = false;
        dgvDoctors.AllowUserToDeleteRows = false;
        dgvDoctors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvDoctors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvDoctors.Columns.AddRange(new DataGridViewColumn[] { colDoctorId, colDoctorFullName, colSpecialty, colRoomNumber, colPhone });
        dgvDoctors.Location = new Point(15, 60);
        dgvDoctors.MultiSelect = false;
        dgvDoctors.Name = "dgvDoctors";
        dgvDoctors.ReadOnly = true;
        dgvDoctors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvDoctors.Size = new Size(630, 205);
        dgvDoctors.TabIndex = 2;
        dgvDoctors.SelectionChanged += dgvDoctors_SelectionChanged;
        // 
        // colDoctorId
        // 
        colDoctorId.DataPropertyName = "Id";
        colDoctorId.HeaderText = "ID";
        colDoctorId.Name = "colDoctorId";
        colDoctorId.ReadOnly = true;
        colDoctorId.Visible = false;
        // 
        // colDoctorFullName
        // 
        colDoctorFullName.DataPropertyName = "FullName";
        colDoctorFullName.FillWeight = 140F;
        colDoctorFullName.HeaderText = "ФИО Врача";
        colDoctorFullName.Name = "colDoctorFullName";
        colDoctorFullName.ReadOnly = true;
        // 
        // colSpecialty
        // 
        colSpecialty.DataPropertyName = "SpecialtyTitle";
        colSpecialty.FillWeight = 110F;
        colSpecialty.HeaderText = "Специальность";
        colSpecialty.Name = "colSpecialty";
        colSpecialty.ReadOnly = true;
        // 
        // colRoomNumber
        // 
        colRoomNumber.DataPropertyName = "RoomNumber";
        colRoomNumber.FillWeight = 60F;
        colRoomNumber.HeaderText = "Кабинет";
        colRoomNumber.Name = "colRoomNumber";
        colRoomNumber.ReadOnly = true;
        // 
        // colPhone
        // 
        colPhone.DataPropertyName = "Phone";
        colPhone.FillWeight = 90F;
        colPhone.HeaderText = "Телефон";
        colPhone.Name = "colPhone";
        colPhone.ReadOnly = true;
        // 
        // cmbSpecialty
        // 
        cmbSpecialty.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbSpecialty.FormattingEnabled = true;
        cmbSpecialty.Location = new Point(176, 22);
        cmbSpecialty.Name = "cmbSpecialty";
        cmbSpecialty.Size = new Size(280, 23);
        cmbSpecialty.TabIndex = 1;
        cmbSpecialty.SelectedIndexChanged += cmbSpecialty_SelectedIndexChanged;
        // 
        // lblSpecialty
        // 
        lblSpecialty.AutoSize = true;
        lblSpecialty.Location = new Point(15, 25);
        lblSpecialty.Name = "lblSpecialty";
        lblSpecialty.Size = new Size(155, 15);
        lblSpecialty.TabIndex = 0;
        lblSpecialty.Text = "Фильтр по специальности:";
        // 
        // grpDateTimeSelection
        // 
        grpDateTimeSelection.Controls.Add(cmbTimeSlot);
        grpDateTimeSelection.Controls.Add(lblTimeSlot);
        grpDateTimeSelection.Controls.Add(dtpAppointmentDate);
        grpDateTimeSelection.Controls.Add(lblAppointmentDate);
        grpDateTimeSelection.Location = new Point(12, 345);
        grpDateTimeSelection.Name = "grpDateTimeSelection";
        grpDateTimeSelection.Size = new Size(660, 75);
        grpDateTimeSelection.TabIndex = 2;
        grpDateTimeSelection.TabStop = false;
        grpDateTimeSelection.Text = "2. Дата и время приёма";
        // 
        // cmbTimeSlot
        // 
        cmbTimeSlot.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbTimeSlot.FormattingEnabled = true;
        cmbTimeSlot.Location = new Point(410, 32);
        cmbTimeSlot.Name = "cmbTimeSlot";
        cmbTimeSlot.Size = new Size(180, 23);
        cmbTimeSlot.TabIndex = 3;
        // 
        // lblTimeSlot
        // 
        lblTimeSlot.AutoSize = true;
        lblTimeSlot.Location = new Point(315, 35);
        lblTimeSlot.Name = "lblTimeSlot";
        lblTimeSlot.Size = new Size(90, 15);
        lblTimeSlot.TabIndex = 2;
        lblTimeSlot.Text = "Время приёма:";
        // 
        // dtpAppointmentDate
        // 
        dtpAppointmentDate.Format = DateTimePickerFormat.Short;
        dtpAppointmentDate.Location = new Point(105, 32);
        dtpAppointmentDate.Name = "dtpAppointmentDate";
        dtpAppointmentDate.Size = new Size(160, 23);
        dtpAppointmentDate.TabIndex = 1;
        dtpAppointmentDate.ValueChanged += dtpAppointmentDate_ValueChanged;
        // 
        // lblAppointmentDate
        // 
        lblAppointmentDate.AutoSize = true;
        lblAppointmentDate.Location = new Point(15, 35);
        lblAppointmentDate.Name = "lblAppointmentDate";
        lblAppointmentDate.Size = new Size(80, 15);
        lblAppointmentDate.TabIndex = 0;
        lblAppointmentDate.Text = "Дата приёма:";
        // 
        // pnlFooter
        // 
        pnlFooter.Controls.Add(lblError);
        pnlFooter.Controls.Add(btnSave);
        pnlFooter.Controls.Add(btnCancel);
        pnlFooter.Dock = DockStyle.Bottom;
        pnlFooter.Location = new Point(0, 430);
        pnlFooter.Name = "pnlFooter";
        pnlFooter.Size = new Size(684, 75);
        pnlFooter.TabIndex = 3;
        // 
        // lblError
        // 
        lblError.ForeColor = Color.Red;
        lblError.Location = new Point(12, 8);
        lblError.Name = "lblError";
        lblError.Size = new Size(410, 58);
        lblError.TabIndex = 2;
        lblError.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // btnSave
        // 
        btnSave.Location = new Point(435, 20);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(115, 35);
        btnSave.TabIndex = 0;
        btnSave.Text = "Записать";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(557, 20);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(115, 35);
        btnCancel.TabIndex = 1;
        btnCancel.Text = "Отмена";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // CreateAppointmentForm
        // 
        AcceptButton = btnSave;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new Size(684, 505);
        Controls.Add(pnlFooter);
        Controls.Add(grpDateTimeSelection);
        Controls.Add(grpDoctorSelection);
        Controls.Add(pnlPatientHeader);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "CreateAppointmentForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Назначение приёма";
        Load += CreateAppointmentForm_Load;
        pnlPatientHeader.ResumeLayout(false);
        pnlPatientHeader.PerformLayout();
        grpDoctorSelection.ResumeLayout(false);
        grpDoctorSelection.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvDoctors).EndInit();
        grpDateTimeSelection.ResumeLayout(false);
        grpDateTimeSelection.PerformLayout();
        pnlFooter.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlPatientHeader;
    private Label lblPatientInfo;
    private GroupBox grpDoctorSelection;
    private Label lblSpecialty;
    private ComboBox cmbSpecialty;
    private DataGridView dgvDoctors;
    private DataGridViewTextBoxColumn colDoctorId;
    private DataGridViewTextBoxColumn colDoctorFullName;
    private DataGridViewTextBoxColumn colSpecialty;
    private DataGridViewTextBoxColumn colRoomNumber;
    private DataGridViewTextBoxColumn colPhone;
    private GroupBox grpDateTimeSelection;
    private Label lblAppointmentDate;
    private DateTimePicker dtpAppointmentDate;
    private Label lblTimeSlot;
    private ComboBox cmbTimeSlot;
    private Panel pnlFooter;
    private Label lblError;
    private Button btnSave;
    private Button btnCancel;
}