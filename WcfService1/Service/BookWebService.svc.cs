using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfLibrary.Domain.Dtos.CreateDTO;
using WcfLibrary.Domain.Dtos.ResponseDTO;
using WcfLibrary.Domain.Dtos.UpdateDTO;

namespace WcfService1.Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "BookWebService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione BookWebService.svc o BookWebService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class BookWebService : IBookWebService
    {
        public int CreateBook(BookCreateDTO bookDTO)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBook(int id_book)
        {
            throw new NotImplementedException();
        }

        public void DoWork()
        {
        }

        public IEnumerable<BookDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool GetAvailable(BookDTO bookDTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookDTO> GetByAuthor(int id_author)
        {
            throw new NotImplementedException();
        }

        public BookDTO GetByBookId(int id_book)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookDTO> GetByGenre(int id_genre)
        {
            throw new NotImplementedException();
        }

        public BookDTO SearchByTitle(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBook(BookUpdateDTO bookDTO)
        {
            throw new NotImplementedException();
        }
    }
}
