using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum EngineDriveType
    {
        [Display(Name = "Front Wheel Drive")]
        FrontWheelDrive, // FWD

        [Display(Name = "Rear Wheel Drive")]
        RearWheelDrive,  // RWD

        [Display(Name = "All Wheel Drive")]
        AllWheelDrive,   // AWD

        [Display(Name = "Four Wheel Drive")]
        FourWheelDrive   // 4WD
    }
}
