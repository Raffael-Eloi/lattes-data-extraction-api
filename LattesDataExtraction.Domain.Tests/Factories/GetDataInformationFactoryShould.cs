using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Enums;
using LattesDataExtraction.Domain.Factories;
using LattesDataExtraction.Domain.Services.DataExtraction;

namespace LattesDataExtraction.Domain.Tests.Factories
{
    public class GetDataInformationFactoryShould
    {
        private IGetDataInformationFactory getDataInformationFactory;

        [SetUp] 
        public void SetUp() 
        {
            getDataInformationFactory = new GetDataInformationFactory();
        }

        [Test]
        public void Return_Curriculum_Vitae_Service_When_Type_Is_Curriculum_Vitae()
        {
            #region Arrange

            var curriculumVitaeType = DataInformationType.CurriculumVitae;

            #endregion

            #region Act

            IGetDataInformationService getDataInformationType = getDataInformationFactory.Create(curriculumVitaeType);

            #endregion

            #region Assert

            Assert.That(getDataInformationType.GetType(), Is.EqualTo(typeof(GetCurriculumVitaeInformationService)));

            #endregion
        }
    }
}
