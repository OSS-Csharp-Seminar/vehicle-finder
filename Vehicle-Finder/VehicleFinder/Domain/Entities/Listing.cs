using Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("listing")]
    public class Listing : BaseEntity
    {
        [Column("user_id")]
        public Guid user_id { get; set; }

        [ForeignKey("user_id")]
        public User User { get; set; }

        [Column("vehicle_id")]
        public Guid vehicle_id { get; set; }

        [ForeignKey("vehicle_id")]
        public Vehicle Vehicle { get; set; }

        [Column("post_datetime")]
        public DateTime post_datetime { get; set; }

        [Column("title")]
        public string title { get; set; }

        [Column("description")]
        public string description { get; set; }

        [Column("price")]
        public decimal price { get; set; }

        [Column("is_sold")]
        public bool is_sold { get; set; }

        [Column("img_directory")]
        public string img_directory { get; set; }
    }
}
