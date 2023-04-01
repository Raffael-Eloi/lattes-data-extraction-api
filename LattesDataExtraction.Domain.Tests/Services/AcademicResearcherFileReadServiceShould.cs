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
    }
}