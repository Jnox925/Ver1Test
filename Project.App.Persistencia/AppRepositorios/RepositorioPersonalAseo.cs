using System.Collections.Generic;
using Project.App.Dominio;
using System.Linq;

namespace Project.App.Persistencia.AppRepositorios
{
    public class RepositorioPersonalAseo : IRepositorioPersonalAseo
    {
        private readonly AppContext _appContext; 

        public RepositorioPersonalAseo(AppContext appContext)
        {
            _appContext = appContext;
        } 

        PersonalAseo IRepositorioPersonalAseo.AddPersonalAseo(PersonalAseo personalAseo)
        {
            var personalAseoAdicionado = _appContext.PersonalAseos.Add(personalAseo);
            _appContext.SaveChanges();
            return personalAseoAdicionado.Entity;
        }

        IEnumerable<PersonalAseo> IRepositorioPersonalAseo.GetAllPersonalAseos()
        {
            return _appContext.PersonalAseos;
        }

        PersonalAseo IRepositorioPersonalAseo.UpdatePersonalAseo(PersonalAseo personalAseo)
        {
            var personalAseoEncontrado = _appContext.PersonalAseos.FirstOrDefault(p => p.id == personalAseo.id);
            if ( personalAseoEncontrado != null)
            {
                personalAseoEncontrado.nombre = personalAseo.nombre; 
                personalAseoEncontrado.apellidos = personalAseo.apellidos;
                personalAseoEncontrado.identificacion = personalAseo.identificacion;
                personalAseoEncontrado.edad = personalAseo.edad;
                personalAseoEncontrado.diagnostico = personalAseo.diagnostico;
                personalAseoEncontrado.vacuna = personalAseo.vacuna;
                personalAseoEncontrado.turno = personalAseo.turno;
                
                _appContext.SaveChanges();
            }
            return personalAseoEncontrado; 
        }

        void IRepositorioPersonalAseo.DeletePersonalAseo(int idPersonalAseo)
        {
            var personalAseoEncontrado = _appContext.PersonalAseos.FirstOrDefault( p => p.id == idPersonalAseo);
            if(personalAseoEncontrado == null)
                return; 
            _appContext.PersonalAseos.Remove(personalAseoEncontrado);
            _appContext.SaveChanges();
        }

        PersonalAseo IRepositorioPersonalAseo.GetPersonalAseo(int idPersonalAseo)
        {
            return _appContext.PersonalAseos.FirstOrDefault( p => p.id == idPersonalAseo); 
        }
    }
}