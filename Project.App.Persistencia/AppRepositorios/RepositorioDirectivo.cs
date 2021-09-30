using System.Collections.Generic;
using Project.App.Dominio;
using System.Linq;

namespace Project.App.Persistencia
{
    public class RepositorioDirectivo : IRepositorioDirectivo
    {
        private readonly AppContext _appContext; 

        public RepositorioDirectivo(AppContext appContext)
        {
            _appContext = appContext;
        } 

        Directivo IRepositorioDirectivo.AddDirectivo(Directivo directivo)
        {
            var directivoAdicionado = _appContext.Directivos.Add(directivo);
            _appContext.SaveChanges();
            return directivoAdicionado.Entity;
        }

        IEnumerable<Directivo> IRepositorioDirectivo.GetAllDirectivos()
        {
            return _appContext.Directivos;
        }

        Directivo IRepositorioDirectivo.UpdateDirectivo(Directivo directivo)
        {
            var directivoEncontrado = _appContext.Directivos.FirstOrDefault(p => p.id == directivo.id);
            if ( directivoEncontrado != null)
            {
                directivoEncontrado.nombre = directivo.nombre; 
                directivoEncontrado.apellidos = directivo.apellidos;
                directivoEncontrado.identificacion = directivo.identificacion;
                directivoEncontrado.edad = directivo.edad;
                directivoEncontrado.diagnostico = directivo.diagnostico;
                directivoEncontrado.vacuna = directivo.vacuna;
                directivoEncontrado.unidad = directivo.unidad;
                
                _appContext.SaveChanges();
            }
            return directivoEncontrado; 
        }

        void IRepositorioDirectivo.DeleteDirectivo(int idDirectivo)
        {
            var directivoEncontrado = _appContext.Directivos.FirstOrDefault( p => p.id == idDirectivo);
            if(directivoEncontrado == null)
                return; 
            _appContext.Directivos.Remove(directivoEncontrado);
            _appContext.SaveChanges();
        }

        Directivo IRepositorioDirectivo.GetDirectivo(int idDirectivo)
        {
            return _appContext.Directivos.FirstOrDefault( p => p.id == idDirectivo); 
        }
    }
}