using J3d.Domain.Service;

namespace J3d.Domain.ValueObect
{
    public class Mail
    {
        #region Constants

        /// <summary>
        ///  Restriction in RFC 2821
        /// https://www.ietf.org/rfc/rfc2821.txt
        /// </summary>
        public const int AddressMaxLength = 320;

        #endregion

        public string Address { get; }

        public Mail(string address)
        {
            AssertionConcern.AssertArgumentNotEmpty(address, $"Propriedade '{nameof(Mail).ToUpper()}.{nameof(address).ToUpper()}' não pode ser vazia!");
            AssertionConcern.AssertArgumentLength(address, AddressMaxLength, $"Propriedade '{nameof(Mail).ToUpper()}.{nameof(address).ToUpper()}' deve conter até {AddressMaxLength} caracteres!");
            MailAssertionConcern.AssertArgumentValid(address, "Informe um E-mail válido!");

            Address = address;
        }
    }
}
