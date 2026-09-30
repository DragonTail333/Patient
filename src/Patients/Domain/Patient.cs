namespace Patients.Domain;

public class Patient
{
    public int Id { get; set; }
    public string CardNumber { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Gender { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string PolicyNumber { get; set; } = null!;

    // Навигационное свойство
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}