using Patients.Domain;

namespace Patients.Services.Abstractions;

public interface IPatientService
{
    public Task<Patient?> FindByCardNumberAsync(string cardNumber);
    public Task AddPatientAsync(Patient patient);

    public Task<List<Patient>> GetAllPatientsAsync(string? cardNumberFilter = null);
}