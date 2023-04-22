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

        public async Task<IEnumerable<AcademicResearcherModel>> GetAll()
        {
            IEnumerable<AcademicResearcher> academicResearchers = await _academicResearcherRepository.GetAll();

            return academicResearchers.Select(academicResearcher => _mapper.Map<AcademicResearcherModel>(academicResearcher));
        }
    }
}