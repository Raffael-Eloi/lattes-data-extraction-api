using LattesDataExtraction.Domain.Enums;

namespace LattesDataExtraction.Domain.Contracts
{
    public interface IGetDataInformationFactory
    {
        IGetDataInformationService Create(DataInformationType type);
    }
}