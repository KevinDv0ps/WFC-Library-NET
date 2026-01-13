using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLibrary.Domain.Entities;

namespace WcfLibrary.Application.Interfaces.InterfaceRepository
{
    public interface IAuthorRepository
    {
        // Obtener todos los autores registrados.
        IEnumerable<Author> GetALL();

        // Obtener un autor por su ID
        // Devuelve null si no existe.
        Author GetById(int id_author);

        // Crear un nuevo autor en la base de datos.
        void CreateAuthor(Author author);

        // Actualizar los datos de un autor (nombre, nacionalidad, etc.)
        void UpdateAuthor(Author author);

        // Obtener autores por su nombre
        IEnumerable<Author> SearchByName(string[] name);
    }
}
