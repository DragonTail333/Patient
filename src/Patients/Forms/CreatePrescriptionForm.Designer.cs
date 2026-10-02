namespace Patients.Forms;

partial class CreatePrescriptionForm
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
        lblMedicationName = new Label();
        txtMedicationName = new TextBox();
        lblDosage = new Label();
        txtDosage = new TextBox();
        lblInstructions = new Label();
        txtInstructions = new TextBox();
        btnSave = new Button();
        btnCancel = new Button();
        lblError = new Label();
        SuspendLayout();
        // 
        // lblMedicationName
        // 
        lblMedicationName.AutoSize = true;
        lblMedicationName.Location = new Point(15, 15);
        lblMedicationName.Name = "lblMedicationName";
        lblMedicationName.Size = new Size(138, 15);
        lblMedicationName.TabIndex = 0;
        lblMedicationName.Text = "Название препарата:";
        // 
        // txtMedicationName
        // 
        txtMedicationName.Location = new Point(15, 33);
        txtMedicationName.Name = "txtMedicationName";
        txtMedicationName.Size = new Size(410, 23);
        txtMedicationName.TabIndex = 1;
        // 
        // lblDosage
        // 
        lblDosage.AutoSize = true;
        lblDosage.Location = new Point(15, 68);
        lblDosage.Name = "lblDosage";
        lblDosage.Size = new Size(68, 15);
        lblDosage.TabIndex = 2;
        lblDosage.Text = "Дозировка:";
        // 
        // txtDosage
        // 
        txtDosage.Location = new Point(15, 86);
        txtDosage.Name = "txtDosage";
        txtDosage.Size = new Size(410, 23);
        txtDosage.TabIndex = 3;
        // 
        // lblInstructions
        // 
        lblInstructions.AutoSize = true;
        lblInstructions.Location = new Point(15, 121);
        lblInstructions.Name = "lblInstructions";
        lblInstructions.Size = new Size(138, 15);
        lblInstructions.TabIndex = 4;
        lblInstructions.Text = "Инструкция по приёму:";
        // 
        // txtInstructions
        // 
        txtInstructions.Location = new Point(15, 139);
        txtInstructions.Multiline = true;
        txtInstructions.Name = "txtInstructions";
        txtInstructions.ScrollBars = ScrollBars.Vertical;
        txtInstructions.Size = new Size(410, 75);
        txtInstructions.TabIndex = 5;
        // 
        // btnSave
        // 
        btnSave.Location = new Point(230, 235);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(110, 30);
        btnSave.TabIndex = 6;
        btnSave.Text = "Добавить";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(350, 235);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(75, 30);
        btnCancel.TabIndex = 7;
        btnCancel.Text = "Отмена";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // lblError
        // 
        lblError.ForeColor = Color.Red;
        lblError.Location = new Point(15, 217);
        lblError.Name = "lblError";
        lblError.Size = new Size(410, 18);
        lblError.TabIndex = 8;
        // 
        // CreatePrescriptionForm
        // 
        AcceptButton = btnSave;
        CancelButton = btnCancel;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(440, 277);
        Controls.Add(lblError);
        Controls.Add(btnCancel);
        Controls.Add(btnSave);
        Controls.Add(txtInstructions);
        Controls.Add(lblInstructions);
        Controls.Add(txtDosage);
        Controls.Add(lblDosage);
        Controls.Add(txtMedicationName);
        Controls.Add(lblMedicationName);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "CreatePrescriptionForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Выписка рецепта";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblMedicationName;
    private TextBox txtMedicationName;
    private Label lblDosage;
    private TextBox txtDosage;
    private Label lblInstructions;
    private TextBox txtInstructions;
    private Button btnSave;
    private Button btnCancel;
    private Label lblError;
}