using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using LattesDataExtraction.Domain.Services.DataExtraction;
using LattesDataExtraction.Domain.Tests.Helpers;
using System.Xml;

namespace LattesDataExtraction.Domain.Tests.Services.DataExtraction
{
    internal class GetBooksChaptersPublishedInformationServiceShould
    {
        private IGetDataInformationService getBooksChaptersPublishedInformationService;

        private string academicResearcherFilePath;

        private XmlDocument academicResearcherDocument;

        [SetUp]
        public void SetUp()
        {
            academicResearcherFilePath = GetAcademicResearcherFilePath.Get();

            academicResearcherDocument = new XmlDocument();

            getBooksChaptersPublishedInformationService = new GetBooksChaptersPublishedInformationService();
        }

        [Test]
        public void Get_Information_From_Xml_Document()
        {
            #region Arrange

            academicResearcherDocument.Load(academicResearcherFilePath);

            AcademicResearcher academicResearcher = new();

            #endregion

            #region Act

            getBooksChaptersPublishedInformationService.GetInformation(academicResearcher, academicResearcherDocument);

            #endregion

            #region Assert

            string expectedBookTitle = "Advances in Intelligent Systems and Computing";
            string expectedChapterTitle = "Mining ENADE Data from the Ulbra Network Institution";
            string expectedType = "Capítulo de livro publicado";
            int expectedYear = 2018;
            string expectedPublisherCountry = "Brasil";
            string expectedPublisherName = "Springer International Publishing";
            string expectedHomePageLink = "http://link.springer.com/10.1007/978-3-319-77028-4_39";
            string expectedDOI = "10.1007/978-3-319-77028-4_39";
            string expectedISBN = "9783319770277";
            string expectedLanguage = "Português";
            int expectedInitialPage = 287;
            int expectedFinalPage = 294;

            Author expectedFirstAuthor = new()
            {
                FullName = "Fabiano Fagundes",
                CitationName = "FAGUNDES, FABIANO",
            };

            Author expectedSecondAuthor = new()
            {
                FullName = "Ladeira, Marcelo",
                CitationName = "Ladeira, Marcelo",
            };

            Assert.That(academicResearcher.BooksChaptersPublished, Is.Not.Null);

            var booksChaptersPublishedVerification = academicResearcher.BooksChaptersPublished
                .FirstOrDefault(
                    x =>
                        x.BookTitle == expectedBookTitle &&
                        x.ChapterTitle == expectedChapterTitle &&
                        x.Type == expectedType &&
                        x.Year.Year == expectedYear &&
                        x.PublisherCountry == expectedPublisherCountry &&
                        x.Language == expectedLanguage &&
                        x.PublisherName == expectedPublisherName &&
                        x.HomePageLink == expectedHomePageLink &&
                        x.DOI == expectedDOI &&
                        x.ISBN == expectedISBN &&
                        x.InitialPage == expectedInitialPage &&
                        x.FinalPage == expectedFinalPage
                );

            Assert.That(booksChaptersPublishedVerification, Is.Not.Null);

            Assert.That(booksChaptersPublishedVerification.Authors, Is.Not.Null);

            var isFirstAuthorInListOfAuthors = booksChaptersPublishedVerification.Authors
                .FirstOrDefault(
                    author =>
                        author.FullName == expectedFirstAuthor.FullName &&
                        author.CitationName == expectedFirstAuthor.CitationName
                 );

            var isSecondAuthorInListOfAuthors = booksChaptersPublishedVerification.Authors
                .FirstOrDefault(
                    author =>
                        author.FullName == expectedSecondAuthor.FullName &&
                        author.CitationName == expectedSecondAuthor.CitationName
                 );

            Assert.Multiple(() =>
            {
                Assert.That(isFirstAuthorInListOfAuthors, Is.Not.Null);
                Assert.That(isSecondAuthorInListOfAuthors, Is.Not.Null);
            });

            #endregion
        }
    }
}