namespace Patients.Forms
{
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
            lblWelcome = new Label();
            btnLogout = new Button();
            btnCreatePatient = new Button();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(328, 207);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(38, 15);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "label1";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(12, 12);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(122, 40);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Резлогиниться";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnCreatePatient
            // 
            btnCreatePatient.Location = new Point(12, 398);
            btnCreatePatient.Name = "btnCreatePatient";
            btnCreatePatient.Size = new Size(122, 40);
            btnCreatePatient.TabIndex = 3;
            btnCreatePatient.Text = "Добавить пациента";
            btnCreatePatient.UseVisualStyleBackColor = true;
            btnCreatePatient.Click += btnCreatePatient_Click;
            // 
            // RegistratorMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCreatePatient);
            Controls.Add(btnLogout);
            Controls.Add(lblWelcome);
            Name = "RegistratorMainForm";
            Text = "RegistratorMainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Button btnLogout;
        private Button btnCreatePatient;
    }
}