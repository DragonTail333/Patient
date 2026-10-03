using ClosedXML.Excel;
using Patients.Services.Abstractions;

namespace Patients.Services;

public class ClosedXmlReportExportService : IReportExportService
{
    public async Task ExportGridToExcelAsync(
        DataGridView dgv,
        string filePath,
        string sheetName = "Отчёт",
        CancellationToken cancellationToken = default)
    {
        // Выполняем тяжелую генерацию в фоновом потоке, чтобы не вешать UI
        await Task.Run(() =>
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(sheetName);

            // 1. Получаем только видимые колонки
            var visibleColumns = dgv.Columns
                .Cast<DataGridViewColumn>()
                .Where(c => c.Visible)
                .ToList();

            // 2. Формируем Заголовки (Шапка)
            for (int colIndex = 0; colIndex < visibleColumns.Count; colIndex++)
            {
                var column = visibleColumns[colIndex];
                var cell = worksheet.Cell(1, colIndex + 1);
                cell.Value = column.HeaderText;

                // Стиль шапки: Жирный шрифт, серый фон, тонкая рамка
                cell.Style.Font.Bold = true;
                cell.Style.Fill.BackgroundColor = XLColor.LightGray;
                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            }

            // 3. Заполняем Данные
            for (int rowIndex = 0; rowIndex < dgv.Rows.Count; rowIndex++)
            {
                var row = dgv.Rows[rowIndex];

                // Пропускаем служебную строку для добавления (если она есть)
                if (row.IsNewRow) continue;

                for (int colIndex = 0; colIndex < visibleColumns.Count; colIndex++)
                {
                    var column = visibleColumns[colIndex];
                    var cellValue = row.Cells[column.Index].Value;
                    var xlCell = worksheet.Cell(rowIndex + 2, colIndex + 1);

                    // Записываем с сохранением типа (числа как числа, даты как даты)
                    if (cellValue != null)
                    {
                        xlCell.Value = XLCellValue.FromObject(cellValue);
                    }
                }
            }

            // 4. Добавляем сетку и автоподбор ширины колонок
            var dataRange = worksheet.Range(1, 1, dgv.Rows.Count + 1, visibleColumns.Count);
            dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

            worksheet.Columns().AdjustToContents();

            // 5. Сохраняем файл
            workbook.SaveAs(filePath);
        }, cancellationToken);
    }
}