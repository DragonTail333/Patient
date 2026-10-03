using Patients.Data.Extensions;
using Patients.Data.Reports.Dto;
using Patients.Services.Abstractions;

namespace Patients.Data.Reports.Strategies;

public class DoctorWorkloadReportStrategy : IReportStrategy
{
    public string Title => "Нагрузка врачей";
    public string Description => "Описание: Подробная статистика приёмов, отмен и выписанных рецептов по специалистам за период.";
    public bool RequiresLimit => false;

    private IReportService _reportService { get; }

    public DoctorWorkloadReportStrategy(IReportService reportService)
    {
        _reportService = reportService;
    }

    public void ConfigureGridColumns(DataGridView dgv)
    {
        dgv.AddTextColumn(nameof(DoctorWorkloadReportDto.DoctorName), "ФИО Врача")
            .AddTextColumn(nameof(DoctorWorkloadReportDto.SpecialtyTitle), "Специализация")
            .AddTextColumn(nameof(DoctorWorkloadReportDto.TotalAppointments), "Всего приёмов")
            .AddTextColumn(nameof(DoctorWorkloadReportDto.CompletedAppointments), "Завершено")
            .AddTextColumn(nameof(DoctorWorkloadReportDto.CancelledAppointments), "Отменено")
            .AddTextColumn(nameof(DoctorWorkloadReportDto.PrescriptionsCount), "Рецептов");

    }

    public async Task<object> ExecuteAsync(ReportParameters parameters, CancellationToken cancellationToken = default)
    {
        return await _reportService.GetDoctorWorkloadReportAsync(
            parameters.StartDate,
            parameters.EndDate,
            cancellationToken);
    }
}