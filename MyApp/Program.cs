using System;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Personaje P1 = new Personaje();
            Personaje P2 = new Personaje();
            P1.CrearPjAleatorio();
            P2.CrearPjAleatorio();
            describirPj(P1);
            Console.WriteLine("\n---------------------------------------------------\n");
            describirPj(P2);
        }

        static void describirPj(Personaje P)
        {
            Console.WriteLine($" Nombre: {P.Datos.Nombre} \n Apodo: {P.Datos.Apodo} \n Fecha de Nacimiento: {P.Datos.FechaDeNacimiento.ToString("dd/MM/yyy")} \n Edad: {P.Datos.edad()} \n Salud: {P.Datos.Salud} \n Tipo: {P.Datos.Tipo} \n Armadura: {P.Caracteristicas.Armadura} \n Destreza: {P.Caracteristicas.Destreza} \n Fuerza: {P.Caracteristicas.Fuerza} \n Velocidad: {P.Caracteristicas.Velocidad}");
        }

    }
}
