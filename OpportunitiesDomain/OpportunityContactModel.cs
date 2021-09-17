using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OpportunitiesDomain
{
    public class OpportunityContactModel
    {
        [Key]
        public int IdOpportunityContacts { get; set; }

        [Required]
        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string OrganizationRole { get; set; }

        [Required]
        public int IdOpportunity { get; set; }

        [Required]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string MiddleName { get; set; }

        [Required]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public int IdPhoneType { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [Column("eMail",TypeName = "Varchar")]
        [StringLength(50)]
        public string EMail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string GoesBy { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(255)]
        public string ContactNotes { get; set; }
    }
}
