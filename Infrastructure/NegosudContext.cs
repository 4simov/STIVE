using Microsoft.EntityFrameworkCore;
using STIVE.Domain.Entities;

namespace STIVE.Infrastructure
{
    public class NegosudContext : DbContext
    {
        public NegosudContext(DbContextOptions<NegosudContext> options)
        : base(options)
        {

        }

        public DbSet<Famille> Famille { get; set; }
        public DbSet<Adresse> Adresse { get; set; }
    }
}
