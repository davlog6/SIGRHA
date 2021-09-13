using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpportunitiesDomain
{
    public class OpportunityModel
    {
        [Key]
        public int IdOpportunity { get; set; }

        [Required]
        public int IdClient { get; set; }

        [Required]
        public string OpportunityName { get; set; }

        [Required]
        public string OpportunityGoesBy { get; set; }

        [Required]
        public int IdOpportunityType { get; set; }

        [Required]
        public string OpportunityNotes { get; set; }

        [Required]
        public int IdOpportunityStatus { get; set; }

        [Required]
        [Column(TypeName="Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public Nullable<DateTime>  UpdatedDate { get; set; }
    }
}
