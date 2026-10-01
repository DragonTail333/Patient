using Microsoft.EntityFrameworkCore;
using Patients.Domain;
using Patients.Services.Abstractions;

namespace Patients.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IDbContextFactory<PatientsContext> _contextFactory;

    public AppointmentService(IDbContextFactory<PatientsContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<List<Appointment>> GetAllAppointmentByDoctorIdAndDateAsync(DateOnly date, int doctorId)
    {
        using var context = _contextFactory.CreateDbContext();

        var startOfDay = DateTime.SpecifyKind(date.ToDateTime(TimeOnly.MinValue), DateTimeKind.Utc);
        var endOfDay = DateTime.SpecifyKind(date.ToDateTime(TimeOnly.MaxValue), DateTimeKind.Utc);

        return await context.Appointments
            .AsNoTracking()
            .Where(a => a.DoctorId == doctorId && a.AppointmentDate >= startOfDay && a.AppointmentDate <= endOfDay)
            .ToListAsync();
    }

    public async Task AddAppointmentAsync(Appointment appointment)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Appointments.Add(appointment);
        await context.SaveChangesAsync();
    }
}