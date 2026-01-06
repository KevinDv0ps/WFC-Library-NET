using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLibrary.Domain.Entities;

namespace WcfLibrary.Application.Interfaces.InterfaceRepository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(int id_user);
        void CreateUser(User user);
        void UpdateUser(User user);
        // Busca un usuario por su nombre de usuario o email para validar login.
        User GetByEmail(string mail);
    }
}
