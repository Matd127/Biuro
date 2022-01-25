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

        [Required(ErrorMessage = "Podaj imię")]
        public string First_Name { get; set; }
        [Required(ErrorMessage = "Podaj nazwisko")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Nieprawidłowy email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Podaj Ulicę")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Podaj kod pocztowy")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Podaj miasto")]
        public string City { get; set; }
        [Required(ErrorMessage = "Podaj numer telefonu")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Podaj datę urodzenia")]
        public DateTime DateofBirth { get; set; }
    }
}
