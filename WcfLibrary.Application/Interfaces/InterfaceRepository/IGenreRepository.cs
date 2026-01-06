using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLibrary.Domain.Entities;

namespace WcfLibrary.Application.Interfaces.InterfaceRepository
{
    public interface IGenreRepository
    {
        // Obtener todos los géneros registrados.
        IEnumerable<Genre> GetAll();
        // Obtener un género por su ID
        // Devuelve null si no existe.
        Genre GetById(int id_genre);
        // Crear un nuevo género en la base de datos.
        void CreateGenre(Genre genre);
        // Actualizar los datos de un género (nombre)
        void UpdateGenre(Genre genre);
        // Obtener géneros por su nombre (devuelve un solo resultado o null)
        Genre GetByName(string name);

    }
}
