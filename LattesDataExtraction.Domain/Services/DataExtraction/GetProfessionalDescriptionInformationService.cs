using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using System.Xml;

namespace LattesDataExtraction.Domain.Services.DataExtraction
{
    internal class GetProfessionalDescriptionInformationService : IGetDataInformationService
    {
        public void GetInformation(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument)
        {
            XmlNodeList professionalDescriptionInformation = academicResearcherDocument.GetElementsByTagName("RESUMO-CV");

            if (professionalDescriptionInformation.Count < 0) return;

            foreach (XmlNode element in professionalDescriptionInformation)
            {
                if (element.Attributes is not null && element.Attributes.Count > 0)
                {
                    XmlAttribute? professionalDescription = element.Attributes["TEXTO-RESUMO-CV-RH"];

                    if (professionalDescription is not null)
                    {
                        academicResearcher.ProfessionalDescription = professionalDescription.Value;
                    }
                }
            }
        }
    }
}