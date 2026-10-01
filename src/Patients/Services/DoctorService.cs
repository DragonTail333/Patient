using Microsoft.EntityFrameworkCore;
using Patients.Domain;
using Patients.Services.Abstractions;

namespace Patients.Services;

public class DoctorService : IDoctorService
{
    private readonly IDbContextFactory<PatientsContext> _contextFactory;

    public DoctorService(IDbContextFactory<PatientsContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<List<Doctor>> GetAllDoctorsAsync()
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Doctors
            .AsNoTracking()
            .Include(d => d.User)
            .Include(d => d.Specialty)
            .OrderBy(d => d.User.LastName)
            .ToListAsync();
    }
}