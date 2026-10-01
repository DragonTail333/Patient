using Microsoft.Extensions.DependencyInjection;
using Patients.Domain;
using Patients.Services.Abstractions;

namespace Patients.Forms;

public partial class RegistratorMainForm : Form
{
    private readonly IServiceScopeFactory? _scopeFactory;
    private User? _currentUser;

    public bool IsLogoutRequested { get; private set; }
    public PatientGridItemDto? SelectedPatient { get; private set; }

    // Конструктор для Visual Studio Designer
    public RegistratorMainForm()
    {
        InitializeComponent();
    }

    // Конструктор для DI
    public RegistratorMainForm(IServiceScopeFactory scopeFactory) : this()
    {
        _scopeFactory = scopeFactory;
    }

    public void Initialize(User user)
    {
        _currentUser = user;
        Text = $"АРМ регистратора — {user.LastName} {user.FirstName}";
        lblWelcome.Text = $"Добро пожаловать, {user.LastName} {user.FirstName} {user.MiddleName}";
    }

    private async void RegistratorMainForm_Load(object sender, EventArgs e)
    {
        await LoadPatientsAsync();
    }

    private async Task LoadPatientsAsync(string? cardNumberFilter = null)
    {
        if (_scopeFactory == null) return;

        using var scope = _scopeFactory.CreateScope();
        var patientService = scope.ServiceProvider.GetRequiredService<IPatientService>();

        var patients = await patientService.GetAllPatientsAsync(cardNumberFilter);

        // Маппинг в DTO для правильного отображения ФИО и формата даты в DataGridView
        var gridItems = patients.Select(p => new PatientGridItemDto
        {
            Id = p.Id,
            CardNumber = p.CardNumber,
            FullName = $"{p.LastName} {p.FirstName} {p.MiddleName}".TrimEnd(),
            BirthDateFormatted = p.BirthDate.ToString("dd.MM.yyyy"),
            Gender = p.Gender,
            Phone = p.Phone,
            PolicyNumber = p.PolicyNumber,
            OriginalPatient = p // используется для хранения оригинального доменного объекта,
                                // на основе которого собиралось DTO
                                // нужно для моментального нахождения искомого Patient в процессе назначения приёма
        }).ToList();

        dgvPatients.AutoGenerateColumns = false;
        dgvPatients.DataSource = gridItems;
        UpdateAppointmentButtonState();
    }

    private async void btnSearch_Click(object sender, EventArgs e)
    {
        await LoadPatientsAsync(txtSearchCardNumber.Text);
    }

    private async void btnResetSearch_Click(object sender, EventArgs e)
    {
        txtSearchCardNumber.Clear();
        await LoadPatientsAsync();
    }

    private async void btnCreatePatient_Click(object sender, EventArgs e)
    {
        if (_scopeFactory == null) return;

        using var scope = _scopeFactory.CreateScope();
        var createPatientForm = scope.ServiceProvider.GetRequiredService<CreatePatientForm>();

        // Если новый пациент успешно сохранен — автоматически обновляем таблицу
        if (createPatientForm.ShowDialog(this) == DialogResult.OK)
        {
            await LoadPatientsAsync();
        }
    }

    private void dgvPatients_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvPatients.CurrentRow?.DataBoundItem is PatientGridItemDto selected)
        {
            SelectedPatient = selected;
        }
        else
        {
            SelectedPatient = null;
        }

        UpdateAppointmentButtonState();
    }

    private void UpdateAppointmentButtonState()
    {
        btnCreateAppointment.Enabled = SelectedPatient != null;
    }

    private void btnCreateAppointment_Click(object sender, EventArgs e)
    {
        OpenAppointmentForm();
    }

    private void dgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        // Игнорируем клики по заголовкам таблицы
        if (e.RowIndex < 0) return;

        OpenAppointmentForm();
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        IsLogoutRequested = true;
        Close();
    }

    /// <summary>
    /// метод открытия формы назначения приёма
    /// </summary>
    private void OpenAppointmentForm()
    {
        if (SelectedPatient == null || _scopeFactory == null) return;

        using var scope = _scopeFactory.CreateScope();
        var appointmentForm = scope.ServiceProvider.GetRequiredService<CreateAppointmentForm>();

        // Инициализируем форму перед показом
        appointmentForm.Initialize(SelectedPatient.Id, SelectedPatient.FullName, _currentUser!.Id);

        if (appointmentForm.ShowDialog(this) == DialogResult.OK)
        {
            // В будущем тут можно обновить данные, если потребуется
        }
    }
}

// Вспомогательный класс отображения для таблицы DataGridView
public class PatientGridItemDto
{
    public int Id { get; set; }
    public string CardNumber { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string BirthDateFormatted { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string PolicyNumber { get; set; } = null!;
    public Patient OriginalPatient { get; set; } = null!;
}
