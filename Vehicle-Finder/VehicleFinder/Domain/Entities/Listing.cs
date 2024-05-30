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
        public Guid UserId { get; set; }

        [ForeignKey("user_id")]
        public User User { get; set; }

        [Column("vehicle_id")]
        public Guid VehicleId { get; set; }

        [ForeignKey("vehicle_id")]
        public Vehicle Vehicle { get; set; }

        [Column("post_datetime")]
        public DateTime PostDatetime { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("is_sold")]
        public bool IsSold { get; set; }

        [Column("img_directory")]
        public string ImgDirectory { get; set; }
    }
}
