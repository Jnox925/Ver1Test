using System.Collections.Generic;
using Project.App.Dominio;

namespace Project.App.Persistencia
{
    public interface IRepositorioVacuna
    {
        IEnumerable<Vacuna> GetAllVacunas(); 

        Vacuna AddVacuna (Vacuna vacuna);

        Vacuna UpdateVacuna (Vacuna vacuna);

        void DeleteVacuna (int idVacuna);

        Vacuna GetVacuna (int idVacuna);
    }
}