using EmployeesDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace EmployeesPersistenceDataBase
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //public List<EmployeeModel> Employees { get; set; }
        public DbSet<EmployeeModel> Employee { get; set; }

    }
}
