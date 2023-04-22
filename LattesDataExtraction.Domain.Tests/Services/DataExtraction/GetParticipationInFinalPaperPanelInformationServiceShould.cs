using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using LattesDataExtraction.Domain.Services.DataExtraction;
using System.Xml;

namespace LattesDataExtraction.Domain.Tests.Services.DataExtraction
{
    internal class GetParticipationInFinalPaperPanelInformationServiceShould
    {
        private IGetDataInformationService getParticipationInFinalPaperPanelInformationService;

        private string academicResearcherFilePath;

        private XmlDocument academicResearcherDocument;

        [SetUp]
        public void SetUp()
        {
            academicResearcherFilePath = @"C:\useful\researcher.xml";

            academicResearcherDocument = new XmlDocument();

            getParticipationInFinalPaperPanelInformationService = new GetParticipationInFinalPaperPanelInformationService();
        }

        [Test]
        public void Get_Information_From_Xml_Document()
        {
            #region Arrange

            academicResearcherDocument.Load(academicResearcherFilePath);

            AcademicResearcher academicResearcher = new();

            #endregion

            #region Act

            getParticipationInFinalPaperPanelInformationService.GetInformation(academicResearcher, academicResearcherDocument);

            #endregion

            #region Assert

            string expectedNatureOfWork = "Graduação";
            string expectedTitle = "Avaliação de Episódios Depressivos Utilizando o Algoritmo de aprendizado de Máquina C4.5";
            int expectedWorkYear = 2000;
            string expectedCountry = "Brasil";
            string expectedLanguage = "Português";

            string expectedCandidateFullName = "Eunicelha de Sousa Lemos";
            string expectedInstitutionCode = "000100000991";
            string expectedInstitutionName = "Centro Universitário Luterano de Palmas";
            string expectedCourseCode = "90000003";
            string expectedCourseName = "Sistemas de Informação";

            string expectedFirstParticipantFullName = "Parcilene Fernandes de Brito";
            string expectedFirstParticipantCitationName = "BRITO, Parcilene Fernandes de";
            string expectedFirstParticipantCnpqId = "2507709383353551";
            
            string expectedSecondParticipantFullName = "Thereza Patrícia Pereira Padilha";
            string expectedSecondParticipantCitationName = "PADILHA, Thereza Patrícia Pereira";

            string expectedFirstKnowlodgeAreaName = "CIENCIAS_EXATAS_E_DA_TERRA";
            string expectedFirstSubKnowlodgeAreaName = "Metodologia e Técnicas da Computação";
            string expectedFirstKnowlodgeAreaSpecialty = "Sistemas de Informação";

            Assert.That(academicResearcher.ParticipationOnFinalPaperPanel, Is.Not.Null);

            var participationInFinalPaperPanelVerification = academicResearcher.ParticipationOnFinalPaperPanel
                .FirstOrDefault(
                    x =>
                        x.NatureOfWork == expectedNatureOfWork &&
                        x.Title == expectedTitle &&
                        x.Year.Year == expectedWorkYear &&
                        x.Country == expectedCountry &&
                        x.Language == expectedLanguage &&
                        x.CandidateFullName == expectedCandidateFullName &&
                        x.InstitutionCode == expectedInstitutionCode &&
                        x.InstitutionName == expectedInstitutionName &&
                        x.CourseCode == expectedCourseCode &&
                        x.CourseName == expectedCourseName
                );

            Assert.That(participationInFinalPaperPanelVerification, Is.Not.Null);

            Assert.That(participationInFinalPaperPanelVerification.Participants.ToList(), Has.Count.GreaterThan(1));

            var isFirstParticipantInListOfParticipants = participationInFinalPaperPanelVerification.Participants
                .FirstOrDefault(
                    participant =>
                        participant.FullName == expectedFirstParticipantFullName &&
                        participant.CitationName == expectedFirstParticipantCitationName &&
                        participant.CNPQId == expectedFirstParticipantCnpqId
                 );

            Assert.That(isFirstParticipantInListOfParticipants, Is.Not.Null);
            
            var isSecondParticipantInListOfParticipants = participationInFinalPaperPanelVerification.Participants
                .FirstOrDefault(
                    participant =>
                        participant.FullName == expectedSecondParticipantFullName &&
                        participant.CitationName == expectedSecondParticipantCitationName
                 );

            Assert.That(isSecondParticipantInListOfParticipants, Is.Not.Null);


            Assert.That(participationInFinalPaperPanelVerification.KnowledgeAreas.ToList(), Has.Count.GreaterThanOrEqualTo(1));
            
            var isFirstKnowledgeAreaInListOfKnowledgeAreas = participationInFinalPaperPanelVerification.KnowledgeAreas
                .FirstOrDefault(
                    knowledgeArea =>
                        knowledgeArea.Name == expectedFirstKnowlodgeAreaName &&
                        knowledgeArea.SubAreaName == expectedFirstSubKnowlodgeAreaName &&
                        knowledgeArea.Specialty == expectedFirstKnowlodgeAreaSpecialty
                 );

            Assert.That(isFirstParticipantInListOfParticipants, Is.Not.Null);

            #endregion
        }
    }
}