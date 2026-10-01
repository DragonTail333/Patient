using Patients.Domain;
using Patients.Services.Abstractions;

namespace Patients.Forms;

public partial class CreatePatientForm : Form
{
    private readonly IPatientService? _patientService;

    public CreatePatientForm()
    {
        InitializeComponent();
    }

    public CreatePatientForm(IPatientService patientService) : this()
    {
        _patientService = patientService;
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        if (_patientService == null) return;

        lblError.Text = string.Empty;

        // Первичная валидация полей формы
        if (!ValidateInputs(out string errorMessage))
        {
            lblError.Text = errorMessage;
            return;
        }

        SetFormEnabled(false);

        try
        {
            var cardNumber = txtCardNumber.Text.Trim();

            // Проверка уникальности номера медкарты перед сохранением
            var existingPatient = await _patientService.FindByCardNumberAsync(cardNumber);
            if (existingPatient != null)
            {
                lblError.Text = $"Пациент с картой №{cardNumber} уже зарегистрирован.";
                return;
            }

            // Создание объекта сущности
            var patient = MapToPatient();

            // Асинхронное сохранение в БД
            await _patientService.AddPatientAsync(patient);

            // Успешный результат закрывает модальное окно
            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            lblError.Text = $"Ошибка сохранения: {ex.Message}";
        }
        finally
        {
            SetFormEnabled(true);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }

    private bool ValidateInputs(out string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(txtCardNumber.Text))
        {
            errorMessage = "Заполните номер медицинской карты.";
            txtCardNumber.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtLastName.Text))
        {
            errorMessage = "Заполните фамилию пациента.";
            txtLastName.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtFirstName.Text))
        {
            errorMessage = "Заполните имя пациента.";
            txtFirstName.Focus();
            return false;
        }

        if (cmbGender.SelectedItem == null)
        {
            errorMessage = "Выберите пол пациента.";
            cmbGender.Focus();
            return false;
        }

        if (dtpBirthDate.Value.Date > DateTime.Today)
        {
            errorMessage = "Дата рождения не может быть в будущем.";
            dtpBirthDate.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtPhone.Text))
        {
            errorMessage = "Заполните номер телефона.";
            txtPhone.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtPolicyNumber.Text))
        {
            errorMessage = "Заполните номер полиса ОМС.";
            txtPolicyNumber.Focus();
            return false;
        }

        errorMessage = string.Empty;
        return true;
    }

    private Patient MapToPatient()
    {
        return new Patient
        {
            CardNumber = txtCardNumber.Text.Trim(),
            LastName = txtLastName.Text.Trim(),
            FirstName = txtFirstName.Text.Trim(),
            MiddleName = string.IsNullOrWhiteSpace(txtMiddleName.Text) ? null : txtMiddleName.Text.Trim(),
            BirthDate = DateOnly.FromDateTime(dtpBirthDate.Value),
            Gender = cmbGender.SelectedItem!.ToString()!,
            Phone = txtPhone.Text.Trim(),
            PolicyNumber = txtPolicyNumber.Text.Trim()
        };
    }

    private void SetFormEnabled(bool enabled)
    {
        btnSave.Enabled = enabled;
        btnCancel.Enabled = enabled;
        txtCardNumber.Enabled = enabled;
        txtLastName.Enabled = enabled;
        txtFirstName.Enabled = enabled;
        txtMiddleName.Enabled = enabled;
        dtpBirthDate.Enabled = enabled;
        cmbGender.Enabled = enabled;
        txtPhone.Enabled = enabled;
        txtPolicyNumber.Enabled = enabled;
    }
}