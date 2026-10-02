namespace Patients.Forms
{
    partial class DoctorMainForm
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

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            dtpAppointmentDate = new DateTimePicker();
            lblDateSelect = new Label();
            btnLogout = new Button();
            lblWelcome = new Label();
            dgvAppointments = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colTime = new DataGridViewTextBoxColumn();
            colCardNumber = new DataGridViewTextBoxColumn();
            colPatientName = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            pnlFooter = new Panel();
            btnStartExamination = new Button();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).BeginInit();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(dtpAppointmentDate);
            pnlHeader.Controls.Add(lblDateSelect);
            pnlHeader.Controls.Add(btnLogout);
            pnlHeader.Controls.Add(lblWelcome);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(900, 55);
            pnlHeader.TabIndex = 0;
            // 
            // dtpAppointmentDate
            // 
            dtpAppointmentDate.Format = DateTimePickerFormat.Short;
            dtpAppointmentDate.Location = new Point(510, 16);
            dtpAppointmentDate.Name = "dtpAppointmentDate";
            dtpAppointmentDate.Size = new Size(140, 23);
            dtpAppointmentDate.TabIndex = 3;
            dtpAppointmentDate.ValueChanged += dtpAppointmentDate_ValueChanged;
            // 
            // lblDateSelect
            // 
            lblDateSelect.AutoSize = true;
            lblDateSelect.Location = new Point(415, 20);
            lblDateSelect.Name = "lblDateSelect";
            lblDateSelect.Size = new Size(89, 15);
            lblDateSelect.TabIndex = 2;
            lblDateSelect.Text = "Дата приёмов:";
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.Location = new Point(780, 13);
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
            lblWelcome.Location = new Point(15, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(123, 15);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Добро пожаловать...";
            // 
            // dgvAppointments
            // 
            dgvAppointments.AllowUserToAddRows = false;
            dgvAppointments.AllowUserToDeleteRows = false;
            dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAppointments.Columns.AddRange(new DataGridViewColumn[] { colId, colTime, colCardNumber, colPatientName, colStatus });
            dgvAppointments.Dock = DockStyle.Fill;
            dgvAppointments.Location = new Point(0, 55);
            dgvAppointments.MultiSelect = false;
            dgvAppointments.Name = "dgvAppointments";
            dgvAppointments.ReadOnly = true;
            dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointments.Size = new Size(900, 385);
            dgvAppointments.TabIndex = 1;
            dgvAppointments.CellFormatting += dgvAppointments_CellFormatting;
            dgvAppointments.SelectionChanged += dgvAppointments_SelectionChanged;
            dgvAppointments.CellDoubleClick += dgvAppointments_CellDoubleClick;
            // 
            // colId
            // 
            colId.DataPropertyName = "Id";
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colTime
            // 
            colTime.DataPropertyName = "TimeFormatted";
            colTime.FillWeight = 50F;
            colTime.HeaderText = "Время";
            colTime.Name = "colTime";
            colTime.ReadOnly = true;
            // 
            // colCardNumber
            // 
            colCardNumber.DataPropertyName = "PatientCardNumber";
            colCardNumber.FillWeight = 80F;
            colCardNumber.HeaderText = "№ Медкарты";
            colCardNumber.Name = "colCardNumber";
            colCardNumber.ReadOnly = true;
            // 
            // colPatientName
            // 
            colPatientName.DataPropertyName = "PatientFullName";
            colPatientName.FillWeight = 180F;
            colPatientName.HeaderText = "ФИО Пациента";
            colPatientName.Name = "colPatientName";
            colPatientName.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "StatusRussian";
            colStatus.FillWeight = 90F;
            colStatus.HeaderText = "Статус";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // pnlFooter
            // 
            pnlFooter.Controls.Add(btnStartExamination);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 440);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(900, 60);
            pnlFooter.TabIndex = 2;
            // 
            // btnStartExamination
            // 
            btnStartExamination.Enabled = false;
            btnStartExamination.Location = new Point(15, 14);
            btnStartExamination.Name = "btnStartExamination";
            btnStartExamination.Size = new Size(185, 32);
            btnStartExamination.TabIndex = 0;
            btnStartExamination.Text = "Провести осмотр";
            btnStartExamination.UseVisualStyleBackColor = true;
            btnStartExamination.Click += btnStartExamination_Click;
            // 
            // DoctorMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 500);
            Controls.Add(dgvAppointments);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);
            MinimumSize = new Size(800, 450);
            Name = "DoctorMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "АРМ Врача";
            Load += DoctorMainForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).EndInit();
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblWelcome;
        private Button btnLogout;
        private Label lblDateSelect;
        private DateTimePicker dtpAppointmentDate;
        private DataGridView dgvAppointments;
        private Panel pnlFooter;
        private Button btnStartExamination;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colCardNumber;
        private DataGridViewTextBoxColumn colPatientName;
        private DataGridViewTextBoxColumn colStatus;
    }
}