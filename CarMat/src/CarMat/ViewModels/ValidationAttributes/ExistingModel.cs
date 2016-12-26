using CarMat.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.ViewModels.ValidationAttributes
{
    public class ExistingModel : ValidationAttribute
    {
        private const string DefaultModelNotFoundMessage = "Nie znaleziono podanego modelu samochodu.";

        public string ModelNotFoundMessage { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _context = validationContext.GetService(typeof(CMContext)) as CMContext;
            string vehicleModel = value.ToString();

            if (_context.VehicleModels.Any(vb => vb.Name.Equals(vehicleModel)))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ModelNotFoundMessage ?? DefaultModelNotFoundMessage);
            }
        }
    }
}
