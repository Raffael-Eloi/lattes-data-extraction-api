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
            string expectedPsychologyAreaCourseCode = "90000008";
            string expectedPsychologyCourseName = "Psicologia";
            string expectedPsychologyFinalPaperTitle = "LUTO NO VIRTUAL: verificação da relação entre as fases do luto e a extinção operante a partir da vivência compartilhada em uma rede social virtual";
            string expectedPsychologyCourseStatus = "CONCLUIDO";
            string expectedPsychologyInstituitionName = "Centro Universitário Luterano de Palmas";
            string expectedPsychologyInstituitionCode = "000100000991";
            int expectedPsychologyStartYear = 2006;
            int expectedPsychologyEndYear = 2012;

            string expectedComputerScienceCourseCode = "90000001";
            string expectedComputerScienceAreaCourseCode = "90000001";
            string expectedComputerScienceCourseName = "Ciências da Computação";
            string expectedComputerScienceFinalPaperTitle = "Revista Multimídia sobre a Ilha de Santa Catarina";
            string expectedComputerScienceCourseStatus = "CONCLUIDO";
            string expectedComputerScienceInstituitionName = "Universidade Federal de Santa Catarina";
            string expectedComputerScienceInstituitionCode = "004300000009";
            int expectedComputerScienceStartYear = 1991;
            int expectedComputerScienceEndYear = 1995;


            Assert.That(academicResearcher.AcademicBackground, Is.Not.Null);

            var psychologyVerification = academicResearcher.AcademicBackground
                .FirstOrDefault(
                    x => 
                        x.CourseCode == expectedPsychologyCourseCode &&
                        x.AreaCourseCode == expectedPsychologyAreaCourseCode &&
                        x.CourseName == expectedPsychologyCourseName &&
                        x.InstituitionCode == expectedPsychologyInstituitionCode &&
                        x.InstituitionName == expectedPsychologyInstituitionName &&
                        x.FinalPaperTitle == expectedPsychologyFinalPaperTitle &&
                        x.CourseStatus == expectedPsychologyCourseStatus &&
                        x.StartYear.Year == expectedPsychologyStartYear && 
                        x.EndYear.Year == expectedPsychologyEndYear && 
                        x.AcademicBackgroundType == Enums.AcademicBackgroundType.Graduation);

            var computerScienceVerification = academicResearcher.AcademicBackground
                .FirstOrDefault(
                    x => 
                        x.CourseCode == expectedComputerScienceCourseCode &&
                        x.AreaCourseCode == expectedComputerScienceAreaCourseCode &&
                        x.CourseName == expectedComputerScienceCourseName &&
                        x.InstituitionCode == expectedComputerScienceInstituitionCode &&
                        x.InstituitionName == expectedComputerScienceInstituitionName &&
                        x.FinalPaperTitle == expectedComputerScienceFinalPaperTitle &&
                        x.CourseStatus == expectedComputerScienceCourseStatus &&
                        x.StartYear.Year == expectedComputerScienceStartYear &&
                        x.EndYear.Year == expectedComputerScienceEndYear &&
                        x.AcademicBackgroundType == Enums.AcademicBackgroundType.Graduation);

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

            Assert.That(academicResearcher.AcademicBackground, Is.Not.Null);

            var techCourseVerification = academicResearcher.AcademicBackground
                .FirstOrDefault(
                    x =>
                        x.CourseCode == expectedTechCourseCode &&
                        x.CourseName == expectedTechCourseName &&
                        x.AcademicBackgroundType == Enums.AcademicBackgroundType.Specialization);

            var psychologyVerification = academicResearcher.AcademicBackground
                .FirstOrDefault(
                    x => 
                        x.CourseCode == expectedPsychologyCourseCode && 
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
            string expectedKeyWord1 = "Sincronização Multimídia";
            string expectedKeyWord2 = "eXtensible Markup Language";
            string expectedKeyWord3 = "SMIL";
            string expectedKeyWord4 = "HTML+TIME";

            Assert.That(academicResearcher.AcademicBackground, Is.Not.Null);

            var mastersVerification = academicResearcher.AcademicBackground
                .FirstOrDefault(
                    x => 
                        x.CourseCode == expectedComputerScienceCourseCode && 
                        x.CourseName == expectedComputerScienceCourseName &&
                        x.CourseCodeCapes == expectedCourseCodeCapes &&
                        x.IdOasis == expectedIdOasis &&
                        x.AdvisorName == expectedAdvisorName && 
                        x.AdvisorCode == expectedAdvisorCode &&
                        x.MasterThesis == expectedMasterThesis &&
                        x.KeyWords.Contains(expectedKeyWord1) &&
                        x.KeyWords.Contains(expectedKeyWord2) &&
                        x.KeyWords.Contains(expectedKeyWord3) &&
                        x.KeyWords.Contains(expectedKeyWord4) &&
                        x.KeyWords.Count() == 4 &&
                        x.AcademicBackgroundType == Enums.AcademicBackgroundType.Master);

            Assert.Multiple(() =>
            {
                Assert.That(mastersVerification, Is.Not.Null);
            });

            #endregion
        }

        [Test]
        public void Get_Doctorate_Information_From_Xml_Document()
        {
            #region Arrange

            academicResearcherDocument.Load(academicResearcherFilePath);

            AcademicResearcher academicResearcher = new();

            #endregion

            #region Act

            getAcademicBackgroundInformationService.GetInformation(academicResearcher, academicResearcherDocument);

            #endregion

            #region Assert

            string expectedDoctorateCourseCode = "60017880";
            string expectedDoctorateCourseName = "Ensino de Ciências e Matemática";
            string expectedCourseCodeCapes = "42019010005P7";
            string expectedDoctorateThesis = "ChatGPT e inteligência artificial na educação: explorando a personalização do aprendizado e novas teorias de ensino e aprendizagem";
            string expectedAdvisorName = "Agostinho Serrano de Andrade Neto";
            string expectedAdvisorCode = "1253401330501170";

            Assert.That(academicResearcher.AcademicBackground, Is.Not.Null);

            var mastersVerification = academicResearcher.AcademicBackground
                .FirstOrDefault(
                    x =>
                        x.CourseCode == expectedDoctorateCourseCode &&
                        x.CourseName == expectedDoctorateCourseName &&
                        x.CourseCodeCapes == expectedCourseCodeCapes &&
                        x.AdvisorName == expectedAdvisorName &&
                        x.AdvisorCode == expectedAdvisorCode &&
                        x.DoctorateThesis == expectedDoctorateThesis &&
                        x.AcademicBackgroundType == Enums.AcademicBackgroundType.Doctorate);

            Assert.Multiple(() =>
            {
                Assert.That(mastersVerification, Is.Not.Null);
            });

            #endregion
        }
    }
}