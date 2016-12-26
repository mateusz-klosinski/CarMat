using CarMat.Models;
using CarMat.ViewModels.ValidationAttributes;
using Microsoft.AspNetCore.Mvc.Rendering;
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


        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        [MaxLength(50, ErrorMessage = "Maksymalna długość pola {0} wynosi {1}")]
        [Display(Name = "Tytuł ogłoszenia")]
        public string Title { get; set; }



        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        [Display(Name = "Data zakończenia oferty")]
        [ValidOfferTime(MaxDaysDuration = 14, WrongDateMessage = "Data musi być z zakresu od jutra do czternastu dni od dzisiaj.")]
        public DateTime DateFinished { get; set; }


        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        [Display(Name = "Cena")]
        public string Price { get; set; }


        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        [MaxLength(5000, ErrorMessage = "Maksymalna długość pola {0} wynosi {1}")]
        [Display(Name = "Opis")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        [Display(Name = "Rok produkcji")]
        [Range(1900, 2017, ErrorMessage = "Pole {0} musi mieć rok z zakresu od {1} do {2}")]
        public int ProductionYear { get; set; }


        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        [Display(Name = "Przebieg")]
        [Range(0, 5000000, ErrorMessage = "Pole {0} musi mieć przebieg z zakresu od {1} do {2} km")]
        public int Mileage { get; set; }


        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        [Display(Name = "Pojemność silnika")]
        [Range(0, 100000, ErrorMessage = "Pole {0} musi mieć pojemność z zakresu od {1} do {2} cm3")]
        public int EngineCapacity { get; set; }


        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        [Display(Name = "Uszkodzenia")]
        public bool isDamaged { get; set; }


        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        [Display(Name = "Zarejestrowany w Polsce")]
        public bool isRegistered { get; set; }


        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        [Display(Name = "Model")]
        [ExistingModel]
        public string VehicleModel { get; set; }


        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        [Display(Name = "Marka")]
        [ExistingBrand]
        public string VehicleBrand { get; set; }


        [Display(Name = "Wyposażenie")]
        public List<string> VehicleEquipment { get; set; }

        public MultiSelectList AvailableEquipment { get; set; }

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
