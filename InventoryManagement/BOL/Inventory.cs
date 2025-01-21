using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BOL
{
    [Table("inventory")]
    public class Inventory : BaseClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        [Column("sku", TypeName = "varchar(50)")]
        public string SKU { get; set; }

        [Column("item_id", TypeName = "int")]
        public int ItemId { get; set; }

        [ForeignKey("ItemId")]
        public virtual Items Item { get; set; }

        [Column("category_id", TypeName = "int")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Column("description", TypeName = "text")]
        public string Description { get; set; }

        [Column("quantity", TypeName = "int")]
        public int Quantity { get; set; }

        [Column("price", TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Column("supplier_id", TypeName = "int")]
        public int SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }

        [Column("reorder_level", TypeName = "int")]
        public int ReorderLevel { get; set; }

        [JsonIgnore]
        public virtual ICollection<Order_Item> OrderItems { get; set; }
    }
}
