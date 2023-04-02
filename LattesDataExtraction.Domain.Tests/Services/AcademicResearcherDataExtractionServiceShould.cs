using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using LattesDataExtraction.Domain.Factories;
using LattesDataExtraction.Domain.Services;

namespace LattesDataExtraction.Domain.Tests.Services
{
    public class AcademicResearcherDataExtractionServiceShould
    {
        private IAcademicResearcherDataExtractionService academicResearcherFileReadService;

        private IGetDataInformationFactory getDataInformationFactory;

        [SetUp]
        public void Setup() 
        {
            getDataInformationFactory = new GetDataInformationFactory();

            academicResearcherFileReadService = new AcademicResearcherDataExtractionService(getDataInformationFactory);
        }

        [Test]
        public void Extract_Curriculum_Vitae_Information_From_File()
        {
            #region Arrange

            var academicResearcherFile = @"C:\useful\researcher.xml";

            #endregion

            #region Act

            AcademicResearcher? academicResearcher = academicResearcherFileReadService.GetAcademicInformation(academicResearcherFile);

            #endregion

            #region Assert

            Assert.That(academicResearcher, Is.Not.Null);
            Assert.That(academicResearcher.IdentifierNumber, Is.Not.Null);

            #endregion
        }

        [Test]
        public void Extract_General_Data_Information_From_File()
        {
            #region Arrange

            var academicResearcherFile = @"C:\useful\researcher.xml";

            #endregion

            #region Act

            AcademicResearcher? academicResearcher = academicResearcherFileReadService.GetAcademicInformation(academicResearcherFile);

            #endregion

            #region Assert

            Assert.That(academicResearcher, Is.Not.Null);
            Assert.That(academicResearcher.FullName, Is.Not.Null);
            Assert.That(academicResearcher.CitationName, Is.Not.Null);
            Assert.That(academicResearcher.CountryOfBirth, Is.Not.Null);
            Assert.That(academicResearcher.StateOfBirth, Is.Not.Null);
            Assert.That(academicResearcher.CityOfBirth, Is.Not.Null);
            Assert.That(academicResearcher.OrcidId, Is.Not.Null);

            #endregion
        }
    }
}