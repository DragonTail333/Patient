using Microsoft.EntityFrameworkCore;
using Patients.Domain;
using Patients.Services.Abstractions;

namespace Patients.Services;

public class PatientService : IPatientService
{
    private readonly IDbContextFactory<PatientsContext> _contextFactory;

    public PatientService(IDbContextFactory<PatientsContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<Patient?> FindByCardNumberAsync(string cardNumber)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Patients
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.CardNumber == cardNumber);
    }

    public async Task AddPatientAsync(Patient patient)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Patients.Add(patient);
        await context.SaveChangesAsync();
    }
}