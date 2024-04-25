using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum AcTypes
    {
        [Display(Name = "Automatic Climate Control")]
        ACC,
        [Display(Name = "Manual Climate Control")]
        MCC,
        [Display(Name = "Dual-zone Climate Control")]
        DualZone,
        //To-be-added

    }
}
