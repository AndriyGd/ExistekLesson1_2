using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8.Generics
{
    public class BookRepository: BaseRepository<Book>
    {
        public List<Book> GetTopBooks(int countBooks)
        {
            return Entities.GetRange(0, countBooks);
        }
    }
}
