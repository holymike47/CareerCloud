using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Security_Logins_Roles")]
    public class SecurityLoginsRolePoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid Login { get; set; }
        [Required]
        public Guid Role { get; set; }
        [Column("Time_Stamp",TypeName = "timestamp")]
        [Timestamp,NotMapped]
        public byte[] TimeStamp { get; set; }
        [ForeignKey(nameof(Login))]
        public virtual SecurityLoginPoco SecurityLogin { get; set; }
        [ForeignKey(nameof(Role))]
        public virtual SecurityRolePoco SecurityRole { get; set; }
    }
}
