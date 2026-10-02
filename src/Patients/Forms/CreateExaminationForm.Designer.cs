namespace Patients.Forms;

partial class CreateExaminationForm
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
        lblPatientInfo = new Label();
        grpExaminationDetails = new GroupBox();
        txtRecommendations = new TextBox();
        lblRecommendations = new Label();
        txtDiagnosis = new TextBox();
        lblDiagnosis = new Label();
        txtAnamnesis = new TextBox();
        lblAnamnesis = new Label();
        txtComplaints = new TextBox();
        lblComplaints = new Label();
        tabControlDetails = new TabControl();
        tabPrescriptions = new TabPage();
        dgvPrescriptions = new DataGridView();
        colMedicationName = new DataGridViewTextBoxColumn();
        colDosage = new DataGridViewTextBoxColumn();
        colInstructions = new DataGridViewTextBoxColumn();
        btnDeletePrescription = new Button();
        btnAddPrescription = new Button();
        tabReferrals = new TabPage();
        dgvReferrals = new DataGridView();
        colReferralType = new DataGridViewTextBoxColumn();
        colTargetDescription = new DataGridViewTextBoxColumn();
        btnDeleteReferral = new Button();
        btnAddReferral = new Button();
        pnlFooter = new Panel();
        lblError = new Label();
        btnSave = new Button();
        btnCancel = new Button();
        pnlHeader.SuspendLayout();
        grpExaminationDetails.SuspendLayout();
        tabControlDetails.SuspendLayout();
        tabPrescriptions.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPrescriptions).BeginInit();
        tabReferrals.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvReferrals).BeginInit();
        pnlFooter.SuspendLayout();
        SuspendLayout();
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = SystemColors.ControlLight;
        pnlHeader.Controls.Add(lblPatientInfo);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Size = new Size(784, 40);
        pnlHeader.TabIndex = 0;
        // 
        // lblPatientInfo
        // 
        lblPatientInfo.AutoSize = true;
        lblPatientInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblPatientInfo.Location = new Point(15, 10);
        lblPatientInfo.Name = "lblPatientInfo";
        lblPatientInfo.Size = new Size(185, 19);
        lblPatientInfo.TabIndex = 0;
        lblPatientInfo.Text = "Пациент: Загрузка данных...";
        // 
        // grpExaminationDetails
        // 
        grpExaminationDetails.Controls.Add(txtRecommendations);
        grpExaminationDetails.Controls.Add(lblRecommendations);
        grpExaminationDetails.Controls.Add(txtDiagnosis);
        grpExaminationDetails.Controls.Add(lblDiagnosis);
        grpExaminationDetails.Controls.Add(txtAnamnesis);
        grpExaminationDetails.Controls.Add(lblAnamnesis);
        grpExaminationDetails.Controls.Add(txtComplaints);
        grpExaminationDetails.Controls.Add(lblComplaints);
        grpExaminationDetails.Location = new Point(12, 46);
        grpExaminationDetails.Name = "grpExaminationDetails";
        grpExaminationDetails.Size = new Size(760, 260);
        grpExaminationDetails.TabIndex = 1;
        grpExaminationDetails.TabStop = false;
        grpExaminationDetails.Text = "Протокол осмотра";
        // 
        // txtRecommendations
        // 
        txtRecommendations.Location = new Point(400, 155);
        txtRecommendations.Multiline = true;
        txtRecommendations.Name = "txtRecommendations";
        txtRecommendations.ScrollBars = ScrollBars.Vertical;
        txtRecommendations.Size = new Size(345, 90);
        txtRecommendations.TabIndex = 7;
        // 
        // lblRecommendations
        // 
        lblRecommendations.AutoSize = true;
        lblRecommendations.Location = new Point(400, 137);
        lblRecommendations.Name = "lblRecommendations";
        lblRecommendations.Size = new Size(88, 15);
        lblRecommendations.TabIndex = 6;
        lblRecommendations.Text = "Рекомендации:";
        // 
        // txtDiagnosis
        // 
        txtDiagnosis.Location = new Point(15, 155);
        txtDiagnosis.Multiline = true;
        txtDiagnosis.Name = "txtDiagnosis";
        txtDiagnosis.ScrollBars = ScrollBars.Vertical;
        txtDiagnosis.Size = new Size(365, 90);
        txtDiagnosis.TabIndex = 5;
        // 
        // lblDiagnosis
        // 
        lblDiagnosis.AutoSize = true;
        lblDiagnosis.Location = new Point(15, 137);
        lblDiagnosis.Name = "lblDiagnosis";
        lblDiagnosis.Size = new Size(55, 15);
        lblDiagnosis.TabIndex = 4;
        lblDiagnosis.Text = "Диагноз:";
        // 
        // txtAnamnesis
        // 
        txtAnamnesis.Location = new Point(400, 42);
        txtAnamnesis.Multiline = true;
        txtAnamnesis.Name = "txtAnamnesis";
        txtAnamnesis.ScrollBars = ScrollBars.Vertical;
        txtAnamnesis.Size = new Size(345, 85);
        txtAnamnesis.TabIndex = 3;
        // 
        // lblAnamnesis
        // 
        lblAnamnesis.AutoSize = true;
        lblAnamnesis.Location = new Point(400, 24);
        lblAnamnesis.Name = "lblAnamnesis";
        lblAnamnesis.Size = new Size(59, 15);
        lblAnamnesis.TabIndex = 2;
        lblAnamnesis.Text = "Анамнез:";
        // 
        // txtComplaints
        // 
        txtComplaints.Location = new Point(15, 42);
        txtComplaints.Multiline = true;
        txtComplaints.Name = "txtComplaints";
        txtComplaints.ScrollBars = ScrollBars.Vertical;
        txtComplaints.Size = new Size(365, 85);
        txtComplaints.TabIndex = 1;
        // 
        // lblComplaints
        // 
        lblComplaints.AutoSize = true;
        lblComplaints.Location = new Point(15, 24);
        lblComplaints.Name = "lblComplaints";
        lblComplaints.Size = new Size(56, 15);
        lblComplaints.TabIndex = 0;
        lblComplaints.Text = "Жалобы:";
        // 
        // tabControlDetails
        // 
        tabControlDetails.Controls.Add(tabPrescriptions);
        tabControlDetails.Controls.Add(tabReferrals);
        tabControlDetails.Location = new Point(12, 312);
        tabControlDetails.Name = "tabControlDetails";
        tabControlDetails.SelectedIndex = 0;
        tabControlDetails.Size = new Size(760, 210);
        tabControlDetails.TabIndex = 2;
        // 
        // tabPrescriptions
        // 
        tabPrescriptions.Controls.Add(dgvPrescriptions);
        tabPrescriptions.Controls.Add(btnDeletePrescription);
        tabPrescriptions.Controls.Add(btnAddPrescription);
        tabPrescriptions.Location = new Point(4, 24);
        tabPrescriptions.Name = "tabPrescriptions";
        tabPrescriptions.Padding = new Padding(3);
        tabPrescriptions.Size = new Size(752, 182);
        tabPrescriptions.TabIndex = 0;
        tabPrescriptions.Text = "Рецепты и назначения";
        tabPrescriptions.UseVisualStyleBackColor = true;
        // 
        // dgvPrescriptions
        // 
        dgvPrescriptions.AllowUserToAddRows = false;
        dgvPrescriptions.AllowUserToDeleteRows = false;
        dgvPrescriptions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvPrescriptions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvPrescriptions.Columns.AddRange(new DataGridViewColumn[] { colMedicationName, colDosage, colInstructions });
        dgvPrescriptions.Location = new Point(6, 6);
        dgvPrescriptions.MultiSelect = false;
        dgvPrescriptions.Name = "dgvPrescriptions";
        dgvPrescriptions.ReadOnly = true;
        dgvPrescriptions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPrescriptions.Size = new Size(620, 170);
        dgvPrescriptions.TabIndex = 0;
        // 
        // colMedicationName
        // 
        colMedicationName.DataPropertyName = "MedicationName";
        colMedicationName.FillWeight = 120F;
        colMedicationName.HeaderText = "Препарат";
        colMedicationName.Name = "colMedicationName";
        colMedicationName.ReadOnly = true;
        // 
        // colDosage
        // 
        colDosage.DataPropertyName = "Dosage";
        colDosage.FillWeight = 80F;
        colDosage.HeaderText = "Дозировка";
        colDosage.Name = "colDosage";
        colDosage.ReadOnly = true;
        // 
        // colInstructions
        // 
        colInstructions.DataPropertyName = "Instructions";
        colInstructions.FillWeight = 150F;
        colInstructions.HeaderText = "Инструкция";
        colInstructions.Name = "colInstructions";
        colInstructions.ReadOnly = true;
        // 
        // btnDeletePrescription
        // 
        btnDeletePrescription.Location = new Point(632, 45);
        btnDeletePrescription.Name = "btnDeletePrescription";
        btnDeletePrescription.Size = new Size(114, 30);
        btnDeletePrescription.TabIndex = 2;
        btnDeletePrescription.Text = "Удалить";
        btnDeletePrescription.UseVisualStyleBackColor = true;
        btnDeletePrescription.Click += btnDeletePrescription_Click;
        // 
        // btnAddPrescription
        // 
        btnAddPrescription.Location = new Point(632, 9);
        btnAddPrescription.Name = "btnAddPrescription";
        btnAddPrescription.Size = new Size(114, 30);
        btnAddPrescription.TabIndex = 1;
        btnAddPrescription.Text = "+ Добавить";
        btnAddPrescription.UseVisualStyleBackColor = true;
        btnAddPrescription.Click += btnAddPrescription_Click;
        // 
        // tabReferrals
        // 
        tabReferrals.Controls.Add(dgvReferrals);
        tabReferrals.Controls.Add(btnDeleteReferral);
        tabReferrals.Controls.Add(btnAddReferral);
        tabReferrals.Location = new Point(4, 24);
        tabReferrals.Name = "tabReferrals";
        tabReferrals.Padding = new Padding(3);
        tabReferrals.Size = new Size(752, 182);
        tabReferrals.TabIndex = 1;
        tabReferrals.Text = "Направления";
        tabReferrals.UseVisualStyleBackColor = true;
        // 
        // dgvReferrals
        // 
        dgvReferrals.AllowUserToAddRows = false;
        dgvReferrals.AllowUserToDeleteRows = false;
        dgvReferrals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvReferrals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvReferrals.Columns.AddRange(new DataGridViewColumn[] { colReferralType, colTargetDescription });
        dgvReferrals.Location = new Point(6, 6);
        dgvReferrals.MultiSelect = false;
        dgvReferrals.Name = "dgvReferrals";
        dgvReferrals.ReadOnly = true;
        dgvReferrals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvReferrals.Size = new Size(620, 170);
        dgvReferrals.TabIndex = 0;
        // 
        // colReferralType
        // 
        colReferralType.DataPropertyName = "ReferralType";
        colReferralType.FillWeight = 100F;
        colReferralType.HeaderText = "Тип направления";
        colReferralType.Name = "colReferralType";
        colReferralType.ReadOnly = true;
        // 
        // colTargetDescription
        // 
        colTargetDescription.DataPropertyName = "TargetDescription";
        colTargetDescription.FillWeight = 200F;
        colTargetDescription.HeaderText = "Цель / Описание";
        colTargetDescription.Name = "colTargetDescription";
        colTargetDescription.ReadOnly = true;
        // 
        // btnDeleteReferral
        // 
        btnDeleteReferral.Location = new Point(632, 45);
        btnDeleteReferral.Name = "btnDeleteReferral";
        btnDeleteReferral.Size = new Size(114, 30);
        btnDeleteReferral.TabIndex = 2;
        btnDeleteReferral.Text = "Удалить";
        btnDeleteReferral.UseVisualStyleBackColor = true;
        btnDeleteReferral.Click += btnDeleteReferral_Click;
        // 
        // btnAddReferral
        // 
        btnAddReferral.Location = new Point(632, 9);
        btnAddReferral.Name = "btnAddReferral";
        btnAddReferral.Size = new Size(114, 30);
        btnAddReferral.TabIndex = 1;
        btnAddReferral.Text = "+ Добавить";
        btnAddReferral.UseVisualStyleBackColor = true;
        btnAddReferral.Click += btnAddReferral_Click;
        // 
        // pnlFooter
        // 
        pnlFooter.Controls.Add(lblError);
        pnlFooter.Controls.Add(btnSave);
        pnlFooter.Controls.Add(btnCancel);
        pnlFooter.Dock = DockStyle.Bottom;
        pnlFooter.Location = new Point(0, 528);
        pnlFooter.Name = "pnlFooter";
        pnlFooter.Size = new Size(784, 60);
        pnlFooter.TabIndex = 3;
        // 
        // lblError
        // 
        lblError.ForeColor = Color.Red;
        lblError.Location = new Point(12, 10);
        lblError.Name = "lblError";
        lblError.Size = new Size(490, 40);
        lblError.TabIndex = 2;
        lblError.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // btnSave
        // 
        btnSave.Location = new Point(515, 13);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(140, 35);
        btnSave.TabIndex = 0;
        btnSave.Text = "Завершить приём";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(662, 13);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(110, 35);
        btnCancel.TabIndex = 1;
        btnCancel.Text = "Отмена";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // CreateExaminationForm
        // 
        AcceptButton = btnSave;
        CancelButton = btnCancel;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(784, 588);
        Controls.Add(pnlFooter);
        Controls.Add(tabControlDetails);
        Controls.Add(grpExaminationDetails);
        Controls.Add(pnlHeader);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "CreateExaminationForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Проведение осмотра";
        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        grpExaminationDetails.ResumeLayout(false);
        grpExaminationDetails.PerformLayout();
        tabControlDetails.ResumeLayout(false);
        tabPrescriptions.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvPrescriptions).EndInit();
        tabReferrals.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvReferrals).EndInit();
        pnlFooter.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlHeader;
    private Label lblPatientInfo;
    private GroupBox grpExaminationDetails;
    private Label lblComplaints;
    private TextBox txtComplaints;
    private Label lblAnamnesis;
    private TextBox txtAnamnesis;
    private Label lblDiagnosis;
    private TextBox txtDiagnosis;
    private Label lblRecommendations;
    private TextBox txtRecommendations;
    private TabControl tabControlDetails;
    private TabPage tabPrescriptions;
    private DataGridView dgvPrescriptions;
    private DataGridViewTextBoxColumn colMedicationName;
    private DataGridViewTextBoxColumn colDosage;
    private DataGridViewTextBoxColumn colInstructions;
    private Button btnAddPrescription;
    private Button btnDeletePrescription;
    private TabPage tabReferrals;
    private DataGridView dgvReferrals;
    private DataGridViewTextBoxColumn colReferralType;
    private DataGridViewTextBoxColumn colTargetDescription;
    private Button btnAddReferral;
    private Button btnDeleteReferral;
    private Panel pnlFooter;
    private Label lblError;
    private Button btnSave;
    private Button btnCancel;
}