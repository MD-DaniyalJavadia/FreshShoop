using Microsoft.AspNetCore.Http;
using FreshShoop.Models;
using Microsoft.AspNetCore.Mvc;
using FreshShoop.ViewModel;
using System.Security.Permissions;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using FreshShoop.Models;
using FreshShoop.Models;
using FreshShoop.ViewModel;

namespace WebApplication1.Controllers
{

    public class ProductController : Controller
    {
        ShopAppContext context;
        IWebHostEnvironment webHostEnvironment;
        public ProductController(ShopAppContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.context = context;
        }

        // GET: ProductController
        public ActionResult Index()

        {
            //var Pro = context.ProductsViews.ToList();
            var Pro = context.Products.Include(Catg => Catg.Category);
            return View(Pro.ToList());
            //return View(Pro);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(string id)
        {
            var Pro = context.Products.Find(id);
            return View(Pro);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = context.Categories.ToList();
            return View(); 
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductView product)
        {
            try
            {
                string fileName = "";
                string uploadPath = "";
                if (product.Image1 != null)
                {
                    fileName = Guid.NewGuid().ToString() + "_" + product.Image1.FileName;
                    uploadPath = Path.Combine(webHostEnvironment.WebRootPath, "Upload\\Product", fileName);


                    Directory.CreateDirectory(Path.GetDirectoryName(uploadPath));


                    using (var stream = new FileStream(uploadPath, FileMode.Create))
                    {
                        await product.Image1.CopyToAsync(stream);
                    }



                    Product pro = new Product();
                    pro.Id = Guid.NewGuid().ToString();
                    pro.Name = product.Name;
                    pro.Description = product.Description;
                    pro.Image1 = Path.Combine("Upload\\Product", fileName);
                    pro.Image = "";
                    pro.Image3 = "";
                    pro.Qunatity = product.Qunatity;
                    pro.UnitPrice = product.UnitPrice;
                    pro.SalePrice = product.SalePrice;
                    pro.CategoryId = product.CategoryId;
                    pro.Satatus = "Active";
                    ShopAppContext shopContext = new ShopAppContext();
                    shopContext.Add(pro);
                    shopContext.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }

                else

                {
                    Product pro = new Product();
                    pro.Id = Guid.NewGuid().ToString();
                    pro.Name = product.Name;
                    pro.Description = product.Description;
                    pro.Image1 = "";
                    pro.Image = "";
                    pro.Image3 = "";
                    pro.Qunatity = product.Qunatity;
                    pro.UnitPrice = product.UnitPrice;
                    pro.SalePrice = product.SalePrice;
                    pro.CategoryId = product.CategoryId;
                    pro.Satatus = "Active";
                    ShopAppContext shopContext = new ShopAppContext();
                    shopContext.Add(pro);
                    shopContext.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }

            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(string id)
        {
            ViewBag.CategoryId = context.Categories.ToList();
            var Pro = context.Products.Find(id);
            ProductEditViewModel productEditView = new ProductEditViewModel();
            productEditView.Id = Pro.Id;
            productEditView.Name = Pro.Name;
            productEditView.ExistingPath = Pro.Image1;
            productEditView.ExistingPath = Pro.Image3;
            productEditView.ExistingPath = Pro.Image;
            productEditView.Qunatity = Pro.Qunatity;
            productEditView.UnitPrice = Pro.UnitPrice;
            productEditView.SalePrice = Pro.SalePrice;
            productEditView.CategoryId = Pro.CategoryId;
            productEditView.Satatus = Pro.Satatus;
            productEditView.Description = Pro.Description;
            return View(productEditView);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, ProductEditViewModel product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            try
            {

                string fileName = "";
                string uploadPath = "";
                if (product.Image1 != null)
                {
                    fileName = Guid.NewGuid().ToString() + "_" + product.Image1.FileName;
                    uploadPath = Path.Combine(webHostEnvironment.WebRootPath, "Upload\\Product", fileName);


                    Directory.CreateDirectory(Path.GetDirectoryName(uploadPath));


                    using (var stream = new FileStream(uploadPath, FileMode.Create))
                    {
                        await product.Image1.CopyToAsync(stream);
                    }


                    Product pro = context.Products.Find(id);
                    pro.Name = product.Name;
                    pro.Description = product.Description;
                    pro.Image1 = Path.Combine("Upload\\Product", fileName);
                    pro.Image = "";
                    pro.Image3 = "";
                    pro.Qunatity = product.Qunatity;
                    pro.UnitPrice = product.UnitPrice;
                    pro.SalePrice = product.SalePrice;
                    pro.CategoryId = product.CategoryId;
                    pro.Satatus = product.Satatus;
                    context.Entry(pro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(string id)
        {
            var Pro = context.Products.Find(id);
            return View(Pro);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                var Pro = context.Products.Find(id);
                context.Remove(Pro);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
