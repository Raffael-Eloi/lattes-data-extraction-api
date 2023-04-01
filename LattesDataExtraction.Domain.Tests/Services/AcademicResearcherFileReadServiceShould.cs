using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using LattesDataExtraction.Domain.Services;

namespace LattesDataExtraction.Domain.Tests.Services
{
    public class AcademicResearcherFileReadServiceShould
    {
        private IAcademicResearcherFileReadService academicResearcherFileReadService;

        [SetUp]
        public void Setup() 
        {
            academicResearcherFileReadService = new AcademicResearcherFileReadService();
        }

        [Test]
        public void Get_Curriculum_Vitae_Information_From_File()
        {
            #region Arrange

            var academicResearcherFile = @"C:\useful\researcher.xml";

            #endregion

            #region Act

            AcademicResearch? academicResearcher = academicResearcherFileReadService.GetAcademicInformation(academicResearcherFile);

            #endregion

            #region Assert

            string expectedIdentifierNumber = "7309417394410594";

            Assert.That(academicResearcher, Is.Not.Null);
            Assert.That(academicResearcher.IdentifierNumber, Is.EqualTo(expectedIdentifierNumber));

            #endregion
        }

        [Test]
        public void Get_General_Data_Information_From_File()
        {
            #region Arrange

            var academicResearcherFile = @"C:\useful\researcher.xml";

            #endregion

            #region Act

            AcademicResearch? academicResearcher = academicResearcherFileReadService.GetAcademicInformation(academicResearcherFile);

            #endregion

            #region Assert

            string expectedFullName = "Fabiano Fagundes";
            string expectedCitationName = "FAGUNDES, Fabiano;FAGUNDES, FABIANO";
            string expectedNationality = "B";
            string expectedCountryOfBirth = "Brasil";
            string expectedStateOfBirth = "SC";
            string expectedCityOfBirth = "Florianópolis";
            string expectedCountryCode = "BRA";;
            string expectedNationalityCountry = "Brasil";
            string expectedOrcidId = "https://orcid.org/0000-0001-9006-6238";

            Assert.That(academicResearcher, Is.Not.Null);
            
            Assert.Multiple(() =>
            {
                Assert.That(academicResearcher.FullName, Is.EqualTo(expectedFullName));
                Assert.That(academicResearcher.CitationName, Is.EqualTo(expectedCitationName));
                Assert.That(academicResearcher.Nationality, Is.EqualTo(expectedNationality));
                Assert.That(academicResearcher.CountryOfBirth, Is.EqualTo(expectedCountryOfBirth));
                Assert.That(academicResearcher.StateOfBirth, Is.EqualTo(expectedStateOfBirth));
                Assert.That(academicResearcher.CityOfBirth, Is.EqualTo(expectedCityOfBirth));
                Assert.That(academicResearcher.CountryCode, Is.EqualTo(expectedCountryCode));
                Assert.That(academicResearcher.NationalityCountry, Is.EqualTo(expectedNationalityCountry));
                Assert.That(academicResearcher.OrcidId, Is.EqualTo(expectedOrcidId));
            });

            #endregion
        }
        
        [Test]
        public void Get_Professional_Description_Information_From_File()
        {
            #region Arrange

            var academicResearcherFile = @"C:\useful\researcher.xml";

            #endregion

            #region Act

            AcademicResearch? academicResearcher = academicResearcherFileReadService.GetAcademicInformation(academicResearcherFile);

            #endregion

            #region Assert

            string expectedProfessionalDescription = @"Bacharel em Ciências da Computação pela Universidade Federal de Santa Catarina - UFSC (1995) e em Psicologia pelo Centro Universitário Luterano de Palmas - CEULP/ULBRA (2012) , com especialização em Redes de Computadores e Inteligência Artificial (2002) e mestrado em Ciências da Computação também pela Universidade Federal de Santa Catarina (2002). Está cursando doutorado em Ensino de Ciências e Matemática pelo PPGECIM-ULBRA. Atualmente é Professor do Centro Universitário Luterano de Palmas nos Cursos de Bacharelado em Sistemas de Informação, Ciência da Computação e Engenharia de Software e também Coordenador Adjunto do curso de Engenharia de Software. Participa dos Conselhos dos Cursos de Sistemas de Informação, Ciência da Computação e Engenharia de Software. É membro ativo do Conselho de Ensino, Pesquisa e extensão (CONSEPE) e do Conselho Superior (CONSUP), tendo participado do Comitê Científico e coordenado a Comissão Própria de Avaliação do CEULP/ULBRA. Tem pesquisas relacionadas à Tecnologia e Qualidade de Vida bem como em Novas Tecnologias Aplicadas na Educação.";

            Assert.That(academicResearcher, Is.Not.Null);
            
            Assert.Multiple(() =>
            {
                Assert.That(academicResearcher.ProfessionalDescription, Is.EqualTo(expectedProfessionalDescription));
            });

            #endregion
        }

        [Test]
        public void Get_Professional_Address_Information_From_File()
        {
            #region Arrange

            var academicResearcherFile = @"C:\useful\researcher.xml";

            #endregion

            #region Act

            AcademicResearch? academicResearcher = academicResearcherFileReadService.GetAcademicInformation(academicResearcherFile);

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
            string expectedPhoneNumber= "32198081";
            string expectedFax= "32198000";
            string expectedPOBox= "160";
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