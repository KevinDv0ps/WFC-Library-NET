using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLibrary.Domain.Dtos.CreateDTO;
using WcfLibrary.Domain.Dtos.ResponseDTO;
using WcfLibrary.Domain.Dtos.UpdateDTO;

namespace WcfLibrary.Application.Interfaces.InterfaceService
{
    public interface IBookService
    {
        BookDTO GetById(int id_book);
        IEnumerable<BookDTO> GetAll();
        int CreateBook(BookCreateDTO bookDTO);
        bool UpdateBook(BookUpdateDTO bookDTO);
        bool DeleteBook(int id_book);
        IEnumerable<BookDTO> GetByAuthor(int id_author);
        IEnumerable<BookDTO> GetByGenre(int id_genre);
        BookDTO SearchByTittle(string name);
        bool GetAvailable(BookDTO bookDTO);
    }
}
