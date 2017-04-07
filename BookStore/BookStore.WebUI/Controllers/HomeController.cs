using System.Collections.Generic;
using System.Web.Mvc;
using BookStore.Business;
using BookStore.WebUI.Models;
using System.Linq;
using BookStore.Business.Dto;
using AutoMapper;
using AutoMapper.XpressionMapper;

namespace BookStore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IBookService _bookService;
        private IAuthorService _authorService;

        public HomeController(IBookService bookService, IAuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public PartialViewResult GetBooks()
        {
            var allBooks = _bookService.GetAllBooks();
            var result = Mapper.Map<IEnumerable<BookViewModel>>(allBooks).ToList();
            var authorsIdCollection = allBooks.Select(x => x.AuthorId).ToList();
            AuthorDto author = null;

            if (result != null)
            {
                for (var i = 0; i < result.Count(); i++)
                {                    
                    author = _authorService.FindAuthorById(authorsIdCollection[i]);
                    result[i].Author = Mapper.Map<AuthorViewModel>(author);                 
                }          
            }
            return PartialView("~/Views/Shared/BooksViewModelsDisplaying.cshtml",result);
        }
    }
}