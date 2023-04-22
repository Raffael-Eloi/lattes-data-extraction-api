using AutoMapper;
using LattesDataExtraction.Application.Contracts;
using LattesDataExtraction.Application.Mappers;
using LattesDataExtraction.Application.Models;
using LattesDataExtraction.Application.Services;
using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using LattesDataExtraction.Domain.Factories;
using LattesDataExtraction.Domain.Services;
using Moq;
using System.Xml;

namespace LattesDataExtraction.Application.Tests.Services
{
    public class LattesDataExtractionServiceShould
    {
        private ILattesDataExtractionService lattesDataExtractionService;

        private Mock<IAcademicResearcherRepository> academicResearcherRepositoryMock;

        private XmlDocument academicResearcherDocument;

        [SetUp]
        public void Setup()
        {
            GetDataInformationFactory factory = new();

            var academicResearcherDataExtractionService = new AcademicResearcherDataExtractionService(factory);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ApplicationMappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            academicResearcherRepositoryMock = new Mock<IAcademicResearcherRepository>();

            lattesDataExtractionService = new LattesDataExtractionService(academicResearcherDataExtractionService, mapper, academicResearcherRepositoryMock.Object);

            var filePath = @"C:\useful\researcher.xml";

            academicResearcherDocument = new();

            academicResearcherDocument.Load(filePath);
        }

        [Test]
        public async Task Read_And_Get_Information_From_Xml_File()
        {
            #region Arrange

            #endregion

            #region Act

            AddAcademicResearcherResponse response = await lattesDataExtractionService.Extract(academicResearcherDocument);

            #endregion

            #region Assert

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Success, Is.True);

            #endregion
        }

        [Test]
        public async Task Persist_Information()
        {
            #region Arrange

            #endregion

            #region Act

            AddAcademicResearcherResponse response = await lattesDataExtractionService.Extract(academicResearcherDocument);

            #endregion

            #region Assert

            academicResearcherRepositoryMock
                .Verify(
                    repository =>
                        repository.AddAsync(It.IsAny<AcademicResearcher>())
                , Times.Once);

            #endregion
        }

        [Test]
        public async Task Return_Notifications_When_File_Data_Is_Invalid()
        {
            #region Arrange

            var academicResearcherDataExtractionService = new Mock<IAcademicResearcherDataExtractionService>();

            var mapper = new Mock<IMapper>();

            var lattesDataExtractionService = new LattesDataExtractionService(academicResearcherDataExtractionService.Object, mapper.Object, academicResearcherRepositoryMock.Object);

            AcademicResearcher invalidAcademicResearcher = new();

            academicResearcherDataExtractionService
                .Setup(service => service.GetAcademicInformation(It.IsAny<XmlDocument>()))
                .Returns(invalidAcademicResearcher);

            #endregion

            #region Act

            AddAcademicResearcherResponse response = await lattesDataExtractionService.Extract(academicResearcherDocument);

            #endregion

            #region Assert

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Success, Is.False);

            Assert.Multiple(() =>
            {
                Assert.That(response.IsValid, Is.False);
                Assert.That(response.Notifications, Has.Count.EqualTo(1));
            });

            Assert.That(response.Notifications.First().Message, Is.EqualTo("The data on the XML file is invalid."));

            #endregion
        }
    }
}