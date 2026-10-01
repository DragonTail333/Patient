namespace Patients.Forms;

partial class CreatePatientForm
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
        lblCardNumber = new Label();
        txtCardNumber = new TextBox();
        lblLastName = new Label();
        txtLastName = new TextBox();
        lblFirstName = new Label();
        txtFirstName = new TextBox();
        lblMiddleName = new Label();
        txtMiddleName = new TextBox();
        lblBirthDate = new Label();
        dtpBirthDate = new DateTimePicker();
        lblGender = new Label();
        cmbGender = new ComboBox();
        lblPhone = new Label();
        txtPhone = new TextBox();
        lblPolicyNumber = new Label();
        txtPolicyNumber = new TextBox();
        btnSave = new Button();
        btnCancel = new Button();
        lblError = new Label();
        SuspendLayout();
        // 
        // lblCardNumber
        // 
        lblCardNumber.AutoSize = true;
        lblCardNumber.Location = new Point(25, 20);
        lblCardNumber.Name = "lblCardNumber";
        lblCardNumber.Size = new Size(88, 15);
        lblCardNumber.TabIndex = 0;
        lblCardNumber.Text = "№ медкарты *:";
        // 
        // txtCardNumber
        // 
        txtCardNumber.Location = new Point(155, 17);
        txtCardNumber.Name = "txtCardNumber";
        txtCardNumber.Size = new Size(240, 23);
        txtCardNumber.TabIndex = 1;
        // 
        // lblLastName
        // 
        lblLastName.AutoSize = true;
        lblLastName.Location = new Point(25, 55);
        lblLastName.Name = "lblLastName";
        lblLastName.Size = new Size(69, 15);
        lblLastName.TabIndex = 2;
        lblLastName.Text = "Фамилия *:";
        // 
        // txtLastName
        // 
        txtLastName.Location = new Point(155, 52);
        txtLastName.Name = "txtLastName";
        txtLastName.Size = new Size(240, 23);
        txtLastName.TabIndex = 3;
        // 
        // lblFirstName
        // 
        lblFirstName.AutoSize = true;
        lblFirstName.Location = new Point(25, 90);
        lblFirstName.Name = "lblFirstName";
        lblFirstName.Size = new Size(42, 15);
        lblFirstName.TabIndex = 4;
        lblFirstName.Text = "Имя *:";
        // 
        // txtFirstName
        // 
        txtFirstName.Location = new Point(155, 87);
        txtFirstName.Name = "txtFirstName";
        txtFirstName.Size = new Size(240, 23);
        txtFirstName.TabIndex = 5;
        // 
        // lblMiddleName
        // 
        lblMiddleName.AutoSize = true;
        lblMiddleName.Location = new Point(25, 125);
        lblMiddleName.Name = "lblMiddleName";
        lblMiddleName.Size = new Size(61, 15);
        lblMiddleName.TabIndex = 6;
        lblMiddleName.Text = "Отчество:";
        // 
        // txtMiddleName
        // 
        txtMiddleName.Location = new Point(155, 122);
        txtMiddleName.Name = "txtMiddleName";
        txtMiddleName.Size = new Size(240, 23);
        txtMiddleName.TabIndex = 7;
        // 
        // lblBirthDate
        // 
        lblBirthDate.AutoSize = true;
        lblBirthDate.Location = new Point(25, 160);
        lblBirthDate.Name = "lblBirthDate";
        lblBirthDate.Size = new Size(101, 15);
        lblBirthDate.TabIndex = 8;
        lblBirthDate.Text = "Дата рождения *:";
        // 
        // dtpBirthDate
        // 
        dtpBirthDate.Format = DateTimePickerFormat.Short;
        dtpBirthDate.Location = new Point(155, 157);
        dtpBirthDate.Name = "dtpBirthDate";
        dtpBirthDate.Size = new Size(240, 23);
        dtpBirthDate.TabIndex = 9;
        // 
        // lblGender
        // 
        lblGender.AutoSize = true;
        lblGender.Location = new Point(25, 195);
        lblGender.Name = "lblGender";
        lblGender.Size = new Size(41, 15);
        lblGender.TabIndex = 10;
        lblGender.Text = "Пол *:";
        // 
        // cmbGender
        // 
        cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbGender.FormattingEnabled = true;
        cmbGender.Items.AddRange(new object[] { "Мужской", "Женский" });
        cmbGender.Location = new Point(155, 192);
        cmbGender.Name = "cmbGender";
        cmbGender.Size = new Size(240, 23);
        cmbGender.TabIndex = 11;
        // 
        // lblPhone
        // 
        lblPhone.AutoSize = true;
        lblPhone.Location = new Point(25, 230);
        lblPhone.Name = "lblPhone";
        lblPhone.Size = new Size(66, 15);
        lblPhone.TabIndex = 12;
        lblPhone.Text = "Телефон *:";
        // 
        // txtPhone
        // 
        txtPhone.Location = new Point(155, 227);
        txtPhone.Name = "txtPhone";
        txtPhone.Size = new Size(240, 23);
        txtPhone.TabIndex = 13;
        // 
        // lblPolicyNumber
        // 
        lblPolicyNumber.AutoSize = true;
        lblPolicyNumber.Location = new Point(25, 265);
        lblPolicyNumber.Name = "lblPolicyNumber";
        lblPolicyNumber.Size = new Size(74, 15);
        lblPolicyNumber.TabIndex = 14;
        lblPolicyNumber.Text = "№ полиса *:";
        // 
        // txtPolicyNumber
        // 
        txtPolicyNumber.Location = new Point(155, 262);
        txtPolicyNumber.Name = "txtPolicyNumber";
        txtPolicyNumber.Size = new Size(240, 23);
        txtPolicyNumber.TabIndex = 15;
        // 
        // btnSave
        // 
        btnSave.Location = new Point(155, 335);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(115, 30);
        btnSave.TabIndex = 17;
        btnSave.Text = "Сохранить";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(280, 335);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(115, 30);
        btnCancel.TabIndex = 18;
        btnCancel.Text = "Отмена";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // lblError
        // 
        lblError.ForeColor = Color.Red;
        lblError.Location = new Point(25, 295);
        lblError.Name = "lblError";
        lblError.Size = new Size(370, 35);
        lblError.TabIndex = 16;
        lblError.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // CreatePatientForm
        // 
        AcceptButton = btnSave;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new Size(420, 380);
        Controls.Add(lblError);
        Controls.Add(btnCancel);
        Controls.Add(btnSave);
        Controls.Add(txtPolicyNumber);
        Controls.Add(lblPolicyNumber);
        Controls.Add(txtPhone);
        Controls.Add(lblPhone);
        Controls.Add(cmbGender);
        Controls.Add(lblGender);
        Controls.Add(dtpBirthDate);
        Controls.Add(lblBirthDate);
        Controls.Add(txtMiddleName);
        Controls.Add(lblMiddleName);
        Controls.Add(txtFirstName);
        Controls.Add(lblFirstName);
        Controls.Add(txtLastName);
        Controls.Add(lblLastName);
        Controls.Add(txtCardNumber);
        Controls.Add(lblCardNumber);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "CreatePatientForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Регистрация нового пациента";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblCardNumber;
    private TextBox txtCardNumber;
    private Label lblLastName;
    private TextBox txtLastName;
    private Label lblFirstName;
    private TextBox txtFirstName;
    private Label lblMiddleName;
    private TextBox txtMiddleName;
    private Label lblBirthDate;
    private DateTimePicker dtpBirthDate;
    private Label lblGender;
    private ComboBox cmbGender;
    private Label lblPhone;
    private TextBox txtPhone;
    private Label lblPolicyNumber;
    private TextBox txtPolicyNumber;
    private Label lblError;
    private Button btnSave;
    private Button btnCancel;
}