using Patients.Domain;

namespace Patients.Services.Abstractions;

public interface ISpecialtyService
{
    public Task<List<Specialty>> GetAllSpecialtysAsync();
}
