using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BOL
{
    [Table("order_item")]
    public class Order_Item : BaseClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        [Column("order_id", TypeName = "int")]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        [Column("Item_Id", TypeName = "int")]
        public int ItemId { get; set; }

        [ForeignKey("ItemId")]
        public virtual Items Item { get; set; }

        [Column("inventory_id", TypeName = "int")]
        public int InventoryId { get; set; }

        [ForeignKey("InventoryId")]
        public virtual Inventory Inventory { get; set; }

        [Column("quantity", TypeName = "int")]
        public int Quantity { get; set; }

        [Column("price", TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
    }
}