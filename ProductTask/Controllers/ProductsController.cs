using Microsoft.AspNetCore.Mvc;
using ProductTask.Models;
using ProductTask.Services;
using System.Text.Json;

namespace ProductTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly GoldPriceService _goldPriceService;

        public ProductsController(GoldPriceService goldPriceService)
        {
            _goldPriceService = goldPriceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get(
     [FromQuery] string? name,
     [FromQuery] double? minPrice,
     [FromQuery] double? maxPrice)
        {
            var jsonString = await System.IO.File.ReadAllTextAsync("Data/products.json");
            var products = JsonSerializer.Deserialize<List<Product>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (products == null)
                return NotFound("Ürün bulunamadı.");

            double goldPrice = await _goldPriceService.GetGoldPricePerGramAsync();

            foreach (var product in products)
            {
                product.Price = (product.PopularityScore + 1) * product.Weight * goldPrice;
            }

            // Filtreleme
            if (!string.IsNullOrWhiteSpace(name))
            {
                products = products
                    .Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (minPrice.HasValue)
            {
                products = products
                    .Where(p => p.Price >= minPrice.Value)
                    .ToList();
            }

            if (maxPrice.HasValue)
            {
                products = products
                    .Where(p => p.Price <= maxPrice.Value)
                    .ToList();
            }

            return Ok(products);
        }
    }

    }
