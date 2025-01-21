using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BOL
{
    [Table("category")]
    public class Category : BaseClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        [Column("name", TypeName = "varchar(50)")]
        public string Name { get; set; }

        // Navigation properties
        [JsonIgnore]
        public virtual ICollection<Items>? Items { get; set; }

        [JsonIgnore]
        public virtual ICollection<Inventory>? Inventories { get; set; }
    }
}