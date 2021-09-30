using System;

namespace Project.App.Dominio
{
    public class Persona
    {
        public int id{get;set;}

        public string nombre{get;set;}

        public string apellidos{get;set;}

        public string identificacion{get;set;}

        public int edad{get;set;}

        public Diagnostico diagnostico{get;set;}
        
        public Vacuna vacuna{get;set;}
    }
}