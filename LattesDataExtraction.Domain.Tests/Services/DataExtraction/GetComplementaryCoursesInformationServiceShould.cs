using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using LattesDataExtraction.Domain.Services.DataExtraction;
using LattesDataExtraction.Domain.Tests.Helpers;
using System.Xml;

namespace LattesDataExtraction.Domain.Tests.Services.DataExtraction
{
    internal class GetComplementaryCoursesInformationServiceShould
    {
        private IGetDataInformationService getComplementaryCoursesInformationService;

        private string academicResearcherFilePath;

        private XmlDocument academicResearcherDocument;

        [SetUp]
        public void SetUp()
        {
            academicResearcherFilePath = GetAcademicResearcherFilePath.Get();

            academicResearcherDocument = new XmlDocument();

            getComplementaryCoursesInformationService = new GetComplementaryCoursesInformationService();
        }

        [Test]
        public void Get_Information_From_Xml_Document()
        {
            #region Arrange

            academicResearcherDocument.Load(academicResearcherFilePath);

            AcademicResearcher academicResearcher = new();

            #endregion

            #region Act

            getComplementaryCoursesInformationService.GetInformation(academicResearcher, academicResearcherDocument);

            #endregion

            #region Assert

            Assert.That(academicResearcher.ComplementaryCourses, Is.Not.Null);

            string expectedCourseName = "Reestruturação Pedagógica: Desafios para a Prática Docente";
            string expectedCourseCode = "90000024";
            string expectedCourseStatus = "CONCLUIDO";
            int expectedStartYear = 2020;
            int expectedEndYear = 2020;
            int expectedCourseDurationInHours = 3;
            string expectedInstitutionName = "Centro Universitário Luterano de Palmas";
            string expectedInstitutionCode = "377200000001";

            var complementaryCoursesVerification = academicResearcher.ComplementaryCourses
                .FirstOrDefault(
                    x =>
                        x.Name == expectedCourseName &&
                        x.Code == expectedCourseCode &&
                        x.Status == expectedCourseStatus &&
                        x.StartYear.Year == expectedStartYear &&
                        x.EndYear.Year == expectedEndYear &&
                        x.DurationInHours == expectedCourseDurationInHours &&
                        x.InstitutionName == expectedInstitutionName &&
                        x.InstitutionCode == expectedInstitutionCode
                );

            Assert.That(complementaryCoursesVerification, Is.Not.Null );

            #endregion
        }
    }
}