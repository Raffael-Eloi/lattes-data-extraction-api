using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using LattesDataExtraction.Domain.Services.DataExtraction;
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
        public void Get_Graduation_Information_From_Xml_Document()
        {
            #region Arrange

            academicResearcherDocument.Load(academicResearcherFilePath);

            AcademicResearcher academicResearcher = new();

            #endregion

            #region Act

            getAcademicBackgroundInformationService.GetInformation(academicResearcher, academicResearcherDocument);

            #endregion

            #region Assert

            string espectedPsychologyCourseCode = "90000008";
            string espectedPsychologyCourseName = "Psicologia";

            string espectedComputerScienceCourseCode = "90000001";
            string espectedComputerScienceCourseName = "Ciências da Computação";


            var psychologyVerification = academicResearcher.AcademicBackgrounds.FirstOrDefault(x => x.CourseCode == espectedPsychologyCourseCode && x.CourseName == espectedPsychologyCourseName);

            var computerScienceVerification = academicResearcher.AcademicBackgrounds.FirstOrDefault(x => x.CourseCode == espectedComputerScienceCourseCode && x.CourseName == espectedComputerScienceCourseName);

            Assert.That(academicResearcher, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(psychologyVerification, Is.Not.Null);
                Assert.That(computerScienceVerification, Is.Not.Null);
            });

            #endregion
        }

        [Test]
        public void Get_Specialization_Information_From_Xml_Document()
        {
            #region Arrange

            academicResearcherDocument.Load(academicResearcherFilePath);

            AcademicResearcher academicResearcher = new();

            #endregion

            #region Act

            getAcademicBackgroundInformationService.GetInformation(academicResearcher, academicResearcherDocument);

            #endregion

            #region Assert

            string espectedTechCourseCode = "90000016";
            string espectedTechCourseName = "Tecnologias Digitais Aplicadas à Educação";

            string espectedPsychologyCourseCode = "90000014";
            string espectedPsychologyCourseName = "Psicologia positiva, ciência do bem-estar e autorrealização";


            var techCourseVerification = academicResearcher.AcademicBackgrounds.FirstOrDefault(x => x.CourseCode == espectedTechCourseCode && x.CourseName == espectedTechCourseName);

            var psychologyVerification = academicResearcher.AcademicBackgrounds.FirstOrDefault(x => x.CourseCode == espectedPsychologyCourseCode && x.CourseName == espectedPsychologyCourseName);

            Assert.That(academicResearcher, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(techCourseVerification, Is.Not.Null);
                Assert.That(psychologyVerification, Is.Not.Null);
            });

            #endregion
        }
    }
}