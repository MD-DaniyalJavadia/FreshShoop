using FreshShoop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FreshShoop.ViewModel;

using Microsoft.AspNetCore.Routing.Constraints;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace FreshShoop.Controllers
{

    public class CategoryController : Controller
    {
        ShopAppContext context;
        private IWebHostEnvironment env;

        public CategoryController(ShopAppContext context, IWebHostEnvironment env)
        {
            this.context = context;
            this.env = env;
        }
        // GET: CategoryController

        public ActionResult Index()
        {
            var Cat = context.Categories.ToList();
            return View(Cat);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(string id)
        {
            var Cate = context.Categories.Find(id);
            return View(Cate);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CategoryView category)
        {
            try
            {
                string uploadPath = "";
                string fileName = "";
                if (category.Image != null)
                {
                    fileName = Guid.NewGuid().ToString() + "_" + category.Image.FileName;
                    uploadPath = Path.Combine(env.WebRootPath, "Uploads", fileName);


                    Directory.CreateDirectory(Path.GetDirectoryName(uploadPath));


                    using (var stream = new FileStream(uploadPath, FileMode.Create))
                    {
                        await category.Image.CopyToAsync(stream);
                    }

                    Category Categ = new Category();
                    Categ.Id = Guid.NewGuid().ToString();
                    Categ.Name = category.Name;
                    Categ.Image = Path.Combine("uploads", fileName);
                    Categ.Status = "Active";
                    ShopAppContext appContext = new ShopAppContext();
                    appContext.Categories.Add(Categ);
                    appContext.SaveChanges();
                    return RedirectToAction(nameof(Create));
                }
                return RedirectToAction(nameof(Create));

            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(string id)
        {
            var catg = context.Categories.Find(id);
            CategoeryEditView categoryEdit = new CategoeryEditView();
            categoryEdit.Id = catg.Id;
            categoryEdit.Name = catg.Name;
            categoryEdit.Status = catg.Status;
            categoryEdit.ExistingPath = catg.Image;
            return View(categoryEdit);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, CategoeryEditView category)
        {

            //if(id!=category.Id)
            //{
            // return BadRequest();
            //}
            try
            {
                string uploadPath = "";
                string fileName = "";
                if (category.Image != null)
                {
                    fileName = Guid.NewGuid().ToString() + "_" + category.Image.FileName;
                    uploadPath = Path.Combine(env.WebRootPath, "Uploads", fileName);


                    Directory.CreateDirectory(Path.GetDirectoryName(uploadPath));


                    using (var stream = new FileStream(uploadPath, FileMode.Create))
                    {
                        await category.Image.CopyToAsync(stream);
                    }


                    Category Categ = context.Categories.Find(id);
                    Categ.Name = category.Name;
                    Categ.Image = Path.Combine("uploads", fileName);
                    Categ.Status = category.Status;
                    context.Entry(Categ).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Category Categ = context.Categories.Find(id);
                    Categ.Name = category.Name;
                    Categ.Status = category.Status;
                    context.Entry(Categ).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(string id)
        {
            var cat = context.Categories.Find(id);
            return View(cat);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                var Catg = context.Categories.Find(id);
                context.Remove(Catg);
                context.SaveChanges();
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
            }
        }
    }
}
