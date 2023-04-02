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

            string expectedPsychologyCourseCode = "90000008";
            string expectedPsychologyCourseName = "Psicologia";

            string expectedComputerScienceCourseCode = "90000001";
            string expectedComputerScienceCourseName = "Ciências da Computação";


            var psychologyVerification = academicResearcher.AcademicBackgrounds
                .FirstOrDefault(x => x.CourseCode == expectedPsychologyCourseCode && 
                    x.CourseName == expectedPsychologyCourseName && 
                    x.AcademicBackgroundType == Enums.AcademicBackgroundType.Graduation);

            var computerScienceVerification = academicResearcher.AcademicBackgrounds
                .FirstOrDefault(x => x.CourseCode == expectedComputerScienceCourseCode 
                    && x.CourseName == expectedComputerScienceCourseName &&
                    x.AcademicBackgroundType == Enums.AcademicBackgroundType.Graduation);

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

            string expectedTechCourseCode = "90000016";
            string expectedTechCourseName = "Tecnologias Digitais Aplicadas à Educação";

            string expectedPsychologyCourseCode = "90000014";
            string expectedPsychologyCourseName = "Psicologia positiva, ciência do bem-estar e autorrealização";


            var techCourseVerification = academicResearcher.AcademicBackgrounds
                .FirstOrDefault(x => x.CourseCode == expectedTechCourseCode 
                && x.CourseName == expectedTechCourseName &&
                x.AcademicBackgroundType == Enums.AcademicBackgroundType.Specialization);

            var psychologyVerification = academicResearcher.AcademicBackgrounds
                .FirstOrDefault(x => x.CourseCode == expectedPsychologyCourseCode && 
                x.CourseName == expectedPsychologyCourseName &&
                x.AcademicBackgroundType == Enums.AcademicBackgroundType.Specialization);

            Assert.That(academicResearcher, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(techCourseVerification, Is.Not.Null);
                Assert.That(psychologyVerification, Is.Not.Null);
            });

            #endregion
        }

        [Test]
        public void Get_Masters_Information_From_Xml_Document()
        {
            #region Arrange

            academicResearcherDocument.Load(academicResearcherFilePath);

            AcademicResearcher academicResearcher = new();

            #endregion

            #region Act

            getAcademicBackgroundInformationService.GetInformation(academicResearcher, academicResearcherDocument);

            #endregion

            #region Assert

            string expectedComputerScienceCourseCode = "41000250";
            string expectedComputerScienceCourseName = "Ciências da Computação";
            string expectedCourseCodeCapes = "41001010025P2";
            string expectedIdOasis = "UFSC_2bbad15662a708439d143030725d9bf5";
            string expectedMasterThesis = "Especificação de uma meta-linguagem para sincronização multimídia";
            string expectedAdvisorName = "José Mazzucco Júnior";
            string expectedAdvisorCode = "1360318693097013";

            var mastersVerification = academicResearcher.AcademicBackgrounds
                .FirstOrDefault(x => x.CourseCode == expectedComputerScienceCourseCode
                && x.CourseName == expectedComputerScienceCourseName &&
                x.CourseCodeCapes == expectedCourseCodeCapes &&
                x.IdOasis == expectedIdOasis &&
                x.AdvisorName == expectedAdvisorName && 
                x.AdvisorCode == expectedAdvisorCode &&
                x.MasterThesis == expectedMasterThesis &&
                x.AcademicBackgroundType == Enums.AcademicBackgroundType.Master);

            Assert.That(academicResearcher, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(mastersVerification, Is.Not.Null);
            });

            #endregion
        }
    }
}