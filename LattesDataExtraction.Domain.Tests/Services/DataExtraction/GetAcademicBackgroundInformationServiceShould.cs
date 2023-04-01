using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using System.Xml;

namespace LattesDataExtraction.Domain.Tests.Services.DataExtraction
{
    internal class GetAcademicBackgroundInformationServiceShould
    {
        private IGetDataInformationService getAcademicBackgroundInformationService;

        private string academicResearcherFilePath;

        private XmlDocument academicResearcherDocument;

        [SetUp]
        public void SetUp()
        {
            academicResearcherFilePath = @"C:\useful\researcher.xml";

            academicResearcherDocument = new XmlDocument();

            getAcademicBackgroundInformationService = new GetAcademicBackgroundInformationService();
        }

        [Test]
        public void Get_Information_From_Xml_Document()
        {
            #region Arrange

            academicResearcherDocument.Load(academicResearcherFilePath);

            AcademicResearcher academicResearcher = new();

            #endregion

            #region Act

            getAcademicBackgroundInformationService.GetInformation(academicResearcher, academicResearcherDocument);

            #endregion

            #region Assert

            int expectedAcademicBackgroundCount = 8;

            Assert.That(academicResearcher, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(academicResearcher.AcademicBackgrounds.Count, Is.EqualTo(expectedAcademicBackgroundCount));
            });

            #endregion
        }
    }
}