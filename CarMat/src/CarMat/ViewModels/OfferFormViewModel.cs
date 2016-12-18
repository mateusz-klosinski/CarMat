using CarMat.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.ViewModels
{
    public class OfferFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Tytuł ogłoszenia")]
        public string Title { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name = "Data zakończenia oferty")]
        public DateTime DateFinished { get; set; }

        [Required]
        [Display(Name = "Cena")]
        public string Price { get; set; }

        [Required]
        [MaxLength(5000)]
        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Rok produkcji")]
        public int ProductionYear { get; set; }

        [Required]
        [Display(Name = "Przebieg")]
        public int Mileage { get; set; }

        [Required]
        [Display(Name = "Pojemność silnika")]
        public int EngineCapacity { get; set; }

        [Required]
        [Display(Name = "Uszkodzenia")]
        public bool isDamaged { get; set; }

        [Required]
        [Display(Name = "Zarejestrowany w Polsce")]
        public bool isRegistered { get; set; }

        [Required]
        [Display(Name = "Model")]
        public string VehicleModel { get; set; }

        [Required]
        [Display(Name = "Marka")]
        public string VehicleBrand { get; set; }

        public string Action { get; set; }


        public string GetTommorowsDate()
        {
            return (DateTime.Today + TimeSpan.FromDays(1)).ToString("yyy-MM-dd");
        }

        public string GetDateFourteenDaysFromToday()
        {
            return (DateTime.Today + TimeSpan.FromDays(14)).ToString("yyy-MM-dd");
        }
    }
}
