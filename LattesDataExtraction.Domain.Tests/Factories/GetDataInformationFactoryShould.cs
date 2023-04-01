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

        [Test]
        public void Return_General_Data_Service_When_Type_Is_General_Data()
        {
            #region Arrange

            var generalDataType = DataInformationType.GeneralData;

            #endregion

            #region Act

            IGetDataInformationService getDataInformationType = getDataInformationFactory.Create(generalDataType);

            #endregion

            #region Assert

            Assert.That(getDataInformationType.GetType(), Is.EqualTo(typeof(GetGeneralDataInformationService)));

            #endregion
        }

        [Test]
        public void Return_Professional_Description_Service_When_Type_Is_Professional_Description()
        {
            #region Arrange

            var professionalDescriptionType = DataInformationType.ProfessionalDescription;

            #endregion

            #region Act

            IGetDataInformationService getDataInformationType = getDataInformationFactory.Create(professionalDescriptionType);

            #endregion

            #region Assert

            Assert.That(getDataInformationType.GetType(), Is.EqualTo(typeof(GetProfessionalDescriptionInformationService)));

            #endregion
        }

        [Test]
        public void Return_Professional_Address_Service_When_Type_Is_Professional_Address()
        {
            #region Arrange

            var professionalAddressType = DataInformationType.ProfessionalAddress;

            #endregion

            #region Act

            IGetDataInformationService getDataInformationType = getDataInformationFactory.Create(professionalAddressType);

            #endregion

            #region Assert

            Assert.That(getDataInformationType.GetType(), Is.EqualTo(typeof(GetProfessionalAddressInformationService)));

            #endregion
        }
    }
}
