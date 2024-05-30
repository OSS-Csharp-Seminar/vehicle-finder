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
        public string EngineName { get; set; }

        [Column("engine_type")]
        public EngineType EngineType { get; set; }

        [Column("engine_power")]
        public int EnginePower { get; set; }

        [Column("shifter_type")]
        public ShifterType ShifterType { get; set; }

        [Column("gear_count")]
        public int GearCount { get; set; }

        [Column("drive_type")]
        public string DriveType { get; set; }

        [Column("consumption")]
        public float Consumption { get; set; }

        [Column("engine_capacity")]
        public int EngineCapacity { get; set; }

        [Column("cylinder_count")]
        public int CylinderCount { get; set; }

    }
}
