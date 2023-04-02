using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using LattesDataExtraction.Domain.Services.DataExtraction;
using System.Xml;

namespace LattesDataExtraction.Domain.Tests.Services.DataExtraction
{
    internal class GetBooksOrganizedOrPublishedInformationServiceShould
    {
        private IGetDataInformationService getBooksOrganizedOrPublishedInformationService;

        private string academicResearcherFilePath;

        private XmlDocument academicResearcherDocument;

        [SetUp]
        public void SetUp()
        {
            academicResearcherFilePath = @"C:\useful\researcher.xml";

            academicResearcherDocument = new XmlDocument();

            getBooksOrganizedOrPublishedInformationService = new GetBooksOrganizedOrPublishedInformationService();
        }

        [Test]
        public void Get_Information_From_Xml_Document()
        {
            #region Arrange

            academicResearcherDocument.Load(academicResearcherFilePath);

            AcademicResearcher academicResearcher = new();

            #endregion

            #region Act

            getBooksOrganizedOrPublishedInformationService.GetInformation(academicResearcher, academicResearcherDocument);

            #endregion

            #region Assert

            string expectedTitle = "Anais do II Encontro de Estudantes de Informática do Estado do Tocantins";
            string expectedOrigin = "ANAIS";
            string expectedType = "LIVRO_ORGANIZADO_OU_EDICAO";
            int expectedYear = 2000;
            string expectedPublishCountry = "Brasil";
            string expectedPublishCity = "Palmas";
            string expectedLanguage = "Português";
            int expectedNumbersOfVolumes = 1;
            int expectedNumbersOfPages = 146;

            Author expectedFirstAuthor = new()
            {
                FullName = "Fabiano Fagundes",
                CitationName = "FAGUNDES, Fabiano;FAGUNDES, FABIANO",
                CNPQId = "7309417394410594",
            };

            Author expectedSecondAuthor = new()
            {
                FullName = "Parcilene Fernandes de Brito",
                CitationName = "BRITO, Parcilene Fernandes de",
                CNPQId = "2507709383353551",
            };

            Assert.That(academicResearcher.BooksPublishedOrOrganized, Is.Not.Null);

            var booksOrganizedOrPublishedVerification = academicResearcher.BooksPublishedOrOrganized
                .FirstOrDefault(
                    x =>
                        x.Title == expectedTitle &&
                        x.Type == expectedType &&
                        x.Origin == expectedOrigin &&
                        x.Year.Year == expectedYear &&
                        x.PublishCountry == expectedPublishCountry &&
                        x.PublishCity == expectedPublishCity &&
                        x.Language == expectedLanguage &&
                        x.NumberOfVolumes == expectedNumbersOfVolumes &&
                        x.NumberOfPages == expectedNumbersOfPages
                );

            Assert.That(booksOrganizedOrPublishedVerification, Is.Not.Null);

            Assert.That(booksOrganizedOrPublishedVerification.Authors, Is.Not.Null);

            var isFirstAuthorInListOfAuthors = booksOrganizedOrPublishedVerification.Authors
                .FirstOrDefault(
                    author =>
                        author.FullName == expectedFirstAuthor.FullName &&
                        author.CitationName == expectedFirstAuthor.CitationName &&
                        author.CNPQId == expectedFirstAuthor.CNPQId
                 );

            var isSecondAuthorInListOfAuthors = booksOrganizedOrPublishedVerification.Authors
                .FirstOrDefault(
                    author =>
                        author.FullName == expectedSecondAuthor.FullName &&
                        author.CitationName == expectedSecondAuthor.CitationName &&
                        author.CNPQId == expectedSecondAuthor.CNPQId
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