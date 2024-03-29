﻿using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Enums;
using LattesDataExtraction.Domain.Services.DataExtraction;

namespace LattesDataExtraction.Domain.Factories
{
    public class GetDataInformationFactory : IGetDataInformationFactory
    {
        private const string DataInformationTypeNotImplementedMessage = "The Data Information Type {0} was not implemented.";

        public IGetDataInformationService Create(DataInformationType type)
        {
            switch (type)
            {
                case DataInformationType.CurriculumVitae:
                    return new GetCurriculumVitaeInformationService();

                case DataInformationType.GeneralData:
                    return new GetGeneralDataInformationService();
                
                case DataInformationType.ProfessionalDescription:
                    return new GetProfessionalDescriptionInformationService();

                case DataInformationType.ProfessionalAddress:
                    return new GetProfessionalAddressInformationService();

                case DataInformationType.AcademicBackground:
                    return new GetAcademicBackgroundInformationService();

                case DataInformationType.PublishedArticles:
                    return new GetPublishedArticlesInformationService();

                case DataInformationType.BooksOrganizedOrPublished:
                    return new GetBooksOrganizedOrPublishedInformationService();

                case DataInformationType.BooksChaptersPublished:
                    return new GetBooksChaptersPublishedInformationService();

                case DataInformationType.WorkAtEvents:
                    return new GetWorkAtEventsInformationService();

                case DataInformationType.OthersBibliographicProduction:
                    return new GetOthersBibliographicProductionInformationService();

                case DataInformationType.TechnicalProduction:
                    return new GetTechnicalProductionsInformationService();

                case DataInformationType.CompletedOrientation: 
                    return new GetCompletedOrientationInformationService();

                case DataInformationType.ComplementaryCourses:
                    return new GetComplementaryCoursesInformationService();

                case DataInformationType.ParticipationInFinalPaperPanel:
                    return new GetParticipationInFinalPaperPanelInformationService();

                case DataInformationType.OrientationInProgress: 
                    return new GetOrientationInProgressInformationService();

                default:
                    throw new ArgumentException(message: string.Format(DataInformationTypeNotImplementedMessage, type));
            }
        }
    }
}