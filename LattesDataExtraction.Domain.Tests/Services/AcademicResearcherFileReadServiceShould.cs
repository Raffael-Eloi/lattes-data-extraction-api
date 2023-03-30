namespace LattesDataExtraction.Domain.Tests.Services
{
    public class AcademicResearcherFileReadServiceShould
    {
        [Test]
        public void Get_Information_From_File()
        {
            #region Arrange

            var academicResearcherFile = @"C:\useful\researcher.xml";

            IAcademicResearcherFileReadService academicResearcherFileReadService = new AcademicResearcherFileReadService();

            #endregion

            #region Act

            AcademicResearch academicResearcher = academicResearcherFileReadService.GetAcademicInformation(academicResearcherFile);

            #endregion

            #region Assert

            Assert.That(academicResearcher, Is.Not.Null);

            #endregion
        }
    }
}