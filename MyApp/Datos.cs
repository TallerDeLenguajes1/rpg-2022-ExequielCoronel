using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPG
{
    public class Datos
    {
        private string tipo;
        private string nombre;
        private string apodo;
        private DateTime fechaDeNacimiento;
        private int salud;//=100

        public string tipo
        {
            get;
            set;
        }

        public string nombre
        {
            get;
            set;
        }

        public string apodo
        {
            get;
            set;
        }

        public DateTime fechaDeNacimiento
        {
            get;
            set;
        }

        public int salud 
        {
            get;
            set;
        }

        int edad()
        {
            return (fechaDeNacimiento);
        }
        
    }
}