using Patients.Domain;

namespace Patients.Services.Abstractions;

public interface IExaminationService
{
    public Task CreateExaminationAsync(Examination examination);
    public Task<Examination?> GetExaminationByAppointmentIdAsync(int appointmentId);
}