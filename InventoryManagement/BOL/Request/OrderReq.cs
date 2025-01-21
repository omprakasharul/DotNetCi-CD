using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Request
{
    public class OrderReq
    {
        public string CustomerName { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set;}
    }

    public class OrderUpdateDto
    {
        public string CustomerName { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string updatedBy { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }

    public class OrderItemDto
    {
        public int ItemId { get; set; }
        public int InventoryId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class InventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
