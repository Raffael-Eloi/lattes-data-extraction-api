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

        [Test]
        public void Return_Academic_Background_Service_When_Type_Is_AcademicBackground()
        {
            #region Arrange

            var academicBackgroundType = DataInformationType.AcademicBackground;

            #endregion

            #region Act

            IGetDataInformationService getDataInformationType = getDataInformationFactory.Create(academicBackgroundType);

            #endregion

            #region Assert

            Assert.That(getDataInformationType.GetType(), Is.EqualTo(typeof(GetAcademicBackgroundInformationService)));

            #endregion
        }

        [Test]
        public void Return_Published_Articles_Service_When_Type_Is_Published_Articles()
        {
            #region Arrange

            var publishedArticlesType = DataInformationType.PublishedArticles;

            #endregion

            #region Act

            IGetDataInformationService getDataInformationType = getDataInformationFactory.Create(publishedArticlesType);

            #endregion

            #region Assert

            Assert.That(getDataInformationType.GetType(), Is.EqualTo(typeof(GetPublishedArticlesInformationService)));

            #endregion
        }

        [Test]
        public void Throw_Exception_When_Data_Information_Type_Does_Not_Exist()
        {
            #region Arrange

            var unknownType = DataInformationType.Unknowwn;

            #endregion

            #region Act

            Exception? threwException = null;

            try
            {
                IGetDataInformationService getDataInformationType = getDataInformationFactory.Create(unknownType);
            }
            catch (ArgumentException ex)
            {
                threwException = ex;
            }

            #endregion

            #region Assert

            Assert.That(threwException, Is.Not.Null);
            
            Assert.Multiple(() =>
            {
                Assert.That(threwException.GetType(), Is.EqualTo(typeof(ArgumentException)));

                Assert.That(threwException.Message, Is.EqualTo("The Data Information Type was not implemented."));
            });

            #endregion
        }
    }
}
