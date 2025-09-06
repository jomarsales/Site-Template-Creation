using J3d.Domain.Service;

namespace J3d.Domain.Entity
{
    public abstract class Page : Entity
    {
        #region Constants

        public const int NameMaxLength = 100;

        #endregion

        #region Properties

        public string Name { get; private set; }

        #endregion

        #region Set Methods

        public void SetName(string name)
        {
            AssertionConcern.AssertArgumentNotEmpty(name, $"Propriedade '{nameof(Page).ToUpper()}.{nameof(name).ToUpper()}' não pode ser vazia!");
            AssertionConcern.AssertArgumentLength(name, NameMaxLength, $"Propriedade '{nameof(Page).ToUpper()}.{nameof(name).ToUpper()}' deve conter até {NameMaxLength} caracteres!");

            Name = name;
        }

        #endregion
    }
}
