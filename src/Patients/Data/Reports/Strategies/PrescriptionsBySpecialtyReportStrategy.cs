using Patients.Data.Extensions;
using Patients.Data.Reports.Dto;
using Patients.Services.Abstractions;

namespace Patients.Data.Reports.Strategies;

public class PrescriptionsBySpecialtyReportStrategy : IReportStrategy
{
    public string Title => "Частота выписки препаратов";
    public string Description => "Описание: Описывает, как часто врачи по определённым специальностям выписывают " +
        "определённые препараты за отведённый временной промежуток";
    public bool RequiresLimit => false;

    private IReportService _reportService { get; }

    public PrescriptionsBySpecialtyReportStrategy(IReportService reportService)
    {
        _reportService = reportService;
    }

    public void ConfigureGridColumns(DataGridView dgv)
    {
        dgv.AddTextColumn(nameof(PrescriptionsBySpecialtyReportDto.SpecialtyTitle), "Специальность врачей")
            .AddTextColumn(nameof(PrescriptionsBySpecialtyReportDto.MedicationName), "Препарат")
            .AddTextColumn(nameof(PrescriptionsBySpecialtyReportDto.PrescriptionsCount), "Количество назначений");
    }

    public async Task<object> ExecuteAsync(ReportParameters parameters, CancellationToken cancellationToken = default)
    {
        return await _reportService.GetPrescriptionsBySpecialtyReportAsync(
            parameters.StartDate,
            parameters.EndDate,
            cancellationToken);
    }
}