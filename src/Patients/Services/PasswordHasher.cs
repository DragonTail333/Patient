using Patients.Services.Abstractions;
using System.Security.Cryptography;
using System.Text;

namespace Patients.Services;

public class PasswordHasher : IPasswordHasher
{
    // SHA256
    public string HashValue(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToHexString(bytes);
    }

    public bool VerifyHash(string password, string passwordHash)
    {
        var hashOfInput = HashValue(password);
        return string.Equals(hashOfInput, passwordHash, StringComparison.OrdinalIgnoreCase);
    }
}