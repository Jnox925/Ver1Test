using System.Collections.Generic;
using Project.App.Dominio;

namespace Project.App.Persistencia
{
    public interface IRepositorioProfesor
    {
        IEnumerable<Profesor> GetAllProfesores(); 

        Profesor AddProfesor (Profesor profesor);

        Profesor UpdateProfesor (Profesor profesor);

        void DeleteProfesor (int idProfesor);

        Profesor GetProfesor (int idProfesor);
    }
}