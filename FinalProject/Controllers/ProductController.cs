using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FinalProject.Controllers
{
    public class ProductController : Controller
    {
        Uri baseAddress = new Uri("38b15f82-38b3-459d-9f45-1b917c54e67a.mock.pstmn.io/users");
        private readonly HttpClient _client;

        public ProductController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ProductViewModel> productList = new List<ProductViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/product/Get").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                productList = JsonConvert.DeserializeObject<List<ProductViewModel>>(data);
            }
            return View(productList);
        }
    }
}
