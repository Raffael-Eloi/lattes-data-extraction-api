using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using LattesDataExtraction.Domain.Enums;
using System.Xml;

namespace LattesDataExtraction.Domain.Services
{
    public class AcademicResearcherDataExtractionService : IAcademicResearcherDataExtractionService
    {
        private readonly IGetDataInformationFactory _getDataInformationFactory;

        private XmlDocument? _academicResearcherDocument;

        private AcademicResearcher? _academicResearch;

        public AcademicResearcherDataExtractionService(IGetDataInformationFactory getDataInformationFactory)
        {
            _getDataInformationFactory = getDataInformationFactory;
        }

        public AcademicResearcher GetAcademicInformation(XmlDocument document)
        {
            _academicResearcherDocument = document;

            InitializeAcademicResearcher();

            GetCurriculumInformationIfExists();

            GetGeneralDataInformationIfExists();

            GetProfessionalDescriptionInformationIfExists();
            
            GetProfessionalAddressInformationIfExists();

            GetAcademicBackgroundInformationIfExists();

            GetWorkAtEventsIfExists();

            GetPublishedArticlesInformationIfExists();

            GetBooksOrganizedOrPublishedIfExists();

            GetBooksChaptersPublishedIfExists();

            GetOthersBibliographicProductionIfExists();

            GetTechnicalProductionIfExists();

            GetCompletedOrientationIfExists();

            return _academicResearch!;
        }

        private void InitializeAcademicResearcher()
        {
            _academicResearch = new()
            {
                Id = Guid.NewGuid(),
            };
        }

        private void GetCurriculumInformationIfExists()
        {
            IGetDataInformationService getDataInformationService = _getDataInformationFactory.Create(DataInformationType.CurriculumVitae);

            getDataInformationService.GetInformation(_academicResearch!, _academicResearcherDocument!);
        }

        private void GetGeneralDataInformationIfExists()
        {
            IGetDataInformationService getDataInformationService = _getDataInformationFactory.Create(DataInformationType.GeneralData);

            getDataInformationService.GetInformation(_academicResearch!, _academicResearcherDocument!);
        }
        
        private void GetProfessionalDescriptionInformationIfExists()
        {
            IGetDataInformationService getDataInformationService = _getDataInformationFactory.Create(DataInformationType.ProfessionalDescription);

            getDataInformationService.GetInformation(_academicResearch!, _academicResearcherDocument!);
        }
        
        private void GetProfessionalAddressInformationIfExists()
        {
            IGetDataInformationService getDataInformationService = _getDataInformationFactory.Create(DataInformationType.ProfessionalAddress);

            getDataInformationService.GetInformation(_academicResearch!, _academicResearcherDocument!);
        }
        
        private void GetAcademicBackgroundInformationIfExists()
        {
            IGetDataInformationService getDataInformationService = _getDataInformationFactory.Create(DataInformationType.AcademicBackground);

            getDataInformationService.GetInformation(_academicResearch!, _academicResearcherDocument!);
        }
        
        private void GetWorkAtEventsIfExists()
        {
            IGetDataInformationService getDataInformationService = _getDataInformationFactory.Create(DataInformationType.WorkAtEvents);

            getDataInformationService.GetInformation(_academicResearch!, _academicResearcherDocument!);
        }
        
        private void GetPublishedArticlesInformationIfExists()
        {
            IGetDataInformationService getDataInformationService = _getDataInformationFactory.Create(DataInformationType.PublishedArticles);

            getDataInformationService.GetInformation(_academicResearch!, _academicResearcherDocument!);
        }
        
        private void GetBooksOrganizedOrPublishedIfExists()
        {
            IGetDataInformationService getDataInformationService = _getDataInformationFactory.Create(DataInformationType.BooksOrganizedOrPublished);

            getDataInformationService.GetInformation(_academicResearch!, _academicResearcherDocument!);
        }
        
        private void GetBooksChaptersPublishedIfExists()
        {
            IGetDataInformationService getDataInformationService = _getDataInformationFactory.Create(DataInformationType.BooksChaptersPublished);

            getDataInformationService.GetInformation(_academicResearch!, _academicResearcherDocument!);
        }
        
        private void GetOthersBibliographicProductionIfExists()
        {
            IGetDataInformationService getDataInformationService = _getDataInformationFactory.Create(DataInformationType.OthersBibliographicProduction);

            getDataInformationService.GetInformation(_academicResearch!, _academicResearcherDocument!);
        }
        
        private void GetTechnicalProductionIfExists()
        {
            IGetDataInformationService getDataInformationService = _getDataInformationFactory.Create(DataInformationType.TechnicalProduction);

            getDataInformationService.GetInformation(_academicResearch!, _academicResearcherDocument!);
        }
        
        private void GetCompletedOrientationIfExists()
        {
            IGetDataInformationService getDataInformationService = _getDataInformationFactory.Create(DataInformationType.CompletedOrientation);

            getDataInformationService.GetInformation(_academicResearch!, _academicResearcherDocument!);
        }
    }
}