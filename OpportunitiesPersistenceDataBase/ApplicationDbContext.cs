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
    }
}
