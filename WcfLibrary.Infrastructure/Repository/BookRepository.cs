using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLibrary.Application.Interfaces.InterfaceRepository;
using WcfLibrary.Domain.Entities;
using System.Data.Entity;
using WcfLibrary.Infrastructure.Data;


namespace WcfLibrary.Infrastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext dataContextLibrary;
        public BookRepository(LibraryDbContext context)
        {
            dataContextLibrary = context;
        }
        public void CreateBook(Book book)
        {
            dataContextLibrary.Books.Add(book);
            dataContextLibrary.SaveChanges();
        }

        public void DeleteBook(Book id_book)
        {
            dataContextLibrary?.Books.Remove(id_book);
            dataContextLibrary.SaveChanges();
        }

        public IEnumerable<Book> GetAll()
        {
            return dataContextLibrary.Books.ToList();
        }

        public IEnumerable<Book> GetByAuthor(int id_author)
        {
            return dataContextLibrary.Books
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .Where(d => d.Authors.Any(a => a.id == id_author))
                .ToList();
        }

        public IEnumerable<Book> GetByGenre(int id_genre)
        {
            return dataContextLibrary.Books
                .Include(b => b.Authors)
                .Include (b => b.Genres)
                .Where(g => g.Genres.Any(b => b.id == id_genre))
                .ToList();
                
        }

        public Book GetById(int id_book)
        {
            return dataContextLibrary.Books
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .FirstOrDefault(b => b.id == id_book);
        }

        public Book SearchByTitle(string name)
        {
            return dataContextLibrary.Books
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .FirstOrDefault(a => a.title.ToLower() == name.ToLower());
        }

        public void UpdateBook(Book book)
        {
            dataContextLibrary.Books.AddOrUpdate(book);
            dataContextLibrary.SaveChanges();
        }
    }
}
