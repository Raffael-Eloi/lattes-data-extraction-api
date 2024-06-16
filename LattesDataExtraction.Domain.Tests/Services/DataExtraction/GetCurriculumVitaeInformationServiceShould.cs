using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using LattesDataExtraction.Domain.Services.DataExtraction;
using LattesDataExtraction.Domain.Tests.Helpers;
using System.Xml;

namespace LattesDataExtraction.Domain.Tests.Services.DataExtraction
{
    public class GetCurriculumVitaeInformationServiceShould
    {
        private IGetDataInformationService getCurriculumVitaeInformationService;

        private string academicResearcherFilePath;

        private XmlDocument academicResearcherDocument;

        [SetUp] 
        public void SetUp() 
        {
            academicResearcherFilePath = GetAcademicResearcherFilePath.Get();

            academicResearcherDocument = new XmlDocument();

            getCurriculumVitaeInformationService = new GetCurriculumVitaeInformationService();
        }
        
        [Test]
        public void Get_Information_From_Xml_Document()
        {
            #region Arrange

            academicResearcherDocument.Load(academicResearcherFilePath);

            AcademicResearcher academicResearcher = new();

            #endregion

            #region Act

            getCurriculumVitaeInformationService.GetInformation(academicResearcher, academicResearcherDocument);

            #endregion

            #region Assert

            string prefix = "http://lattes.cnpq.br/";
            string expectedIdentifierNumber = "7309417394410594";
            string expectedLattesId = prefix + expectedIdentifierNumber;

            Assert.That(academicResearcher, Is.Not.Null);
            Assert.That(academicResearcher.IdentifierNumber, Is.EqualTo(expectedIdentifierNumber));
            Assert.That(academicResearcher.LattesId, Is.EqualTo(expectedLattesId));

            #endregion
        }
    }
}