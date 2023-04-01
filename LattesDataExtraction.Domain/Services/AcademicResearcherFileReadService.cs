using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using System.Xml;

namespace LattesDataExtraction.Domain.Services
{
    internal class AcademicResearcherFileReadService : IAcademicResearcherFileReadService
    {
        private XmlDocument? _academicResearcherDocument;

        private AcademicResearch? _academicResearch;

        public AcademicResearch? GetAcademicInformation(string academicResearcherFile)
        {
            LoadXmlFile(academicResearcherFile);

            GetCurriculumInformationIfExists();

            GetGeneralDataInformationIfExists();

            GetProfessionalDescriptionInformationIfExists();

            return _academicResearch;
        }

        private void LoadXmlFile(string academicResearcherFile)
        {
            _academicResearcherDocument = new();

            _academicResearcherDocument.Load(academicResearcherFile);
        }

        private void GetCurriculumInformationIfExists()
        {
            _academicResearch = new();

            XmlNodeList curriculumVitaeInformation = _academicResearcherDocument.GetElementsByTagName("CURRICULO-VITAE");
            
            if (curriculumVitaeInformation.Count < 0) return;

            foreach (XmlNode element in curriculumVitaeInformation)
            {
                if (element.Attributes != null && element.Attributes.Count > 0)
                {
                    XmlAttribute? identifierNumber = element.Attributes["NUMERO-IDENTIFICADOR"];

                    if (identifierNumber != null)
                    {
                        _academicResearch.IdentifierNumber = identifierNumber.Value;
                    }
                }

            }
        }

        private void GetGeneralDataInformationIfExists()
        {
            XmlNodeList generalDataInformation = _academicResearcherDocument.GetElementsByTagName("DADOS-GERAIS");

            if (generalDataInformation.Count < 0) return;

            foreach (XmlNode element in generalDataInformation)
            {
                if (element.Attributes != null && element.Attributes.Count > 0)
                {
                    XmlAttribute? fullName = element.Attributes["NOME-COMPLETO"];

                    if (fullName != null)
                    {
                        _academicResearch!.FullName = fullName.Value;
                    }

                    XmlAttribute? citationName = element.Attributes["NOME-EM-CITACOES-BIBLIOGRAFICAS"];

                    if (citationName != null)
                    {
                        _academicResearch!.CitationName = citationName.Value;
                    }
                    
                    XmlAttribute? nationality = element.Attributes["NACIONALIDADE"];

                    if (nationality != null)
                    {
                        _academicResearch!.Nationality = nationality.Value;
                    }

                    XmlAttribute? countryOfBirth = element.Attributes["PAIS-DE-NASCIMENTO"];

                    if (countryOfBirth != null)
                    {
                        _academicResearch!.CountryOfBirth = countryOfBirth.Value;
                    }

                    XmlAttribute? stateOfBirth = element.Attributes["UF-NASCIMENTO"];

                    if (stateOfBirth != null)
                    {
                        _academicResearch!.StateOfBirth = stateOfBirth.Value;
                    }
                    
                    XmlAttribute? cityOfBirth = element.Attributes["CIDADE-NASCIMENTO"];

                    if (cityOfBirth != null)
                    {
                        _academicResearch!.CityOfBirth = cityOfBirth.Value;
                    }

                    XmlAttribute? countryCode = element.Attributes["SIGLA-PAIS-NACIONALIDADE"];

                    if (countryCode != null)
                    {
                        _academicResearch!.CountryCode = countryCode.Value;
                    }

                    XmlAttribute? nationalityCountry = element.Attributes["PAIS-DE-NACIONALIDADE"];

                    if (nationalityCountry != null)
                    {
                        _academicResearch!.NationalityCountry = nationalityCountry.Value;
                    }

                    XmlAttribute? orcidId = element.Attributes["ORCID-ID"];

                    if (orcidId != null)
                    {
                        _academicResearch!.OrcidId = orcidId.Value;
                    }
                }

            }
        }
        
        private void GetProfessionalDescriptionInformationIfExists()
        {
            XmlNodeList professionalDescriptionInformation = _academicResearcherDocument.GetElementsByTagName("RESUMO-CV");

            if (professionalDescriptionInformation.Count < 0) return;

            foreach (XmlNode element in professionalDescriptionInformation)
            {
                if (element.Attributes != null && element.Attributes.Count > 0)
                {
                    XmlAttribute? professionalDescription = element.Attributes["TEXTO-RESUMO-CV-RH"];

                    if (professionalDescription != null)
                    {
                        _academicResearch!.ProfessionalDescription = professionalDescription.Value;
                    }
                }
            }
        }
    }
}