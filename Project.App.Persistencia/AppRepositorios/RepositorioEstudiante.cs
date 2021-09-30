using System.Collections.Generic;
using Project.App.Dominio;
using System.Linq;

namespace Project.App.Persistencia
{
    public class RepositorioEstudiante : IRepositorioEstudiante
    {
        private readonly AppContext _appContext; 

        public RepositorioEstudiante(AppContext appContext)
        {
            _appContext = appContext;
        } 

        Estudiante IRepositorioEstudiante.AddEstudiante(Estudiante estudiante)
        {
            var estudianteAdicionado = _appContext.Estudiantes.Add(estudiante);
            _appContext.SaveChanges();
            return estudianteAdicionado.Entity;
        }

        IEnumerable<Estudiante> IRepositorioEstudiante.GetAllEstudiantes()
        {
            return _appContext.Estudiantes;
        }

        Estudiante IRepositorioEstudiante.UpdateEstudiante(Estudiante estudiante)
        {
            var estudianteEncontrado = _appContext.Estudiantes.FirstOrDefault(p => p.id == estudiante.id);
            if ( estudianteEncontrado != null)
            {
                estudianteEncontrado.nombre = estudiante.nombre; 
                estudianteEncontrado.apellidos = estudiante.apellidos;
                estudianteEncontrado.identificacion = estudiante.identificacion;
                estudianteEncontrado.edad = estudiante.edad;
                estudianteEncontrado.diagnostico = estudiante.diagnostico;
                estudianteEncontrado.vacuna = estudiante.vacuna;
                estudianteEncontrado.carrera = estudiante.carrera;
                estudianteEncontrado.semestre = estudiante.semestre;
                
                _appContext.SaveChanges();
            }
            return estudianteEncontrado; 
        }

        void IRepositorioEstudiante.DeleteEstudiante(int idEstudiante)
        {
            var estudianteEncontrado = _appContext.Estudiantes.FirstOrDefault( p => p.id == idEstudiante);
            if(estudianteEncontrado == null)
                return; 
            _appContext.Estudiantes.Remove(estudianteEncontrado);
            _appContext.SaveChanges();
        }

        Estudiante IRepositorioEstudiante.GetEstudiante(int idEstudiante)
        {
            return _appContext.Estudiantes.FirstOrDefault( p => p.id == idEstudiante); 
            
        }

    }
}