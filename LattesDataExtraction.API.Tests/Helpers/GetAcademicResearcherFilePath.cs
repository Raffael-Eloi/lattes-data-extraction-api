namespace LattesDataExtraction.API.Tests.Helpers;

public static class GetAcademicResearcherFilePath
{
    public static string Get()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string fullFilePath = Path.Combine(currentDirectory, "Data", "lattes-resume-example.xml");
        return fullFilePath.Replace("bin\\Debug\\net7.0", "");
    }
}