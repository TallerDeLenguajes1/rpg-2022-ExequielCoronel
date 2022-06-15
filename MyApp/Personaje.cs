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
        public Datos Datos { get => this.datos; set => this.datos = value; }
        public Caracteristicas Caracteristicas { get => this.caracteristicas; set => this.caracteristicas = value; }

        public Personaje()
        {
            datos = new Datos();
            caracteristicas = new Caracteristicas();
        }

        public void restaurarSalud()
        {
            datos.Salud=5000;
        }
        public void CrearPjAleatorio()
        {
            int selector;
            string [] N = new string[6] {"Luke","Joshep","Patrick","Natalie","Caroline","Mikel"};
            string [] A = new string[6] {"Gordon","Young","Falcon","Barrios","Philips","Filmus"};
            string [] apodo = new string[9] {"Alpha","Locus","Fear","Seth","Isceradin","Grin","Razor","Slade","Dark"};
            Random rnd = new Random();
            Datos.Nombre = N[rnd.Next(0,N.Count())] + " " + A[rnd.Next(0,A.Count())];
            Datos.Apodo = apodo[rnd.Next(0,apodo.Count())];
            Datos.Salud=5000;
            Datos.FechaDeNacimiento = new DateTime(rnd.Next(Datos.FechaPelea1.Year-299,Datos.FechaPelea1.Year),rnd.Next(1,13),rnd.Next(1,30));
            selector = rnd.Next(1,4);
            switch (selector)
            {
                case 1:
                    Datos.Tipo=Tipo.cazador;
                    Caracteristicas.Fuerza = rnd.Next(2,5);
                    Caracteristicas.Armadura = rnd.Next(3,7);
                    Caracteristicas.Destreza = rnd.Next(5,8);
                    Caracteristicas.Velocidad = 30 - (Caracteristicas.Fuerza+Caracteristicas.Armadura+caracteristicas.Destreza);
                    if(Caracteristicas.Velocidad>10)
                    {
                        Caracteristicas.Nivel = rnd.Next(1,51);
                    } else {
                        Caracteristicas.Nivel = rnd.Next(20,101);
                    }
                    break;
                case 2:
                    Datos.Tipo=Tipo.hechizero;
                    Caracteristicas.Armadura = rnd.Next(3,8);
                    Caracteristicas.Fuerza = rnd.Next(3,8);
                    Caracteristicas.Velocidad = rnd.Next(3,8);
                    Caracteristicas.Destreza = 30 - (Caracteristicas.Velocidad+Caracteristicas.Armadura+caracteristicas.Fuerza);
                    if(Caracteristicas.Destreza>10)
                    {
                        Caracteristicas.Nivel = rnd.Next(1,5);
                    } else {
                        Caracteristicas.Nivel = rnd.Next(2,10);
                    }
                    break;
                case 3:
                    Datos.Tipo=Tipo.titan;
                    Caracteristicas.Destreza = rnd.Next(1,5);
                    Caracteristicas.Velocidad = rnd.Next(5,5);
                    Caracteristicas.Armadura = rnd.Next(3,9);
                    Caracteristicas.Fuerza = 30 - (Caracteristicas.Velocidad+Caracteristicas.Armadura+caracteristicas.Destreza);
                    if(Caracteristicas.Fuerza>10)
                    {
                        Caracteristicas.Nivel = rnd.Next(1,5);
                    } else {
                        Caracteristicas.Nivel = rnd.Next(2,10);
                    }
                    break;
                default:
                    break;
            }  
        }
    }
}