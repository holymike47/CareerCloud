using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Profiles")]
    public class ApplicantProfilePoco : IPoco
    {

        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid Login { get; set; }
        [Column("Current_Salary")]
        public decimal? CurrentSalary { get; set; }
        [Column("Current_Rate")]
        public decimal? CurrentRate { get; set; }
        [MaxLength(10)]
        public string Currency { get; set; }
        [Column("Country_Code"),StringLength(10)]
        public string Country { get; set; }
        [Column("State_Province_Code"),StringLength(10)]
        public string Province { get; set; }
        [Column("Street_Address"),StringLength(100)]
        public string Street { get; set; }
        [Column("City_Town"),StringLength(100)]
        public string City { get; set; }
        [Column("Zip_Postal_Code"),StringLength(20)]
        public string PostalCode { get; set; }
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
