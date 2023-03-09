using Microsoft.AspNetCore.Mvc;
using Mission09_belengv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_belengv.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private BookstoreRepository repo { get; set; }
        public TypesViewComponent (BookstoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["category"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(X => X);

            return View(types);
        }
    }
}
