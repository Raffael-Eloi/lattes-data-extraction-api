using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using LattesDataExtraction.Domain.Services.DataExtraction;
using System.Xml;

namespace LattesDataExtraction.Domain.Tests.Services.DataExtraction
{
    internal class GetProfessionalAddressInformationServiceShould
    {
        private IGetDataInformationService getProfessionalAddressInformationService;

        private string academicResearcherFilePath;

        private XmlDocument academicResearcherDocument;

        [SetUp]
        public void SetUp()
        {
            academicResearcherFilePath = @"C:\useful\researcher.xml";

            academicResearcherDocument = new XmlDocument();

            getProfessionalAddressInformationService = new GetProfessionalAddressInformationService();
        }

        [Test]
        public void Get_Information_From_Xml_Document()
        {
            #region Arrange

            academicResearcherDocument.Load(academicResearcherFilePath);

            AcademicResearcher academicResearcher = new();

            #endregion

            #region Act

            getProfessionalAddressInformationService.GetInformation(academicResearcher, academicResearcherDocument);

            #endregion

            #region Assert

            string expectedCompanyCode = "000100000991";
            string expectedCompanyName = "Centro Universitário Luterano de Palmas";
            string expectedAddressComplement = "Av. Teotônio Segurado s/n";
            string expectedCountry = "Brasil";
            string expectedState = "TO";
            string expectedZipCode = "77054-970";
            string expectedCity = "Palmas";
            string expectedDistinct = "1501 SUL";
            string expectedDDD = "63";
            string expectedPhoneNumber = "32198081";
            string expectedFax = "32198000";
            string expectedPOBox = "160";
            string expectedHomePage = "http://www.ulbra-to.br";

            Assert.That(academicResearcher, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(academicResearcher.ProfessionalAddress.CompanyCode, Is.EqualTo(expectedCompanyCode));
                Assert.That(academicResearcher.ProfessionalAddress.CompanyName, Is.EqualTo(expectedCompanyName));
                Assert.That(academicResearcher.ProfessionalAddress.AddressComplement, Is.EqualTo(expectedAddressComplement));
                Assert.That(academicResearcher.ProfessionalAddress.Country, Is.EqualTo(expectedCountry));
                Assert.That(academicResearcher.ProfessionalAddress.State, Is.EqualTo(expectedState));
                Assert.That(academicResearcher.ProfessionalAddress.ZipCode, Is.EqualTo(expectedZipCode));
                Assert.That(academicResearcher.ProfessionalAddress.City, Is.EqualTo(expectedCity));
                Assert.That(academicResearcher.ProfessionalAddress.District, Is.EqualTo(expectedDistinct));
                Assert.That(academicResearcher.ProfessionalAddress.DDD, Is.EqualTo(expectedDDD));
                Assert.That(academicResearcher.ProfessionalAddress.PhoneNumber, Is.EqualTo(expectedPhoneNumber));
                Assert.That(academicResearcher.ProfessionalAddress.Fax, Is.EqualTo(expectedFax));
                Assert.That(academicResearcher.ProfessionalAddress.POBox, Is.EqualTo(expectedPOBox));
                Assert.That(academicResearcher.ProfessionalAddress.HomePage, Is.EqualTo(expectedHomePage));
            });

            #endregion
        }
    }
}
