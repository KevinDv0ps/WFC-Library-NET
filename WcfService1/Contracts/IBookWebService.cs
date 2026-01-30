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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IBookWebService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IBookWebService
    {
        [OperationContract]
        BookDTO GetByBookId(int id_book);
        [OperationContract]
        IEnumerable<BookDTO> GetAll();
        [OperationContract]
        int CreateBook(BookCreateDTO bookDTO);
        [OperationContract]
        bool UpdateBook(BookUpdateDTO bookDTO);
        [OperationContract]
        bool DeleteBook(int id_book);
        [OperationContract]
        IEnumerable<BookDTO> GetByAuthor(int id_author);
        [OperationContract]
        IEnumerable<BookDTO> GetByGenre(int id_genre);
        [OperationContract]
        BookDTO SearchByTitle(string name);
        [OperationContract]
        bool GetAvailable(BookDTO bookDTO);
    }
}
