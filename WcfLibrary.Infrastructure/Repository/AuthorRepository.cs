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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext dataContextLibrary;
        public AuthorRepository(LibraryDbContext context)
        {
            dataContextLibrary = context;
        }

        public void CreateAuthor(Author author)
        {
            dataContextLibrary.Authors.Add(author);
            dataContextLibrary.SaveChanges();
        }

        public IEnumerable<Author> GetALL()
        {
            return dataContextLibrary.Authors.ToList();
        }

        public Author GetById(int id_author)
        {
            return dataContextLibrary.Authors.Find(id_author);
        }

        public IEnumerable<Author> SearchByName(string[] name)
        {
            return dataContextLibrary.Authors
                .Where(author =>
                    name.All(p =>
                        author.first_name.ToLower().Contains(p) ||
                        (author.second_name != null && author.second_name.ToLower().Contains(p)) ||
                        author.first_lastname.ToLower().Contains(p) ||
                        (author.second_lastname != null && author.second_lastname.ToLower().Contains(p))
                    )
                )
                .ToList();
        }

        public void UpdateAuthor(Author author)
        {
            dataContextLibrary.Authors.AddOrUpdate(author);
            dataContextLibrary.SaveChangesAsync();
        }

    }
}
