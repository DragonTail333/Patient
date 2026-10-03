namespace Patients.Data.Reports.Dto;

public record DoctorWorkloadReportDto
{
    public int DoctorId { get; init; }
    public string DoctorName { get; init; } = string.Empty;
    public string SpecialtyTitle { get; init; } = string.Empty;
    public int TotalAppointments { get; init; }
    public int CompletedAppointments { get; init; }
    public int CancelledAppointments { get; init; }
    public int PrescriptionsCount { get; init; }
}