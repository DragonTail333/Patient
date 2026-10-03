namespace Patients.Data.Reports.Dto;

public record TopDiagnosisReportDto
{
    public string Diagnosis { get; init; } = string.Empty;
    public long CasesCount { get; init; }
    public decimal Percentage { get; init; }
}