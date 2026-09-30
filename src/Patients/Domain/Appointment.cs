using Patients.Domain.Enums;

namespace Patients.Domain;

public class Appointment
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public int CreatedByUserId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;

    public Patient Patient { get; set; } = null!;
    public Doctor Doctor { get; set; } = null!;
    public User CreatedByUser { get; set; } = null!;
    public Examination? Examination { get; set; }
}