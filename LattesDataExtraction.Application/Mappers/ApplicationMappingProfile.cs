using AutoMapper;
using LattesDataExtraction.Application.Models;
using LattesDataExtraction.Domain.Entities;

namespace LattesDataExtraction.Application.Mappers
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<AcademicResearcher, AddAcademicResearcherResponse>();
        }
    }
}