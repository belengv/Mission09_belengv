using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_belengv.Models
{
    public class EFBookstoreRepository : BookstoreRepository
    {
        private BookstoreContext context { get; set; }
        public EFBookstoreRepository(BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Book> Books => context.Books;
    }
}
