using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laboratory.Models
{
    public class Client
    {
        public int ClientID { get; set; }

        [Display(Name = "Nazwa firmy")]
        [Required]
        public string CompanyName { get; set; } = string.Empty;

        [Display(Name = "Adres")]
        [Required]
        public string Address { get; set; } = string.Empty;

        [RegularExpression(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ\s]*$")]
        [Display(Name = "Osoba kontaktowa")]
        [Required]
        public string ContactPerson { get; set; } = string.Empty;

        [Display(Name = "Numer telefonu")]
        [DataType(DataType.PhoneNumber)]
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [RegularExpression("^((AT)?U[0-9]{8}|(BE)?0[0-9]{9}|(BG)?[0-9]{9,10}|(CY)?[0-9]{8}L|(CZ)?[0-9]{8,10}|(DE)?[0-9]{9}|(DK)?[0-9]{8}|(EE)?[0-9]{9}|(EL|GR)?[0-9]{9}|(ES)?[0-9A-Z][0-9]{7}[0-9A-Z]|(FI)?[0-9]{8}|(FR)?[0-9A-Z]{2}[0-9]{9}|(GB)?([0-9]{9}([0-9]{3})?|[A-Z]{2}[0-9]{3})|(HU)?[0-9]{8}|(IE)?[0-9]S[0-9]{5}L|(IT)?[0-9]{11}|(LT)?([0-9]{9}|[0-9]{12})|(LU)?[0-9]{8}|(LV)?[0-9]{11}|(MT)?[0-9]{8}|(NL)?[0-9]{9}B[0-9]{2}|(PL)?[0-9]{10}|(PT)?[0-9]{9}|(RO)?[0-9]{2,10}|(SE)?[0-9]{12}|(SI)?[0-9]{8}|(SK)?[0-9]{10})$")]
        [Required]
        public string NIP { get; set; } = string.Empty;


        [Display(Name = "Waluta")]
        [Required]
        public string Currency { get; set; } = string.Empty;

        [Display(Name = "Termin płatności")]
        [Required]
        public int PaymentTerms { get; set; }

        public virtual ICollection<Order> Order { get; set; }

    }
}
