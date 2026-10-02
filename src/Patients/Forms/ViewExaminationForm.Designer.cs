namespace Patients.Forms;

partial class ViewExaminationForm
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
        lblPatientInfo = new Label();
        lblComplaints = new Label();
        txtComplaints = new TextBox();
        lblAnamnesis = new Label();
        txtAnamnesis = new TextBox();
        lblDiagnosis = new Label();
        txtDiagnosis = new TextBox();
        lblRecommendations = new Label();
        txtRecommendations = new TextBox();
        tabDetails = new TabControl();
        tabPrescriptions = new TabPage();
        dgvPrescriptions = new DataGridView();
        colMedicationName = new DataGridViewTextBoxColumn();
        colDosage = new DataGridViewTextBoxColumn();
        colInstructions = new DataGridViewTextBoxColumn();
        tabReferrals = new TabPage();
        dgvReferrals = new DataGridView();
        colReferralType = new DataGridViewTextBoxColumn();
        colTargetDescription = new DataGridViewTextBoxColumn();
        btnClose = new Button();
        tabDetails.SuspendLayout();
        tabPrescriptions.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPrescriptions).BeginInit();
        tabReferrals.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvReferrals).BeginInit();
        SuspendLayout();
        // 
        // lblPatientInfo
        // 
        lblPatientInfo.AutoSize = true;
        lblPatientInfo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
        lblPatientInfo.Location = new Point(15, 12);
        lblPatientInfo.Name = "lblPatientInfo";
        lblPatientInfo.Size = new Size(188, 17);
        lblPatientInfo.TabIndex = 0;
        lblPatientInfo.Text = "Пациент: ... | Протокол №...";
        // 
        // lblComplaints
        // 
        lblComplaints.AutoSize = true;
        lblComplaints.Location = new Point(15, 40);
        lblComplaints.Name = "lblComplaints";
        lblComplaints.Size = new Size(59, 15);
        lblComplaints.TabIndex = 1;
        lblComplaints.Text = "Жалобы:";
        // 
        // txtComplaints
        // 
        txtComplaints.BackColor = SystemColors.Control;
        txtComplaints.Location = new Point(15, 58);
        txtComplaints.Multiline = true;
        txtComplaints.Name = "txtComplaints";
        txtComplaints.ReadOnly = true;
        txtComplaints.ScrollBars = ScrollBars.Vertical;
        txtComplaints.Size = new Size(650, 50);
        txtComplaints.TabIndex = 2;
        // 
        // lblAnamnesis
        // 
        lblAnamnesis.AutoSize = true;
        lblAnamnesis.Location = new Point(15, 115);
        lblAnamnesis.Name = "lblAnamnesis";
        lblAnamnesis.Size = new Size(59, 15);
        lblAnamnesis.TabIndex = 3;
        lblAnamnesis.Text = "Анамнез:";
        // 
        // txtAnamnesis
        // 
        txtAnamnesis.BackColor = SystemColors.Control;
        txtAnamnesis.Location = new Point(15, 133);
        txtAnamnesis.Multiline = true;
        txtAnamnesis.Name = "txtAnamnesis";
        txtAnamnesis.ReadOnly = true;
        txtAnamnesis.ScrollBars = ScrollBars.Vertical;
        txtAnamnesis.Size = new Size(650, 50);
        txtAnamnesis.TabIndex = 4;
        // 
        // lblDiagnosis
        // 
        lblDiagnosis.AutoSize = true;
        lblDiagnosis.Location = new Point(15, 190);
        lblDiagnosis.Name = "lblDiagnosis";
        lblDiagnosis.Size = new Size(55, 15);
        lblDiagnosis.TabIndex = 5;
        lblDiagnosis.Text = "Диагноз:";
        // 
        // txtDiagnosis
        // 
        txtDiagnosis.BackColor = SystemColors.Control;
        txtDiagnosis.Location = new Point(15, 208);
        txtDiagnosis.Multiline = true;
        txtDiagnosis.Name = "txtDiagnosis";
        txtDiagnosis.ReadOnly = true;
        txtDiagnosis.ScrollBars = ScrollBars.Vertical;
        txtDiagnosis.Size = new Size(650, 50);
        txtDiagnosis.TabIndex = 6;
        // 
        // lblRecommendations
        // 
        lblRecommendations.AutoSize = true;
        lblRecommendations.Location = new Point(15, 265);
        lblRecommendations.Name = "lblRecommendations";
        lblRecommendations.Size = new Size(88, 15);
        lblRecommendations.TabIndex = 7;
        lblRecommendations.Text = "Рекомендации:";
        // 
        // txtRecommendations
        // 
        txtRecommendations.BackColor = SystemColors.Control;
        txtRecommendations.Location = new Point(15, 283);
        txtRecommendations.Multiline = true;
        txtRecommendations.Name = "txtRecommendations";
        txtRecommendations.ReadOnly = true;
        txtRecommendations.ScrollBars = ScrollBars.Vertical;
        txtRecommendations.Size = new Size(650, 50);
        txtRecommendations.TabIndex = 8;
        // 
        // tabDetails
        // 
        tabDetails.Controls.Add(tabPrescriptions);
        tabDetails.Controls.Add(tabReferrals);
        tabDetails.Location = new Point(15, 345);
        tabDetails.Name = "tabDetails";
        tabDetails.SelectedIndex = 0;
        tabDetails.Size = new Size(650, 180);
        tabDetails.TabIndex = 9;
        // 
        // tabPrescriptions
        // 
        tabPrescriptions.Controls.Add(dgvPrescriptions);
        tabPrescriptions.Location = new Point(4, 24);
        tabPrescriptions.Name = "tabPrescriptions";
        tabPrescriptions.Padding = new Padding(3);
        tabPrescriptions.Size = new Size(642, 152);
        tabPrescriptions.TabIndex = 0;
        tabPrescriptions.Text = "Рецепты";
        tabPrescriptions.UseVisualStyleBackColor = true;
        // 
        // dgvPrescriptions
        // 
        dgvPrescriptions.AllowUserToAddRows = false;
        dgvPrescriptions.AllowUserToDeleteRows = false;
        dgvPrescriptions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvPrescriptions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvPrescriptions.Columns.AddRange(new DataGridViewColumn[] { colMedicationName, colDosage, colInstructions });
        dgvPrescriptions.Dock = DockStyle.Fill;
        dgvPrescriptions.Location = new Point(3, 3);
        dgvPrescriptions.MultiSelect = false;
        dgvPrescriptions.Name = "dgvPrescriptions";
        dgvPrescriptions.ReadOnly = true;
        dgvPrescriptions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPrescriptions.Size = new Size(636, 146);
        dgvPrescriptions.TabIndex = 0;
        // 
        // colMedicationName
        // 
        colMedicationName.DataPropertyName = "MedicationName";
        colMedicationName.HeaderText = "Препарат";
        colMedicationName.Name = "colMedicationName";
        colMedicationName.ReadOnly = true;
        // 
        // colDosage
        // 
        colDosage.DataPropertyName = "Dosage";
        colDosage.HeaderText = "Дозировка";
        colDosage.Name = "colDosage";
        colDosage.ReadOnly = true;
        // 
        // colInstructions
        // 
        colInstructions.DataPropertyName = "Instructions";
        colInstructions.HeaderText = "Инструкции";
        colInstructions.Name = "colInstructions";
        colInstructions.ReadOnly = true;
        // 
        // tabReferrals
        // 
        tabReferrals.Controls.Add(dgvReferrals);
        tabReferrals.Location = new Point(4, 24);
        tabReferrals.Name = "tabReferrals";
        tabReferrals.Padding = new Padding(3);
        tabReferrals.Size = new Size(642, 152);
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
        dgvReferrals.Dock = DockStyle.Fill;
        dgvReferrals.Location = new Point(3, 3);
        dgvReferrals.MultiSelect = false;
        dgvReferrals.Name = "dgvReferrals";
        dgvReferrals.ReadOnly = true;
        dgvReferrals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvReferrals.Size = new Size(636, 146);
        dgvReferrals.TabIndex = 0;
        // 
        // colReferralType
        // 
        colReferralType.DataPropertyName = "ReferralType";
        colReferralType.HeaderText = "Тип направления";
        colReferralType.Name = "colReferralType";
        colReferralType.ReadOnly = true;
        // 
        // colTargetDescription
        // 
        colTargetDescription.DataPropertyName = "TargetDescription";
        colTargetDescription.HeaderText = "Цель / Описание";
        colTargetDescription.Name = "colTargetDescription";
        colTargetDescription.ReadOnly = true;
        // 
        // btnClose
        // 
        btnClose.Location = new Point(565, 535);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(100, 30);
        btnClose.TabIndex = 10;
        btnClose.Text = "Закрыть";
        btnClose.UseVisualStyleBackColor = true;
        btnClose.Click += btnClose_Click;
        // 
        // ViewExaminationForm
        // 
        CancelButton = btnClose;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(680, 577);
        Controls.Add(btnClose);
        Controls.Add(tabDetails);
        Controls.Add(txtRecommendations);
        Controls.Add(lblRecommendations);
        Controls.Add(txtDiagnosis);
        Controls.Add(lblDiagnosis);
        Controls.Add(txtAnamnesis);
        Controls.Add(lblAnamnesis);
        Controls.Add(txtComplaints);
        Controls.Add(lblComplaints);
        Controls.Add(lblPatientInfo);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ViewExaminationForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Протокол осмотра (Просмотр)";
        tabDetails.ResumeLayout(false);
        tabPrescriptions.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvPrescriptions).EndInit();
        tabReferrals.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvReferrals).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblPatientInfo;
    private Label lblComplaints;
    private TextBox txtComplaints;
    private Label lblAnamnesis;
    private TextBox txtAnamnesis;
    private Label lblDiagnosis;
    private TextBox txtDiagnosis;
    private Label lblRecommendations;
    private TextBox txtRecommendations;
    private TabControl tabDetails;
    private TabPage tabPrescriptions;
    private DataGridView dgvPrescriptions;
    private DataGridViewTextBoxColumn colMedicationName;
    private DataGridViewTextBoxColumn colDosage;
    private DataGridViewTextBoxColumn colInstructions;
    private TabPage tabReferrals;
    private DataGridView dgvReferrals;
    private DataGridViewTextBoxColumn colReferralType;
    private DataGridViewTextBoxColumn colTargetDescription;
    private Button btnClose;
}