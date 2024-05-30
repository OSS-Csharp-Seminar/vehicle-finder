using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("car_maintenance")]
    public class Maintenance : BaseEntity
    {
        [Column("basic_cost")]
        public float BasicCost { get; set; }

        [Column("full_cost")]
        public float FullCost { get; set; }

        [Column("basic_details")]
        public string BasicDetails { get; set; }

        [Column("full_details")]
        public string FullDetails { get; set; }

    }
}
