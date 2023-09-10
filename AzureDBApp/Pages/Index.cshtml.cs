using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AzureDBApp.Model;
using AzureDBApp.BAL;

namespace AzureDBApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products; 
        public void OnGet()
        {
            ProductService productService = new ProductService();
            Products = productService.GetProducts();
        }
    }
}