using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum CarBodyShape
    {
        [Display(Name = "Sedan")]
        Sedan,

        [Display(Name = "Coupe")]
        Coupe,

        [Display(Name = "Hatchback")]
        Hatchback,

        [Display(Name = "Convertible")]
        Convertible,

        [Display(Name = "SUV")]
        SUV,

        [Display(Name = "Crossover")]
        Crossover,

        [Display(Name = "Pickup Truck")]
        PickupTruck,

        [Display(Name = "Van")]
        Van,

        [Display(Name = "Wagon")]
        Wagon,

        [Display(Name = "Minivan")]
        Minivan

        // Add more body shapes as needed
    }
}
