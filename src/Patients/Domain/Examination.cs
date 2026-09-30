namespace Patients.Domain;

public class Examination
{
    public int Id { get; set; }
    public int AppointmentId { get; set; }
    public DateTime ExaminationDate { get; set; }
    public string Complaints { get; set; } = null!;
    public string Anamnesis { get; set; } = null!;
    public string Diagnosis { get; set; } = null!;
    public string Recommendations { get; set; } = null!;

    public Appointment Appointment { get; set; } = null!;
    public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    public ICollection<Referral> Referrals { get; set; } = new List<Referral>();
}