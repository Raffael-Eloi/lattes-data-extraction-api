using LattesDataExtraction.Domain.Enums;

namespace LattesDataExtraction.Domain.Contracts
{
    internal interface IGetDataInformationFactory
    {
        IGetDataInformationService Create(DataInformationType type);
    }
}