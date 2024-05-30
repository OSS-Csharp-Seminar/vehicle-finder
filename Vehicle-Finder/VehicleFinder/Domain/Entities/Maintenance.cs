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
        public float basic_cost { get; set; }

        [Column("full_cost")]
        public float full_cost { get; set; }

        [Column("basic_details")]
        public string basic_details { get; set; }

        [Column("full_details")]
        public string full_details { get; set; }


    }
}
