namespace Patients.Services.Abstractions;

public interface IPasswordHasher
{
    string HashValue(string password);
    bool VerifyHash(string password, string passwordHash);
}