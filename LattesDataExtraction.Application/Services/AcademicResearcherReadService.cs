using AutoMapper;
using LattesDataExtraction.Application.Contracts;
using LattesDataExtraction.Application.Models;
using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;

namespace LattesDataExtraction.Application.Services
{
    public class AcademicResearcherReadService : IAcademicResearcherReadService
    {
        private const string AcademicResearcherDoesNotExistMessage = "Academic Researcher does not exist.";

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

            if (RequestIsInvalid(academicResearcher, out AcademicResearcherModelResponse invalidResponse))
            {
                return invalidResponse;
            }

            return CreateAcademicResearcherModelResponse(academicResearcher);
        }

        private static bool RequestIsInvalid(AcademicResearcher? academicResearcher, out AcademicResearcherModelResponse invalidResponse)
        {
            invalidResponse = new AcademicResearcherModelResponse();

            if (academicResearcher == null)
            {
                invalidResponse.AddNotification("AcademicReseracherId", AcademicResearcherDoesNotExistMessage);

                return true;
            }

            return false;
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