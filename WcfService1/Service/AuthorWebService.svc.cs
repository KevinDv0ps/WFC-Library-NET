using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfLibrary.Application.Interfaces.InterfaceRepository;
using WcfLibrary.Application.Interfaces.InterfaceService;
using WcfLibrary.Application.Services;
using WcfLibrary.Domain.Dtos.CreateDTO;
using WcfLibrary.Domain.Dtos.ResponseDTO;
using WcfLibrary.Domain.Dtos.UpdateDTO;
using WcfLibrary.Infrastructure.Data;
using WcfLibrary.Infrastructure.Repository;
using WcfService1.Contracts;

namespace WcfService1.Service
{

    public class AuthorWebService : IAuthorServiceContract
    {
        private readonly IAuthorService _authorService;
        private readonly IAuthorRepository repository;
        private readonly LibraryDbContext dataContextLibrary;


        public AuthorWebService()
        {
            dataContextLibrary = new LibraryDbContext();
            repository = new AuthorRepository(dataContextLibrary);
            _authorService = new AuthorService(repository);
        }
        public int CreateUser(AuthorCreateDTO dto)
        {
            try
            {
                var result = _authorService.CreateAuthor(dto);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public AuthorDTO GetUser(int id)
        {
            try
            {
                var result = _authorService.GetById(id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<AuthorDTO> GetUsers()
        {
            try
            {
                var result = _authorService.GetAll();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<AuthorDTO> SearchByName(string name)
        {
            try
            {
                var result = _authorService.SearchByName(name);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateAuthor(AuthorUpdateDTO authorDTO)
        {
            try
            {
                var result = _authorService.UpdateAuthor(authorDTO);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
