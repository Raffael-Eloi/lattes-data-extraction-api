using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Enums;
using LattesDataExtraction.Domain.Services.DataExtraction;

namespace LattesDataExtraction.Domain.Factories
{
    internal class GetDataInformationFactory : IGetDataInformationFactory
    {
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

                default:
                    return null;
            }
        }
    }
}