using Dapper;
using Microsoft.EntityFrameworkCore;
using Patients.Services.Abstractions;
using Patients.Data.Reports.Dto;

namespace Patients.Services;

public class ReportService : IReportService
{
    private readonly IDbContextFactory<PatientsContext> _contextFactory;

    public ReportService(IDbContextFactory<PatientsContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IReadOnlyCollection<DoctorWorkloadReportDto>> GetDoctorWorkloadReportAsync(
        DateOnly startDate,
        DateOnly endDate,
        CancellationToken cancellationToken = default)
    {
        var fromTimestamp = startDate.ToDateTime(TimeOnly.MinValue);
        var toTimestamp = endDate.ToDateTime(new TimeOnly(23, 59, 59));

        await using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        var connection = context.Database.GetDbConnection();

        const string sql = """
            SELECT 
                doctor_id AS DoctorId,
                doctor_name AS DoctorName,
                specialty_title AS SpecialtyTitle,
                total_appointments AS TotalAppointments,
                completed_appointments AS CompletedAppointments,
                cancelled_appointments AS CancelledAppointments,
                prescriptions_count AS PrescriptionsCount
            FROM public.get_doctor_workload_report(@From, @To);
            """;

        var command = new CommandDefinition(
            commandText: sql,
            parameters: new { From = fromTimestamp, To = toTimestamp },
            cancellationToken: cancellationToken
        );

        var result = await connection.QueryAsync<DoctorWorkloadReportDto>(command);

        return result.ToList();
    }

    public async Task<IReadOnlyCollection<ExaminationRegistryReportDto>> GetExaminationRegistryReportAsync(
        DateOnly startDate,
        DateOnly endDate,
        CancellationToken cancellationToken = default)
    {
        var fromTimestamp = startDate.ToDateTime(TimeOnly.MinValue);
        var toTimestamp = endDate.ToDateTime(new TimeOnly(23, 59, 59));

        await using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        var connection = context.Database.GetDbConnection();

        const string sql = """
            SELECT 
                examination_id AS ExaminationId,
                examination_date AS ExaminationDate,
                patient_card AS PatientCard,
                patient_name AS PatientName,
                doctor_name AS DoctorName,
                diagnosis AS Diagnosis,
                has_prescriptions AS HasPrescriptions,
                has_referrals AS HasReferrals
            FROM public.get_examination_registry_report(@From, @To);
            """;

        var command = new CommandDefinition(sql, new { From = fromTimestamp, To = toTimestamp }, cancellationToken: cancellationToken);
        var result = await connection.QueryAsync<ExaminationRegistryReportDto>(command);
        return result.ToList();
    }

    public async Task<IReadOnlyList<PrescriptionsBySpecialtyReportDto>> GetPrescriptionsBySpecialtyReportAsync(
        DateOnly startDate,
        DateOnly endDate,
        CancellationToken cancellationToken = default)
    {
        var fromTimestamp = startDate.ToDateTime(TimeOnly.MinValue);
        var toTimestamp = endDate.ToDateTime(new TimeOnly(23, 59, 59));

        await using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        var connection = context.Database.GetDbConnection();

        const string sql = """
            SELECT 
                specialty_title AS SpecialtyTitle,
                medication_name AS MedicationName,
                prescriptions_count AS PrescriptionsCount
            FROM public.get_prescriptions_by_specialty_report(@StartDate, @EndDate);;
            """;

        var command = new CommandDefinition(sql, new { StartDate = startDate, EndDate = endDate }, cancellationToken: cancellationToken);
        var result = await connection.QueryAsync<PrescriptionsBySpecialtyReportDto>(command);

        return result.ToList();
    }

    public async Task<IReadOnlyCollection<TopDiagnosisReportDto>> GetTopDiagnosesReportAsync(
        DateOnly startDate,
        DateOnly endDate,
        int limit,
        CancellationToken cancellationToken = default)
    {
        var fromTimestamp = startDate.ToDateTime(TimeOnly.MinValue);
        var toTimestamp = endDate.ToDateTime(new TimeOnly(23, 59, 59));

        await using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        var connection = context.Database.GetDbConnection();

        const string sql = """
        SELECT 
            diagnosis AS Diagnosis,
            cases_count AS CasesCount,
            percentage AS Percentage
        FROM public.get_top_diagnoses_report(@From, @To, @Limit);
        """;

        var command = new CommandDefinition(
            sql,
            new { From = fromTimestamp, To = toTimestamp, Limit = limit },
            cancellationToken: cancellationToken);

        var result = await connection.QueryAsync<TopDiagnosisReportDto>(command);
        return result.ToList();
    }

}