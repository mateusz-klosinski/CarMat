using System;
using System.ComponentModel.DataAnnotations;

namespace CarMat.ViewModels
{
    public class ValidOfferTime : ValidationAttribute
    {

        public string WrongDateMessage { get; set; }

        public int MaxDaysDuration { get; set; } = 14;

        private string DefaultWrongDateMessage = "Data spoza zakresu lub błędne dane.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date;
            DateTime.TryParse(value.ToString(), out date);

            if (date >= DateTime.Today + TimeSpan.FromDays(1) 
                && date <= DateTime.Today + TimeSpan.FromDays(MaxDaysDuration))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(WrongDateMessage ?? DefaultWrongDateMessage);
            }
        }
    }
}