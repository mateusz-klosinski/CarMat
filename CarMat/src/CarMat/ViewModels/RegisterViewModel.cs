using CarMat.ViewModels.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "{0} jest wymagana do rejestracji")]
        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} jest wymagany do rejestracji")]
        [EmailAddress(ErrorMessage = "Należy wpisać poprawny adres email np. jan.kowalski@poczta.pl")]
        [Display(Name = "Adres e-mail")]
        public string Email { get; set; }

        
        [Required(ErrorMessage = "{0} jest wymagane do rejestracji")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Hasło musi mieć przynajmniej 5 znaków długości")]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Pole {0} jest wymagane do rejestracji")]
        [StringLength(100, MinimumLength = 5 , ErrorMessage ="Hasło musi mieć przynajmniej 5 znaków długosci")]
        [Display(Name = "Powtórz hasło")]
        public string RepeatPassword { get; set; }

        [Display(Name = "Miasto")]
        [Required(ErrorMessage = "Pole {0} jest wymagane do rejestracji")]
        [LettersOnly]
        public string City { get; set; }

        [Display(Name ="Województwo")]
        [Required(ErrorMessage = "Pole {0} jest wymagane do rejestracji")]
        [ExistingProvince]
        public string Province { get; set; }
    }
}
