using Repositry_Pattern.Models.DAL;
using Repositry_Pattern.Models.Data;
using Repositry_Pattern.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repositry_Pattern.Controllers
{
    public class MyBooksController : Controller
    {

        private IBookRepositry interfaceobj;
        // Declare Constructor
        public MyBooksController()
        {
            interfaceobj = new BookRepositry(new Db());
        }
        // MyBooks/Index shows the books list
        [HttpGet]
        public ActionResult Index()
        {
            var data = from m in interfaceobj.GetBookVMs() select m;
            return View(data);
        }
        // MyBooks/CreateBook
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(BookVM book)
        {
           // Check Model State
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            interfaceobj.InsertBook(book);
            interfaceobj.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            BookVM b = interfaceobj.GetBookById(id);
            return View(b);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            BookVM b = interfaceobj.GetBookById(id);
            return View(b);
        }
        [HttpPost]
        public ActionResult Edit(BookVM book)
        {
            interfaceobj.UpdateBook(book);
            interfaceobj.Save();
            // Set TempMessage
            TempData["SM"] = "You have Successfully Edit a Page";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
         
            interfaceobj.DeleteBook(id);
            interfaceobj.Save();
            return RedirectToAction("Index");
        }
    }
}