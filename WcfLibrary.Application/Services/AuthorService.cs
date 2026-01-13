using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLibrary.Application.Interfaces.InterfaceRepository;
using WcfLibrary.Application.Interfaces.InterfaceService;
using WcfLibrary.Domain.Dtos.CreateDTO;
using WcfLibrary.Domain.Dtos.ResponseDTO;
using WcfLibrary.Domain.Dtos.UpdateDTO;
using WcfLibrary.Domain.Entities;

namespace WcfLibrary.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public int CreateAuthor(AuthorCreateDTO authorDTO)
        {
            var author = new Author
            {
                first_name = authorDTO.first_name,
                second_name = authorDTO.second_name,
                first_lastname = authorDTO.first_lastname,
                second_lastname = authorDTO.second_lastname,
                nacionality = authorDTO.nacionality,
                birth_date = authorDTO.birth_date,
                death_date = authorDTO.death_date
            };

            _authorRepository.CreateAuthor(author);
            return author.id;
        }

        public IEnumerable<AuthorDTO> GetAll()
        {
            var authors = _authorRepository.GetALL();
            return authors.Select(a => new AuthorDTO
            {
                id_author = a.id,
                first_name = a.first_name,
                second_name = a.second_name,
                first_lastname = a.first_lastname,
                second_lastname = a.second_lastname,
                nacionality = a.nacionality,
                birth_date = a.birth_date,
                death_date = a.death_date,
            });
        }

        public AuthorDTO GetById(int id)
        {
            var author = _authorRepository.GetById(id);
            if (author == null) return null;
            return new AuthorDTO
            {
                id_author = author.id,
                first_name = author.first_name,
                second_name = author.second_name,
                first_lastname = author.first_lastname,
                second_lastname = author.second_lastname,
                nacionality = author.nacionality,
                birth_date = author.birth_date,
                death_date = author.death_date,
            };
        }

        public IEnumerable<AuthorDTO> SearchByName(string name)
        {
            var parts = name
                .ToLower()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var result = _authorRepository.SearchByName(parts);
            return result.Select(a => a == null ? null : new AuthorDTO
            {
                id_author = a.id,
                first_name = a.first_name,
                second_name = a.second_name,
                first_lastname = a.first_lastname,
                second_lastname = a.second_lastname,
                nacionality = a.nacionality,
                birth_date = a.birth_date,
                death_date = a.death_date,
            });
        }

        public bool UpdateAuthor(AuthorUpdateDTO authorDTO)
        {
            var author = _authorRepository.GetById(authorDTO.id);
            if (author == null) return false;

            //author.id = authorDTO.id;
            author.first_name = authorDTO.first_name;
            author.second_name = authorDTO.second_name;
            author.first_lastname = authorDTO.first_lastname;
            author.second_lastname = authorDTO.second_lastname;
            author.birth_date = authorDTO.birth_date;
            author.death_date = authorDTO.death_date;

            _authorRepository.UpdateAuthor(author);
            return true;
        }
    }
}
