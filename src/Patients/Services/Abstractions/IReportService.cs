using Patients.Domain;
using Patients.Data.Reports.Dto;


namespace Patients.Services.Abstractions;

public interface IReportService
{
    public Task<IReadOnlyCollection<DoctorWorkloadReportDto>> GetDoctorWorkloadReportAsync(
        DateOnly startDate,
        DateOnly endDate,
        CancellationToken cancellationToken = default);

    public Task<IReadOnlyCollection<ExaminationRegistryReportDto>> GetExaminationRegistryReportAsync(
        DateOnly startDate,
        DateOnly endDate,
        CancellationToken cancellationToken = default);

    public Task<IReadOnlyList<PrescriptionsBySpecialtyReportDto>> GetPrescriptionsBySpecialtyReportAsync(
        DateOnly startDate,
        DateOnly endDate,
        CancellationToken cancellationToken = default);

    public Task<IReadOnlyCollection<TopDiagnosisReportDto>> GetTopDiagnosesReportAsync(
        DateOnly startDate,
        DateOnly endDate,
        int limit,
        CancellationToken cancellationToken = default);
}