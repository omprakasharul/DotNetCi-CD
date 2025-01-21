using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BOL
{
    [Table("items")]
    public class Items
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        [Column("item_name", TypeName = "varchar(250)")]
        public string? ItemName { get; set; }

        [Column("category_id", TypeName = "int")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Column("Status", TypeName = "bit")]
        public bool Status { get; set; }

        [Column("price", TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [JsonIgnore]
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}