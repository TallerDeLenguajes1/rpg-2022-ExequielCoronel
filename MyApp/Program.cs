using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Threading;


namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            //Declaro variables 
            string control;
            int opcion, opcionPrincipal, banderaArchivoGanadoresCreado = 0;
            string rutaArchivo = @"C:\Users\execo\Escritorio\Universidad\3ero\1erCuatrimestre\TallerDeLenguajes1\Practica\RPG\MyApp\jugadores", extensionArchivo = ".Json", rutaArchivoGanadores = @"C:\Users\execo\Escritorio\Universidad\3ero\1erCuatrimestre\TallerDeLenguajes1\Practica\RPG\MyApp\Ganadores.csv";
            Personaje Ganador = new Personaje();
            List<Personaje> ListaPj = new List<Personaje>();
            System.Console.WriteLine("\n\tBienvenido!, este juego consiste en dada una lista de 6 participantes, los mismos pelean hasta quedar solo uno con vida y ser el ganador del trono de hierro\n");
            //Bucle hasta que se decida salir del juego
            do{
                System.Console.WriteLine("Seleccione una opción: 1-->Luchar, 2-->Mostar historial de ganadores, 3-->Vaciar el historial de ganadores, 0-->Salir del Juego");
                do{ //Bucle hasta que se seleccione una opcion valida
                    control = Console.ReadLine();
                    if(control!="0" && control!="1" && control!="2" && control!="3")
                    {
                        System.Console.WriteLine("\nPor favor seleccion una opcion valida!\n1-->Luchar, 2-->Mostar historial de ganadores, 3-->Vaciar el historial de ganadores, 0-->Salir del Juego");
                    }
                }while(control!="0" && control!="1" && control!="2" && control!="3");
                opcionPrincipal=Convert.ToInt32(control);
                switch (opcionPrincipal) 
                {
                    //Opcion salir del juego se muestra por pantalla 
                    case 0:
                        int confirmar;
                        System.Console.WriteLine("\nEsta seguro que desea salir del juego? 1-->Si, 0-->No: ");
                        do{
                            control = Console.ReadLine();
                            if(control!="1" && control!="0")
                            {
                                System.Console.WriteLine("\n Por favor seleccion una opcion valida!\nEsta seguro que desea salir del juego? 1-->Si, 0-->No: ");
                            }
                        }while(control!="1" && control!="0");
                        confirmar = Convert.ToInt32(control);
                        if(confirmar==1)
                        {
                            System.Console.WriteLine("\nEsperamos que regreses pronto!\n");
                            opcionPrincipal = -1;
                        }
                        break;
                    //Opcion  Luchar, carga los personajes en una lista y los mismos pelean hasta quedar solo 1
                    case 1: 
                        do{
                            System.Console.WriteLine($"\n Cargado de personajes, 1-->Aleatoriamente, 0-->Archivo Json:");
                            control = Console.ReadLine();
                            if(control != "1" && control != "0")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                System.Console.WriteLine($"\n Porfavor ingrese una opcion valida! 1-->Aleatoriamente, 0-->Archivo Json: \n");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }while(control != "1" && control != "0");
                        opcion=Convert.ToInt32(control);
                        if(opcion == 1)
                        {
                            ListaPj=CargarPersonajesAleatorios();
                            File.WriteAllText(rutaArchivo+extensionArchivo,JsonSerializer.Serialize(ListaPj));
                        } else if(opcion==0)
                                {
                                    if(!File.Exists(rutaArchivo+extensionArchivo))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        System.Console.WriteLine($"\nEl archivo con los personajes no esta creado o no se encuentra en la ruta necesaria, se cargaran los personajes de manera aleatoria!\n");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        ListaPj = CargarPersonajesAleatorios();
                                        File.WriteAllText(rutaArchivo+extensionArchivo,JsonSerializer.Serialize(ListaPj));
                                    } else {
                                        string Json = File.ReadAllText(rutaArchivo+extensionArchivo);
                                        ListaPj = JsonSerializer.Deserialize<List<Personaje>>(Json);  
                                    }     
                                }
                        MostrarPeleadores(ListaPj);
                        Ganador=Pelear(ListaPj);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        System.Console.WriteLine("\nGanador del trono de Hierro:");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        describirPj(Ganador);
                        Console.ForegroundColor = ConsoleColor.White; 
                        //Si no existe el archivo csv bandera=1 para poner el encabezado del archivo al crearlo
                        if(!File.Exists(rutaArchivoGanadores))
                        {
                            banderaArchivoGanadoresCreado = 1;
                        }
                        StreamWriter archivoW = File.AppendText(rutaArchivoGanadores);
                        if(banderaArchivoGanadoresCreado == 1)
                        {
                            archivoW.WriteLine($"Nombre;Apodo;Tipo");   //encabezado archivo csv
                        }
                        archivoW.WriteLine($"{Ganador.Datos.Nombre};{Ganador.Datos.Apodo};{Ganador.Datos.Tipo}");
                        archivoW.Close();
                        banderaArchivoGanadoresCreado = 0;
                        break;
                    case 2:
                        if(!File.Exists(rutaArchivoGanadores))
                        {
                            System.Console.WriteLine("\n\tEl historial de ganadores esta vacio\n");
                        } else {
                            System.Console.WriteLine("\n\tHistorial de ganadores: \n- - - - - - - - - - - - - - - -");
                            string HistorialGanadores = File.ReadAllText(rutaArchivoGanadores);
                            System.Console.WriteLine($"{HistorialGanadores.Replace(';','-')}\n- - - - - - - - - - - - - - - -");
                        }
                        break;
                    case 3:
                        if(!File.Exists(rutaArchivoGanadores))
                        {
                            System.Console.WriteLine("\nEl historial de ganadores esta vacio\n");
                        } else {
                            System.Console.WriteLine("Esta Seguro de vaciar el historial de ganadores? 1-->Si, 0-->No: ");
                            do
                            {
                                control = Console.ReadLine();
                                if(control!="0" && control!="1")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    System.Console.WriteLine("\nOpcion no valida! Esta Seguro de eliminar el historial de ganadores? 1-->Si, 0-->No: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                            }while(control!="0" && control!="1");
                            confirmar = Convert.ToInt32(control);
                            if(confirmar == 1)
                            {
                                File.Delete(rutaArchivoGanadores);
                                System.Console.WriteLine("\nSe vacio correctamente el historial de ganadores!\n");
                            } 
                        }
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("\nOpcion no valida!");
                        if(opcionPrincipal==-1)
                        {
                            opcionPrincipal=0;
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }while(opcionPrincipal!=-1);  
        }

        //FUNCIONES

        static List<Personaje> CargarPersonajesAleatorios()
        {
            List<Personaje> ListadoPJ = new List<Personaje>();
            for(int i=0;i<6;i++)
            {
                Personaje P = new Personaje();
                P.CrearPjAleatorio();
                ListadoPJ.Add(P);
            }
            return ListadoPJ;
        }
        static void MostrarPeleadores(List<Personaje> L)
        {
            int i=1;
            foreach (var PJ in L)
            {
                System.Console.WriteLine($"\n\tPersonaje {i}:");
                describirPj(PJ);
                i++;
            }
        }
        static Personaje Pelear(List<Personaje> L)
        {
            const int MAXDAÑOPROVOCABLE = 50000;
            Personaje P1 = new Personaje();
            Personaje P2 = new Personaje();
            Random rnd = new Random();
            int poderDisparo, efectividadDisparo, valorAtaque, poderDefensa, dañoProvocado, Ganador;
            int turno = 0, posicion1, posicion2;
            int cantidadPj = L.Count();
            Console.ForegroundColor=ConsoleColor.Red;
            System.Console.WriteLine("\n\tEmpieza la Batalla!\n");
            Console.ForegroundColor = ConsoleColor.White;
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
                for(int i=0;i<6;i++)
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
                    P1.Caracteristicas.Nivel+=1;
                    switch(P1.Datos.Tipo)
                    {
                        case Tipo.cazador:
                            P1.Caracteristicas.Fuerza+=1;
                            P1.Caracteristicas.Armadura+=1;
                            break;
                        case Tipo.hechizero:
                            P1.Caracteristicas.Velocidad+=1;
                            P1.Caracteristicas.Fuerza+=1;
                            break;
                        case Tipo.titan:
                            P1.Caracteristicas.Velocidad+=1;
                            P1.Caracteristicas.Destreza+=1;
                            break;
                        default:
                            break;

                    }
                    P1.restaurarSalud();
                    L.Remove(P2);
                    switch(cantidadPj)
                    {
                        case 6:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            System.Console.WriteLine($"\n\tGanador Ronda 1:");
                            Console.ForegroundColor = ConsoleColor.White;
                            describirPj(P1);
                            break;
                        case 5:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            System.Console.WriteLine("\n\tGanador Ronda 2:");
                            Console.ForegroundColor = ConsoleColor.White;
                            describirPj(P1);
                            break;
                        case 4:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            System.Console.WriteLine("\n\tGanador Ronda 3:");
                            Console.ForegroundColor = ConsoleColor.White;
                            describirPj(P1);
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            System.Console.WriteLine("\n\tGanador Ronda 4:");
                            Console.ForegroundColor = ConsoleColor.White;
                            describirPj(P1);
                            break;
                        default:
                            break;
                    }
                    cantidadPj--;
                } else if(Ganador == 2)
                        {
                            P2.Caracteristicas.Nivel+=1;
                            switch(P2.Datos.Tipo)
                            {
                                case Tipo.cazador:
                                    P2.Caracteristicas.Fuerza+=1;
                                    P2.Caracteristicas.Armadura+=1;
                                    break;
                                case Tipo.hechizero:
                                    P2.Caracteristicas.Velocidad+=1;
                                    P2.Caracteristicas.Fuerza+=1;
                                    break;
                                case Tipo.titan:
                                    P2.Caracteristicas.Velocidad+=1;
                                    P2.Caracteristicas.Destreza+=1;
                                    break;
                                default:
                                    break;
                            }
                            P2.restaurarSalud();
                            L.Remove(P1);
                            switch(cantidadPj)
                            {
                                case 6:
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    System.Console.WriteLine($"\n\tGanador Ronda 1:");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    describirPj(P2);
                                    break;
                                case 5:
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    System.Console.WriteLine("\n\tGanador Ronda 2:");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    describirPj(P2);
                                    break;
                                case 4:
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    System.Console.WriteLine("\n\tGanador Ronda 3:");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    describirPj(P2);
                                    break;
                                case 3:
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    System.Console.WriteLine("\n\tGanador Ronda 4:");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    describirPj(P2);
                                    break;
                                default:
                                    break;
                            }
                            cantidadPj--;
                        } else {
                            P1.restaurarSalud();
                            P2.restaurarSalud();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            System.Console.WriteLine("La pelea termino en empate!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
            }
            return L[0];
        }

        static void describirPj(Personaje P)
        {
            System.Console.WriteLine("--------------------------------");
            Thread.Sleep(2000);
            Console.WriteLine($" Nombre: {P.Datos.Nombre} \n Apodo: {P.Datos.Apodo} \n Fecha de Nacimiento: {P.Datos.FechaDeNacimiento.ToString("dd/MM/yyy")} \n Edad: {P.Datos.edad()} \n Salud: {P.Datos.Salud} \n Tipo: {P.Datos.Tipo} \n Armadura: {P.Caracteristicas.Armadura} \n Destreza: {P.Caracteristicas.Destreza} \n Fuerza: {P.Caracteristicas.Fuerza} \n Velocidad: {P.Caracteristicas.Velocidad}");
            System.Console.WriteLine("--------------------------------");
        }

    }
}
