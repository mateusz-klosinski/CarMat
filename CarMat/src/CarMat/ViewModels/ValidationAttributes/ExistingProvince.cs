using CarMat.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.ViewModels.ValidationAttributes
{
    public class ExistingProvince : ValidationAttribute
    {
        private const string DefaultProvinceNotFoundMessage = "Nie znaleziono podanego województwa";

        public string ProvinceNotFoundMessage { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _context = validationContext.GetService(typeof(CMContext)) as CMContext;
            string province = value.ToString();

            if (_context.Provinces.Any(p => p.Name.Equals(province)))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ProvinceNotFoundMessage ?? DefaultProvinceNotFoundMessage);
            }
        }
    }
}
