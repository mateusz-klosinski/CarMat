using CarMat.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.ViewModels.ValidationAttributes
{
    public class ExistingBrand : ValidationAttribute
    {
        private const string DefaultBrandNotFoundMessage = "Nie znaleziono podanej marki samochodu.";

        public string BrandNotFoundMessage { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _context = validationContext.GetService(typeof(CMContext)) as CMContext;
            string vehicleBrand = value.ToString();

            if (_context.VehicleBrands.Any(vb => vb.Name.Equals(vehicleBrand)))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(BrandNotFoundMessage ?? DefaultBrandNotFoundMessage);
            }
        }
    }
}
