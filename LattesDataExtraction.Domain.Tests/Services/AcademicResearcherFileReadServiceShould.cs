using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using LattesDataExtraction.Domain.Services;

namespace LattesDataExtraction.Domain.Tests.Services
{
    public class AcademicResearcherFileReadServiceShould
    {
        [Test]
        public void Get_Curriculo_Vitae_Information_From_File()
        {
            #region Arrange

            var academicResearcherFile = @"C:\useful\researcher.xml";

            IAcademicResearcherFileReadService academicResearcherFileReadService = new AcademicResearcherFileReadService();

            #endregion

            #region Act

            AcademicResearch? academicResearcher = academicResearcherFileReadService.GetAcademicInformation(academicResearcherFile);

            #endregion

            #region Assert

            string identifierNumber = "7309417394410594";

            Assert.That(academicResearcher, Is.Not.Null);
            Assert.That(academicResearcher.IdentifierNumber, Is.EqualTo(identifierNumber));

            #endregion
        }
    }
}