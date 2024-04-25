using Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("user")]
    public class User : BaseEntity
    {
        [Column("user_name")]
        public string user_name { get; set; }

        [Column("email")]
        public string email { get; set; }

        [Column("phone_number")]
        public string phone_number { get; set; }

        [Column("birth_date")]
        public DateTime birth_date { get; set; }

        [Column("password_hash")]
        public string password_hash { get; set; }

        [Column("first_name")]
        public string first_name { get; set; }

        [Column("last_name")]
        public string last_name { get; set; }
    }
}
