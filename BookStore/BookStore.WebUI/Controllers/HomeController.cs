using System.Collections.Generic;
using System.Web.Mvc;
using BookStore.Business;
using BookStore.WebUI.Models;
using BookStore.Business.Dto;
using AutoMapper;

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
        public ActionResult GetAuthors() {
            var result = _authorService.GetAllAuthors();
            return PartialView("~/Views/Shared/AuthorsDisplaying.cshtml",Mapper.Map<IEnumerable<AuthorViewModel>>(result));
        }
    }
}