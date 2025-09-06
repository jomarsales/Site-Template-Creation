using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace J3d.Domain.Repository
{
    public abstract class Repository<TEntity> where TEntity : Entity.Entity
    {
        #region Properties

        /// <summary>
        /// Indica qual provedor a classe deve utilizar. 
        /// Será informado por meio de parâmetro no construtor.
        /// Poderá vir de um arquivo de configuração.
        /// </summary>
        protected DbProviderFactory Factory;

        /// <summary>
        /// String de conexão com o banco de dados.
        /// Será informada por meeio de parâmetro no construtor.
        /// Poderá vir de um arquivo de configuração.
        /// </summary>
        protected string ConnectionString;

        #endregion

        #region Constructor

        protected Repository(DbProviderFactory factory, string connectionString)
        {
            Factory = factory;
            ConnectionString = connectionString;
        }

        #endregion

        #region Abstract Methods

        public abstract TEntity Find(int id);

        public abstract List<TEntity> SelectAll();

        public abstract int Add(TEntity entity);

        public abstract int Update(TEntity entity);

        public abstract int Delete(TEntity entity);

        public abstract int GetLastRecordedId();

        public abstract TEntity Convert(IDataReader reader);

        public abstract DbParameter[] GetParameters(TEntity entity, bool includeId = true);

        #endregion

        #region Virtual Methods

        protected virtual DbParameter GetDbParameter(object property, string name, Type type)
        {
            var parameter = Factory.CreateParameter();

            if (parameter == null) return null;

            if (property == null)
            {
                parameter.DbType = GetSqlType(type);
                parameter.ParameterName = $"@{name}";
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.DbType = GetSqlType(type);
                parameter.ParameterName = $"@{name}";
                parameter.Value = property;
            }

            return parameter;
        }

        private static DbType GetSqlType(Type type)
        {
            DbType dbType;

            switch (type.ToString())
            {
                case "System.Boolean":
                    dbType = DbType.Boolean;
                    break;
                case "System.Char":
                    dbType = DbType.StringFixedLength;
                    break;
                case "System.DateTime":
                    dbType = DbType.DateTime;
                    break;
                case "System.Decimal":
                    dbType = DbType.Decimal;
                    break;
                case "System.Double":
                    dbType = DbType.Double;
                    break;
                case "System.Single":
                    dbType = DbType.Single;
                    break;
                case "System.Guid":
                    dbType = DbType.Guid;
                    break;
                case "System.Byte":
                    dbType = DbType.Byte;
                    break;
                case "System.SByte":
                    dbType = DbType.SByte;
                    break;
                case "System.Int16":
                    dbType = DbType.Int16;
                    break;
                case "System.Int32":
                    dbType = DbType.Int32;
                    break;
                case "System.Int64":
                    dbType = DbType.Int64;
                    break;
                case "System.String":
                    dbType = DbType.String;
                    break;
                case "System.UInt16":
                    dbType = DbType.UInt16;
                    break;
                case "System.UInt32":
                    dbType = DbType.UInt32;
                    break;
                case "System.UInt64":
                    dbType = DbType.UInt64;
                    break;
                default:
                    dbType = DbType.String;
                    break;
            }

            return dbType;
        }

        #endregion
    }
}
