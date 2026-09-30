namespace Patients.Domain;

public class Doctor
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int SpecialtyId { get; set; }
    public string RoomNumber { get; set; } = null!;
    public string Phone { get; set; } = null!;

    public User User { get; set; } = null!;
    public Specialty Specialty { get; set; } = null!;
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}