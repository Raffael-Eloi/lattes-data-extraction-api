using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using LattesDataExtraction.Domain.Services.DataExtraction;
using System.Xml;

namespace LattesDataExtraction.Domain.Tests.Services.DataExtraction
{
    internal class GetCompletedOrientationInformationServiceShould
    {
        private IGetDataInformationService getCompletedOrientationInformationService;

        private string academicResearcherFilePath;

        private XmlDocument academicResearcherDocument;

        [SetUp]
        public void SetUp()
        {
            academicResearcherFilePath = @"C:\useful\researcher.xml";

            academicResearcherDocument = new XmlDocument();

            getCompletedOrientationInformationService = new GetCompletedOrientationInformationService();
        }

        [Test]
        public void Get_Information_From_Xml_Document()
        {
            #region Arrange

            academicResearcherDocument.Load(academicResearcherFilePath);

            AcademicResearcher academicResearcher = new();

            #endregion

            #region Act

            getCompletedOrientationInformationService.GetInformation(academicResearcher, academicResearcherDocument);

            #endregion

            #region Assert

            string expectedNatureOfWork = "TRABALHO_DE_CONCLUSAO_DE_CURSO_GRADUACAO";
            string expectedTitle = "Estruturação e Implementação de Parser para Hiperdocumentos Baseados em eXtensible Markup Language";
            int expectedWorkYear = 2001;
            string expectedCountry = "Brasil";
            string expectedLanguage = "Português";

            string expectedAcademicOrientedFullName = "Luciano Leite Teixeira";
            string expectedInstitutionCode = "000100000991";
            string expectedInstitutionName = "Centro Universitário Luterano de Palmas";
            string expectedCourseCode = "90000003";
            string expectedCourseName = "Sistemas de Informação";
            string expectedOrientationType = "ORIENTADOR_PRINCIPAL";

            string expectedFirstKeyWord = "XML";
            string expectedSecondKeyWord = "Parser";
            string expectedThirdKeyWord = "Hiperdocumentos";

            string expectedFirstKnowlodgeAreaName = "CIENCIAS_EXATAS_E_DA_TERRA";
            string expectedFirstSubKnowlodgeAreaName = "Metodologia e Técnicas da Computação";
            string expectedFirstKnowlodgeAreaSpecialty = "Multimídia";

            Assert.That(academicResearcher.CompletedOrientation, Is.Not.Null);

            var completedOrientationVerification = academicResearcher.CompletedOrientation
                .FirstOrDefault(
                    x =>
                        x.NatureOfWork == expectedNatureOfWork &&
                        x.Title == expectedTitle &&
                        x.Year.Year == expectedWorkYear &&
                        x.Country == expectedCountry &&
                        x.Language == expectedLanguage &&
                        x.AcademicOrientedFullName == expectedAcademicOrientedFullName &&
                        x.InstitutionCode == expectedInstitutionCode &&
                        x.InstitutionName == expectedInstitutionName &&
                        x.CourseCode == expectedCourseCode &&
                        x.CourseName == expectedCourseName &&
                        x.Type == expectedOrientationType
                );

            Assert.That(completedOrientationVerification, Is.Not.Null);

            Assert.That(completedOrientationVerification.KeyWords, Is.Not.Null);
            
            Assert.Multiple(() =>
            {
                Assert.That(completedOrientationVerification.KeyWords, Has.Some.Matches<KeyWord>(keyword => keyword.Name == expectedFirstKeyWord));
                Assert.That(completedOrientationVerification.KeyWords, Has.Some.Matches<KeyWord>(keyword => keyword.Name == expectedSecondKeyWord));
                Assert.That(completedOrientationVerification.KeyWords, Has.Some.Matches<KeyWord>(keyword => keyword.Name == expectedThirdKeyWord));
            });

            var isFirstKnowledgeAreaInListOfKnowledgeAreas = completedOrientationVerification.KnowledgeAreas
                .FirstOrDefault(
                    knowledgeArea =>
                        knowledgeArea.Name == expectedFirstKnowlodgeAreaName &&
                        knowledgeArea.SubAreaName == expectedFirstSubKnowlodgeAreaName &&
                        knowledgeArea.Specialty == expectedFirstKnowlodgeAreaSpecialty
                 );

            Assert.That(isFirstKnowledgeAreaInListOfKnowledgeAreas, Is.Not.Null);

            #endregion
        }
    }
}