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

    public async Task<List<Patient>> GetAllPatientsAsync(string? cardNumberFilter = null)
    {
        using var context = _contextFactory.CreateDbContext();
        var query = context.Patients.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(cardNumberFilter))
        {
            query = query.Where(p => p.CardNumber.Contains(cardNumberFilter.Trim()));
        }

        return await query
            .OrderBy(p => p.LastName)
            .ThenBy(p => p.FirstName)
            .ToListAsync();
    }
}