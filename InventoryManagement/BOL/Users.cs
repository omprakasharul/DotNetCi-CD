using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BOL
{
    [Table("users")]
    public class Users : BaseClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("id", TypeName = "varchar(75)")]
        public string Id { get; set; }

        [Column("roleId", TypeName = "varchar(75)")]
        public string RoleId { get; set; }

        [JsonIgnore]
        public Roles? Role { get; set; } = null;

        [Column("first_name", TypeName = "varchar(25)")]
        public string FirstName { get; set; }

        [Column("last_name", TypeName = "varchar(25)")]
        public string LastName { get; set; }

        [Column("user_name", TypeName = "varchar(50)")]
        public string UserName { get; set; }

        [Column("email", TypeName = "varchar(75)")]
        public string Email { get; set; }

        [Column("password", TypeName = "varchar(125)")]
        public string Password { get; set; }

        [Column("street", TypeName = "varchar(100)")]
        public string Street { get; set; }

        [Column("city", TypeName = "varchar(100)")]
        public string City { get; set; }

        [Column("zipcode", TypeName = "varchar(25)")]
        public string ZipCode { get; set; }

        [Column("country", TypeName = "varchar(25)")]
        public string Country { get; set; }

        [Column("profile_pic", TypeName = "varchar(125)")]
        public string ProfilePic { get; set; }

        [Column("mobile_number", TypeName = "varchar(25)")]
        public string MobileNumber { get; set; }

        [Column("status", TypeName = "varchar(25)")]
        public string Status { get; set; }
    }
}
