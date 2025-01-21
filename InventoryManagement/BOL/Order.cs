using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BOL
{
    [Table("order")]
    public class Order : BaseClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        [Column("customer_name", TypeName = "varchar(100)")]
        public string CustomerName { get; set; }

        [Column("order_date", TypeName = "datetime")]
        public DateTime OrderDate { get; set; }

        [Column("status", TypeName = "varchar(25)")]
        public string Status { get; set; }

        [Column("total_amount", TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }

        [Column("supplier_id", TypeName = "int")]
        public int SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<Order_Item> OrderItems { get; set; }
    }
}