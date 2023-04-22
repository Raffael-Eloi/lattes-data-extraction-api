using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using LattesDataExtraction.Domain.Services.DataExtraction;
using System.Xml;

namespace LattesDataExtraction.Domain.Tests.Services.DataExtraction
{
    internal class GetOrientationInProgressInformationServiceShould
    {
        private IGetDataInformationService getOrientationInProgressInformationService;

        private string academicResearcherFilePath;

        private XmlDocument academicResearcherDocument;

        [SetUp]
        public void SetUp()
        {
            academicResearcherFilePath = @"C:\useful\researcher.xml";

            academicResearcherDocument = new XmlDocument();

            getOrientationInProgressInformationService = new GetOrientationInProgressInformationService();
        }

        [Test]
        public void Get_Information_From_Xml_Document()
        {
            #region Arrange

            academicResearcherDocument.Load(academicResearcherFilePath);

            AcademicResearcher academicResearcher = new();

            #endregion

            #region Act

            getOrientationInProgressInformationService.GetInformation(academicResearcher, academicResearcherDocument);

            #endregion

            #region Assert

            string expectedNatureOfWork = "Iniciação Científica";
            string expectedTitle = "Desenvolvimento de um Portal a partir da Definição de uma Ontologia para o Domínio &quot;Fauna e Flora&quot; do Parque Estadual do Cantão";
            int expectedYear = 2007;
            string expectedCountry = "Brasil";
            string expectedLanguage = "Português";

            string expectedAcademicOrientedFullName = "Rafael Gomes Amorim";
            string expectedInstitutionCode = "000100000991";
            string expectedInstitutionName = "Centro Universitário Luterano de Palmas";
            string expectedCourseCode = "90000003";
            string expectedCourseName = "Sistemas de Informação";

            Assert.That(academicResearcher.OrientationInProgress, Is.Not.Null);

            var orientationInProgressVerification = academicResearcher.OrientationInProgress
                .FirstOrDefault(
                    x =>
                        x.NatureOfWork == expectedNatureOfWork &&
                        x.Title == expectedTitle &&
                        x.Year.Year == expectedYear &&
                        x.Country == expectedCountry &&
                        x.Language == expectedLanguage &&
                        x.AcademicOrientedFullName == expectedAcademicOrientedFullName &&
                        x.InstitutionCode == expectedInstitutionCode &&
                        x.InstitutionName == expectedInstitutionName &&
                        x.CourseCode == expectedCourseCode &&
                        x.CourseName == expectedCourseName
                );

            Assert.That(orientationInProgressVerification, Is.Not.Null);

            #endregion
        }
    }
}