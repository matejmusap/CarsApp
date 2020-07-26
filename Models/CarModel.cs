using System;
using System.ComponentModel.DataAnnotations;

namespace CarsApp.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string ModelOfCar { get; set; }
        [Required]
        public string ClassOfCar { get; set; }
        [Required]
        public string OriginCountry { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public int Length { get; set; }
        [Required]
        public int Width { get; set; }

    }
}