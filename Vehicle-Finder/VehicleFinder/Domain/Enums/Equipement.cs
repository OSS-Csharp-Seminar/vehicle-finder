using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum CarEquipement
    {
        [Display(Name = "Manual Rollable Windows")]
        RollableWindowsManual,

        [Display(Name = "Electric Rollable Windows")]
        RollableWindowsElectric,

        [Display(Name = "GPS Navigation")]
        GPSNavigation,

        [Display(Name = "Bluetooth Connectivity")]
        BluetoothConnectivity,

        [Display(Name = "Touchscreen Display")]
        TouchscreenDisplay,

        [Display(Name = "Leather Seats")]
        LeatherSeats,

        [Display(Name = "Heated Seats")]
        HeatedSeats,

        [Display(Name = "Backup Camera")]
        BackupCamera,

        [Display(Name = "Parking Sensors")]
        ParkingSensors,

        //To-be-added

    }
}
