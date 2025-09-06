using System;
using J3d.Domain.Service;

namespace J3d.Domain.Entity
{
    /// <summary>
    /// Interface utilizada como forma de firmar um contrato entre o ORM e as Entidades que deverão ser manipuladas pelo mesmo.
    /// Dessa forma, toda entidade do sistema deve herdar de IEntity para que o DbManager consiga abstrair as tarefas de CRUD
    /// </summary>
    public abstract class Entity
    {
        #region Properties

        public int Id { get; private set; }

        public DateTime Date { get; private set; }
        
        #endregion

        #region Set Methods

        public void SetId(int id)
        {
            //AssertionConcern.AssertArgumentTrue(id > 0, $"Propriedade '{nameof(Entity).ToUpper()}.{nameof(Id).ToUpper()}' não pode ser número negativo!");

            if (id <= 0)
                return;

            Id = id;
        }

        public void SetDate(DateTime data)
        {
            AssertionConcern.AssertArgumentTrue((data >= new DateTime(1753, 1, 1)) && (data <= new DateTime(2999, 1, 1)), $"Propriedade '{nameof(Entity).ToUpper()}.{nameof(data).ToUpper()}', cujo valor é: {data} é inválida!");
            Date = data;
        }

        #endregion

        #region Abstract Methods

        public abstract string ToSelectQuery();

        public abstract string ToInsertQuery();

        public abstract string ToUpdateQuery();

        public abstract string ToDeleteQuery();

        public virtual string ToLastRecordedId(string name)
        {
            return $"SELECT MAX({nameof(Id)}) FROM {name}";
        }

        #endregion

        #region Constructor

        protected Entity()
        {
            SetDate(DateTime.Now);
        }

        #endregion
    }
}
