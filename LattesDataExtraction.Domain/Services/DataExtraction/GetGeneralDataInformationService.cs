using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using System.Xml;

namespace LattesDataExtraction.Domain.Services.DataExtraction
{
    internal class GetGeneralDataInformationService : IGetDataInformationService
    {
        private AcademicResearcher? _academicResearcher;

        public void GetInformation(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument)
        {
            _academicResearcher = academicResearcher;

            XmlNodeList generalDataInformation = academicResearcherDocument.GetElementsByTagName("DADOS-GERAIS");

            if (DoesNotHaveInformationData(generalDataInformation)) return;

            foreach (XmlNode element in generalDataInformation)
            {
                if (ElementDoesNotExist(element))
                {
                    return;
                }

                GetFullNameIfExsit(element);

                GetCitationNameIfExist(element);

                GetCountryOfBirthIfExist(element);

                GetStateOfBirthIfExist(element);

                GetCityOfBornIfExist(element);

                GetCountryCodeIfExsit(element);

                GetCountryIfExist(element);

                GetOrcidIdIfExist(element);
            }
        }

        private static bool DoesNotHaveInformationData(XmlNodeList generalDataInformation)
        {
            return generalDataInformation.Count <= 0;
        }

        private static bool ElementDoesNotExist(XmlNode element)
        {
            return element.Attributes is null || element.Attributes.Count == 0;
        }

        private void GetFullNameIfExsit(XmlNode element)
        {
            XmlAttribute? fullName = element.Attributes!["NOME-COMPLETO"];

            if (fullName is not null)
            {
                _academicResearcher!.FullName = fullName.Value;
            }
        }

        private void GetCitationNameIfExist(XmlNode element)
        {
            XmlAttribute? citationName = element.Attributes!["NOME-EM-CITACOES-BIBLIOGRAFICAS"];

            if (citationName is not null)
            {
                _academicResearcher!.CitationName = citationName.Value;
            }
        }

        private void GetCountryOfBirthIfExist(XmlNode element)
        {
            XmlAttribute? countryOfBirth = element.Attributes!["PAIS-DE-NASCIMENTO"];
            if (countryOfBirth is not null)
            {
                _academicResearcher!.CountryOfBirth = countryOfBirth.Value;
            }
        }

        private void GetStateOfBirthIfExist(XmlNode element)
        {
            XmlAttribute? stateOfBirth = element.Attributes!["UF-NASCIMENTO"];
            if (stateOfBirth is not null)
            {
                _academicResearcher!.StateOfBirth = stateOfBirth.Value;
            }
        }

        private void GetCityOfBornIfExist(XmlNode element)
        {
            XmlAttribute? cityOfBirth = element.Attributes!["CIDADE-NASCIMENTO"];
            if (cityOfBirth is not null)
            {
                _academicResearcher!.CityOfBirth = cityOfBirth.Value;
            }
        }

        private void GetCountryCodeIfExsit(XmlNode element)
        {
            XmlAttribute? countryCode = element.Attributes!["SIGLA-PAIS-NACIONALIDADE"];
            if (countryCode is not null)
            {
                _academicResearcher!.CountryCode = countryCode.Value;
            }
        }

        private void GetCountryIfExist(XmlNode element)
        {
            XmlAttribute? nationalityCountry = element.Attributes!["PAIS-DE-NACIONALIDADE"];

            if (nationalityCountry is not null)
            {
                _academicResearcher!.NationalityCountry = nationalityCountry.Value;
            }
        }

        private void GetOrcidIdIfExist(XmlNode element)
        {
            XmlAttribute? orcidId = element.Attributes!["ORCID-ID"];

            if (orcidId is not null)
            {
                _academicResearcher!.OrcidId = orcidId.Value;
            }
        }
    }
}