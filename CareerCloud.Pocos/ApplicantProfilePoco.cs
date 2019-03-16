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
    [Table("Applicant_Profiles")]
    public class ApplicantProfilePoco : IPoco
    {

        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        [Required]
        public Guid Login { get; set; }
        [DataMember]
        [Column("Current_Salary")]
        public decimal? CurrentSalary { get; set; }
        [DataMember]
        [Column("Current_Rate")]
        public decimal? CurrentRate { get; set; }
        [DataMember]
        [MaxLength(10)]
        public string Currency { get; set; }
        [DataMember]
        [Column("Country_Code"),StringLength(10)]
        public string Country { get; set; }
        [DataMember]
        [Column("State_Province_Code"),StringLength(10)]
        public string Province { get; set; }
        [DataMember]
        [Column("Street_Address"),StringLength(100)]
        public string Street { get; set; }
        [DataMember]
        [Column("City_Town"),StringLength(100)]
        public string City { get; set; }
        [DataMember]
        [Column("Zip_Postal_Code"),StringLength(20)]
        public string PostalCode { get; set; }
        [DataMember]
        [Column("Time_Stamp",TypeName = "timestamp")]
        [Timestamp,NotMapped]
        public byte[] TimeStamp { get; set; }
        [ForeignKey(nameof(Login))]
        public virtual SecurityLoginPoco SecurityLogin { get; set; }
        [ForeignKey(nameof(Country))]
        public virtual SystemCountryCodePoco SystemCountryCode { get; set; }
       
        public virtual ICollection<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public virtual ICollection<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public virtual ICollection<ApplicantResumePoco> ApplicantResumes { get; set; }
        public virtual ICollection<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public virtual ICollection<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }
    }
}
