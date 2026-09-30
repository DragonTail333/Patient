using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;

namespace Patients.Data.Configurations.Common;

public static class EntityTypeBuilderExtensions
{
    public static CheckConstraintBuilder HasEnumCheckConstraint<TEnum>(
        this TableBuilder tableBuilder,
        string constraintName,
        string columnName) where TEnum : struct, Enum
    {
        var sb = new StringBuilder($"\"{columnName}\" IN (");

        foreach (var value in Enum.GetValues<TEnum>())
        {
            sb.Append($"'{value}', ");
        }

        sb.Remove(sb.Length - 2, 2);
        sb.Append(")");

        return tableBuilder.HasCheckConstraint(constraintName, sb.ToString());
    }
}