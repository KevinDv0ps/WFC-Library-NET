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
    public class UserRepository : IUserRepository
    {
        private readonly LibraryDbContext dataContextLibrary;
        public UserRepository(LibraryDbContext context)
        {
            dataContextLibrary = context;
        }
        public void CreateUser(User user)
        {
            dataContextLibrary.Users.Add(user);
            dataContextLibrary.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return dataContextLibrary.Users.ToList();
        }

        public User GetByEmail(string mail)
        {
            return dataContextLibrary.Users.FirstOrDefault(e => e.email == mail);
        }

        public User GetById(int id_user)
        {
            return dataContextLibrary.Users.Find(id_user);
        }

        public void UpdateUser(User user)
        {
            dataContextLibrary.Users.AddOrUpdate(user);
            dataContextLibrary.SaveChanges();
        }
    }
}
