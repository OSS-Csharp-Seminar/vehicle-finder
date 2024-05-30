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
        public string Make { get; set; }

        [Required]
        [Column("model")]
        public string Model { get; set; }

        [Column("manufacture_year")]
        public int ManufactureYear { get; set; }

        [Column("model_year")]
        public int ModelYear { get; set; }

        [Column("registration_until")]
        public DateTime RegistrationUntil { get; set; }

        [Column("kilometers")]
        public int Kilometers { get; set; }

        [Column("owners_count")]
        public int OwnersCount { get; set; }
        [ForeignKey("VehicleEngineId")]
        public Guid? VehicleEngineId { get; set; }
        public Engine? VehicleEngine { get; set; }

        [ForeignKey("VehicleBodyId")]
        public Guid? VehicleBodyId { get; set; }
        public Body? VehicleBody { get; set; }

        [ForeignKey("VehicleMaintenanceId")]
        public Guid? VehicleMaintenanceId { get; set; }
        public Maintenance? VehicleMaintenance { get; set; }
    }
}
