using ChieuThu6.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChieuThu6.Controllers
{
    public class BookController : Controller
    {
        // GET: BookController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListBook()
        {
            BookManagerContext context = new BookManagerContext();
            var listbook = context.Books.ToList();
            return View(listbook);
        }


        [Authorize]
        public ActionResult Buy(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if(book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book b)
        {
            BookManagerContext context = new BookManagerContext();
            if (b == null)
            {
                return HttpNotFound();
            }
            context.Books.AddOrUpdate(b);
            context.SaveChanges();
            return RedirectToAction("ListBook");
        }
        public ActionResult Details(int id)
        {
            BookManagerContext context = new BookManagerContext();
            var b = context.Books.Find(id);
            if(b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        public ActionResult Edit(int id)
        {
            BookManagerContext context = new BookManagerContext();
            var b = context.Books.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost]
        public ActionResult Edit(Book b)
        {
            BookManagerContext context = new BookManagerContext();
            if (b == null)
            {
                return HttpNotFound();
            }
            Book editBook = context.Books.FirstOrDefault(p => p.ID == b.ID);
            if (editBook != null)
            {
                editBook.Tieu_De = b.Tieu_De;
                editBook.Noi_Dung = b.Noi_Dung;
                editBook.Hinh_Anh = b.Hinh_Anh;
                editBook.Gia = b.Gia;
                context.Books.AddOrUpdate(b); //Add or Update Book b
                context.SaveChanges();
            }
            return RedirectToAction("ListBook");
        }
        public ActionResult Delete(int id)
        {
            BookManagerContext context = new BookManagerContext();
            var b = context.Books.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost]
        public ActionResult Delete(Book b)
        {
            BookManagerContext context = new BookManagerContext();
            if (b == null)
            {
                return HttpNotFound();
            }
            Book dbDelete = context.Books.FirstOrDefault(p => p.ID == b.ID);
            if (dbDelete != null)
            {
                context.Books.Remove(dbDelete);
                context.SaveChanges();
            }
            return RedirectToAction("ListBook");
        }
    }
}