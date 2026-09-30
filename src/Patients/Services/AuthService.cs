using Microsoft.EntityFrameworkCore;
using Patients.Domain;
using Patients.Services.Abstractions;

namespace Patients.Services;

public class AuthService : IAuthService
{
    private readonly IDbContextFactory<PatientsContext> _contextFactory;
    private readonly IPasswordHasher _passwordHasher;

    public AuthService(IDbContextFactory<PatientsContext> contextFactory, IPasswordHasher passwordHasher)
    {
        _contextFactory = contextFactory;
        _passwordHasher = passwordHasher;
    }

    public async Task<User?> AuthenticateAsync(string login, string password)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        var user = await context.Users
            .AsNoTracking()
            .Include(u => u.Doctor)
            .FirstOrDefaultAsync(u => u.Login == login);

        if (user == null)
        {
            return null;
        }

        var isPasswordValid = _passwordHasher.VerifyHash(password, user.PasswordHash);
        if (!isPasswordValid)
        {
            return null;
        }

        return user;
    }
}