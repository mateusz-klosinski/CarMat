using CarMat.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarMat.ViewModels
{
    public class VehicleViewModel
    {
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

        /*[Required]
        public List<string> VehicleEquipment { get; set; }*/
    }
}