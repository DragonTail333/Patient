using Microsoft.Extensions.DependencyInjection;
using Patients.Domain;
using Patients.Domain.Enums;
using Patients.Services.Abstractions;
using System.Data;

namespace Patients.Forms;

public partial class CreateAppointmentForm : Form
{
    private readonly IServiceScopeFactory? _scopeFactory;

    private int _patientId;
    private int _registrarUserId;
    private List<Doctor> _allDoctors = new();

    // Конфигурация рабочего дня
    private readonly TimeSpan _slotDuration = TimeSpan.FromMinutes(20);
    private readonly TimeOnly _workStart = new(8, 0);
    private readonly TimeOnly _workEnd = new(16, 0);

    public DoctorGridItemDto? SelectedDoctor { get; private set; }

    public CreateAppointmentForm()
    {
        InitializeComponent();
    }

    public CreateAppointmentForm(IServiceScopeFactory scopeFactory) : this()
    {
        _scopeFactory = scopeFactory;
    }

    public void Initialize(int patientId, string patientFullName, int registrarUserId)
    {
        _patientId = patientId;
        _registrarUserId = registrarUserId;

        Text = $"Запись на приём — {patientFullName}";
        lblPatientInfo.Text = $"Пациент: {patientFullName} (ID: {patientId})";

        // Ограничиваем календарь: нельзя выбрать прошедшую дату
        dtpAppointmentDate.MinDate = DateTime.Today;
        dtpAppointmentDate.Value = DateTime.Today;
    }

    private async Task LoadInitialDataAsync()
    {
        if (_scopeFactory == null) return;

        using var scope = _scopeFactory.CreateScope();
        var specialtyService = scope.ServiceProvider.GetRequiredService<ISpecialtyService>();
        var doctorService = scope.ServiceProvider.GetRequiredService<IDoctorService>();

        // Загрузка специальностей
        var specialties = await specialtyService.GetAllSpecialtysAsync();

        // ComboBox с пунктом "Все специальности"
        var specialtyItems = new List<SpecialtySelectItem>
        {
            new SpecialtySelectItem { Id = null, Title = "-- Все специальности --" }
        };
        specialtyItems.AddRange(specialties.Select(s => new SpecialtySelectItem { Id = s.Id, Title = s.Title }));

        cmbSpecialty.DataSource = specialtyItems;
        cmbSpecialty.DisplayMember = nameof(SpecialtySelectItem.Title);
        cmbSpecialty.ValueMember = nameof(SpecialtySelectItem.Id);

        // Загрузка всех врачей (один раз)
        _allDoctors = await doctorService.GetAllDoctorsAsync();

        // Отобразить врачей в таблице
        ApplyDoctorFilter();
    }

    private void cmbSpecialty_SelectedIndexChanged(object sender, EventArgs e)
    {
        ApplyDoctorFilter();
    }

    private void ApplyDoctorFilter()
    {
        var selectedSpecialtyId = cmbSpecialty.SelectedValue as int?;

        var filteredDoctors = _allDoctors.AsEnumerable();

        if (selectedSpecialtyId.HasValue)
        {
            filteredDoctors = filteredDoctors.Where(d => d.SpecialtyId == selectedSpecialtyId.Value);
        }

        var gridItems = filteredDoctors.Select(d => new DoctorGridItemDto
        {
            Id = d.Id,
            FullName = $"{d.User.LastName} {d.User.FirstName} {d.User.MiddleName}".TrimEnd(),
            SpecialtyTitle = d.Specialty.Title,
            RoomNumber = d.RoomNumber,
            Phone = d.Phone,
            OriginalDoctor = d
        }).ToList();

        dgvDoctors.AutoGenerateColumns = false;
        dgvDoctors.DataSource = gridItems;

        UpdateSelectedDoctor();
    }

    private async void dgvDoctors_SelectionChanged(object sender, EventArgs e)
    {
        UpdateSelectedDoctor();
        await RefreshAvailableTimeSlotsAsync();
    }

    private async void dtpAppointmentDate_ValueChanged(object sender, EventArgs e)
    {
        await RefreshAvailableTimeSlotsAsync();
    }

