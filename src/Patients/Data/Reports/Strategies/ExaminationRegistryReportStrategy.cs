using Patients.Data.Extensions;
using Patients.Data.Reports.Dto;
using Patients.Services.Abstractions;

namespace Patients.Data.Reports.Strategies;

public class ExaminationRegistryReportStrategy : IReportStrategy
{
    public string Title => "Реестр осмотров";
    public string Description => "Описание: Подробный реестр проведённых приёмов и осмотров с диагнозами, наличием рецептов и направлений.";
    public bool RequiresLimit => false;

    private IReportService _reportService { get; }

    public ExaminationRegistryReportStrategy(IReportService reportService)
    {
        _reportService = reportService;
    }

    public void ConfigureGridColumns(DataGridView dgv)
    {
        dgv.AddTextColumn(nameof(ExaminationRegistryReportDto.ExaminationId), "№ Осмотра")
            .AddTextColumn(nameof(ExaminationRegistryReportDto.ExaminationDate), "Дата и время")
            .AddTextColumn(nameof(ExaminationRegistryReportDto.PatientCard), "№ Карты")
            .AddTextColumn(nameof(ExaminationRegistryReportDto.PatientName), "Пациент")
            .AddTextColumn(nameof(ExaminationRegistryReportDto.DoctorName), "Врач")
            .AddTextColumn(nameof(ExaminationRegistryReportDto.Diagnosis), "Диагноз")
            .AddCheckBoxColumn(nameof(ExaminationRegistryReportDto.HasPrescriptions), "Рецепты")
            .AddCheckBoxColumn(nameof(ExaminationRegistryReportDto.HasReferrals), "Направления");
    }

    public async Task<object> ExecuteAsync(ReportParameters parameters, CancellationToken cancellationToken = default)
    {
        return await _reportService.GetExaminationRegistryReportAsync(
            parameters.StartDate,
            parameters.EndDate,
            cancellationToken);
    }
}