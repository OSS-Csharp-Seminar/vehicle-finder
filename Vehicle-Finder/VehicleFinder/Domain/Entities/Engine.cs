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
    [Table("car_engine")]
    public class Engine : BaseEntity
    {
        [Column("engine_name")]
        public string engine_name { get; set; }

        [Column("engine_type")]
        public EngineType engine_type { get; set; }

        [Column("engine_power")]
        public int engine_power { get; set; }

        [Column("shifter_type")]
        public ShifterType shifter_type { get; set; }

        [Column("gear_count")]
        public int gear_count { get; set; }

        [Column("drive_type")]
        public string drive_type { get; set; }

        [Column("consumption")]
        public float consumption { get; set; }

        [Column("engine_capacity")]
        public int engine_capacity { get; set; }

        [Column("cylinder_count")]
        public int cylinder_count { get; set; }

        public Guid vehicle_id { get; set; }
        [ForeignKey("vehicle_id")]
        public Vehicle vehicle { get; set; }

    }
}
