using System.Collections.Generic;
using Project.App.Dominio;

namespace Project.App.Persistencia
{
    public interface IRepositorioInstalaciones
    {
        IEnumerable <Instalaciones> GetAllInstalaciones(); 

        Instalaciones AddInstalaciones (Instalaciones instalaciones);

        Instalaciones UpdateInstalaciones (Instalaciones instalaciones);

        void DeleteInstalaciones (int idInstalaciones);

        Instalaciones GetInstalaciones (int idInstalaciones);
    }
}