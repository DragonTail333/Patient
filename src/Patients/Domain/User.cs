using Patients.Domain.Enums;

namespace Patients.Domain;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public UserRole Role { get; set; }
    public string LastName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string? MiddleName { get; set; }

    public Doctor? Doctor { get; set; }
    public ICollection<Appointment> CreatedAppointments { get; set; } = new List<Appointment>();
}