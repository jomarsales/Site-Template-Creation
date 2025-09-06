using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using J3d.Domain.Entity;
using J3d.Domain.Repository;
using J3d.Orm.Service;

namespace J3d.Orm.Repository
{
    public class ImageRepository : Repository<Image>
    {
        #region Properties

        private readonly DbManager<Image> _dataBase;

        #endregion

        #region Constructor

        public ImageRepository(DbProviderFactory factory, string connectionString) : base(factory, connectionString)
        {
            _dataBase = new DbManager<Image>(Factory, ConnectionString, Convert);
        }

        #endregion

        #region Methods

        public override Image Find(int id)
        {
            var query = new StringBuilder(new Image("#", "#").ToSelectQuery()).AppendLine($" WHERE {nameof(Image.Id)} = @{nameof(Image.Id)}");

            return _dataBase.Select(query.ToString(), GetDbParameter(id, $"{nameof(Image.Id)}", id.GetType())).FirstOrDefault(i => i.Id == id);
        }

        public override List<Image> SelectAll()
        {
            return _dataBase.Select(new Image("#", "#").ToSelectQuery());
        }

        public override int Add(Image entity)
        {
            var affectedRows = _dataBase.Execute(entity.ToInsertQuery(), GetParameters(entity, false));

            entity.SetId(GetLastRecordedId());

            return affectedRows;
        }

        public override int Update(Image entity)
        {
            return _dataBase.Execute(entity.ToUpdateQuery(), GetParameters(entity));
        }

        public override int Delete(Image entity)
        {
            return _dataBase.Execute(entity.ToDeleteQuery(), GetDbParameter(entity.Id, $"{nameof(entity.Id)}", entity.Id.GetType()));
        }

        public override int GetLastRecordedId()
        {
            return (int?)_dataBase.ExecuteScalar(new Image("#", "#").ToLastRecordedId(nameof(Image))) ?? 0;
        }

        public override Image Convert(IDataReader reader)
        {
            var image = new Image(reader[nameof(Image.Title)].ToString(), reader[nameof(Image.Path)].ToString());

            image.SetId(int.Parse(reader[nameof(Image.Id)].ToString()));
            image.SetAlt(reader[nameof(Image.Alt)].ToString());
            image.SetDate(DateTime.Parse(reader[nameof(Image.Date)].ToString()));

            return image;
        }

        public override DbParameter[] GetParameters(Image entity, bool includeId = true)
        {
            var list = new List<DbParameter>
            {
                GetDbParameter(entity.Title, $"{nameof(Image.Title)}", entity.Title.GetType()),
                GetDbParameter(entity.Alt, $"{nameof(Image.Alt)}", !string.IsNullOrEmpty(entity.Alt) ? entity.Alt.GetType() : typeof(string)),
                GetDbParameter(entity.Path, $"{nameof(Image.Path)}", entity.Path.GetType()),
                GetDbParameter(entity.Date, $"{nameof(Image.Date)}", entity.Date.GetType())
            };

            if(includeId)
                list.Add(GetDbParameter(entity.Id, $"{nameof(entity.Id)}", entity.Id.GetType()));

            return list.ToArray();
        }

        #endregion
    }
}
