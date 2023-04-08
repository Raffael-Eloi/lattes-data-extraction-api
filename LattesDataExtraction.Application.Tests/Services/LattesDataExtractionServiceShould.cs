using LattesDataExtraction.Domain.Factories;
using LattesDataExtraction.Domain.Services;
using System.Xml;

namespace LattesDataExtraction.Application.Tests.Services
{
    public class LattesDataExtractionServiceShould
    {
        private ILattesDataExtractionService lattesDataExtractionService;

        [SetUp]
        public void Setup()
        {
            GetDataInformationFactory factory = new();

            var academicResearcherDataExtractionService = new AcademicResearcherDataExtractionService(factory);

            lattesDataExtractionService = new LattesDataExtractionService(academicResearcherDataExtractionService);
        }

        [Test]
        public void Read_And_Get_Information_From_Xml_File()
        {
            #region Arrange

            var academicResearcherFilePath = @"C:\useful\researcher.xml";

            XmlDocument academicResearcherDocument = new();
            academicResearcherDocument.Load(academicResearcherFilePath);

            AddAcademicResearcherRequest request = new()
            {
                File = academicResearcherDocument
            };

            #endregion

            #region Act

            AddAcademicResearcherResponse response = lattesDataExtractionService.Extract(request);

            #endregion

            #region Assert

            Assert.That(response, Is.Not.Null);
            
            #endregion
        }
    }
}