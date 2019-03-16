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
    [Table("Company_Profiles")]
    public class CompanyProfilePoco : IPoco
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        [Column("Registration_Date"),Required]
        public DateTime RegistrationDate { get; set; }
        [DataMember]
        [Column("Company_Website"),StringLength(100)]
        public string CompanyWebsite { get; set; }
        [DataMember]
        [Column("Contact_Phone"),StringLength(20),Required]
        public string ContactPhone { get; set; }
        [DataMember]
        [Column("Contact_Name"),StringLength(50)]
        public string ContactName { get; set; }
        [DataMember]
        [Column("Company_Logo")]
        public byte[] CompanyLogo { get; set; }
        [DataMember]
        [Column("Time_Stamp",TypeName = "timestamp")]
        [Timestamp,NotMapped]
        public byte[] TimeStamp { get; set; }
        public virtual ICollection<CompanyLocationPoco> CompanyLocations { get; set; }
        public virtual ICollection<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public virtual ICollection<CompanyJobPoco> CompanyJobs { get; set; }
    }
}
