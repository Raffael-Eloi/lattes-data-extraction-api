using BoDi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace LattesDataExtraction.API.Tests.Hooks
{
    [Binding]
    public sealed class EnvironmentSetupHooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun(IObjectContainer testThreadContainer)
        {
            HttpClient? apiHttpClient;

            var application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.UseEnvironment("Development");
            });

            apiHttpClient = application.CreateClient();

            testThreadContainer.RegisterInstanceAs(apiHttpClient);
        }

        [AfterTestRun]
        public static void AfterTestRun(IObjectContainer testThreadContainer)
        {
            testThreadContainer.Resolve<HttpClient>().Dispose();
        }
    }
}
