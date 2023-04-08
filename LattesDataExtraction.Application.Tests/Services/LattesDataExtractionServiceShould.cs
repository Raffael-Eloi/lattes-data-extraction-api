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

namespace LattesDataExtraction.Application.Tests.Services
{
    public class LattesDataExtractionServiceShould
    {
        private ILattesDataExtractionService lattesDataExtractionService;

        private Mock<IAcademicResearcherRepository> academicResearcherRepositoryMock;

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
        }

        [Test]
        public void Read_And_Get_Information_From_Xml_File()
        {
            #region Arrange

            var academicResearcherFilePath = @"C:\useful\researcher.xml";

            AddAcademicResearcherRequest request = new()
            {
                File = academicResearcherFilePath
            };

            #endregion

            #region Act

            AddAcademicResearcherResponse response = lattesDataExtractionService.Extract(request);

            #endregion

            #region Assert

            Assert.That(response, Is.Not.Null);
            
            #endregion
        }

        [Test]
        public void Persist_Information()
        {
            #region Arrange

            var academicResearcherFilePath = @"C:\useful\researcher.xml";

            AddAcademicResearcherRequest request = new()
            {
                File = academicResearcherFilePath
            };

            #endregion

            #region Act

            AddAcademicResearcherResponse response = lattesDataExtractionService.Extract(request);

            #endregion

            #region Assert

            academicResearcherRepositoryMock
                .Verify(
                    repository => 
                        repository.Save(It.IsAny<AcademicResearcher>())
                , Times.Once);

            #endregion
        }

        [Test]
        public void Return_Notifications_When_File_Data_Is_Invalid()
        {
            #region Arrange

            var academicResearcherDataExtractionService = new Mock<IAcademicResearcherDataExtractionService>();

            var mapper = new Mock<IMapper>();

            var lattesDataExtractionService = new LattesDataExtractionService(academicResearcherDataExtractionService.Object, mapper.Object, academicResearcherRepositoryMock.Object);

            var academicResearcherFilePath = @"C:\useful\researcher.xml";

            AddAcademicResearcherRequest request = new()
            {
                File = academicResearcherFilePath
            };

            AcademicResearcher? invalidAcademicResearcher = null;

            academicResearcherDataExtractionService
                .Setup(service => service.GetAcademicInformation(It.IsAny<string>()))
                .Returns(invalidAcademicResearcher);

            #endregion

            #region Act

            AddAcademicResearcherResponse response = lattesDataExtractionService.Extract(request);

            #endregion

            #region Assert

            Assert.That(response, Is.Not.Null);
            
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