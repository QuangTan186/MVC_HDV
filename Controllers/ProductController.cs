using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;
using ProductManager.Services;

namespace ProductManager.Controllers
{
    public class ProductController : Controller
    {
       private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }
 
        public IActionResult Index()
        {
            var products = _productService.GetProducts();
            return View(products);
        }

        public IActionResult Update(int id)
        {
            var product = _productService.GetProductById(id);
            if(product == null) return RedirectToAction("Create");
            ViewBag.Product = product;
            var categories = _productService.GetCategories();            
            return View(categories);
        }
        public IActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            var categories = _productService.GetCategories();
            return View(categories);
        }
        public IActionResult Save(Product product)
        {
            _productService.CreateProduct(product);
            return RedirectToAction("Index");
        }
    }
}