using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum ShifterType
    {
        [Display(Name = "Manual")]
        Manual,

        [Display(Name = "Automatic")]
        Automatic,

        [Display(Name = "Semi-Automatic")]
        SemiAutomatic,

        [Display(Name = "Continuously Variable Transmission (CVT)")]
        CVT,

        [Display(Name = "Dual-Clutch Transmission (DCT)")]
        DCT,

        [Display(Name = "Automated Manual Transmission (AMT)")]
        AMT
        // Add more shifter types as needed
    }
}
