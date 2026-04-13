using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shopping.Web.Services;

namespace Shopping.Web.Pages
{
    public class IndexModel
        (ICatalogService catalogService, ILogger<IndexModel> logger)
        : PageModel
    {
        public IEnumerable<ProductModal> Product { get; set; }
        public async Task OnGetAsync()
        {
            logger.LogInformation("On Get Loaded");
            var data = await catalogService.GetProducts();
            Product = data.Products;
        }
    }
}
