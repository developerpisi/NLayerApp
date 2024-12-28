using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Web.Services;

namespace NLayer.Web.Controllers
{
    public class ProductsController : Controller
    {

        private readonly ProductApiService _productApiService;
        private readonly CategoryApiService _categoryApiService;

        public ProductsController(CategoryApiService categoryApiService, ProductApiService productApiService)
        {
            _categoryApiService = categoryApiService;
            _productApiService = productApiService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _productApiService.GetProductsWithCategoryAsync());
        }

        public async Task<IActionResult> Save()
        {
            var categoriesDto = await _categoryApiService.GetAllAsync();
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)

        {
            if (ModelState.IsValid)
            {
                await _productApiService.SaveAsync(productDto);
                return RedirectToAction(nameof(Index));
            }

            var categoriesDto = await _categoryApiService.GetAllAsync();

            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");
            return View();
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productApiService.GetByIdAsync(id);
            var categoriesDto = await _categoryApiService.GetAllAsync();
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name",product.CategoryId);
            return View(product);
        }
        //
        // [HttpPost]
        // public async Task<IActionResult> Update(ProductDto productDto)
        // {
        //     if(ModelState.IsValid)
        //     {
        //         await _productApiService.UpdateAsync(productDto); 
        //         return RedirectToAction(nameof(Index));
        //     }
        //
        //     var categoriesDto = await  _categoryApiService.GetAllAsync();
        //     ViewBag.categories = new SelectList(categoriesDto, "Id", "Name", productDto.CategoryId);
        //     return View(productDto);
        // }
        //
        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                // Güncelleme işlemini API'ye gönder
                var updatedProduct = await _productApiService.UpdateAsync(productDto);

                // Eğer güncelleme başarılıysa, Index sayfasına yönlendir
                if (updatedProduct != null)
                {
                    return RedirectToAction(nameof(Index));
                }

                // Hata durumunda güncelleme sayfasını tekrar göster
                ModelState.AddModelError("", "Update failed.");
            }

            // Eğer ModelState geçerli değilse, kategori listelerini tekrar al ve sayfayı yeniden yükle
            var categoriesDto = await _categoryApiService.GetAllAsync();
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name", productDto.CategoryId);
            return View(productDto);
        }
        
        public async Task<IActionResult> Remove(int id)
        {
            await _productApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}