using J3d.Domain.Service;

namespace J3d.Domain.ValueObect
{
    public class Url
    {
        #region Constants

        public const int UrlMaxLength = 500;

        #endregion

        public string Address { get; }

        public Url(string address)
        {
            AssertionConcern.AssertArgumentNotEmpty(address, $"Propriedade '{nameof(Url).ToUpper()}.{nameof(address).ToUpper()}' não pode ser vazia!");
            AssertionConcern.AssertArgumentLength(address, UrlMaxLength, $"Propriedade '{nameof(Url).ToUpper()}.{nameof(address).ToUpper()}' deve conter até {UrlMaxLength} caracteres!");
            UrlAssertionConcern.AssertArgumentValid(address, "Informe uma URL válida!");

            Address = address;
        }
    }
}
