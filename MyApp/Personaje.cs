using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPG
{
    public class Personaje
    {
        private Datos datos;
        private Caracteristicas caracteristicas;

        public Datos datos
        {
            get;
            set;
        }

        public Caracteristicas caracteristicas
        {
            get;
            set;
        }
    }
}