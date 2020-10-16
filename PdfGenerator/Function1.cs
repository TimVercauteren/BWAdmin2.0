using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Models.Document;
using PuppeteerSharp;

namespace PdfGenerator
{

    public class GeneratePdf
    {
        private readonly AppInfo _appInfo;

        public GeneratePdf(AppInfo browserInfo)
        {
            this._appInfo = browserInfo;
        }

        [FunctionName("GeneratePdf")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req, ILogger log)
        {
            log.LogInformation($"Browser path: {_appInfo.BrowserExecutablePath}");

            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true,
                ExecutablePath = _appInfo.BrowserExecutablePath
            });
            var page = await browser.NewPageAsync();
            await page.GoToAsync($"http://localhost:{_appInfo.RazorPagesServerPort}/");

            var data = JsonSerializer.Serialize(OfferteModelsForTesting.TestModel());

            OfferteModelsForTesting.TestModel();
            await page.TypeAsync("#items-box", data);
            await Task.WhenAll(
                page.WaitForNavigationAsync(),
                page.ClickAsync("#submit-button"));
            var stream = await page.PdfStreamAsync();
            await browser.CloseAsync();

            return new FileStreamResult(stream, "application/pdf");
        }
    }
}
