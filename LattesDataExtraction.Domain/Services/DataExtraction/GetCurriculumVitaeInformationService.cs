using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using System.Xml;

namespace LattesDataExtraction.Domain.Services.DataExtraction
{
    internal class GetCurriculumVitaeInformationService : IGetDataInformationService
    {
        private const string LattesPrefix = "http://lattes.cnpq.br/";

        public void GetInformation(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument)
        {
            XmlNodeList information = academicResearcherDocument.GetElementsByTagName("CURRICULO-VITAE");

            if (information.Count < 0) return;

            foreach (XmlNode element in information)
            {
                if (element.Attributes is not null && element.Attributes.Count > 0)
                {
                    XmlAttribute? identifierNumber = element.Attributes["NUMERO-IDENTIFICADOR"];

                    if (identifierNumber is not null)
                    {
                        academicResearcher.IdentifierNumber = identifierNumber.Value;
                        academicResearcher.LattesId = LattesPrefix + identifierNumber.Value;
                    }
                }
            }
        }
    }
}