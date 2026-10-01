using Microsoft.EntityFrameworkCore;
using Patients.Domain;
using Patients.Services.Abstractions;

namespace Patients.Services;

public class SpecialtyService : ISpecialtyService
{
    private readonly IDbContextFactory<PatientsContext> _contextFactory;

    public SpecialtyService(IDbContextFactory<PatientsContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<List<Specialty>> GetAllSpecialtysAsync()
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Specialties
            .AsNoTracking()
            .OrderBy(s => s.Title)
            .ToListAsync();
    }
}