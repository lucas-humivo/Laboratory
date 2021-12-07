using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laboratory.Models
{
    public class Order
    {

        [Display(Name = "Klient")]
        public int ClientID { get; set; }

        [Display(Name = "Klient")]
        public virtual Client Client { get; set; }


        public int OrderID { get; set; }
        
        [Display(Name = "Numer zlecenia, przykład: 100/LA/TH/2021")]
        [Required]
        public string Number { get; set; } = string.Empty;

        [Display(Name = "Opis zlecenia")]
        [Required]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Cena")]
        [Column(TypeName = "decimal(18,4)")]
        [Required]
        public decimal Price { get; set; }

        [Display(Name = "Rabat")]
        [Column(TypeName = "decimal(18,4)")]
        [Required]
        public decimal Discount { get; set; }
    }
}
