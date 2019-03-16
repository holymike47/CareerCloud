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
    [Table("Applicant_Skills")]
    public class ApplicantSkillPoco : IPoco
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        [Required]
        public Guid Applicant { get; set; }
        [DataMember]
        [Required,StringLength(100)]
        public string Skill { get; set; }
        [DataMember]
        [Column("Skill_Level"),StringLength(10),Required]
        public string SkillLevel { get; set; }
        [DataMember]
        [Column("Start_Month"),Required]
        public byte StartMonth { get; set; }
        [DataMember]
        [Column("Start_Year"),Required]
        public int StartYear { get; set; }
        [DataMember]
        [Column("End_Month"),Required]
        public byte EndMonth { get; set; }
        [DataMember]
        [Column("End_Year"),Required]
        public int EndYear { get; set; }
        [DataMember]
        [Column("Time_Stamp",TypeName = "timestamp")]
        [Timestamp,NotMapped]
        public byte[] TimeStamp { get; set; }
        [ForeignKey(nameof(Applicant))]
        public virtual ApplicantProfilePoco ApplicantProfile { get; set; }
    }
}
