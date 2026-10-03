namespace Patients.Data.Reports.Dto;

public record ExaminationRegistryReportDto
{
    public long ExaminationId { get; init; }
    public DateTime ExaminationDate { get; init; }
    public string PatientCard { get; init; } = string.Empty;
    public string PatientName { get; init; } = string.Empty;
    public string DoctorName { get; init; } = string.Empty;
    public string Diagnosis { get; init; } = string.Empty;
    public bool HasPrescriptions { get; init; }
    public bool HasReferrals { get; init; }
}