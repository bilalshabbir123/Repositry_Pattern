using Repositry_Pattern.Models.Data;
using Repositry_Pattern.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repositry_Pattern.Models.DAL
{
    public class BookRepositry : IBookRepositry
    {
        private Db db;

        public BookRepositry(Db db)
        {
            this.db = db;
        }

        public void DeleteBook(int bookID)
        {
                BookDTO dto = db.Books.Find(bookID);
                //Remove the books
                db.Books.Remove(dto);
                //Save 
                db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public BookVM GetBookById(int bookId)
        {
            BookVM model;
            BookDTO dto = db.Books.Find(bookId);
            model = new BookVM(dto);
            return model;
        }

        public IEnumerable<BookVM> GetBookVMs()
        {
            List<BookVM> listofbooks;
            using (Db db=new Db ())
            {
                listofbooks = db.Books.ToArray().Select(x => new BookVM(x)).ToList();
            }
            return (listofbooks);
        }

        public void InsertBook(BookVM model)
        {
           

            using (Db db = new Db())
            {
                // Init BookDTO
                BookDTO dto = new BookDTO();
                // DTO Title
                dto.Name = model.Name;
                // Make sure the Book Name is Unique

                //if (db.Books.Any(x => x.Name == model.Name))
                //{
                //    ModelState.AddModelError("", "That Name are Already Exists");
                //    return View(model);

                //}
                // BookDTO the reset
                dto.Name = model.Name;
                dto.Publisher = model.Publisher;
                dto.Author = model.Author;
                dto.Description = model.Description;
                // save dto
                db.Books.Add(dto);
                db.SaveChanges();
            }
        }

        public void Save()
        {
            using (Db db=new Db ())
            {
                db.SaveChanges();
            }
        }

        public void UpdateBook(BookVM bookVM)
        {
            using (Db db = new Db())
            {
                // Get book id
                int id = bookVM.Id;
                BookDTO dto = db.Books.Find(id);
                dto.Name = bookVM.Name;
                // Make sure the book name is Unique
                //if (db.Books.Any(x => x.Name == bookVM.Name))
                //{
                //    ModelState.AddModelError("", "That Book are already Exists");
                //}
                // DTO the reset
                dto.Name = bookVM.Name;
                dto.Publisher = bookVM.Publisher;
                dto.Author = bookVM.Author;
                dto.Description = bookVM.Description;
                //save the dto
                db.SaveChanges();
            }
            // Set TempMessage
            //TempData["SM"] = "You have Successfully Edit a Page";
        }
    }
}