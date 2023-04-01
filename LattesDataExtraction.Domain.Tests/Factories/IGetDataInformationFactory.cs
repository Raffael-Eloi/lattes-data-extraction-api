using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Enums;

namespace LattesDataExtraction.Domain.Tests.Factories
{
    internal interface IGetDataInformationFactory
    {
        IGetDataInformationService Create(DataInformationType type); 
    }
}