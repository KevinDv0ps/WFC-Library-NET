using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLibrary.Domain.Entities;

namespace WcfLibrary.Application.Interfaces.InterfaceRepository
{
    public interface IBookRepository
    {
        // Obtener un libro por su ID
        // Devuelve null si no existe.
        Book GetById(int id_book);

        // Obtener todos los libros registrados.
        IEnumerable<Book> GetAll();

        // Crear un nuevo libro en la base de datos.
        void CreateBook(Book book);

        // Actualizar los datos de un libro (título, género, autor, etc.)
        void UpdateBook(Book book);

        // Eliminar un libro (si quieres manejar borrado lógico, lo harías en Infrastructure)
        void DeleteBook(Book id_book);

        // Obtener todos los libros de un autor específico
        IEnumerable<Book> GetByAuthor(int id_author);

        // Obtener todos los libros de un género específico
        IEnumerable<Book> GetByGenre(int id_genre);

        // Obtener libros por su título
        Book SearchByTittle(string name);
    }
}