    private void UpdateSelectedDoctor()
    {
        if (dgvDoctors.CurrentRow?.DataBoundItem is DoctorGridItemDto selected)
        {
            SelectedDoctor = selected;
        }
        else
        {
            SelectedDoctor = null;
        }
    }

    private async void CreateAppointmentForm_Load(object sender, EventArgs e)
    {
        await LoadInitialDataAsync();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }

    /// <summary>
    /// Перерасчёт свободных слотов времени для выбранного врача и даты
    /// </summary>
    private async Task RefreshAvailableTimeSlotsAsync()
    {
        cmbTimeSlot.DataSource = null;
        lblError.Text = string.Empty;

        if (SelectedDoctor == null || _scopeFactory == null)
        {
            btnSave.Enabled = false;
            return;
        }

        var selectedDate = DateOnly.FromDateTime(dtpAppointmentDate.Value);

        using var scope = _scopeFactory.CreateScope();
        var appointmentService = scope.ServiceProvider.GetRequiredService<IAppointmentService>();

        // Получаем существующие приёмы из БД
        var existingAppointments = await appointmentService.GetAllAppointmentByDoctorIdAndDateAsync(selectedDate, SelectedDoctor.Id);

        // Генерируем свободные слоты
        var availableSlots = CalculateFreeSlots(selectedDate, existingAppointments);

        if (availableSlots.Count == 0)
        {
            lblError.Text = "На выбранную дату нет свободных слотов для записи.";
            btnSave.Enabled = false;
            return;
        }

        cmbTimeSlot.DataSource = availableSlots;
        btnSave.Enabled = true;
    }

    private List<string> CalculateFreeSlots(DateOnly date, List<Appointment> existingAppointments)
    {
        var freeSlots = new List<string>();

        // Множество уже занятых времён (формат HH:mm)
        var occupiedTimes = existingAppointments
            .Select(a => TimeOnly.FromDateTime(a.AppointmentDate).ToString("HH:mm"))
            .ToHashSet();

        var currentSlot = _workStart;
        var now = DateTime.Now;
        var isToday = date == DateOnly.FromDateTime(now);
        var currentTimeOnly = TimeOnly.FromDateTime(now);

        while (currentSlot < _workEnd)
        {
            var slotString = currentSlot.ToString("HH:mm");

            // Проверяем: слот не занят И (если день сегодняшний) время слота ещё не прошло
            bool isOccupied = occupiedTimes.Contains(slotString);
            bool isPastTimeToday = isToday && currentSlot <= currentTimeOnly;

            if (!isOccupied && !isPastTimeToday)
            {
                freeSlots.Add(slotString);
            }

            currentSlot = currentSlot.Add(_slotDuration);
        }

        return freeSlots;
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        if (SelectedDoctor == null || cmbTimeSlot.SelectedItem == null || _scopeFactory == null)
        {
            lblError.Text = "Выберите врача и время приёма.";
            return;
        }

        btnSave.Enabled = false;
        lblError.Text = string.Empty;

        try
        {
            var selectedDate = DateOnly.FromDateTime(dtpAppointmentDate.Value);
            var selectedTime = TimeOnly.Parse(cmbTimeSlot.SelectedItem.ToString()!);

            // Собираем локальную дату и время, затем приводим к Utc для timestamptz
            var localDateTime = selectedDate.ToDateTime(selectedTime);
            var appointmentDateTimeUtc = DateTime.SpecifyKind(localDateTime, DateTimeKind.Utc);

            var appointment = new Appointment
            {
                PatientId = _patientId,
                DoctorId = SelectedDoctor.Id,
                CreatedByUserId = _registrarUserId,
                AppointmentDate = appointmentDateTimeUtc,
                Status = AppointmentStatus.Scheduled
            };

            using var scope = _scopeFactory.CreateScope();
            var appointmentService = scope.ServiceProvider.GetRequiredService<IAppointmentService>();

            await appointmentService.AddAppointmentAsync(appointment);

            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            lblError.Text = $"Ошибка сохранения приёма: {ex.Message}";
            btnSave.Enabled = true;
        }
    }
}

public class SpecialtySelectItem
{
    public int? Id { get; set; }
    public string Title { get; set; } = null!;
}

public class DoctorGridItemDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string SpecialtyTitle { get; set; } = null!;
    public string RoomNumber { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public Doctor OriginalDoctor { get; set; } = null!;
}