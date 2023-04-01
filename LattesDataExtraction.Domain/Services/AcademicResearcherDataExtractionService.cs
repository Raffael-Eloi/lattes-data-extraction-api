using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using System.Xml;

namespace LattesDataExtraction.Domain.Services
{
    internal class AcademicResearcherDataExtractionService : IAcademicResearcherDataExtractionService
    {
        private XmlDocument? _academicResearcherDocument;

        private AcademicResearcher? _academicResearch;

        public AcademicResearcher? GetAcademicInformation(string academicResearcherFile)
        {
            LoadXmlFile(academicResearcherFile);

            GetCurriculumInformationIfExists();

            GetGeneralDataInformationIfExists();

            GetProfessionalDescriptionInformationIfExists();
            
            GetProfessionalAddressInformationIfExists();

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
                if (element.Attributes is not null && element.Attributes.Count > 0)
                {
                    XmlAttribute? identifierNumber = element.Attributes["NUMERO-IDENTIFICADOR"];

                    if (identifierNumber is not null)
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
                if (element.Attributes is not null && element.Attributes.Count > 0)
                {
                    XmlAttribute? fullName = element.Attributes["NOME-COMPLETO"];

                    if (fullName is not null)
                    {
                        _academicResearch!.FullName = fullName.Value;
                    }

                    XmlAttribute? citationName = element.Attributes["NOME-EM-CITACOES-BIBLIOGRAFICAS"];

                    if (citationName is not null)
                    {
                        _academicResearch!.CitationName = citationName.Value;
                    }
                    
                    XmlAttribute? nationality = element.Attributes["NACIONALIDADE"];

                    if (nationality is not null)
                    {
                        _academicResearch!.Nationality = nationality.Value;
                    }

                    XmlAttribute? countryOfBirth = element.Attributes["PAIS-DE-NASCIMENTO"];

                    if (countryOfBirth is not null)
                    {
                        _academicResearch!.CountryOfBirth = countryOfBirth.Value;
                    }

                    XmlAttribute? stateOfBirth = element.Attributes["UF-NASCIMENTO"];

                    if (stateOfBirth is not null)
                    {
                        _academicResearch!.StateOfBirth = stateOfBirth.Value;
                    }
                    
                    XmlAttribute? cityOfBirth = element.Attributes["CIDADE-NASCIMENTO"];

                    if (cityOfBirth is not null)
                    {
                        _academicResearch!.CityOfBirth = cityOfBirth.Value;
                    }

                    XmlAttribute? countryCode = element.Attributes["SIGLA-PAIS-NACIONALIDADE"];

                    if (countryCode is not null)
                    {
                        _academicResearch!.CountryCode = countryCode.Value;
                    }

                    XmlAttribute? nationalityCountry = element.Attributes["PAIS-DE-NACIONALIDADE"];

                    if (nationalityCountry is not null)
                    {
                        _academicResearch!.NationalityCountry = nationalityCountry.Value;
                    }

                    XmlAttribute? orcidId = element.Attributes["ORCID-ID"];

                    if (orcidId is not null)
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
                if (element.Attributes is not null && element.Attributes.Count > 0)
                {
                    XmlAttribute? professionalDescription = element.Attributes["TEXTO-RESUMO-CV-RH"];

                    if (professionalDescription is not null)
                    {
                        _academicResearch!.ProfessionalDescription = professionalDescription.Value;
                    }
                }
            }
        }
        
        private void GetProfessionalAddressInformationIfExists()
        {
            XmlNodeList professionalAddressInformation = _academicResearcherDocument.GetElementsByTagName("ENDERECO-PROFISSIONAL");

            if (professionalAddressInformation.Count < 0) return;

            foreach (XmlNode element in professionalAddressInformation)
            {
                if (element.Attributes is not null && element.Attributes.Count > 0)
                {
                    XmlAttribute? companyCode = element.Attributes["CODIGO-INSTITUICAO-EMPRESA"];

                    if (companyCode is not null)
                    {
                        _academicResearch!.ProfessionalAddress.CompanyCode = companyCode.Value;
                    }

                    XmlAttribute? companyName = element.Attributes["NOME-INSTITUICAO-EMPRESA"];

                    if (companyName is not null)
                    {
                        _academicResearch!.ProfessionalAddress.CompanyName = companyName.Value;
                    }

                    XmlAttribute? addressComplement = element.Attributes["LOGRADOURO-COMPLEMENTO"];

                    if (addressComplement is not null)
                    {
                        _academicResearch!.ProfessionalAddress.AddressComplement = addressComplement.Value;
                    }

                    XmlAttribute? country = element.Attributes["PAIS"];

                    if (country is not null)
                    {
                        _academicResearch!.ProfessionalAddress.Country = country.Value;
                    }

                    XmlAttribute? state = element.Attributes["UF"];

                    if (state is not null)
                    {
                        _academicResearch!.ProfessionalAddress.State = state.Value;
                    }

                    XmlAttribute? zipCode = element.Attributes["CEP"];

                    if (zipCode is not null)
                    {
                        _academicResearch!.ProfessionalAddress.ZipCode = zipCode.Value;
                    }

                    XmlAttribute? city = element.Attributes["CIDADE"];

                    if (city is not null)
                    {
                        _academicResearch!.ProfessionalAddress.City = city.Value;
                    }

                    XmlAttribute? district = element.Attributes["BAIRRO"];

                    if (district is not null)
                    {
                        _academicResearch!.ProfessionalAddress.District = district.Value;
                    }

                    XmlAttribute? ddd = element.Attributes["DDD"];

                    if (ddd is not null)
                    {
                        _academicResearch!.ProfessionalAddress.DDD = ddd.Value;
                    }

                    XmlAttribute? phoneNumber = element.Attributes["TELEFONE"];

                    if (phoneNumber is not null)
                    {
                        _academicResearch!.ProfessionalAddress.PhoneNumber = phoneNumber.Value;
                    }
                    
                    XmlAttribute? fax = element.Attributes["FAX"];

                    if (fax is not null)
                    {
                        _academicResearch!.ProfessionalAddress.Fax = fax.Value;
                    }
                    
                    XmlAttribute? poBox = element.Attributes["CAIXA-POSTAL"];

                    if (poBox is not null)
                    {
                        _academicResearch!.ProfessionalAddress.POBox = poBox.Value;
                    }

                    XmlAttribute? homePage = element.Attributes["HOME-PAGE"];

                    if (homePage is not null)
                    {
                        _academicResearch!.ProfessionalAddress.HomePage = homePage.Value;
                    }
                }
            }
        }
    }
}