﻿using DemoMVC.DataAccess;
using DemoMVC.Models;
using ut = DemoMVC.Utils.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class BookController : Controller
    {
        private string errorMessage = "";
        private BookContext db = new BookContext();
        [HttpGet]
        public ActionResult List()
        {
           // SetCookieIFNotExist();

            return View(db.bookRepozitory.findAll());
        }

      private void SetCookieIFNotExist()
        {
            HttpCookie bascket = Request.Cookies["bascket1"];
            if (bascket == null)
            {
                Response.Cookies["bascket1"].Value = string.Empty;
                Response.Cookies["bascket1"].Expires = DateTime.Now.AddMinutes(10);
            }
        }
        [HttpGet]
        public ActionResult Bucket()
        {
            return View();
        }
    [HttpPost]
        public ActionResult List(IList<Book> books)
        {
            return View(books);
        }
        public ActionResult EditBook(int? bookId, string errorMessage)
        {
            int id = ut.GetInt(bookId);
            if (id > 0)
            {
                ViewBag.ErrorMessage = errorMessage;
                Book bookModel = db.bookRepozitory.findBook(id);
                return View(bookModel);
            }
            else
            {//TODO:change to displaying message
                return RedirectToAction("List");
            }

        }
        [HttpPost]
        public ActionResult UpdateBook(Book model)
        {
            if (ModelState.IsValid)
            {
                bool isSaved = db.bookRepozitory.update(model);
                errorMessage = "";
                //todo:display success message
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("EditBook", new
                {
                    bookId = model.ID,
                    errorMessage = "Error in form book"
                });
            }

        }       
        [HttpPost]
        public string DeleteBook(int? bookId)
        {
            string statusCode = "0";
            int id = 0;
            if (int.TryParse("" + bookId, out id))
            {
                ViewBag.ErrorMessage = errorMessage;
                bool isDeleted =db.bookRepozitory.delete(id);
                return (isDeleted) ? "1" : "2";
            }
            else
            {
                return statusCode;
                
            }

        }
        [HttpPost]
        public string DeleteBooks(string bookIds)
        {
            string [] IDs = bookIds.Split(',');
            
            for (int i=0; i< IDs.Length-1; i++)
            {
                bool isDeleted = db.bookRepozitory.delete((Int32.Parse(IDs[i])));
               
            }
            return "1";
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(Book model)
        {          
            model.ID = new Random().Next(1000, 2000);
            if (ModelState.IsValid)
            {
                db.bookRepozitory.addBook(model);
                return RedirectToAction("List");
            }
            else
            {
                errorMessage = "Error in form book";
                return RedirectToAction("AddBook");
            }
        }

        [HttpGet]
        public ActionResult SearchBooks(string val)
        {
            if (val == "")
            {
                ViewBag.message = "Value canot be empty";
                return View("List");
            }
            else
            {
                IList<Book> findedBooks = db.bookRepozitory.searchBooks(val);
                ViewBag.model = findedBooks;
                return View("List", findedBooks);
            }
        }
       
    }
}