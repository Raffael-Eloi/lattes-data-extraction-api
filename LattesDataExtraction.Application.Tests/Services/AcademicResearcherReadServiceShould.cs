using AutoMapper;
using LattesDataExtraction.Application.Contracts;
using LattesDataExtraction.Application.Mappers;
using LattesDataExtraction.Application.Models;
using LattesDataExtraction.Application.Services;
using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using Moq;

namespace LattesDataExtraction.Application.Tests.Services
{
    internal class AcademicResearcherReadServiceShould
    {
        private Mock<IAcademicResearcherRepository> academicResearcherRepositoryMock;

        private IAcademicResearcherReadService academicResearcherReadService;

        [SetUp] 
        public void Setup() 
        {
            academicResearcherRepositoryMock = new Mock<IAcademicResearcherRepository>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ApplicationMappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            academicResearcherReadService = new AcademicResearcherReadService(academicResearcherRepositoryMock.Object, mapper);
        }

        [Test]
        public async Task Get_Academic_Researchers_By_Id()
        {
            #region Arrange

            var academicReseracherId = Guid.NewGuid();

            var academicResearcherMock = new AcademicResearcher()
            {
                Id = academicReseracherId
            };

            academicResearcherRepositoryMock
                .Setup(repository => repository.GetById(academicReseracherId))
                .ReturnsAsync(academicResearcherMock);

            #endregion

            #region Act

            AcademicResearcherModelResponse academicResearcher = await academicResearcherReadService.GetById(academicReseracherId);

            #endregion

            #region Assert

            Assert.That(academicResearcher.Id, Is.Not.Empty);

            #endregion
        }

        [Test]
        public async Task Return_Notification_When_Academic_Researcher_Does_Not_Exist()
        {
            #region Arrange

            var academicReseracherId = Guid.NewGuid();

            AcademicResearcher? unexistingAcademicResearcher = null;

            academicResearcherRepositoryMock
                .Setup(repository => repository.GetById(academicReseracherId))
                .ReturnsAsync(unexistingAcademicResearcher);

            #endregion

            #region Act

            AcademicResearcherModelResponse academicResearcher = await academicResearcherReadService.GetById(academicReseracherId);

            #endregion

            #region Assert

            Assert.Multiple(() =>
            {
                Assert.That(academicResearcher.IsValid, Is.False);
                Assert.That(academicResearcher.Notifications, Has.Count.EqualTo(1));
                Assert.That(academicResearcher.Notifications.First().Key, Is.EqualTo("AcademicReseracherId"));
                Assert.That(academicResearcher.Notifications.First().Message, Is.EqualTo("Academic Researcher does not exist."));
            });

            #endregion
        }

        [Test]
        public async Task Get_All_Academic_Researchers_Added()
        {
            #region Arrange

            var academicResearchersMock = new List<AcademicResearcher>() 
            { 
                new AcademicResearcher()
                {
                    Id = Guid.NewGuid()
                }
            };

            academicResearcherRepositoryMock
                .Setup(repository => repository.GetAll())
                .ReturnsAsync(academicResearchersMock);

            #endregion

            #region Act

            IEnumerable<AcademicResearcherModelResponse> academicResearchers = await academicResearcherReadService.GetAll();

            #endregion

            #region Assert

            Assert.That(academicResearchers.Count, Is.EqualTo(1));

            #endregion
        }
    }
}