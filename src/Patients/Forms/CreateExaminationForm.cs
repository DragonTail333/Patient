using Microsoft.Extensions.DependencyInjection;
using Patients.Domain;
using System.ComponentModel;
namespace Patients.Forms;

public partial class CreateExaminationForm : Form
{
    private readonly IServiceScopeFactory? _scopeFactory;

    private int _appointmentId;
    private string _patientFullName = string.Empty;

    private readonly BindingList<Prescription> _prescriptions = new();
    private readonly BindingList<Referral> _referrals = new();

    public string Complaints => txtComplaints.Text.Trim();
    public string Anamnesis => txtAnamnesis.Text.Trim();
    public string Diagnosis => txtDiagnosis.Text.Trim();
    public string Recommendations => txtRecommendations.Text.Trim();

    public IReadOnlyList<Prescription> Prescriptions => _prescriptions.ToList();
    public IReadOnlyList<Referral> Referrals => _referrals.ToList();

    public CreateExaminationForm()
    {
        InitializeComponent();
        SetupDataBinding();
        AttachEventHandlers();
    }

    public CreateExaminationForm(IServiceScopeFactory scopeFactory) : this()
    {
        _scopeFactory = scopeFactory;
    }

    public void Initialize(int appointmentId, string patientFullName)
    {
        _appointmentId = appointmentId;
        _patientFullName = patientFullName;

        Text = $"Проведение осмотра — {_patientFullName}";
        lblPatientInfo.Text = $"Пациент: {_patientFullName} | Приём №{_appointmentId}";
    }

    private void SetupDataBinding()
    {
        dgvPrescriptions.AutoGenerateColumns = false;
        dgvPrescriptions.DataSource = _prescriptions;

        dgvReferrals.AutoGenerateColumns = false;
        dgvReferrals.DataSource = _referrals;
    }

    private void AttachEventHandlers()
    {
        // снять розовое подсвечивание поля, как только врач начинает вводить текст
        txtComplaints.TextChanged += ClearControlHighlight;
        txtAnamnesis.TextChanged += ClearControlHighlight;
        txtDiagnosis.TextChanged += ClearControlHighlight;
        txtRecommendations.TextChanged += ClearControlHighlight;
    }

    private void ClearControlHighlight(object? sender, EventArgs e)
    {
        if (sender is TextBox textBox && textBox.BackColor != SystemColors.Window)
        {
            textBox.BackColor = SystemColors.Window;

            // Если все поля уже исправлены, очищаем текст ошибки
            if (IsAllRequiredFieldsFilled())
            {
                lblError.Text = string.Empty;
            }
        }
    }

    private bool IsAllRequiredFieldsFilled()
    {
        return !string.IsNullOrWhiteSpace(txtComplaints.Text) &&
               !string.IsNullOrWhiteSpace(txtAnamnesis.Text) &&
               !string.IsNullOrWhiteSpace(txtDiagnosis.Text) &&
               !string.IsNullOrWhiteSpace(txtRecommendations.Text);
    }

    private bool ValidateInputs()
    {
        lblError.Text = string.Empty;

        // Сброс цвета фона полей
        txtComplaints.BackColor = SystemColors.Window;
        txtAnamnesis.BackColor = SystemColors.Window;
        txtDiagnosis.BackColor = SystemColors.Window;
        txtRecommendations.BackColor = SystemColors.Window;

        var missingFields = new List<string>();
        TextBox? firstInvalidField = null;

        if (string.IsNullOrWhiteSpace(txtComplaints.Text))
        {
            txtComplaints.BackColor = Color.MistyRose;
            missingFields.Add("Жалобы");
            firstInvalidField ??= txtComplaints;
        }

        if (string.IsNullOrWhiteSpace(txtAnamnesis.Text))
        {
            txtAnamnesis.BackColor = Color.MistyRose;
            missingFields.Add("Анамнез");
            firstInvalidField ??= txtAnamnesis;
        }

        if (string.IsNullOrWhiteSpace(txtDiagnosis.Text))
        {
            txtDiagnosis.BackColor = Color.MistyRose;
            missingFields.Add("Диагноз");
            firstInvalidField ??= txtDiagnosis;
        }

        if (string.IsNullOrWhiteSpace(txtRecommendations.Text))
        {
            txtRecommendations.BackColor = Color.MistyRose;
            missingFields.Add("Рекомендации");
            firstInvalidField ??= txtRecommendations;
        }

        if (missingFields.Count > 0)
        {
            lblError.Text = $"Заполните обязательные поля: {string.Join(", ", missingFields)}.";
            firstInvalidField?.Focus();
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

        DialogResult = DialogResult.OK;
    }

    #region prescription

    private void btnAddPrescription_Click(object sender, EventArgs e)
    {
        if (_scopeFactory == null) return;

        using var scope = _scopeFactory.CreateScope();
        var prescriptionForm = scope.ServiceProvider.GetRequiredService<CreatePrescriptionForm>();

        if (prescriptionForm.ShowDialog(this) == DialogResult.OK && prescriptionForm.CreatedPrescription != null)
        {
            _prescriptions.Add(prescriptionForm.CreatedPrescription);
        }
    }

    private void btnDeletePrescription_Click(object sender, EventArgs e)
    {
        if (dgvPrescriptions.CurrentRow?.DataBoundItem is Prescription selected)
        {
            _prescriptions.Remove(selected);
        }
    }

    #endregion

    #region referrals

    private void btnAddReferral_Click(object sender, EventArgs e)
    {
        if (_scopeFactory == null) return;

        using var scope = _scopeFactory.CreateScope();
        var referralForm = scope.ServiceProvider.GetRequiredService<CreateReferralForm>();

        if (referralForm.ShowDialog(this) == DialogResult.OK && referralForm.CreatedReferral != null)
        {
            _referrals.Add(referralForm.CreatedReferral);
        }
    }

    private void btnDeleteReferral_Click(object sender, EventArgs e)
    {
        if (dgvReferrals.CurrentRow?.DataBoundItem is Referral selected)
        {
            _referrals.Remove(selected);
        }
    }

    #endregion

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }
}