using Patients.Domain;

namespace Patients.Services.Abstractions;

public interface IDoctorService
{
    public Task<Doctor?> GetDoctorByUserIdAsync(int id);

    public Task<List<Doctor>> GetAllDoctorsAsync();
}
