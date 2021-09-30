using System.Collections.Generic;
using Project.App.Dominio;
using System.Linq;

namespace Project.App.Persistencia
{
    public class RepositorioSalon : IRepositorioSalon
    {
        private readonly AppContext _appContext; 

        public RepositorioSalon(AppContext appContext)
        {
            _appContext = appContext;
        } 

        Salon IRepositorioSalon.AddSalon(Salon salon)
        {
            var salonAdicionado = _appContext.Salones.Add(salon);
            _appContext.SaveChanges();
            return salonAdicionado.Entity;
        }

        IEnumerable<Salon> IRepositorioSalon.GetAllSalones()
        {
            return _appContext.Salones;
        }

        Salon IRepositorioSalon.UpdateSalon(Salon salon)
        {
            var salonEncontrado = _appContext.Salones.FirstOrDefault(p => p.id == salon.id);
            if ( salonEncontrado != null)
            {
                salonEncontrado.aforo = salon.aforo; 
                salonEncontrado.hora = salon.hora;
                
                _appContext.SaveChanges();
            }
            return salonEncontrado; 
        }

        void IRepositorioSalon.DeleteSalon(int idSalon)
        {
            var salonEncontrado = _appContext.Salones.FirstOrDefault( p => p.id == idSalon);
            if(salonEncontrado == null)
                return; 
            _appContext.Salones.Remove(salonEncontrado);
            _appContext.SaveChanges();
        }

        Salon IRepositorioSalon.GetSalon(int idSalon)
        {
            return _appContext.Salones.FirstOrDefault( p => p.id == idSalon); 
        }
    }
}