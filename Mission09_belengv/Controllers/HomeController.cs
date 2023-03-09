using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission09_belengv.Models;
using Mission09_belengv.Models.ViewModels;

namespace Mission09_belengv.Controllers
{
    public class HomeController : Controller
    {
        private BookstoreRepository repo;
        public HomeController (BookstoreRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index(string category, int pageNum = 1)
        {
            int pageSize = 10; //10 books per page only

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == category || category == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = 
                        (category == null 
                            ? repo.Books.Count() 
                            : repo.Books.Where(X => X.Category == category).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}