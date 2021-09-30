using System.Collections.Generic;
using Project.App.Dominio;
using System.Linq;

namespace Project.App.Persistencia.AppRepositorios
{
    public class RepositorioInstalaciones : IRepositorioInstalaciones
    {
        private readonly AppContext _appContext; 

        public RepositorioInstalaciones(AppContext appContext)
        {
            _appContext = appContext;
        } 

        Instalaciones IRepositorioInstalaciones.AddInstalaciones(Instalaciones personalAseo)
        {
            var instalacionesAdicionada = _appContext.InstalacionesDb.Add(personalAseo);
            _appContext.SaveChanges();
            return instalacionesAdicionada.Entity;
        }

        IEnumerable<Instalaciones> IRepositorioInstalaciones.GetAllInstalaciones()
        {
            return _appContext.InstalacionesDb;
        }

        Instalaciones IRepositorioInstalaciones.UpdateInstalaciones(Instalaciones instalacionesAseo)
        {
            var instalacionesAseoEncontrada = _appContext.InstalacionesDb.FirstOrDefault(p => p.id == instalacionesAseo.id);
            if ( instalacionesAseoEncontrada != null)
            {
                instalacionesAseoEncontrada.salon = instalacionesAseo.salon; 
                
                _appContext.SaveChanges();
            }
            return instalacionesAseoEncontrada; 
        }

        void IRepositorioInstalaciones.DeleteInstalaciones(int idInstalaciones)
        {
            var instalacionesAseoEncontrado = _appContext.InstalacionesDb.FirstOrDefault( p => p.id == idInstalaciones);
            if(instalacionesAseoEncontrado == null)
                return; 
            _appContext.InstalacionesDb.Remove(instalacionesAseoEncontrado);
            _appContext.SaveChanges();
        }

        Instalaciones IRepositorioInstalaciones.GetInstalaciones(int idInstalaciones)
        {
            return _appContext.InstalacionesDb.FirstOrDefault( p => p.id == idInstalaciones); 
        }
    }
}