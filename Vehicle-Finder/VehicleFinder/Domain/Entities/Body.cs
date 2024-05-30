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
        public int door_count { get; set; }

        [Column("seat_count")]
        public int seat_count { get; set; }
        
        [Column("ac_type")]
        public AcTypes ac_type { get; set; }

        [Column("equipment")]
        public CarEquipement equipment { get; set; } //takoder moze bit enum

        [Column("body_shape")]
        public CarBodyShape body_shape { get; set; } //moze bit enum sa nekoliko opcija
        
    }
}
