using LattesDataExtraction.Application.Models;
using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using Moq;

namespace LattesDataExtraction.Application.Tests.Services
{
    internal class AcademicResearcherReadServiceShould
    {
        [Test]
        public async Task Get_All_Academic_Researchers_Added()
        {
            #region Arrange

            var academicResearcherRepositoryMock = new Mock<IAcademicResearcherRepository>();

            IAcademicResearcherReadService academicResearcherReadService = new AcademicResearcherReadService(academicResearcherRepositoryMock.Object);

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

            IEnumerable<AcademicResearcherModel> academicResearchers = await academicResearcherReadService.GetAll();

            #endregion

            #region Assert

            Assert.That(academicResearchers.Count, Is.EqualTo(1));

            #endregion
        }
    }
}