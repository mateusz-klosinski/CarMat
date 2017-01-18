using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CarMat.ViewModels.ValidationAttributes
{
    public class LettersOnly : ValidationAttribute
    {

        public string WrongCharactersMessage { get; set; }

        private string DefaultWrongCharactersMessage = "W polu można wpisać tylko litery";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!((string)value).Any(c => char.IsDigit(c)))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(WrongCharactersMessage ?? DefaultWrongCharactersMessage);
            }
        }
    }
}