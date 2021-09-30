using System.Collections.Generic;
using Project.App.Dominio;
using System.Linq;

namespace Project.App.Persistencia
{
    public class RepositorioDiagnostico : IRepositorioDiagnostico
    {
        private readonly AppContext _appContext; 

        public RepositorioDiagnostico(AppContext appContext)
        {
            _appContext = appContext;
        } 

        Diagnostico IRepositorioDiagnostico.AddDiagnostico(Diagnostico diagnostico)
        {
            var diagnosticoAdicionado = _appContext.Diagnosticos.Add(diagnostico);
            _appContext.SaveChanges();
            return diagnosticoAdicionado.Entity;
        }
        
        IEnumerable<Diagnostico> IRepositorioDiagnostico.GetAllDiagnosticos()
        {
            return _appContext.Diagnosticos;
        }

        Diagnostico IRepositorioDiagnostico.UpdateDiagnostico(Diagnostico diagnostico)
        {
            var diagnosticoEncontrado = _appContext.Diagnosticos.FirstOrDefault(p => p.id == diagnostico.id);
            if ( diagnosticoEncontrado != null)
            {
                diagnosticoEncontrado.sintomas = diagnostico.sintomas; 
                diagnosticoEncontrado.fecha = diagnostico.fecha;
                
                _appContext.SaveChanges();
            }
            return diagnosticoEncontrado; 
        }

        void IRepositorioDiagnostico.DeleteDiagnostico(int idDiagnostico)
        {
            var diagnosticoEncontrado = _appContext.Diagnosticos.FirstOrDefault( p => p.id == idDiagnostico);
            if(diagnosticoEncontrado == null)
                return; 
            _appContext.Diagnosticos.Remove(diagnosticoEncontrado);
            _appContext.SaveChanges();
        }

        Diagnostico IRepositorioDiagnostico.GetDiagnostico(int idDiagnostico)
        {
            return _appContext.Diagnosticos.FirstOrDefault( p => p.id == idDiagnostico); 
        }
    }
}