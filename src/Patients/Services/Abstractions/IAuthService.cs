using Patients.Domain;

namespace Patients.Services.Abstractions;

public interface IAuthService
{
    public Task<User?> AuthenticateAsync(string login, string password);
}