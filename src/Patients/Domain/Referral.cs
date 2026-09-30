namespace Patients.Domain;

public class Referral
{
    public int Id { get; set; }
    public int ExaminationId { get; set; }
    public string ReferralType { get; set; } = null!;
    public string TargetDescription { get; set; } = null!;

    // Навигационное свойство
    public Examination Examination { get; set; } = null!;
}