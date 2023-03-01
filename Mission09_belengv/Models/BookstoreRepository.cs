using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_belengv.Models
{
    public interface BookstoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}
