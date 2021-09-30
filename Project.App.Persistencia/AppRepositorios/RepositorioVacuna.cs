using System.Collections.Generic;
using Project.App.Dominio;
using System.Linq;

namespace Project.App.Persistencia 
{
    public class RepositorioVacuna : IRepositorioVacuna
    {
        private readonly AppContext _appContext; 

        public RepositorioVacuna(AppContext appContext)
        {
            _appContext = appContext;
        } 

        Vacuna IRepositorioVacuna.AddVacuna(Vacuna vacuna)
        {
            var vacunaAdicionada = _appContext.Vacunas.Add(vacuna);
            _appContext.SaveChanges();
            return vacunaAdicionada.Entity;
        }

        IEnumerable<Vacuna> IRepositorioVacuna.GetAllVacunas()
        {
            return _appContext.Vacunas;
        }

        Vacuna IRepositorioVacuna.UpdateVacuna(Vacuna vacuna)
        {
            var vacunaEncontrada = _appContext.Vacunas.FirstOrDefault(p => p.id == vacuna.id);
            if ( vacunaEncontrada != null)
            {
                vacunaEncontrada.fabricante = vacuna.fabricante; 
                vacunaEncontrada.esquema = vacuna.esquema;
                
                _appContext.SaveChanges();
            }
            return vacunaEncontrada; 
        }

        void IRepositorioVacuna.DeleteVacuna(int idVacuna)
        {
            var vacunaEncontrada = _appContext.Vacunas.FirstOrDefault( p => p.id == idVacuna);
            if(vacunaEncontrada == null)
                return; 
            _appContext.Vacunas.Remove(vacunaEncontrada);
            _appContext.SaveChanges();
        }

        Vacuna IRepositorioVacuna.GetVacuna(int idVacuna)
        {
            return _appContext.Vacunas.FirstOrDefault( p => p.id == idVacuna); 
        }
    }
}