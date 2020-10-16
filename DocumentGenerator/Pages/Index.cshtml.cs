using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Models.Document;

namespace OfferteTemplater.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public new OfferDocumentModel Content { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        //public void OnGet()
        //{
        //    this.Content = OfferteModelsForTesting.TestModel();
        //}

        public void OnPost()
        {
            var serializeExample = JsonSerializer.Serialize(OfferteModelsForTesting.TestModel());
            var itemsJson = Request.Form["items"].First();

            Content = JsonSerializer.Deserialize<OfferDocumentModel>(itemsJson);
        }
    }
}
