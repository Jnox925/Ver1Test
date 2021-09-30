using System.Collections.Generic;
using Project.App.Dominio;

namespace Project.App.Persistencia
{
    public interface IRepositorioDiagnostico
    {
        IEnumerable<Diagnostico> GetAllDiagnosticos(); 

        Diagnostico AddDiagnostico (Diagnostico vacuna);

        Diagnostico UpdateDiagnostico (Diagnostico vacuna);

        void DeleteDiagnostico (int idDiagnostico);

        Diagnostico GetDiagnostico (int idDiagnostico);
    }
}