using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum EngineType
    {
        [Display(Name = "Diesel")]
        Diesel,

        [Display(Name = "Electric")]
        Electric,

        [Display(Name = "Petrol")]
        Petrol,

        [Display(Name = "Hybrid")]
        Hybrid,

        [Display(Name = "Plug-in Hybrid")]
        PluginHybrid,

        [Display(Name = "Flex Fuel")]
        FlexFuel,

        [Display(Name = "Natural Gas")]
        NaturalGas,

        [Display(Name = "Hydrogen")]
        Hydrogen
        // Add more engine types as needed
    }
}
