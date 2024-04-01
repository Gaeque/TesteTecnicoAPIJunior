using Microsoft.EntityFrameworkCore;
using TesteTecnicoAPIJunior.Entities;

namespace TesteTecnicoAPIJunior.Context
{
    public class JobContext : DbContext
    {   

        public JobContext(DbContextOptions<JobContext> options ) : base(options)
        {

        }

        public DbSet<Jobs> Jobs { get; set; }

    }
}
