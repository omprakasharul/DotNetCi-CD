using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BOL
{
    [Table("roles")]
    public class Roles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("id", TypeName = "varchar(75)")]
        public required string Id { get; set; }

        [Column("role_name", TypeName = "varchar(25)")]
        public string RoleName { get; set; }

        [JsonIgnore]
        public List<Users> ListUsers { get; set; }
    }
}
