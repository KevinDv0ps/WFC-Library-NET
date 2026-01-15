using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLibrary.Application.Interfaces.InterfaceRepository;
using WcfLibrary.Domain.Entities;
using WcfLibrary.Infrastructure.Data;

namespace WcfLibrary.Infrastructure.Repository
{
    internal class GenreRepository: IGenreRepository
    {
        private readonly LibraryDbContext dataContextLibrary;
        public GenreRepository(LibraryDbContext context)
        {
            dataContextLibrary = context;
        }

        public void CreateGenre(Genre genre)
        {
            dataContextLibrary.Genres.Add(genre);
            dataContextLibrary.SaveChanges();
        }

        public IEnumerable<Genre> GetAll()
        {
            return dataContextLibrary.Genres.ToList();
        }

        public Genre GetById(int id_genre)
        {
            return dataContextLibrary.Genres.Find(id_genre);
        }

        public Genre GetByName(string name)
        {
            return dataContextLibrary.Genres.FirstOrDefault(g => g.genre_name.ToLower() == name.ToLower());
        }

        public void UpdateGenre(Genre genre)
        {
            dataContextLibrary.Genres.AddOrUpdate(genre);
            dataContextLibrary.SaveChanges();
        }
    }
}
