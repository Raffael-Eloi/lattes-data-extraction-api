using AutoMapper;
using LattesDataExtraction.Application.Contracts;
using LattesDataExtraction.Application.Mappers;
using LattesDataExtraction.Application.Models;
using LattesDataExtraction.Application.Services;
using LattesDataExtraction.Domain.Factories;
using LattesDataExtraction.Domain.Services;

namespace LattesDataExtraction.Application.Tests.Services
{
    public class LattesDataExtractionServiceShould
    {
        private ILattesDataExtractionService lattesDataExtractionService;

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

            lattesDataExtractionService = new LattesDataExtractionService(academicResearcherDataExtractionService, mapper);
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
    }
}