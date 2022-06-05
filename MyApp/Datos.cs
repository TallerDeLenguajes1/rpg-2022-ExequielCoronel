using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPG
{
    public enum Tipo
    {
        cazador = 0,
        hechizero = 1,
        titan = 2
    }
    public class Datos
    {
    
        private DateTime FechaPelea = new DateTime(980,03,21);
        private Tipo tipo; 
        private string nombre;
        private string apodo;
        private int salud;
        private DateTime fechaDeNacimiento;

        public Tipo Tipo { get => tipo; set => tipo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public int Salud { get => salud; set => salud = value; }
        public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
        public DateTime FechaPelea1 { get => FechaPelea; private set => FechaPelea = value; }

        public Datos()
        {
            Tipo = Tipo;
            nombre = "";
            apodo = "";
            salud = 0;
            fechaDeNacimiento = new DateTime();
        }
        public int edad()
        {
            int add = 0;
            if(fechaDeNacimiento.Year < FechaPelea.Year && fechaDeNacimiento.Month < FechaPelea.Month)
            {
                add=1;
            } else {
                if(fechaDeNacimiento.Month==FechaPelea.Month && fechaDeNacimiento.Day < FechaPelea.Day)
                {
                    add=1;
                }
            }
            return (FechaPelea.Year-fechaDeNacimiento.Year)+add;
        }
    }
}