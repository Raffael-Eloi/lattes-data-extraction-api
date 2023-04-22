using LattesDataExtraction.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LattesDataExtraction.Infraestructure.Context
{
    internal class AcademicResearcherContext : DbContext
    {
        public AcademicResearcherContext(DbContextOptions<AcademicResearcherContext> options) : base(options) 
        {
            
        }

        internal DbSet<AcademicResearcher> AcademicResearchers => Set<AcademicResearcher>();
    }
}