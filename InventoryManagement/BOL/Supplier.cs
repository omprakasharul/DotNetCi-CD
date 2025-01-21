using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BOL
{
    [Table("supplier")]
    public class Supplier : BaseClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        [Column("name", TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column("contact_info", TypeName = "varchar(255)")]
        public string ContactInfo { get; set; }

        [Column("email", TypeName = "varchar(75)")]
        public string Email { get; set; }

        [Column("phone", TypeName = "varchar(25)")]
        public string Phone { get; set; }

        [Column("address", TypeName = "varchar(255)")]
        public string Address { get; set; }

        [Column("notes", TypeName = "text")]
        public string Notes { get; set; }

        [Column("last_order_date", TypeName = "datetime")]
        public DateTime LastOrderDate { get; set; }

        [Column("is_active", TypeName = "bit")]
        public bool IsActive { get; set; }

        // Navigation properties
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }

        [JsonIgnore]
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}