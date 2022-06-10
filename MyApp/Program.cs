using System;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Personaje Ganador = new Personaje();
            List<Personaje> ListaPj = new List<Personaje>();
            for(int i=0;i<16;i++)
            {
                Personaje P = new Personaje();
                P.CrearPjAleatorio();
                ListaPj.Add(P);
            }
            Ganador=Pelear(ListaPj);
            describirPj(Ganador);
        }

        static Personaje Pelear(List<Personaje> L)
        {
            const int MAXDAÑOPROVOCABLE = 500000;
            Personaje P1 = new Personaje();
            Personaje PjGanador = new Personaje();
            Personaje P2 = new Personaje();
            Random rnd = new Random();
            int poderDisparo, efectividadDisparo, valorAtaque, poderDefensa, dañoProvocado, Ganador;
            int turno = 0, posicion1, posicion2;
            int cantidadPj = L.Count();
            while(cantidadPj > 1)
            {
                Ganador = 0;
                posicion1 = rnd.Next(0,cantidadPj);
                do{
                    posicion2 = rnd.Next(0,cantidadPj);
                }while(posicion1 == posicion2);
                P1=L[posicion1];
                P2=L[posicion2];
                turno = rnd.Next(1,3);
                for(int i=0;i<3;i++)
                {
                    if(turno == 1)
                    {
                        poderDisparo = P1.Caracteristicas.Destreza * P1.Caracteristicas.Fuerza * P1.Caracteristicas.Nivel;
                        efectividadDisparo = rnd.Next(1,100);
                        valorAtaque = poderDisparo * efectividadDisparo;
                        poderDefensa = P2.Caracteristicas.Armadura * P2.Caracteristicas.Velocidad;
                        dañoProvocado = ((valorAtaque * efectividadDisparo - poderDefensa) / MAXDAÑOPROVOCABLE) * 100;
                        P2.Datos.Salud-=dañoProvocado;
                        turno = 2;
                    } else {
                        poderDisparo = P2.Caracteristicas.Destreza * P2.Caracteristicas.Fuerza * P2.Caracteristicas.Nivel;
                        efectividadDisparo = rnd.Next(1,100);
                        valorAtaque = poderDisparo * efectividadDisparo;
                        poderDefensa = P1.Caracteristicas.Armadura * P1.Caracteristicas.Velocidad;
                        dañoProvocado = ((valorAtaque * efectividadDisparo - poderDefensa) / MAXDAÑOPROVOCABLE) * 100;
                        P1.Datos.Salud-=dañoProvocado;
                        turno = 1;
                    }
                    if(P1.Datos.Salud <= 0)
                    {
                        Ganador = 2;
                        break;
                    } else if(P2.Datos.Salud <= 0){
                        Ganador = 1;
                        break;
                    }
                }
                if(Ganador==0 && P1.Datos.Salud < P2.Datos.Salud)
                {
                    Ganador = 2;
                } else if(Ganador == 0 && P2.Datos.Salud < P1.Datos.Salud)
                        {
                            Ganador = 1;
                        }
                if(Ganador == 1)
                {
                    if(cantidadPj==2)
                    {
                        PjGanador=L[posicion1];
                    }
                    L[posicion1].Caracteristicas.Nivel+=1;
                    switch(L[posicion1].Datos.Tipo)
                    {
                        case Tipo.cazador:
                            L[posicion1].Caracteristicas.Fuerza+=1;
                            L[posicion1].Caracteristicas.Armadura+=1;
                            break;
                        case Tipo.hechizero:
                            L[posicion1].Caracteristicas.Velocidad+=1;
                            L[posicion1].Caracteristicas.Fuerza+=1;
                            break;
                        case Tipo.titan:
                            L[posicion1].Caracteristicas.Velocidad+=1;
                            L[posicion1].Caracteristicas.Destreza+=1;
                            break;
                        default:
                            break;

                    }
                    L[posicion1].restaurarSalud();
                    L.Remove(P2);
                } else {
                    if(cantidadPj==2)
                    {
                        PjGanador=L[posicion2];
                    }
                    L[posicion2].Caracteristicas.Nivel+=1;
                    switch(L[posicion2].Datos.Tipo)
                    {
                        case Tipo.cazador:
                            L[posicion2].Caracteristicas.Fuerza+=1;
                            L[posicion2].Caracteristicas.Armadura+=1;
                            break;
                        case Tipo.hechizero:
                            L[posicion2].Caracteristicas.Velocidad+=1;
                            L[posicion2].Caracteristicas.Fuerza+=1;
                            break;
                        case Tipo.titan:
                            L[posicion2].Caracteristicas.Velocidad+=1;
                            L[posicion2].Caracteristicas.Destreza+=1;
                            break;
                        default:
                            break;
                    }
                    L[posicion2].restaurarSalud();
                    L.Remove(P1);
                }
                cantidadPj--;
            }
            return PjGanador;
        }

        static void describirPj(Personaje P)
        {
            Console.WriteLine($" Nombre: {P.Datos.Nombre} \n Apodo: {P.Datos.Apodo} \n Fecha de Nacimiento: {P.Datos.FechaDeNacimiento.ToString("dd/MM/yyy")} \n Edad: {P.Datos.edad()} \n Salud: {P.Datos.Salud} \n Tipo: {P.Datos.Tipo} \n Armadura: {P.Caracteristicas.Armadura} \n Destreza: {P.Caracteristicas.Destreza} \n Fuerza: {P.Caracteristicas.Fuerza} \n Velocidad: {P.Caracteristicas.Velocidad}");
        }

    }
}
