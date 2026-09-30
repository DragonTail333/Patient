namespace Patients.Domain;

public class Prescription
{
    public int Id { get; set; }
    public int ExaminationId { get; set; }
    public string MedicationName { get; set; } = null!;
    public string Dosage { get; set; } = null!;
    public string Instructions { get; set; } = null!;

    public Examination Examination { get; set; } = null!;
}