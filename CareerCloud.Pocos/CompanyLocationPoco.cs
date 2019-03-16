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
    [Table("Company_Locations")]
    public class CompanyLocationPoco : IPoco
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        [Required]
        public Guid Company { get; set; }
        [DataMember]
        [Column("Country_Code"),StringLength(10),Required]
        public string CountryCode { get; set; }
        [DataMember]
        [Column("State_Province_Code"),MaxLength(10)]
        public string Province { get; set; }
        [DataMember]
        [Column("Street_Address"),MaxLength(100)]
        public string Street { get; set; }
        [DataMember]
        [Column("City_Town"),MaxLength(100)]
        public string City { get; set; }
        [DataMember]
        [Column("Zip_Postal_Code"),MaxLength(20)]
        public string PostalCode { get; set; }
        [DataMember]
        [Column("Time_Stamp",TypeName = "timestamp")]
        [Timestamp,NotMapped]
        public byte[] TimeStamp { get; set; }
        [ForeignKey(nameof(Company))]
        public virtual CompanyProfilePoco CompanyProfile { get; set; }
    }
}
