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
    [Table("Applicant_Work_History")]
    public class ApplicantWorkHistoryPoco : IPoco
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        [Required]
        public Guid Applicant { get; set; }
        [DataMember]
        [Column("Company_Name"),StringLength(150),Required]
        public string CompanyName { get; set; }
        [DataMember]
        [Column("Country_Code"),StringLength(10),Required]
        public string CountryCode { get; set; }
        [DataMember]
        [StringLength(50),Required]
        public string Location { get; set; }
        [DataMember]
        [Column("Job_Title"),StringLength(50),Required]
        public string JobTitle { get; set; }
        [DataMember]
        [Column("Job_Description"),StringLength(500),Required]
        public string JobDescription { get; set; }
        [DataMember]
        [Column("Start_Month"),Required]
        public short StartMonth { get; set; }
        [DataMember]
        [Column("Start_Year"),Required]
        public int StartYear { get; set; }
        [DataMember]
        [Column("End_Month"),Required]
        public short EndMonth { get; set; }
        [DataMember]
        [Column("End_Year"),Required]
        public int EndYear { get; set; }
        [DataMember]
        [Column("Time_Stamp",TypeName = "timestamp")]
        [Timestamp,NotMapped]
        public byte[] TimeStamp { get; set; }
        [ForeignKey(nameof(Applicant))]
        public virtual ApplicantProfilePoco ApplicantProfile { get; set; }
        [ForeignKey(nameof(CountryCode))]
        public virtual SystemCountryCodePoco SystemCountryCode { get; set; }
    }
}
