using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Author>> GetAsync()
        {
            return await dataContextLibrary.Authors.ToListAsync();
        }

        public async Task<Author?> GetAsyncById(int id_author)
        {
            return await dataContextLibrary.Authors.FindAsync(id_author);
        }

        public async Task<IEnumerable<Author?>> SearchByNameAsync(string[] name)
        {
            return await dataContextLibrary.Authors
                .Where(author =>
                    name.All(p =>
                        author.first_name.ToLower().Contains(p) ||
                        (author.second_name != null && author.second_name.ToLower().Contains(p)) ||
                        author.first_lastname.ToLower().Contains(p) ||
                        (author.second_lastname != null && author.second_lastname.ToLower().Contains(p))
                    )
                )
                .ToListAsync();
        }

        public async Task UpdateAsync(Author author)
        {
            dataContextLibrary.Authors.Update(author);
            await dataContextLibrary.SaveChangesAsync();
        }

    }
}
