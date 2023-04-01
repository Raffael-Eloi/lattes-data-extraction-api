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

                default:
                    return null;
            }
        }
    }
}