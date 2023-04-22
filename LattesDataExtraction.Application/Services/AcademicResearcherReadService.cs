﻿using AutoMapper;
using LattesDataExtraction.Application.Contracts;
using LattesDataExtraction.Application.Models;
using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;

namespace LattesDataExtraction.Application.Services
{
    public class AcademicResearcherReadService : IAcademicResearcherReadService
    {
        private readonly IAcademicResearcherRepository _academicResearcherRepository;

        private readonly IMapper _mapper;

        public AcademicResearcherReadService(IAcademicResearcherRepository academicResearcherRepository, IMapper mapper)
        {
            _academicResearcherRepository = academicResearcherRepository;
            _mapper = mapper;
        }

        public async Task<AcademicResearcherModelResponse> GetById(Guid academicReseracherId)
        {
            AcademicResearcher? academicResearcher = await _academicResearcherRepository.GetById(academicReseracherId);

            return CreateAcademicResearcherModelResponse(academicResearcher);
        }

        public async Task<IEnumerable<AcademicResearcherModelResponse>> GetAll()
        {
            IEnumerable<AcademicResearcher> academicResearchers = await _academicResearcherRepository.GetAll();
            
            return AcademicResearchModelResponse(academicResearchers);
        }

        private IEnumerable<AcademicResearcherModelResponse> AcademicResearchModelResponse(IEnumerable<AcademicResearcher> academicResearchers)
        {
            return academicResearchers.Select(academicResearcher => CreateAcademicResearcherModelResponse(academicResearcher));
        }

        private AcademicResearcherModelResponse CreateAcademicResearcherModelResponse(AcademicResearcher? academicResearcher)
        {
            return _mapper.Map<AcademicResearcherModelResponse>(academicResearcher);
        }
    }
}