using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using System.Xml;

namespace LattesDataExtraction.Domain.Services.DataExtraction
{
    internal class GetGeneralDataInformationService : IGetDataInformationService
    {
        public void GetInformation(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument)
        {
            XmlNodeList generalDataInformation = academicResearcherDocument.GetElementsByTagName("DADOS-GERAIS");

            if (generalDataInformation.Count < 0) return;

            foreach (XmlNode element in generalDataInformation)
            {
                if (element.Attributes is not null && element.Attributes.Count > 0)
                {
                    XmlAttribute? fullName = element.Attributes["NOME-COMPLETO"];

                    if (fullName is not null)
                    {
                        academicResearcher.FullName = fullName.Value;
                    }

                    XmlAttribute? citationName = element.Attributes["NOME-EM-CITACOES-BIBLIOGRAFICAS"];

                    if (citationName is not null)
                    {
                        academicResearcher.CitationName = citationName.Value;
                    }

                    XmlAttribute? nationality = element.Attributes["NACIONALIDADE"];

                    if (nationality is not null)
                    {
                        academicResearcher.Nationality = nationality.Value;
                    }

                    XmlAttribute? countryOfBirth = element.Attributes["PAIS-DE-NASCIMENTO"];

                    if (countryOfBirth is not null)
                    {
                        academicResearcher.CountryOfBirth = countryOfBirth.Value;
                    }

                    XmlAttribute? stateOfBirth = element.Attributes["UF-NASCIMENTO"];

                    if (stateOfBirth is not null)
                    {
                        academicResearcher.StateOfBirth = stateOfBirth.Value;
                    }

                    XmlAttribute? cityOfBirth = element.Attributes["CIDADE-NASCIMENTO"];

                    if (cityOfBirth is not null)
                    {
                        academicResearcher.CityOfBirth = cityOfBirth.Value;
                    }

                    XmlAttribute? countryCode = element.Attributes["SIGLA-PAIS-NACIONALIDADE"];

                    if (countryCode is not null)
                    {
                        academicResearcher.CountryCode = countryCode.Value;
                    }

                    XmlAttribute? nationalityCountry = element.Attributes["PAIS-DE-NACIONALIDADE"];

                    if (nationalityCountry is not null)
                    {
                        academicResearcher.NationalityCountry = nationalityCountry.Value;
                    }

                    XmlAttribute? orcidId = element.Attributes["ORCID-ID"];

                    if (orcidId is not null)
                    {
                        academicResearcher.OrcidId = orcidId.Value;
                    }
                }
            }
        }
    }
}