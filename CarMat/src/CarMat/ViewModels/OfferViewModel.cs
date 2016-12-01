using CarMat.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.ViewModels
{
    public class OfferViewModel
    {
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
        public decimal Price { get; set; }

        [Required]
        [MaxLength(5000)]
        [Display(Name = "Opis")]
        public string Description { get; set; }

        public VehicleViewModel Vehicle { get; set; }


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
