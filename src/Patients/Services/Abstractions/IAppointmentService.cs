using Patients.Domain;

namespace Patients.Services.Abstractions;

public interface IAppointmentService
{
    public Task AddAppointmentAsync(Appointment appointment);

    public Task<List<Appointment>> GetAllAppointmentByDoctorIdAndDateAsync(DateOnly date, int doctorId);
}
