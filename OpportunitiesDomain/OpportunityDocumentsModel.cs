using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OpportunitiesDomain
{
    public class OpportunityDocumentsModel
    {
        [Key]
        public int IdOpportunityDocuments { get; set; }

        [Required]
        public int IdOpportunity { get; set; }

        [Required]
        public int IdDocumentType { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        [DefaultValue(null)]
        public string DocNumber { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(255)]
        [DefaultValue(null)]
        public string DocumentNotes { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime EffBeginDate { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime EffEndDate { get; set; }

        [DefaultValue(null)]
        [Column(TypeName = "Longblob")]
        public Byte[] File { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [DefaultValue(null)]
        public string FileName { get; set; }
        
    }
}
