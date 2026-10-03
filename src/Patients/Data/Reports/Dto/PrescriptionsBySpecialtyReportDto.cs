namespace Patients.Data.Reports.Dto;

public record PrescriptionsBySpecialtyReportDto
{
    public string SpecialtyTitle { get; init; } = string.Empty;
    public string MedicationName { get; init; } = string.Empty;
    public long PrescriptionsCount { get; init; }
}
