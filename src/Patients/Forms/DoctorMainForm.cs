using Microsoft.Extensions.DependencyInjection;
using Patients.Domain;
using Patients.Domain.Enums;
using Patients.Services.Abstractions;
namespace Patients.Forms;

public partial class DoctorMainForm : Form
{
    private readonly IServiceScopeFactory? _scopeFactory;
    private User? _currentUser;
    private Doctor? _currentDoctor;

    public bool IsLogoutRequested { get; private set; }
    public AppointmentGridItemDto? SelectedAppointment { get; private set; }

    public DoctorMainForm()
    {
        InitializeComponent();
    }

    public DoctorMainForm(IServiceScopeFactory scopeFactory) : this()
    {
        _scopeFactory = scopeFactory;
    }

    public void Initialize(User user)
    {
        _currentUser = user;
        Text = $"АРМ Врача — {user.LastName} {user.FirstName}";
        lblWelcome.Text = $"Загрузка профиля врача...";

        dtpAppointmentDate.MinDate = DateTime.Today;
        dtpAppointmentDate.Value = DateTime.Today;
    }

    private async void DoctorMainForm_Load(object sender, EventArgs e)
    {
        if (_currentUser == null || _scopeFactory == null) return;

        // Если Doctor не был подгружен при логине — добираем через сервис
        if (_currentUser.Doctor != null)
        {
            _currentDoctor = _currentUser.Doctor;
        }
        else
        {
            using var scope = _scopeFactory.CreateScope();
            var doctorService = scope.ServiceProvider.GetRequiredService<IDoctorService>();
            _currentDoctor = await doctorService.GetDoctorByUserIdAsync(_currentUser.Id);
        }

        if (_currentDoctor == null)
        {
            MessageBox.Show("Не удалось найти профиль врача для текущего пользователя.", "Ошибка доступа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
            return;
        }

        // Обновляем шапку данными врача
        Text = $"АРМ Врача — {_currentUser.LastName} {_currentUser.FirstName} ({_currentDoctor.Specialty?.Title ?? "Врач"})";
        lblWelcome.Text = $"Врач: {_currentUser.LastName} {_currentUser.FirstName} {_currentUser.MiddleName} | Кабинет: {_currentDoctor.RoomNumber}";

        await LoadAppointmentsAsync();
    }

    private async void dtpAppointmentDate_ValueChanged(object sender, EventArgs e)
    {
        await LoadAppointmentsAsync();
    }

    private async Task LoadAppointmentsAsync()
    {
        if (_currentDoctor == null || _scopeFactory == null) return;

        var selectedDate = DateOnly.FromDateTime(dtpAppointmentDate.Value);

        using var scope = _scopeFactory.CreateScope();
        var appointmentService = scope.ServiceProvider.GetRequiredService<IAppointmentService>();

        var appointments = await appointmentService.GetAllAppointmentByDoctorIdAndDateAsync(selectedDate, _currentDoctor.Id);

        var gridItems = appointments.Select(a => new AppointmentGridItemDto
        {
            Id = a.Id,
            TimeFormatted = TimeOnly.FromDateTime(a.AppointmentDate).ToString("HH:mm"),
            PatientCardNumber = a.Patient?.CardNumber ?? "—",
            PatientFullName = a.Patient != null
                ? $"{a.Patient.LastName} {a.Patient.FirstName} {a.Patient.MiddleName}".TrimEnd()
                : "Не указан",
            Status = a.Status,
            StatusRussian = GetStatusRussianName(a.Status),
            OriginalAppointment = a
        }).ToList();

        dgvAppointments.AutoGenerateColumns = false;
        dgvAppointments.DataSource = gridItems;

        UpdateSelectedAppointment();
    }

    private void dgvAppointments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dgvAppointments.Rows[e.RowIndex].DataBoundItem is AppointmentGridItemDto item)
        {
            switch (item.Status)
            {
                case AppointmentStatus.Completed:
                    dgvAppointments.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                    dgvAppointments.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.ForestGreen;
                    break;
                case AppointmentStatus.Cancelled:
                    dgvAppointments.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                    dgvAppointments.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkGray;
                    break;
                case AppointmentStatus.Scheduled:
                    dgvAppointments.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    break;
            }
        }
    }

    private void dgvAppointments_SelectionChanged(object sender, EventArgs e)
    {
        UpdateSelectedAppointment();
    }

    private void dgvAppointments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        OpenExaminationForm();
    }

    private void btnStartExamination_Click(object sender, EventArgs e)
    {
        OpenExaminationForm();
    }

    private void OpenExaminationForm()
    {
        if (SelectedAppointment == null || _scopeFactory == null) return;

        if (SelectedAppointment.Status == AppointmentStatus.Cancelled)
        {
            MessageBox.Show("Нельзя провести осмотр по отменённой записи.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var scope = _scopeFactory.CreateScope();
        var examinationForm = scope.ServiceProvider.GetRequiredService<CreateExaminationForm>();
        examinationForm.Initialize(SelectedAppointment.Id, SelectedAppointment.PatientFullName);

        if (examinationForm.ShowDialog(this) == DialogResult.OK)
        {
            // Обновить список приёмов после завершения осмотра
            _ = LoadAppointmentsAsync();
        }
    }

    private void UpdateSelectedAppointment()
    {
        if (dgvAppointments.CurrentRow?.DataBoundItem is AppointmentGridItemDto selected)
        {
            SelectedAppointment = selected;
            btnStartExamination.Enabled = selected.Status != AppointmentStatus.Cancelled;
        }
        else
        {
            SelectedAppointment = null;
            btnStartExamination.Enabled = false;
        }
    }

    private static string GetStatusRussianName(AppointmentStatus status) => status switch
    {
        AppointmentStatus.Scheduled => "Ожидает приёма",
        AppointmentStatus.Completed => "Завершён",
        AppointmentStatus.Cancelled => "Отменён",
        _ => status.ToString()
    };

    private void btnLogout_Click(object sender, EventArgs e)
    {
        IsLogoutRequested = true;
        Close();
    }
}

public class AppointmentGridItemDto
{
    public int Id { get; set; }
    public string TimeFormatted { get; set; } = null!;
    public string PatientCardNumber { get; set; } = null!;
    public string PatientFullName { get; set; } = null!;
    public AppointmentStatus Status { get; set; }
    public string StatusRussian { get; set; } = null!;
    public Appointment OriginalAppointment { get; set; } = null!;
}
