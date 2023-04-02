﻿using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using LattesDataExtraction.Domain.Enums;
using System.Xml;

namespace LattesDataExtraction.Domain.Services
{
    internal class AcademicResearcherDataExtractionService : IAcademicResearcherDataExtractionService
    {
        private readonly IGetDataInformationFactory _getDataInformationFactory;

        private XmlDocument? _academicResearcherDocument;

        private AcademicResearcher? _academicResearch;

        public AcademicResearcherDataExtractionService(IGetDataInformationFactory getDataInformationFactory)
        {
            _getDataInformationFactory = getDataInformationFactory;
        }

        public AcademicResearcher? GetAcademicInformation(string academicResearcherFile)
        {
            LoadXmlFile(academicResearcherFile);

            InitializeAcademicResearcher();

            GetCurriculumInformationIfExists();

            GetGeneralDataInformationIfExists();

            GetProfessionalDescriptionInformationIfExists();
            
            GetProfessionalAddressInformationIfExists();

            GetAcademicBackgroundInformationIfExists();

            GetPublishedArticlesInformationIfExists();

            return _academicResearch;
        }

        private void LoadXmlFile(string academicResearcherFile)
        {
            _academicResearcherDocument = new();

            _academicResearcherDocument.Load(academicResearcherFile);
        }

        private void InitializeAcademicResearcher()
        {
            _academicResearch = new();
        }

        private void GetCurriculumInformationIfExists()
        {
            IGetDataInformationService getDataInformationService = _getDataInformationFactory.Create(DataInformationType.CurriculumVitae);

            getDataInformationService.GetInformation(_academicResearch!, _academicResearcherDocument);
        }

        private void GetGeneralDataInformationIfExists()
        {
            IGetDataInformationService getDataInformationService = _getDataInformationFactory.Create(DataInformationType.GeneralData);

            getDataInformationService.GetInformation(_academicResearch!, _academicResearcherDocument);
        }
        
        private void GetProfessionalDescriptionInformationIfExists()
        {
            IGetDataInformationService getDataInformationService = _getDataInformationFactory.Create(DataInformationType.ProfessionalDescription);

            getDataInformationService.GetInformation(_academicResearch!, _academicResearcherDocument);
        }
        
        private void GetProfessionalAddressInformationIfExists()
        {
            IGetDataInformationService getDataInformationService = _getDataInformationFactory.Create(DataInformationType.ProfessionalAddress);

            getDataInformationService.GetInformation(_academicResearch!, _academicResearcherDocument);
        }
        
        private void GetAcademicBackgroundInformationIfExists()
        {
            IGetDataInformationService getDataInformationService = _getDataInformationFactory.Create(DataInformationType.AcademicBackground);

            getDataInformationService.GetInformation(_academicResearch!, _academicResearcherDocument);
        }
        
        private void GetPublishedArticlesInformationIfExists()
        {
            IGetDataInformationService getDataInformationService = _getDataInformationFactory.Create(DataInformationType.PublishedArticles);

            getDataInformationService.GetInformation(_academicResearch!, _academicResearcherDocument);
        }
    }
}