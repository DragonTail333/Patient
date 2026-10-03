using Microsoft.Extensions.DependencyInjection;
using Patients.Data.Reports.Strategies;
using Patients.Domain;
using Patients.Services;
using Patients.Services.Abstractions;

namespace Patients.Forms;

public partial class ChiefDoctorMainForm : Form
{
    private readonly List<IReportStrategy> _reports;
    private readonly IReportExportService _exportService;
    private User? _currentUser;

    public bool IsLogoutRequested { get; private set; }

    // DI автоматически передает все зарегистрированные отчеты в массив/список
    public ChiefDoctorMainForm(IEnumerable<IReportStrategy> reports,
        IReportExportService exportService)
    {
        _reports = reports?.ToList() ?? throw new ArgumentNullException(nameof(reports));
        _exportService = exportService ?? throw new ArgumentNullException(nameof(exportService));

        InitializeComponent();
    }

    public void Initialize(User user)
    {
        _currentUser = user;
        Text = $"АРМ Главврача — {_currentUser.LastName} {_currentUser.FirstName}";

        SetupReportNavigation();
    }

    private void SetupReportNavigation()
    {
        cmbReportType.SelectedIndexChanged -= cmbReportType_SelectedIndexChanged;

        cmbReportType.DataSource = _reports;
        cmbReportType.DisplayMember = nameof(IReportStrategy.Title);

        cmbReportType.SelectedIndexChanged += cmbReportType_SelectedIndexChanged;

        if (cmbReportType.SelectedItem is IReportStrategy initialReport)
        {
            ApplyReportConfiguration(initialReport);
        }
    }

    private void cmbReportType_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (cmbReportType.SelectedItem is IReportStrategy selectedReport)
        {
            ApplyReportConfiguration(selectedReport);
        }
    }

    private void ApplyReportConfiguration(IReportStrategy report)
    {
        txtReportDescription.Text = report.Description;
        numLimit.Enabled = report.RequiresLimit;
        lblLimit.Enabled = report.RequiresLimit;

        dgvReport.DataSource = null;
        dgvReport.Columns.Clear();
        dgvReport.AutoGenerateColumns = false;

        // Конфигурирование колонок перенесено в сам отчет
        report.ConfigureGridColumns(dgvReport);
    }

    private async void btnGenerate_Click(object sender, EventArgs e)
    {
        if (cmbReportType.SelectedItem is not IReportStrategy selectedReport) return;

        var startDate = DateOnly.FromDateTime(dtpStartDate.Value.Date);
        var endDate = DateOnly.FromDateTime(dtpEndDate.Value.Date);

        if (startDate > endDate)
        {
            MessageBox.Show("Дата начала периода не может быть позже даты окончания.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int limit = (int)numLimit.Value;
        if (selectedReport.RequiresLimit && limit <= 0)
        {
            MessageBox.Show("Лимит записей должен быть больше 0.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        SetLoadingState(isLoading: true);

        try
        {
            var parameters = new ReportParameters(startDate, endDate, limit);

            // Полиморфный вызов: форма не знает, какой именно это отчет!
            var reportData = await selectedReport.ExecuteAsync(parameters);
            dgvReport.DataSource = reportData;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при формировании отчёта: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            SetLoadingState(isLoading: false);
        }
    }

    private void SetLoadingState(bool isLoading)
    {
        pnlFilter.Enabled = !isLoading;
        Cursor = isLoading ? Cursors.WaitCursor : Cursors.Default;
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        IsLogoutRequested = true;
        Close();
    }

    private async void btnPrint_Click(object sender, EventArgs e)
    {
        // Проверяем, есть ли данные в таблице
        if (dgvReport.Rows.Count == 0 || (dgvReport.Rows.Count == 1 && dgvReport.Rows[0].IsNewRow))
        {
            MessageBox.Show("Нет данных для экспорта.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (cmbReportType.SelectedItem is not IReportStrategy selectedReport) return;

        // Настраиваем диалог сохранения файла
        using var saveFileDialog = new SaveFileDialog
        {
            Filter = "Книга Excel (*.xlsx)|*.xlsx",
            Title = "Сохранение отчёта в Excel",
            FileName = $"{selectedReport.Title}_{DateTime.Now:yyyy-MM-dd_HH-mm}.xlsx"
        };

        if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

        SetLoadingState(isLoading: true);

        try
        {
            await _exportService.ExportGridToExcelAsync(
                dgvReport,
                saveFileDialog.FileName,
                sheetName: selectedReport.Title);

            MessageBox.Show(
                "Отчёт успешно сохранён!",
                "Успех",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Не удалось сохранить файл: {ex.Message}",
                "Ошибка экспорта",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            SetLoadingState(isLoading: false);
        }
    }
}

public enum ReportType
{
    TopDiagnoses,      // Требует лимит
    DoctorWorkload,    // Без лимита
    PrescriptionsBySpecialty,  // Без лимита
    ExaminationRegistry      // Без лимита
}

// Дескриптор для связи элементов в ComboBox
public class ReportItem
{
    public ReportType Type { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool RequiresLimit { get; set; }

    public override string ToString() => Title;
}