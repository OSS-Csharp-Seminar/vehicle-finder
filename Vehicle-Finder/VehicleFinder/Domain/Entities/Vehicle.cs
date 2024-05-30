using Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("vehicle")]
    public class Vehicle : BaseEntity
    {
        [Required]
        [Column("make")]
        public string make { get; set; }

        [Required]
        [Column("model")]
        public string model { get; set; }

        [Column("manufacture_year")]
        public int manufacture_year { get; set; }

        [Column("model_year")]
        public int model_year { get; set; }

        [Column("registration_until")]
        public DateTime registration_until { get; set; }

        [Column("kilometers")]
        public int kilometers { get; set; }

        [Column("owners_count")]
        public int owners_count { get; set; }

        public Engine? vehicle_engine { get; set; }
        public Body? vehicle_body { get; set; }
        public Maintenance? vehicle_maintenance { get; set; }
    }
}
