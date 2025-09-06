using J3d.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using OrmTest.Entity;
using J3d.Orm.Service;
using System.Data.Common;

namespace OrmTest.Repository
{
    public class PaginaRepository : Repository<Pagina>
    {
        private readonly DbManager<Pagina> _dataBase;

        public PaginaRepository(DbProviderFactory factory, string connectionString) : base(factory, connectionString)
        {
            _dataBase = new DbManager<Pagina>(Factory, ConnectionString, Convert);
        }

        public override Pagina Find(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Pagina> SelectAll()
        {
            return _dataBase.Select(new Pagina().ToSelectQuery());
        }

        public override int Add(Pagina entity)
        {
            #region Parameters

            var pName = Factory.CreateParameter();
            pName.DbType = DbType.String;
            pName.ParameterName = $"@{nameof(Pagina.Name)}";
            pName.Value = entity.Name;

            var pTitle = Factory.CreateParameter();
            pTitle.DbType = DbType.String;
            pTitle.ParameterName = $"@{nameof(Pagina.Title)}";
            pTitle.Value = entity.Title;

            var pText = Factory.CreateParameter();
            pText.DbType = DbType.String;
            pText.ParameterName = $"@{nameof(Pagina.Text)}";
            pText.Value = entity.Text;

            var pDate = Factory.CreateParameter();
            pDate.DbType = DbType.DateTime;
            pDate.ParameterName = $"@{nameof(Pagina.Date)}";
            pDate.Value = entity.Date;

            #endregion

            var affectedRows = _dataBase.Execute(entity.ToInsertQuery(), pName, pTitle, pText, pDate);

            if (affectedRows > 0)
            {
                entity.SetId(GetLastRecordedId());
            }

            return affectedRows;
        }

        public override int Update(Pagina entity)
        {
            #region Parameters

            var pId = Factory.CreateParameter();
            pId.DbType = DbType.Int32;
            pId.ParameterName = $"@{nameof(Pagina.Id)}";
            pId.Value = entity.Id;

            var pName = Factory.CreateParameter();
            pName.DbType = DbType.String;
            pName.ParameterName = $"@{nameof(Pagina.Name)}";
            pName.Value = entity.Name;

            var pTitle = Factory.CreateParameter();
            pTitle.DbType = DbType.String;
            pTitle.ParameterName = $"@{nameof(Pagina.Title)}";
            pTitle.Value = entity.Title;

            var pText = Factory.CreateParameter();
            pText.DbType = DbType.String;
            pText.ParameterName = $"@{nameof(Pagina.Text)}";
            pText.Value = entity.Text;

            var pDate = Factory.CreateParameter();
            pDate.DbType = DbType.DateTime;
            pDate.ParameterName = $"@{nameof(Pagina.Date)}";
            pDate.Value = entity.Date;

            #endregion

            return _dataBase.Execute(entity.ToUpdateQuery(), pId, pName, pTitle, pText, pDate);
        }

        public override int Delete(Pagina entity)
        {
            #region Parameters

            var pId = Factory.CreateParameter();
            pId.DbType = DbType.Int32;
            pId.ParameterName = $"@{nameof(Pagina.Id)}";
            pId.Value = entity.Id;

            #endregion

            return _dataBase.Execute(entity.ToDeleteQuery(), pId);
        }

        public override int GetLastRecordedId()
        {
            return (int?)_dataBase.ExecuteScalar(new Pagina().ToLastRecordedId(nameof(Pagina))) ?? 0;
        }

        public override Pagina Convert(IDataReader reader)
        {
            var pagina = new Pagina
            {
                Title = reader[nameof(Pagina.Title)].ToString(),
                Text = reader[nameof(Pagina.Text)].ToString(),
            };

            pagina.SetId(int.Parse(reader[nameof(Pagina.Id)].ToString()));
            pagina.SetName(nameof(Pagina));
            pagina.SetDate(DateTime.Parse(reader[nameof(Pagina.Date)].ToString()));

            return pagina;
        }

        public override DbParameter[] GetParameters(Pagina entity, bool includeId = true)
        {
            throw new NotImplementedException();
        }
    }
}
