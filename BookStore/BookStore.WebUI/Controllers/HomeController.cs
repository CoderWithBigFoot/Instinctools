using System.Collections.Generic;
using System.Web.Mvc;
using BookStore.Business;
using BookStore.WebUI.Models;
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
        public PartialViewResult GetAuthors() {
            var authorsCollection = _authorService.GetAllAuthors();
            var result = Mapper.Map<IEnumerable<AuthorViewModel>>(authorsCollection);
            return PartialView("~/Views/Shared/AuthorsDisplaying.cshtml", result);
        }

        [HttpGet]
        public PartialViewResult GetAuthor() {
            var author = _authorService.FindAuthorById(1);
            var result = Mapper.Map<AuthorViewModel>(author);
            return PartialView("/Views/Shared/AuthorViewModelDisplaying.cshtml", result);
        }

        [HttpGet]
        public PartialViewResult GetAuthorByPredicate() {
            var author = _authorService.FindAuthorsBy(x => x.Id == 1);
            var result = Mapper.Map<AuthorViewModel>(author);
            return PartialView("/Views/Shared/AuthorViewModelDisplaying.cshtml", result);
        }
    }
}