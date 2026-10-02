using Microsoft.EntityFrameworkCore;
using Patients.Domain;
using Patients.Domain.Enums;
using Patients.Services.Abstractions;

namespace Patients.Services;

public class ExaminationService : IExaminationService
{
    private readonly IDbContextFactory<PatientsContext> _contextFactory;

    public ExaminationService(IDbContextFactory<PatientsContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task CreateExaminationAsync(Examination examination)
    {
        // валидация
        if (examination == null)
            throw new ArgumentNullException(nameof(examination));

        if (string.IsNullOrWhiteSpace(examination.Complaints) ||
            string.IsNullOrWhiteSpace(examination.Anamnesis) ||
            string.IsNullOrWhiteSpace(examination.Diagnosis) ||
            string.IsNullOrWhiteSpace(examination.Recommendations))
        {
            throw new InvalidOperationException("Все основные поля протокола осмотра должны быть заполнены.");
        }

        using var context = await _contextFactory.CreateDbContextAsync();

        // Получить родительский приём и проверяем его текущий статус
        var appointment = await context.Appointments.FindAsync(examination.AppointmentId);

        if (appointment == null)
            throw new InvalidOperationException($"Приём с ID {examination.AppointmentId} не найден в базе данных.");
        else if (appointment.Status != AppointmentStatus.Scheduled)
            throw new InvalidOperationException("Нельзя завершить приём, который не находится в статусе 'Ожидает приёма'.");


        // Добавить осмотр (он уже с вложенными рецептами и направлениями)
        await context.Examinations.AddAsync(examination);

        // Обновить статус приёма, к которому относится новый осмотор
        appointment.Status = AppointmentStatus.Completed;

        await context.SaveChangesAsync();
    }
}