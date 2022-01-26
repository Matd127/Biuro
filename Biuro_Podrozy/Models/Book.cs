using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biuro_Podrozy.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Display(Name = "Imię")]
        [StringLength(30)]
        [Required(ErrorMessage = "Podaj imię")]
        public string First_Name { get; set; }

        [Display(Name = "Nazwisko")]
        [StringLength(30)]
        [Required(ErrorMessage = "Podaj nazwisko")]
        public string Surname { get; set; }

        [Display(Name = "Zarezerwowane miejsca")]
        [Range(1,12, ErrorMessage ="Liczba miejsc musy być między 1 a 12")]
        [Required(ErrorMessage = "Nieprawidłowa liczba miejsc")]
        public int? Seats { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Nieprawidłowy email")]
        public string Email { get; set; }

        [Display(Name = "Adres")]
        [Required(ErrorMessage = "Podaj Adres")]
        public string Address { get; set; }

        [Display(Name = "Kod pocztowy")]
        [StringLength(6)]
        [RegularExpression(@"[0-9]{2}[-][0-9]{3}", ErrorMessage = "Nieprawidłowy format kodu pocztowego")]
        [Required(ErrorMessage = "Podaj kod pocztowy")]
        public string PostalCode { get; set; }

        [Display(Name = "Miasto")]
        [StringLength(30)]
        [RegularExpression(@"[A-ZŻŹŚŁĆ]{1}[a-zżźńółęąćś]+", ErrorMessage = "Nieprawidłowa wartość w polu miasto")]
        [Required(ErrorMessage = "Podaj miasto")]
        public string City { get; set; }

        [Display(Name = "Numer telefonu")]
        [StringLength(9)]
        //[RegularExpression(@"[1-9]{1}\d{2}[' ']{1}\d{3}[' ']{1}\d{3}", ErrorMessage = "Nieprawidłowy format numeru telefonu")]
        [Required(ErrorMessage = "Podaj numer telefonu")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Data urodzenia")]
        [Required(ErrorMessage = "Podaj datę urodzenia")]
        [DataType(DataType.Date)]
        public DateTime? DateofBirth { get; set; }
        public BiuroItem BiuroItem { get; set; }
    }
}
