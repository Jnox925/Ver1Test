using System.Collections.Generic;
using Project.App.Dominio;
using System.Linq;

namespace Project.App.Persistencia
{
    public class RepositorioProfesor : IRepositorioProfesor
    {
        private readonly AppContext _appContext; 

        public RepositorioProfesor(AppContext appContext)
        {
            _appContext = appContext;
        } 

        Profesor IRepositorioProfesor.AddProfesor(Profesor profesor)
        {
            var profesorAdicionado = _appContext.Profesores.Add(profesor);
            _appContext.SaveChanges();
            return profesorAdicionado.Entity;
        }

        IEnumerable<Profesor> IRepositorioProfesor.GetAllProfesores()
        {
            return _appContext.Profesores;
        }

        Profesor IRepositorioProfesor.UpdateProfesor(Profesor profesor)
        {
            var profesorEncontrado = _appContext.Profesores.FirstOrDefault(p => p.id == profesor.id);
            if ( profesorEncontrado != null)
            {
                profesorEncontrado.nombre = profesor.nombre; 
                profesorEncontrado.apellidos = profesor.apellidos;
                profesorEncontrado.identificacion = profesor.identificacion;
                profesorEncontrado.edad = profesor.edad;
                profesorEncontrado.diagnostico = profesor.diagnostico;
                profesorEncontrado.vacuna = profesor.vacuna;
                profesorEncontrado.departamento = profesor.departamento;
                profesorEncontrado.materia = profesor.materia;
                
                _appContext.SaveChanges();
            }
            return profesorEncontrado; 
        }

        void IRepositorioProfesor.DeleteProfesor(int idProfesor)
        {
            var profesorEncontrado = _appContext.Profesores.FirstOrDefault( p => p.id == idProfesor);
            if(profesorEncontrado == null)
                return; 
            _appContext.Profesores.Remove(profesorEncontrado);
            _appContext.SaveChanges();
        }

        Profesor IRepositorioProfesor.GetProfesor(int idProfesor)
        {
            return _appContext.Profesores.FirstOrDefault( p => p.id == idProfesor); 
        }
    }
}