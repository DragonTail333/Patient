using Patients.Domain;

namespace Patients.Forms;

public partial class CreateReferralForm : Form
{
    public Referral? CreatedReferral { get; private set; }

    public CreateReferralForm()
    {
        InitializeComponent();
        AttachEventHandlers();
    }

    private void AttachEventHandlers()
    {
        txtReferralType.TextChanged += ClearControlHighlight;
        txtTargetDescription.TextChanged += ClearControlHighlight;
    }

    private void ClearControlHighlight(object? sender, EventArgs e)
    {
        if (sender is TextBox textBox && textBox.BackColor != SystemColors.Window)
        {
            textBox.BackColor = SystemColors.Window;
            if (!string.IsNullOrWhiteSpace(txtReferralType.Text) && !string.IsNullOrWhiteSpace(txtTargetDescription.Text))
            {
                lblError.Text = string.Empty;
            }
        }
    }

    private bool ValidateInputs()
    {
        lblError.Text = string.Empty;
        txtReferralType.BackColor = SystemColors.Window;
        txtTargetDescription.BackColor = SystemColors.Window;

        var missingFields = new List<string>();

        if (string.IsNullOrWhiteSpace(txtReferralType.Text))
        {
            txtReferralType.BackColor = Color.MistyRose;
            missingFields.Add("Тип направления");
        }

        if (string.IsNullOrWhiteSpace(txtTargetDescription.Text))
        {
            txtTargetDescription.BackColor = Color.MistyRose;
            missingFields.Add("Цель / Описание");
        }

        if (missingFields.Count > 0)
        {
            lblError.Text = $"Заполните поля: {string.Join(", ", missingFields)}.";
            return false;
        }

        return true;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (!ValidateInputs())
        {
            return;
        }

        CreatedReferral = new Referral
        {
            ReferralType = txtReferralType.Text.Trim(),
            TargetDescription = txtTargetDescription.Text.Trim()
        };

        DialogResult = DialogResult.OK;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }
}
