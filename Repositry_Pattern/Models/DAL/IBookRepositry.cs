using Repositry_Pattern.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositry_Pattern.Models.DAL
{
    interface IBookRepositry:IDisposable
    {
        IEnumerable<BookVM> GetBookVMs();
        BookVM GetBookById(int bookId);
        void InsertBook(BookVM book);
        void DeleteBook(int bookID);

        void UpdateBook(BookVM bookVM);

        void Save();
    }
}
