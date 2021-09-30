using System.Collections.Generic;
using Project.App.Dominio;

namespace Project.App.Persistencia
{
    public interface IRepositorioPersonalAseo
    {
        IEnumerable <PersonalAseo> GetAllPersonalAseos(); 

        PersonalAseo AddPersonalAseo (PersonalAseo personalAseo);

        PersonalAseo UpdatePersonalAseo (PersonalAseo personalAseo);

        void DeletePersonalAseo (int idPersonalAseo);

        PersonalAseo GetPersonalAseo (int idPersonalAseo);
    }
}