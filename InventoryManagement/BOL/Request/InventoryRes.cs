using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BOL.Request
{
    public class InventoryRes : BaseClass
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public virtual Items Item { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public int ReorderLevel { get; set; }

        [JsonIgnore]
        public virtual ICollection<Order_Item> OrderItems { get; set; }
    }
}
