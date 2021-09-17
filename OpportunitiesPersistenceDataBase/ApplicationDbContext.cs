using System;
using Microsoft.EntityFrameworkCore;
using OpportunitiesDomain;

namespace OpportunitiesPersistenceDataBase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<OpportunityModel> Opportunity { get; set; }
        public DbSet<OpportunityDocumentsModel> OpportunityDocuments { get; set; }
        public DbSet<OpportunityContactModel> OpportunityContact { get; set; }
    }
}
