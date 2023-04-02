using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using System.Xml;

namespace LattesDataExtraction.Domain.Tests.Services.DataExtraction
{
    internal class GetPublishedArticlesInformationServiceShould
    {
        private IGetDataInformationService getPublishedArticlesInformationService;

        private string academicResearcherFilePath;

        private XmlDocument academicResearcherDocument;

        [SetUp]
        public void SetUp()
        {
            academicResearcherFilePath = @"C:\useful\researcher.xml";

            academicResearcherDocument = new XmlDocument();

            getPublishedArticlesInformationService = new GetPublishedArticlesInformationService();
        }

        [Test]
        public void Get_Published_Articles_Information_From_Xml_Document()
        {
            #region Arrange

            academicResearcherDocument.Load(academicResearcherFilePath);

            AcademicResearcher academicResearcher = new();

            #endregion

            #region Act

            getPublishedArticlesInformationService.GetInformation(academicResearcher, academicResearcherDocument);

            #endregion

            #region Assert

            string expectedTitle = "Barriers Faced by Women in Software Development Projects";
            int expectedYear = 2019;
            string expectedLanguage = "Inglês";
            string expectedDOI = "10.3390/info10100309";
            string expectedISSN = "20782489";
            string expectedSeries = "10";
            string expectedVolume = "10";
            string expectedTitleOfJornalOrMagazine = "INFORMATION";
            int expectedInitialPage = 309;

            Author expectedFirstAuthor = new()
            {
                FullName = "ACCO TIVES, HELOISE",
                CitationName = "ACCO TIVES, HELOISE",
                CNPQId = "1023044011801001",
            };

            Author expectedSecondAuthor = new()
            {
                FullName = "BOGO MARIOTI, MADIANITA",
                CitationName = "BOGO MARIOTI, MADIANITA",
                CNPQId = "8179501249569570",
            };

            var scientificArticleVerification = academicResearcher.PublishedArticles
                .FirstOrDefault(
                    x =>
                        x.Title == expectedTitle &&
                        x.ArticleYear.Year == expectedYear &&
                        x.Language == expectedLanguage &&
                        x.DOI == expectedDOI &&
                        x.ISSN == expectedISSN &&
                        x.Series == expectedSeries &&
                        x.Volume == expectedVolume &&
                        x.TitleOfJornalOrMagazine == expectedTitleOfJornalOrMagazine &&
                        x.InitialPage == expectedInitialPage &&
                        x.Authors.Contains(expectedFirstAuthor) &&
                        x.Authors.Contains(expectedSecondAuthor)
                );

            Assert.Multiple(() =>
            {
                Assert.That(scientificArticleVerification, Is.Not.Null);
            });

            #endregion
        }
    }
}