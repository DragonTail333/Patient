using Patients.Domain;

namespace Patients.Services.Abstractions;

public interface IDoctorService
{
    public Task<List<Doctor>> GetAllDoctorsAsync();
}
