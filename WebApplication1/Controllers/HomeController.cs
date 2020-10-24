using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<Product> productList;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            if(this.productList == null)
            {
                this.productList = new List<Product>();
            }
            Product product1 = new Product() { ProductName = "iPhone12", ProductCategory = "Smart Phone", ProductSupplier = "Apple", ProductPrice = 30000, ProductStockQuantity = 200 };
            Product product2 = new Product() { ProductName = "Thinkpad P1", ProductCategory = "Notebook", ProductSupplier = "Lenovo", ProductPrice = 80000, ProductStockQuantity = 20 };
            Product product3 = new Product() { ProductName = "Galaxy x20", ProductCategory = "Smart Phone", ProductSupplier = "Samsung", ProductPrice = 25000, ProductStockQuantity = 100 };
            Product product4 = new Product() { ProductName = "iPad", ProductCategory = "Tablet", ProductSupplier = "Apple", ProductPrice = 20000, ProductStockQuantity = 150 };
            Product product5 = new Product() { ProductName = "Mate 30", ProductCategory = "Smart Phone", ProductSupplier = "Huawei", ProductPrice = 28000, ProductStockQuantity = 180 };
            this.productList.Add(product1);
            this.productList.Add(product2);
            this.productList.Add(product3);
            this.productList.Add(product4);
            this.productList.Add(product5);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Course()
        {
            return View();
        }

        public IActionResult Link()
        {
            return View();
        }

        public IActionResult ListProduct()
        {
            return View(this.productList);
        }

        public IActionResult ProductDetail(int pid)
        {
            if(this.productList.ElementAtOrDefault(pid) == null)
            {
                return RedirectToAction("Error");
            }

            return View(this.productList[pid]);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            this.productList.Add(p);
            return RedirectToAction("ListProduct");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GetImage1()
        {
            return PhysicalFile(@"C:\Users\Phumin\Desktop\Component-Based Software Development\Lab\1.jpg", "image/jpeg");
        }

        public IActionResult GetPDF1()
        {
            return PhysicalFile(@"C:\Users\Phumin\Desktop\Component-Based Software Development\Lab\1.pdf", "application/pdf");
        }

        public IActionResult GetPDF2()
        {
            var stream = new FileStream(@"C:\Users\Phumin\Desktop\Component-Based Software Development\Lab\2.pdf", FileMode.Open);
            return new FileStreamResult(stream, "application/pdf");
        }

        public IActionResult GetExcel1()
        {
            return PhysicalFile(@"C:\Users\Phumin\Desktop\Component-Based Software Development\Lab\1.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public IActionResult GetCSV1()
        {
            return PhysicalFile(@"C:\Users\Phumin\Desktop\Component-Based Software Development\Lab\1.csv", "text/csv");
        }

        public JsonResult JsonProducts()
        {
            return Json(this.productList);
        }

    }
}
