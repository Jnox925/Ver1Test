using System.Collections.Generic;
using Project.App.Dominio;

namespace Project.App.Persistencia
{
    public interface IRepositorioDirectivo
    {
        IEnumerable <Directivo> GetAllDirectivos(); 

        Directivo AddDirectivo (Directivo directivo);

        Directivo UpdateDirectivo (Directivo directivo);

        void DeleteDirectivo (int idDirectivo);

        Directivo GetDirectivo (int idDirectivo);
    }
}