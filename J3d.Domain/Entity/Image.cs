using System.Text;
using J3d.Domain.Service;

namespace J3d.Domain.Entity
{
    public class Image : Entity
    {
        #region Constants

        public const int TitleMaxLength = 200;

        public const int AltMaxLength = 200;

        public const int PathMaxLength = 600;

        #endregion

        #region Properties

        public string Title { get; private set; }

        public string Alt { get; private set; }

        public string Path { get; private set; }

        #endregion

        #region Constructor

        public Image(string title, string path)
        {
            SetTitle(title);
            SetPath(path);
        }

        #endregion

        #region Methods

        private void SetTitle(string title)
        {
            AssertionConcern.AssertArgumentNotEmpty(title, $"Propriedade '{nameof(Image).ToUpper()}.{nameof(Title).ToUpper()}' não pode ser vazia!");
            AssertionConcern.AssertArgumentLength(title, TitleMaxLength, $"Propriedade '{nameof(Image).ToUpper()}.{nameof(Title).ToUpper()}' deve conter até {TitleMaxLength} caracteres!");

            Title = title;
        }

        private void SetPath(string path)
        {
            AssertionConcern.AssertArgumentNotEmpty(path, $"Propriedade '{nameof(Image).ToUpper()}.{nameof(Path).ToUpper()}' não pode ser vazia!");
            AssertionConcern.AssertArgumentLength(path, PathMaxLength, $"Propriedade '{nameof(Image).ToUpper()}.{nameof(Path).ToUpper()}' deve conter até {PathMaxLength} caracteres!");

            Path = path;
        }

        public void SetAlt(string alt)
        {
            if (string.IsNullOrEmpty(alt))
            {
                Alt = null;
                return;
            }

            AssertionConcern.AssertArgumentLength(alt, AltMaxLength, $"Propriedade '{nameof(Image).ToUpper()}.{nameof(Alt).ToUpper()}' deve conter até {AltMaxLength} caracteres!");

            Alt = alt;
        }

        public void Change(string title, string path)
        {
            SetTitle(title);
            SetPath(path);
        }

        #region Queries Methods

        public override string ToSelectQuery()
        {
            var query = new StringBuilder();

            query.AppendLine("SELECT ");
            query.AppendLine($"{nameof(Id)}, ");
            query.AppendLine($"{nameof(Title)}, ");
            query.AppendLine($"{nameof(Alt)}, ");
            query.AppendLine($"{nameof(Path)}, ");
            query.AppendLine($"{nameof(Date)} ");
            query.AppendLine($"FROM {nameof(Image)}");

            return query.ToString();
        }

        public override string ToInsertQuery()
        {
            var query = new StringBuilder();

            query.AppendLine($"INSERT INTO {nameof(Image)} (");
            query.AppendLine($"{nameof(Title)}, ");
            query.AppendLine($"{nameof(Alt)}, ");
            query.AppendLine($"{nameof(Path)}, ");
            query.AppendLine($"{nameof(Date)} ");
            query.AppendLine(" ) VALUES ( ");
            query.AppendLine($"@{nameof(Title)}, ");
            query.AppendLine($"@{nameof(Alt)}, ");
            query.AppendLine($"@{nameof(Path)}, ");
            query.AppendLine($"@{nameof(Date)}) ");

            return query.ToString();
        }

        public override string ToUpdateQuery()
        {
            var query = new StringBuilder();

            query.AppendLine($"UPDATE {nameof(Image)} SET ");
            query.AppendLine($"{nameof(Title)} = @{nameof(Title)}, ");
            query.AppendLine($"{nameof(Alt)} = @{nameof(Alt)}, ");
            query.AppendLine($"{nameof(Path)} = @{nameof(Path)}, ");
            query.AppendLine($"{nameof(Date)} = @{nameof(Date)}");
            query.AppendLine(" WHERE ");
            query.AppendLine($" {nameof(Id)} = @{nameof(Id)}");

            return query.ToString();
        }

        public override string ToDeleteQuery()
        {
            var query = new StringBuilder();

            query.AppendLine($"DELETE FROM {nameof(Image)} ");
            query.AppendLine("WHERE ");
            query.AppendLine($" {nameof(Id)} = @{nameof(Id)}");

            return query.ToString();
        }

        #endregion

        #endregion
    }
}
