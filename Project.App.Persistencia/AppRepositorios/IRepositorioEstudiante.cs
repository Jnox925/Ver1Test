using System.Collections.Generic;
using Project.App.Dominio;

namespace Project.App.Persistencia
{
    public interface IRepositorioEstudiante
    {
        //Metodos CRUD
        IEnumerable<Estudiante> GetAllEstudiantes(); 

        Estudiante AddEstudiante(Estudiante estudiante);

        Estudiante UpdateEstudiante(Estudiante estudiante);

        void DeleteEstudiante(int idEstudiante);

        Estudiante GetEstudiante(int idEstudiante);
    }
}