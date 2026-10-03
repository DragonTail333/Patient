namespace Patients.Services.Abstractions;

public interface IReportExportService
{
    public Task ExportGridToExcelAsync(DataGridView dgv, string filePath, string sheetName = "Отчёт", CancellationToken cancellationToken = default);
}