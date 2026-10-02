using Patients.Domain;

namespace Patients.Forms;

public partial class CreatePrescriptionForm : Form
{
    public Prescription? CreatedPrescription { get; private set; }

    public CreatePrescriptionForm()
    {
        InitializeComponent();
        AttachEventHandlers();
    }

    private void AttachEventHandlers()
    {
        txtMedicationName.TextChanged += ClearControlHighlight;
        txtDosage.TextChanged += ClearControlHighlight;
        txtInstructions.TextChanged += ClearControlHighlight;
    }

    private void ClearControlHighlight(object? sender, EventArgs e)
    {
        if (sender is TextBox textBox && textBox.BackColor != SystemColors.Window)
        {
            textBox.BackColor = SystemColors.Window;
            if (!string.IsNullOrWhiteSpace(txtMedicationName.Text) &&
                !string.IsNullOrWhiteSpace(txtDosage.Text) &&
                !string.IsNullOrWhiteSpace(txtInstructions.Text))
            {
                lblError.Text = string.Empty;
            }
        }
    }

    private bool ValidateInputs()
    {
        lblError.Text = string.Empty;
        txtMedicationName.BackColor = SystemColors.Window;
        txtDosage.BackColor = SystemColors.Window;
        txtInstructions.BackColor = SystemColors.Window;

        var missingFields = new List<string>();

        if (string.IsNullOrWhiteSpace(txtMedicationName.Text))
        {
            txtMedicationName.BackColor = Color.MistyRose;
            missingFields.Add("Препарат");
        }

        if (string.IsNullOrWhiteSpace(txtDosage.Text))
        {
            txtDosage.BackColor = Color.MistyRose;
            missingFields.Add("Дозировка");
        }

        if (string.IsNullOrWhiteSpace(txtInstructions.Text))
        {
            txtInstructions.BackColor = Color.MistyRose;
            missingFields.Add("Инструкция");
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

        CreatedPrescription = new Prescription
        {
            MedicationName = txtMedicationName.Text.Trim(),
            Dosage = txtDosage.Text.Trim(),
            Instructions = txtInstructions.Text.Trim()
        };

        DialogResult = DialogResult.OK;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }
}
