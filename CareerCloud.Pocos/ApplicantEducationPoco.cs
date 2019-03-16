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
    [Table("Applicant_Educations")]
    public class ApplicantEducationPoco: IPoco
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        [Required]
        public Guid Applicant { get; set; }
        [DataMember]
        [Required,StringLength(100)]
        public string Major { get; set; }
        [DataMember]
        [Column("Certificate_Diploma"),StringLength(100)]
        public string CertificateDiploma { get; set; }
        [DataMember]
        [Column("Start_Date")]
        public DateTime? StartDate { get; set; }
        [DataMember]
        [Column("Completion_Date")]
        public DateTime? CompletionDate { get; set; }
        [DataMember]
        [Column("Completion_Percent")]
        public byte? CompletionPercent { get; set; }
        [DataMember]
        [Column("Time_Stamp",TypeName = "timestamp")]
        [Timestamp,NotMapped]  
        public byte[] TimeStamp { get; set; }
        [ForeignKey(nameof(Applicant))]
        public virtual ApplicantProfilePoco ApplicantProfile { get; set; }
    }
}
