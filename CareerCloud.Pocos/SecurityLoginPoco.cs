﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Security_Logins")]
    public class SecurityLoginPoco : IPoco
    {

        [Key]
        public Guid Id { get; set; }
        [MaxLength(50),Required]
        public string Login { get; set; }
        [StringLength(100),Required]
        public string Password { get; set; }
        [Column("Created_Date"),Required]
        public DateTime Created { get; set; }
        [Column("Password_Update_Date")]
        public DateTime? PasswordUpdate { get; set; }
        [Column("Agreement_Accepted_Date")]
        public DateTime? AgreementAccepted { get; set; }
        [Column("Is_Locked"),Required]
        public bool IsLocked { get; set; }
        [Column("Is_Inactive"),Required]
        public bool IsInactive { get; set; }
        [Column("Email_Address"),StringLength(50),Required]
        public string EmailAddress { get; set; }
        [Column("Phone_Number"),StringLength(20)]
        public string PhoneNumber { get; set; }
        [Column("Full_Name"),StringLength(100)]
        public string FullName { get; set; }
        [Column("Force_Change_Password"),Required]
        public bool ForceChangePassword { get; set; }
        [Column("Prefferred_Language"),StringLength(10)]
        public string PrefferredLanguage { get; set; }
        [Column("Time_Stamp",TypeName = "timestamp")]
        [Timestamp,NotMapped]
        public byte[] TimeStamp { get; set; }
        public virtual ICollection<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public virtual ICollection<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        public virtual ICollection<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
    }
}
