using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [DataContract]
    [Table("Security_Logins_Log")]
    public class SecurityLoginsLogPoco : IPoco
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        [Required]
        public Guid Login { get; set; }
        [DataMember]
        [Column("Source_IP"),StringLength(15),Required]
        public string SourceIP { get; set; }
        [DataMember]
        [Column("Logon_Date"),Required]
        public DateTime LogonDate { get; set; }
        [DataMember]
        [Column("Is_Succesful"),Required]
        public bool IsSuccesful { get; set; }
        [ForeignKey(nameof(Login))]
        public virtual SecurityLoginPoco SecurityLogin { get; set; }
    }
}
