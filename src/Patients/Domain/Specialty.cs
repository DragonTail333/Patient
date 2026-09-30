namespace Patients.Domain;

public class Specialty
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;

    // Навигационное свойство
    public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}