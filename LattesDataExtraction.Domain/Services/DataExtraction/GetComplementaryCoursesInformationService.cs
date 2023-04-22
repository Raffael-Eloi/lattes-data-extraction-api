using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using System.Xml;

namespace LattesDataExtraction.Domain.Services.DataExtraction
{
    internal class GetComplementaryCoursesInformationService : IGetDataInformationService
    {
        private List<ComplementaryCourse>? _complementaryCoursesList;

        private ComplementaryCourse? _complementaryCourse;

        public void GetInformation(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument)
        {
            GetDataFromFile(academicResearcher, academicResearcherDocument);
        }

        private void GetDataFromFile(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument)
        {
            _complementaryCoursesList = new();

            XmlNodeList complementaryCoursesInformation = academicResearcherDocument!.GetElementsByTagName("FORMACAO-COMPLEMENTAR");

            if (complementaryCoursesInformation.Count < 0) return;

            foreach (XmlNode element in complementaryCoursesInformation)
            {
                if (element is null || element.ChildNodes is null || element.ChildNodes.Count == 0) continue;

                foreach (XmlNode complementaryCourseElement in element.ChildNodes)
                {
                    if (complementaryCourseElement is null) continue; 

                    _complementaryCourse = new();

                    GetData(complementaryCourseElement);

                    _complementaryCoursesList.Add(_complementaryCourse!);
                }
            }

            academicResearcher.ComplementaryCourses = _complementaryCoursesList;
        }

        private void GetData(XmlNode complementaryCourseElement)
        {
            if (complementaryCourseElement.Name is not null && complementaryCourseElement.Name == "OUTROS")
            {
                if (complementaryCourseElement.Attributes is null || complementaryCourseElement.Attributes.Count == 0) return;

                XmlAttributeCollection allComplementaryCourses = complementaryCourseElement.Attributes;

                foreach (XmlAttribute complementaryCourse in allComplementaryCourses)
                {
                    if (complementaryCourse is null || string.IsNullOrEmpty(complementaryCourse.Name) || string.IsNullOrEmpty(complementaryCourse.Value)) continue;

                    if (complementaryCourse.Name == "CARGA-HORARIA")
                    {
                        _complementaryCourse!.DurationInHours = int.Parse(complementaryCourse.Value);
                    }

                    if (complementaryCourse.Name == "CODIGO-INSTITUICAO")
                    {
                        _complementaryCourse!.InstitutionCode = complementaryCourse.Value;
                    }

                    if (complementaryCourse.Name == "NOME-INSTITUICAO")
                    {
                        _complementaryCourse!.InstitutionName = complementaryCourse.Value;
                    }
                    
                    if (complementaryCourse.Name == "CODIGO-CURSO")
                    {
                        _complementaryCourse!.Code = complementaryCourse.Value;
                    }
                    
                    if (complementaryCourse.Name == "NOME-CURSO")
                    {
                        _complementaryCourse!.Name = complementaryCourse.Value;
                    }
                    
                    if (complementaryCourse.Name == "STATUS-DO-CURSO")
                    {
                        _complementaryCourse!.Status = complementaryCourse.Value;
                    }

                    if (complementaryCourse.Name == "ANO-DE-INICIO")
                    {
                        _complementaryCourse!.StartYear = new DateOnly(int.Parse(complementaryCourse.Value), 1, 1);
                    }
                    
                    if (complementaryCourse.Name == "ANO-DE-CONCLUSAO")
                    {
                        _complementaryCourse!.EndYear = new DateOnly(int.Parse(complementaryCourse.Value), 1, 1);
                    }
                }
            }
        }
    }
}