using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using LattesDataExtraction.Domain.Factories;
using LattesDataExtraction.Domain.Services;
using System.Xml;

namespace LattesDataExtraction.Domain.Tests.Services
{
    internal class AcademicResearcherDataExtractionServiceShould
    {
        private IAcademicResearcherDataExtractionService academicResearcherFileReadService;

        private IGetDataInformationFactory getDataInformationFactory;

        private XmlDocument academicResearcherDocument;

        [SetUp]
        public void Setup() 
        {
            getDataInformationFactory = new GetDataInformationFactory();

            academicResearcherFileReadService = new AcademicResearcherDataExtractionService(getDataInformationFactory);

            var filePath = @"C:\useful\researcher.xml";

            academicResearcherDocument = new XmlDocument();

            academicResearcherDocument.Load(filePath);
        }

        [Test]
        public void Extract_Curriculum_Vitae_Information_From_File()
        {
            #region Arrange

            #endregion

            #region Act

            AcademicResearcher? academicResearcher = academicResearcherFileReadService.GetAcademicInformation(academicResearcherDocument);

            #endregion

            #region Assert

            Assert.That(academicResearcher, Is.Not.Null);

            Assert.That(academicResearcher.IdentifierNumber, Is.Not.Null);

            #endregion
        }

        [Test]
        public void Extract_General_Data_Information_From_File()
        {
            #region Arrange

            #endregion

            #region Act

            AcademicResearcher? academicResearcher = academicResearcherFileReadService.GetAcademicInformation(academicResearcherDocument);

            #endregion

            #region Assert

            Assert.That(academicResearcher, Is.Not.Null);
            
            Assert.Multiple(() =>
            {
                Assert.That(academicResearcher.FullName, Is.Not.Null);
                Assert.That(academicResearcher.CitationName, Is.Not.Null);
                Assert.That(academicResearcher.CountryOfBirth, Is.Not.Null);
                Assert.That(academicResearcher.StateOfBirth, Is.Not.Null);
                Assert.That(academicResearcher.CityOfBirth, Is.Not.Null);
                Assert.That(academicResearcher.OrcidId, Is.Not.Null);
            });

            #endregion
        }

        [Test]
        public void Extract_Professional_Description_Information_From_File()
        {
            #region Arrange

            #endregion

            #region Act

            AcademicResearcher? academicResearcher = academicResearcherFileReadService.GetAcademicInformation(academicResearcherDocument);

            #endregion

            #region Assert

            Assert.That(academicResearcher, Is.Not.Null);
            Assert.That(academicResearcher.ProfessionalDescription, Is.Not.Null);

            #endregion
        }

        [Test]
        public void Extract_Professional_Address_Information_From_File()
        {
            #region Arrange

            #endregion

            #region Act

            AcademicResearcher? academicResearcher = academicResearcherFileReadService.GetAcademicInformation(academicResearcherDocument);

            #endregion

            #region Assert

            Assert.That(academicResearcher, Is.Not.Null);

            Assert.That(academicResearcher.ProfessionalAddress, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(academicResearcher.ProfessionalAddress.CompanyCode, Is.Not.Null);
                Assert.That(academicResearcher.ProfessionalAddress.CompanyName, Is.Not.Null);
                Assert.That(academicResearcher.ProfessionalAddress.AddressComplement, Is.Not.Null);
                Assert.That(academicResearcher.ProfessionalAddress.Country, Is.Not.Null);
                Assert.That(academicResearcher.ProfessionalAddress.State, Is.Not.Null);
                Assert.That(academicResearcher.ProfessionalAddress.ZipCode, Is.Not.Null);
                Assert.That(academicResearcher.ProfessionalAddress.City, Is.Not.Null);
                Assert.That(academicResearcher.ProfessionalAddress.District, Is.Not.Null);
                Assert.That(academicResearcher.ProfessionalAddress.DDD, Is.Not.Null);
                Assert.That(academicResearcher.ProfessionalAddress.PhoneNumber, Is.Not.Null);
                Assert.That(academicResearcher.ProfessionalAddress.Fax, Is.Not.Null);
                Assert.That(academicResearcher.ProfessionalAddress.POBox, Is.Not.Null);
                Assert.That(academicResearcher.ProfessionalAddress.HomePage, Is.Not.Null);
            });

            #endregion
        }

        [Test]
        public void Extract_Academic_Background_Information_From_File()
        {
            #region Arrange

            #endregion

            #region Act

            AcademicResearcher? academicResearcher = academicResearcherFileReadService.GetAcademicInformation(academicResearcherDocument);

            #endregion

            #region Assert

            Assert.That(academicResearcher, Is.Not.Null);

            Assert.That(academicResearcher.AcademicBackground, Is.Not.Null);

            Assert.That(academicResearcher.AcademicBackground.ToList(), Has.Count.EqualTo(8));

            #endregion
        }

        [Test]
        public void Extract_Published_Articles_Information_From_File()
        {
            #region Arrange

            #endregion

            #region Act

            AcademicResearcher? academicResearcher = academicResearcherFileReadService.GetAcademicInformation(academicResearcherDocument);

            #endregion

            #region Assert

            Assert.That(academicResearcher, Is.Not.Null);

            Assert.That(academicResearcher.PublishedArticles, Is.Not.Null);
            
            Assert.Multiple(() =>
            {
                Assert.That(academicResearcher.PublishedArticles.ToList(), Has.Count.EqualTo(3));
                Assert.That(academicResearcher.PublishedArticles.First().Authors, Is.Not.Null);
            });

            Assert.That(academicResearcher.PublishedArticles.First().Authors!.ToList(), Has.Count.GreaterThan(1));

            #endregion
        }

