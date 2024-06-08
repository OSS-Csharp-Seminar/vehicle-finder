using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("car_body")]
    public class Body : BaseEntity
    {
        [Column("door_count")]
        public int DoorCount { get; set; }

        [Column("seat_count")]
        public int SeatCount { get; set; }

        [Column("ac_type")]
        public AcTypes AcType { get; set; }

        [Column("equipment")]
        public CarEquipement Equipment { get; set; } 

        [Column("body_shape")]
        public CarBodyShape BodyShape { get; set; } 
    }
}
