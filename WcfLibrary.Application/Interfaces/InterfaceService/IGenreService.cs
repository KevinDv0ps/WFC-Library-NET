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
    public interface IGenreService
    {
        int CreateGenre(GenreCreateDTO dto);
        IEnumerable<GenreDTO> GetAll();
        GenreDTO GetById(int id);
        bool UpdateGenre(GenreUpdateDTO dto);
    }
}
