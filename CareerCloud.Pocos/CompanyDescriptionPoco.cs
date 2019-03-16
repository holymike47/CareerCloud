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
    [Table("Company_Descriptions")]
    public class CompanyDescriptionPoco : IPoco
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        [Required]
        public Guid Company { get; set; }
        [DataMember]
        [StringLength(10),Required]
        public string LanguageId { get; set; }
        [DataMember]
        [Column("Company_Name"),StringLength(50),Required]
        public string CompanyName { get; set; }
        [DataMember]
        [Column("Company_Description"),StringLength(1000),Required]
        public string CompanyDescription { get; set; }
        [DataMember]
        [Column("Time_Stamp",TypeName = "timestamp")]
        [Timestamp,NotMapped]
        public byte[] TimeStamp { get; set; }
        [ForeignKey(nameof(Company))]
        public virtual CompanyProfilePoco CompanyProfile { get; set; }
        [ForeignKey(nameof(LanguageId))]
        public virtual SystemLanguageCodePoco SystemLanguageCode { get; set; }
    }
}
