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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IGenreWebService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IGenreWebService
    {
        [OperationContract]
        int CreateGenre(GenreCreateDTO dto);
        [OperationContract]
        IEnumerable<GenreDTO> GetAll();
        [OperationContract]
        GenreDTO GetByGnereId(int id);
        [OperationBehavior]
        bool UpdateGenre(GenreUpdateDTO dto);
    }
}
