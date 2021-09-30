using System.Collections.Generic;
using Project.App.Dominio;

namespace Project.App.Persistencia
{
    public interface IRepositorioSalon
    {
        IEnumerable<Salon> GetAllSalones(); 

        Salon AddSalon (Salon salon);

        Salon UpdateSalon (Salon salon);

        void DeleteSalon (int idSalon);

        Salon GetSalon (int idSalon);
    }
}