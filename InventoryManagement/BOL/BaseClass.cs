using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class BaseClass
    {
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }

        [Column("updated_date")]
        public DateTime UpdatedDate { get; set; }

        [Column("is_active", TypeName = "bit")]
        public bool IsActive { get; set; }

        [Column("is_delete", TypeName = "bit")]
        public bool IsDelete { get; set; }

        [Column("created_by", TypeName = "varchar(125)")]
        public string CreatedBy { get; set; }

        [Column("updated_by", TypeName = "varchar(125)")]
        public string UpdatedBy { get; set; }
    }
}