        [Test]
        public void Extract_Books_Organized_Or_Published_Information_From_File()
        {
            #region Arrange

            #endregion

            #region Act

            AcademicResearcher? academicResearcher = academicResearcherFileReadService.GetAcademicInformation(academicResearcherDocument);

            #endregion

            #region Assert

            Assert.That(academicResearcher, Is.Not.Null);

            Assert.That(academicResearcher.BooksPublishedOrOrganized, Is.Not.Null);
            
            Assert.Multiple(() =>
            {
                Assert.That(academicResearcher.BooksPublishedOrOrganized.ToList(), Has.Count.EqualTo(7));
                Assert.That(academicResearcher.BooksPublishedOrOrganized.First().Authors, Is.Not.Null);

            });

            Assert.That(academicResearcher.BooksPublishedOrOrganized.First().Authors!.ToList(), Has.Count.GreaterThan(1));

            #endregion
        }

        [Test]
        public void Extract_Books_Chapters_Published_Information_From_File()
        {
            #region Arrange

            #endregion

            #region Act

            AcademicResearcher? academicResearcher = academicResearcherFileReadService.GetAcademicInformation(academicResearcherDocument);

            #endregion

            #region Assert

            Assert.That(academicResearcher, Is.Not.Null);

            Assert.That(academicResearcher.BooksChaptersPublished, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(academicResearcher.BooksChaptersPublished.ToList(), Has.Count.EqualTo(3));
                Assert.That(academicResearcher.BooksChaptersPublished.First().Authors, Is.Not.Null);

            });

            Assert.That(academicResearcher.BooksChaptersPublished.First().Authors!.ToList(), Has.Count.GreaterThan(1));

            #endregion
        }

        [Test]
        public void Extract_Work_At_Events_Information_From_File()
        {
            #region Arrange

            #endregion

            #region Act

            AcademicResearcher? academicResearcher = academicResearcherFileReadService.GetAcademicInformation(academicResearcherDocument);

            #endregion

            #region Assert

            Assert.That(academicResearcher, Is.Not.Null);

            Assert.That(academicResearcher.WorkAtEvents, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(academicResearcher.WorkAtEvents.ToList(), Has.Count.EqualTo(189));
                Assert.That(academicResearcher.WorkAtEvents.First().Authors, Is.Not.Null);
            });

            Assert.That(academicResearcher.WorkAtEvents.First().Authors!.ToList(), Has.Count.GreaterThan(1));

            #endregion
        }

        [Test]
        public void Extract_Others_Bibliographic_Productions_Information_From_File()
        {
            #region Arrange

            #endregion

            #region Act

            AcademicResearcher? academicResearcher = academicResearcherFileReadService.GetAcademicInformation(academicResearcherDocument);

            #endregion

            #region Assert

            Assert.That(academicResearcher, Is.Not.Null);

            Assert.That(academicResearcher.OthersBibliographicProductions, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(academicResearcher.OthersBibliographicProductions.ToList(), Has.Count.EqualTo(16));
                Assert.That(academicResearcher.OthersBibliographicProductions.First().Authors, Is.Not.Null);
            });

            Assert.That(academicResearcher.OthersBibliographicProductions.First().Authors!.ToList(), Has.Count.GreaterThanOrEqualTo(1));

            #endregion
        }

        [Test]
        public void Extract_Technical_Productions_Information_From_File()
        {
            #region Arrange

            #endregion

            #region Act

            AcademicResearcher? academicResearcher = academicResearcherFileReadService.GetAcademicInformation(academicResearcherDocument);

            #endregion

            #region Assert

            Assert.That(academicResearcher, Is.Not.Null);

            Assert.That(academicResearcher.TechnicalProductions, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(academicResearcher.TechnicalProductions.ToList(), Has.Count.EqualTo(6));
                Assert.That(academicResearcher.TechnicalProductions.First().Authors, Is.Not.Null);
            });

            Assert.That(academicResearcher.TechnicalProductions.First().Authors!.ToList(), Has.Count.GreaterThanOrEqualTo(5));

            #endregion
        }

        [Test]
        public void Extract_Completed_Orientation_Information_From_File()
        {
            #region Arrange

            #endregion

            #region Act

            AcademicResearcher? academicResearcher = academicResearcherFileReadService.GetAcademicInformation(academicResearcherDocument);

            #endregion

            #region Assert

            Assert.That(academicResearcher, Is.Not.Null);

            Assert.That(academicResearcher.CompletedOrientation, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(academicResearcher.CompletedOrientation.ToList(), Has.Count.EqualTo(83));
                Assert.That(academicResearcher.CompletedOrientation.First().KeyWorkds.ToList(), Has.Count.GreaterThanOrEqualTo(3));
                Assert.That(academicResearcher.CompletedOrientation.First().KnowledgeAreas.ToList(), Has.Count.GreaterThanOrEqualTo(1));
            });

            #endregion
        }

        [Test]
        public void Extract_Complementary_Courses_Information_From_File()
        {
            #region Arrange

            #endregion

            #region Act

            AcademicResearcher? academicResearcher = academicResearcherFileReadService.GetAcademicInformation(academicResearcherDocument);

            #endregion

            #region Assert

            Assert.That(academicResearcher, Is.Not.Null);

            Assert.That(academicResearcher.ComplementaryCourses, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(academicResearcher.ComplementaryCourses.ToList(), Has.Count.GreaterThanOrEqualTo(25));
            });

            #endregion
        }
    }
}