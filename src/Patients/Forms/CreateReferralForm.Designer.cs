namespace Patients.Forms
{
    partial class CreateReferralForm
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
            lblReferralType = new Label();
            txtReferralType = new TextBox();
            lblTargetDescription = new Label();
            txtTargetDescription = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblError = new Label();
            SuspendLayout();
            // 
            // lblReferralType
            // 
            lblReferralType.AutoSize = true;
            lblReferralType.Location = new Point(15, 15);
            lblReferralType.Name = "lblReferralType";
            lblReferralType.Size = new Size(107, 15);
            lblReferralType.TabIndex = 0;
            lblReferralType.Text = "Тип направления:";
            // 
            // txtReferralType
            // 
            txtReferralType.Location = new Point(15, 33);
            txtReferralType.Name = "txtReferralType";
            txtReferralType.Size = new Size(410, 23);
            txtReferralType.TabIndex = 1;
            // 
            // lblTargetDescription
            // 
            lblTargetDescription.AutoSize = true;
            lblTargetDescription.Location = new Point(15, 68);
            lblTargetDescription.Name = "lblTargetDescription";
            lblTargetDescription.Size = new Size(105, 15);
            lblTargetDescription.TabIndex = 2;
            lblTargetDescription.Text = "Цель / Описание:";
            // 
            // txtTargetDescription
            // 
            txtTargetDescription.Location = new Point(15, 86);
            txtTargetDescription.Multiline = true;
            txtTargetDescription.Name = "txtTargetDescription";
            txtTargetDescription.ScrollBars = ScrollBars.Vertical;
            txtTargetDescription.Size = new Size(410, 85);
            txtTargetDescription.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(230, 200);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(110, 30);
            btnSave.TabIndex = 4;
            btnSave.Text = "Добавить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(350, 200);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 30);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblError
            // 
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(15, 175);
            lblError.Name = "lblError";
            lblError.Size = new Size(410, 20);
            lblError.TabIndex = 6;
            // 
            // CreateReferralForm
            // 
            AcceptButton = btnSave;
            CancelButton = btnCancel;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(440, 242);
            Controls.Add(lblError);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtTargetDescription);
            Controls.Add(lblTargetDescription);
            Controls.Add(txtReferralType);
            Controls.Add(lblReferralType);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateReferralForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Выписка направления";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblReferralType;
        private TextBox txtReferralType;
        private Label lblTargetDescription;
        private TextBox txtTargetDescription;
        private Button btnSave;
        private Button btnCancel;
        private Label lblError;
    }
}