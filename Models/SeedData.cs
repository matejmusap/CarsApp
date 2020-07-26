using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CarsApp.Data;
using System;
using System.Linq;

namespace CarsApp
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CarsAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CarsAppContext>>()))
            {
                // Look for any movies.
                if (context.Car.Any())
                {
                    return;   // DB has been seeded
                }

                context.Car.AddRange(
                    new Models.Car
                    {
                        DisplayName = "Ford Escort Mark V",
                        Manufacturer = "Ford Europe",
                        ModelOfCar = "Escort Mark V Hatchback",
                        ClassOfCar = "Small family car (C)",
                        OriginCountry = "Ireland",
                        Height = 1395,
                        Length = 4036,
                        Width = 1692
                    },
                    new Models.Car
                    {
                        DisplayName = "Cadillac Catera",
                        Manufacturer = "Opel (General Motors)",
                        ModelOfCar = "Catera",
                        ClassOfCar = "Mid-size / Executive car (E-segment)",
                        OriginCountry = "USA",
                        Height = 1433,
                        Length = 4882,
                        Width = 1786
                    },
                    new Models.Car
                    {
                        DisplayName = "Maserati GranTurismo MC Sport Line",
                        Manufacturer = "Maserati (Fiat Chrysler Automobiles)",
                        ModelOfCar = "GranTurismo MC Sport Line",
                        ClassOfCar = "Grand tourer (S)",
                        OriginCountry = "Italy",
                        Height = 1353,
                        Length = 4881,
                        Width = 1915
                    },
                    new Models.Car
                    {
                        DisplayName = "Ford Sierra",
                        Manufacturer = "Ford Europe",
                        ModelOfCar = "Sierra",
                        ClassOfCar = "Mid-size car/Large family car (D)",
                        OriginCountry = "Ireland",
                        Height = 1367,
                        Length = 4531,
                        Width = 1727
                    },
                    new Models.Car
                    {
                        DisplayName = "Honda N360",
                        Manufacturer = "Honda",
                        ModelOfCar = "N360",
                        ClassOfCar = "Kei car/city car",
                        OriginCountry = "Japan",
                        Height = 1346,
                        Length = 2995,
                        Width = 1295
                    },
                    new Models.Car
                    {
                        DisplayName = "Lancia Kappa Saloon",
                        Manufacturer = "Lancia",
                        ModelOfCar = "Kappa Saloon",
                        ClassOfCar = "Executive car (E)",
                        OriginCountry = "Italy",
                        Height = 1462,
                        Length = 4687,
                        Width = 1826
                    },
                    new Models.Car
                    {
                        DisplayName = "Peugeot 308 I (T7)",
                        Manufacturer = "Peugeot",
                        ModelOfCar = "308 I (T7)",
                        ClassOfCar = "Small family car (C)",
                        OriginCountry = "France",
                        Height = 1498,
                        Length = 4276,
                        Width = 1815
                    },
                    new Models.Car
                    {
                        DisplayName = "Mercedes-Benz C-Class (W205)",
                        Manufacturer = "Daimler AG",
                        ModelOfCar = "C-Class (W205)",
                        ClassOfCar = "Compact executive car (D)",
                        OriginCountry = "Germany",
                        Height = 1442,
                        Length = 4686,
                        Width = 1810
                    },
                    new Models.Car
                    {
                        DisplayName = "Citroën C4 Exclusive hatchback",
                        Manufacturer = "Citroën",
                        ModelOfCar = "C4 Exclusive hatchback",
                        ClassOfCar = "Compact car",
                        OriginCountry = "France",
                        Height = 1491,
                        Length = 4329,
                        Width = 1789
                    },
                    new Models.Car
                    {
                        DisplayName = "Chevrolet Vega",
                        Manufacturer = "General Motors",
                        ModelOfCar = "Vega",
                        ClassOfCar = "Subcompact",
                        OriginCountry = "USA",
                        Height = 1295,
                        Length = 4310,
                        Width = 1661
                     },
                     new Models.Car
                     {
                         DisplayName = "Volkswagen Golf Mk7",
                         Manufacturer = "Volkswagen",
                         ModelOfCar = "Golf Mark 7",
                         ClassOfCar = "Compact car / Small family car (C)",
                         OriginCountry = "Germany",
                         Height = 1452,
                         Length = 4255,
                         Width = 1799
                     },
                    new Models.Car
                    {
                        DisplayName = "Kia Picanto",
                        Manufacturer = "Kia",
                        ModelOfCar = "Picanto JA",
                        ClassOfCar = "City car",
                        OriginCountry = "South Korea",
                        Height = 1490,
                        Length = 3595,
                        Width = 1595
                    },
                    new Models.Car
                    {
                        DisplayName = "Renault Twingo III",
                        Manufacturer = "Renault (Renault Slovenia)",
                        ModelOfCar = "Twingo III",
                        ClassOfCar = "City car",
                        OriginCountry = "Slovenia",
                        Height = 1550,
                        Length = 3590,
                        Width = 1640
                    },
                    new Models.Car
                    {
                        DisplayName = "Ferrari F8 Tributo",
                        Manufacturer = "Ferrari",
                        ModelOfCar = "F8 Tributo",
                        ClassOfCar = "Sports car (S)",
                        OriginCountry = "Italy",
                        Height = 1206,
                        Length = 4611,
                        Width = 1979
                    },
                    new Models.Car
                    {
                       DisplayName = "Ford Fiesta Mark IV hatchback",
                       Manufacturer = "Ford",
                       ModelOfCar = "Fiesta Mark IV hatchback",
                       ClassOfCar = "Supermini (B)",
                       OriginCountry = "USA",
                       Height = 1320,
                       Length = 3828,
                       Width = 1634
                    }
            );
                context.SaveChanges();
            }
        }
    }
}