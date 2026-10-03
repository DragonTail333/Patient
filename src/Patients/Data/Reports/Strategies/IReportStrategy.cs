namespace Patients.Data.Reports.Strategies;

public record ReportParameters(DateOnly StartDate, DateOnly EndDate, int Limit);

public interface IReportStrategy
{
    string Title { get; }
    string Description { get; }
    bool RequiresLimit { get; }

    // Конфигурирует колонки DataGridView под свой DTO
    void ConfigureGridColumns(DataGridView dgv);

    // Выполняет запрос к БД
    Task<object> ExecuteAsync(ReportParameters parameters, CancellationToken cancellationToken = default);
}