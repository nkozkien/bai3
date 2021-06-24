using lab3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab3.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult ListBook()
        {
            BookManagerContext context = new BookManagerContext();
            var listBook = context.Books.ToList();
            return View(listBook);
        }
        [Authorize]
        public ActionResult Buy(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [Authorize]
        public ActionResult CreateBook()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult CreateBook(Book book)
        {
            BookManagerContext context = new BookManagerContext();
            context.Books.AddOrUpdate(book);
            context.SaveChanges();
            return RedirectToAction("ListBook");

        }
        [Authorize]
        public ActionResult EditBook(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            BookManagerContext context = new BookManagerContext();
            Book bookUpdate = context.Books.SingleOrDefault(p => p.ID == book.ID);
            if (bookUpdate != null)
            {
                context.Books.AddOrUpdate(book);
                context.SaveChanges();
            }

            return RedirectToAction("ListBook");

        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [Authorize]
        [HttpPost]
        public ActionResult DeleteBook(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if (book != null)
            {
                context.Books.Remove(book);
                context.SaveChanges();
            }
            return RedirectToAction("ListBook");
        }
    }

    }