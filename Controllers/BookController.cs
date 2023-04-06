using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace BookMVC.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            using (BookDBEntities1 db = new BookDBEntities1())
            {
                List<tblBook> BookList = (from data in db.tblBooks select data).ToList();
                return View(BookList);
            }
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View(new tblBook());
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(tblBook book)
        {
            try
            {
                if ( (book.book_name != null) || (book.book_author != null) || (book.book_price != 0) ) 
                    {
                        using (BookDBEntities1 db = new BookDBEntities1())
                        {
                            db.tblBooks.Add(book);
                            db.SaveChanges();
                        }
                    }
                else
                    {
                        return Content("<center><h3>Something is missing !</h3></center>");
                    }
                return RedirectToAction("Index");

                // TODO: Add insert logic here

            }
            catch
            {
                return View();
            }
            
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            using (BookDBEntities1 db = new BookDBEntities1())
            {
                tblBook book = (from data in db.tblBooks where data.book_id == id select data).Single();
                return View(book);
            }
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(tblBook book)
        {
            try
            {
                // TODO: Add update logic here
                if ((book.book_name != null) || (book.book_author != null) || (book.book_price != 0))
                {
                    using (BookDBEntities1 db = new BookDBEntities1())
                    {
                        tblBook tbl = (from data in db.tblBooks where data.book_id == book.book_id select data).Single();
                        tbl.book_name = book.book_name;
                        tbl.book_author = book.book_author;
                        tbl.book_price = book.book_price;
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            using(BookDBEntities1 db = new BookDBEntities1())
            {
                db.tblBooks.Remove(db.tblBooks.Find(id));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
