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
    public interface IAuthorService
    {
        int CreateAuthor(AuthorCreateDTO dto);
        IEnumerable<AuthorDTO> GetAll();
        AuthorDTO GetById(int id);
        bool UpdateAuthor(AuthorUpdateDTO authorDTO);
        IEnumerable<AuthorDTO> SearchByName(string name);
    }
}
