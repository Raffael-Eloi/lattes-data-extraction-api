using LattesDataExtraction.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LattesDataExtraction.Infraestructure.Context
{
    internal class AcademicResearcherEFContext : DbContext
    {
        public AcademicResearcherEFContext(DbContextOptions<AcademicResearcherEFContext> options) : base(options) 
        {
            
        }

        public DbSet<AcademicResearcher> AcademicResearchers { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<AcademicResearcher>()
        //        .HasMany(a => a.AcademicBackground)
        //        .HasForeignKey(
        //}
    }
}