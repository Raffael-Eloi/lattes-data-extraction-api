using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using System.Xml;

namespace LattesDataExtraction.Domain.Services.DataExtraction
{
    internal class GetProfessionalAddressInformationService : IGetDataInformationService
    {
        public void GetInformation(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument)
        {
            XmlNodeList professionalAddressInformation = academicResearcherDocument.GetElementsByTagName("ENDERECO-PROFISSIONAL");

            if (professionalAddressInformation.Count < 0) return;

            academicResearcher.ProfessionalAddress = new ProfessionalAddress();

            foreach (XmlNode element in professionalAddressInformation)
            {
                if (element.Attributes is not null && element.Attributes.Count > 0)
                {
                    XmlAttribute? companyCode = element.Attributes["CODIGO-INSTITUICAO-EMPRESA"];

                    if (companyCode is not null)
                    {
                        academicResearcher.ProfessionalAddress.CompanyCode = companyCode.Value;
                    }

                    XmlAttribute? companyName = element.Attributes["NOME-INSTITUICAO-EMPRESA"];

                    if (companyName is not null)
                    {
                        academicResearcher.ProfessionalAddress.CompanyName = companyName.Value;
                    }

                    XmlAttribute? addressComplement = element.Attributes["LOGRADOURO-COMPLEMENTO"];

                    if (addressComplement is not null)
                    {
                        academicResearcher.ProfessionalAddress.AddressComplement = addressComplement.Value;
                    }

                    XmlAttribute? country = element.Attributes["PAIS"];

                    if (country is not null)
                    {
                        academicResearcher.ProfessionalAddress.Country = country.Value;
                    }

                    XmlAttribute? state = element.Attributes["UF"];

                    if (state is not null)
                    {
                        academicResearcher.ProfessionalAddress.State = state.Value;
                    }

                    XmlAttribute? zipCode = element.Attributes["CEP"];

                    if (zipCode is not null)
                    {
                        academicResearcher.ProfessionalAddress.ZipCode = zipCode.Value;
                    }

                    XmlAttribute? city = element.Attributes["CIDADE"];

                    if (city is not null)
                    {
                        academicResearcher.ProfessionalAddress.City = city.Value;
                    }

                    XmlAttribute? district = element.Attributes["BAIRRO"];

                    if (district is not null)
                    {
                        academicResearcher.ProfessionalAddress.District = district.Value;
                    }

                    XmlAttribute? ddd = element.Attributes["DDD"];

                    if (ddd is not null)
                    {
                        academicResearcher.ProfessionalAddress.DDD = ddd.Value;
                    }

                    XmlAttribute? phoneNumber = element.Attributes["TELEFONE"];

                    if (phoneNumber is not null)
                    {
                        academicResearcher.ProfessionalAddress.PhoneNumber = phoneNumber.Value;
                    }

                    XmlAttribute? fax = element.Attributes["FAX"];

                    if (fax is not null)
                    {
                        academicResearcher.ProfessionalAddress.Fax = fax.Value;
                    }

                    XmlAttribute? poBox = element.Attributes["CAIXA-POSTAL"];

                    if (poBox is not null)
                    {
                        academicResearcher.ProfessionalAddress.POBox = poBox.Value;
                    }

                    XmlAttribute? homePage = element.Attributes["HOME-PAGE"];

                    if (homePage is not null)
                    {
                        academicResearcher.ProfessionalAddress.HomePage = homePage.Value;
                    }
                }
            }
        }
    }
}