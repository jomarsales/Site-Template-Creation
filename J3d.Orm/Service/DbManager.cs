using J3d.Domain.Entity;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using static J3d.Domain.Delegate.ConvertIDataReaderToIEntity;

namespace J3d.Orm.Service
{
    public class DbManager<TEntity> where TEntity : Entity
    {
        #region Properties

        /// <summary>
        /// Indica qual provedor a classe deve utilizar. 
        /// Será informado por meio de parâmetro no construtor.
        /// Poderá vir de um arquivo de configuração.
        /// </summary>
        private readonly DbProviderFactory _factory;

        /// <summary>
        /// String de conexão com o banco de dados.
        /// Será informada por meeio de parâmetro no construtor.
        /// Poderá vir de um arquivo de configuração.
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Delegate que representa um ponto de entrada para um método que converte o dara reader em um objeto
        /// Será informada por meeio de parâmetro no construtor. 
        /// </summary>
        private readonly ConvertIDataReaderToIEntityDelegate _convertIDataReaderToIEntityDelegate;

        #endregion

        #region Constructor

        public DbManager(DbProviderFactory factory, string connectionString, ConvertIDataReaderToIEntityDelegate convertIDataReaderToIEntityDelegate)
        {
            _factory = factory;
            _connectionString = connectionString;
            _convertIDataReaderToIEntityDelegate = convertIDataReaderToIEntityDelegate;
        }
        
        #endregion

        #region Methods

        /// <summary>
        /// Comando de seleção.
        /// </summary>
        /// <param name="commandText">Instrução SQL devidamente parametrizada</param>
        /// <param name="parameters">Parâmetros para o Command</param>
        /// <returns>Lista de objetos corelacionados</returns>
        public List<TEntity> Select(string commandText, params DbParameter[] parameters)
        {
            var list = new List<TEntity>();

            using (IDbConnection connection = _factory.CreateConnection())
            {
                if (connection == null) return list;

                connection.ConnectionString = _connectionString;

                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;

                    foreach (var parameter in parameters)
                        command.Parameters.Add(parameter);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                        while (reader.Read())
                            list.Add((TEntity) _convertIDataReaderToIEntityDelegate(reader));
                }
            }

            return list;
        }

        /// <summary>
        /// Instruções de inserção, atualização e deleção
        /// </summary>
        /// <param name="commandText">Instrução SQL devidamente parametrizada</param>
        /// <param name="parameters">Parâmetros para o Command</param>
        /// <returns>Linhas afetadas</returns>
        public int Execute(string commandText, params DbParameter[] parameters)
        {
            int rowsAffecteds;

            using (IDbConnection connection = _factory.CreateConnection())
            {
                if (connection == null) return 0;

                connection.ConnectionString = _connectionString;

                using (var command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = commandText;

                        foreach (var parameter in parameters)
                            command.Parameters.Add(parameter);

                        connection.Open();

                        rowsAffecteds = command.ExecuteNonQuery();
                    }
                    finally
                    {
                        command.Parameters.Clear();
                    }
                }
            }

            return rowsAffecteds;
        }

        /// <summary>
        /// Instruções escalares (agregadas e afins)
        /// </summary>
        /// <param name="commandText">Instrução SQL</param>
        /// <returns>Objeto resultante da função escalar ou agregada</returns>
        public object ExecuteScalar(string commandText)
        {
            object value;

            using (IDbConnection connection = _factory.CreateConnection())
            {
                if (connection == null) return null;

                connection.ConnectionString = _connectionString;

                using (var command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = commandText;

                        connection.Open();

                        value = command.ExecuteScalar();
                    }
                    finally
                    {
                        command.Parameters.Clear();
                    }
                }
            }

            return value;
        }

        #endregion
    }
}
