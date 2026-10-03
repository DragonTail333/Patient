using Patients.Data.Extensions;
using Patients.Services.Abstractions;
using Patients.Data.Reports.Dto;

namespace Patients.Data.Reports.Strategies;

public class TopDiagnosesReportStrategy : IReportStrategy
{
    public string Title => "Топ диагнозов";
    public string Description => "Описание: Отображает наиболее часто ставимые диагнозы за указанный период с ограничением количества записей.";
    public bool RequiresLimit => true;

    private IReportService _reportService { get; }

    public TopDiagnosesReportStrategy(IReportService reportService)
    {
        _reportService = reportService;
    }

    public void ConfigureGridColumns(DataGridView dgv)
    {
        dgv.AddTextColumn(nameof(TopDiagnosisReportDto.Diagnosis), "Диагноз")
           .AddTextColumn(nameof(TopDiagnosisReportDto.CasesCount), "Кол-во случаев")
           .AddPercentColumn(nameof(TopDiagnosisReportDto.Percentage), "Доля (%)");
    }

    public async Task<object> ExecuteAsync(ReportParameters parameters, CancellationToken cancellationToken = default)
    {
        return await _reportService.GetTopDiagnosesReportAsync(parameters.StartDate, parameters.EndDate, parameters.Limit);
    }
}