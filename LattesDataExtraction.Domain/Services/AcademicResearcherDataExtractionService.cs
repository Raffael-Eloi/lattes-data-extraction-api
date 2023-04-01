using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using System.Xml;

namespace LattesDataExtraction.Domain.Services
{
    internal class AcademicResearcherDataExtractionService : IAcademicResearcherDataExtractionService
    {
        private readonly IGetDataInformationService _getCurriculumVitaeInformationService;

        private readonly IGetDataInformationService _getGeneralDataInformationService;

        private XmlDocument? _academicResearcherDocument;

        private AcademicResearcher? _academicResearch;

        public AcademicResearcherDataExtractionService(
         )
        {
        }

        public AcademicResearcher? GetAcademicInformation(string academicResearcherFile)
        {
            LoadXmlFile(academicResearcherFile);

            InitializeAcademicResearcher();

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

        private void InitializeAcademicResearcher()
        {
            _academicResearch = new();
        }

        private void GetCurriculumInformationIfExists()
        {
            _getCurriculumVitaeInformationService.GetInformation(_academicResearch!, _academicResearcherDocument);
        }

        private void GetGeneralDataInformationIfExists()
        {
            _getGeneralDataInformationService.GetInformation(_academicResearch!, _academicResearcherDocument);
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