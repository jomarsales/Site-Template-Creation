using J3d.Domain.Entity;
using System;
using System.Text;

namespace OrmTest.Entity
{
    public class Pagina : Page
    {
        public string Title { get; set; }
        public string Text { get; set; }

        public override string ToSelectQuery()
        {
            var query = new StringBuilder();

            query.AppendLine("SELECT ");
            query.AppendLine($"{nameof(Id)}, ");
            query.AppendLine($"{nameof(Name)}, ");
            query.AppendLine($"{nameof(Title)}, ");
            query.AppendLine($"{nameof(Text)}, ");
            query.AppendLine($"{nameof(Date)} ");
            query.AppendLine($"FROM {nameof(Pagina)}");

            return query.ToString();
        }

        public override string ToInsertQuery()
        {
            var query = new StringBuilder();

            query.AppendLine($"INSERT INTO {nameof(Pagina)} (");
            query.AppendLine($"{nameof(Name)}, ");
            query.AppendLine($"{nameof(Title)}, ");
            query.AppendLine($"{nameof(Text)}, ");
            query.AppendLine($"{nameof(Date)} ");
            query.AppendLine($") VALUES ( ");
            query.AppendLine($"@{nameof(Name)}, ");
            query.AppendLine($"@{nameof(Title)}, ");
            query.AppendLine($"@{nameof(Text)}, ");
            query.AppendLine($"@{nameof(Date)}) ");

            return query.ToString();
        }

        public override string ToUpdateQuery()
        {
            var query = new StringBuilder();

            query.AppendLine($"UPDATE {nameof(Pagina)} SET ");
            query.AppendLine($"{nameof(Name)} = @{nameof(Name)}, ");
            query.AppendLine($"{nameof(Title)} = @{nameof(Title)}, ");
            query.AppendLine($"{nameof(Text)} = @{nameof(Text)}, ");
            query.AppendLine($"{nameof(Date)} = @{nameof(Date)}");
            query.AppendLine(" WHERE ");
            query.AppendLine($" {nameof(Id)} = @{nameof(Id)}");

            return query.ToString();
        }

        public override string ToDeleteQuery()
        {
            var query = new StringBuilder();

            query.AppendLine($"DELETE FROM {nameof(Pagina)} ");
            query.AppendLine("WHERE ");
            query.AppendLine($" {nameof(Id)} = @{nameof(Id)}");

            return query.ToString();
        }
    }
}
