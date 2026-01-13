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
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public int CreateGenre(GenreCreateDTO genreDto)
        {
            var exist = _genreRepository.GetByName(genreDto.genre_name);
            if (exist != null) return 0;
            var genre = new Genre
            {
                genre_name = genreDto.genre_name,
            };
            _genreRepository.CreateGenre(genre);
            return genre.id;
        }

        public IEnumerable<GenreDTO> GetAll()
        {
            var genres = _genreRepository.GetAll();

            return genres.Select(g => new GenreDTO
            {
                id_genre = g.id,
                genre_name = g.genre_name
            });
        }

        public GenreDTO GetById(int id)
        {
            var genre = _genreRepository.GetById(id);
            if (genre == null) return null;
            return new GenreDTO
            {
                id_genre = genre.id,
                genre_name = genre.genre_name
            };
        }

        public bool UpdateGenre(GenreUpdateDTO genreDto)
        {
            var genre = _genreRepository.GetById(genreDto.id);
            if (genre == null) return false;

            var exist = _genreRepository.GetByName(genreDto.genre_name);
            if (exist != null && exist.id != genreDto.id) return false;

            genre.genre_name = genreDto.genre_name;
            _genreRepository.UpdateGenre(genre);
            return true;
        }
    }
}
