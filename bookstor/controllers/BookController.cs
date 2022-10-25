using bookstor.modle.Reposiories;
using bookstor.modle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using bookstor.viewmodles;
using System.Linq;
using System.Collections.Generic;

namespace bookstor.controllers
{
    public class BookController : Controller
    {
        private readonly ibookStore<Book> bookRepository;
        private readonly ibookStore<Author> authorRepository;

        public BookController(ibookStore<Book> bookRepository,ibookStore<Author>authorRepository)
        {
            this.bookRepository = bookRepository;
            this.authorRepository = authorRepository;
        }
        // GET: BookController
        public ActionResult Index()
        {
            var books = bookRepository.List();
            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book = bookRepository.Find(id);
            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            var model = new BookAuthorViewModle
            {
                authors = FillSelectList()
            };
            return View(model);
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAuthorViewModle Model)
        {
            try
            {
                if (Model.AuhtorID == -1)
                {
                    ViewBag.Message = "please select an Author from tehe list";
                    var vmodel = new BookAuthorViewModle
                    {
                        authors = FillSelectList()
                    };
                    return View(vmodel); 
                }
                var author = authorRepository.Find(Model.AuhtorID);
                Book book = new Book
                {
                    id=Model.BookID,
                    title=Model.title,
                    Description=Model.Description,
                    Author=author

                };
                bookRepository.Add(book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var book = bookRepository.Find(id);
            var authorID = book.Author == null ? book.Author.id = 0 : book.Author.id;
            var viewModel = new BookAuthorViewModle
            {
                BookID = book.id,
                title = book.title,
                Description = book.Description,
                AuhtorID = authorID,
                authors = authorRepository.List().ToList(),

            };
            return View(viewModel);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,BookAuthorViewModle viewModle)
        {
            try
            {
                var author = authorRepository.Find(viewModle.AuhtorID);
                Book book = new Book
                {
                    
                    title = viewModle.title,
                    Description = viewModle.Description,
                    Author = author

                };
                bookRepository.Update(viewModle.BookID,book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var book = bookRepository.Find(id);
            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)

        {
            bookRepository.Delete(id);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        List<Author> FillSelectList()
        {
            var authors = authorRepository.List().ToList();
            authors.Insert(0, new Author { id = -1, fullname = "---please select Author" });
            return authors;
        }
    }
}
