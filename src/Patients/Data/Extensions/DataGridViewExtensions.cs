namespace Patients.Data.Extensions;

public static class DataGridViewExtensions
{
    public static DataGridView AddTextColumn(this DataGridView dgv, string propertyName, string headerText)
    {
        dgv.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = propertyName,
            HeaderText = headerText,
            Name = propertyName
        });
        return dgv;
    }

    public static DataGridView AddPercentColumn(this DataGridView dgv, string propertyName, string headerText, string format = "N2")
    {
        var percentageColumn = new DataGridViewTextBoxColumn
        {
            DataPropertyName = propertyName,
            HeaderText = headerText,
            Name = propertyName
        };
        percentageColumn.DefaultCellStyle.Format = format;
        dgv.Columns.Add(percentageColumn);
        return dgv;
    }

    public static DataGridView AddCheckBoxColumn(this DataGridView dgv, string propertyName, string headerText, int width = 80)
    {
        dgv.Columns.Add(new DataGridViewCheckBoxColumn
        {
            DataPropertyName = propertyName,
            HeaderText = headerText,
            Name = propertyName,
            Width = width
        });
        return dgv;
    }
}