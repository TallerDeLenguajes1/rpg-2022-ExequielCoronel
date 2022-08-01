using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Text.Json;

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
            string [] apodo = new string[9] {"Alpha","Locus","Fear","Seth","Isceradin","Grin","Razor","Slade","Dark"};
            Random rnd = new Random();
            NombreAleatorio();
            Datos.Apodo = apodo[rnd.Next(0,apodo.Count())];
            Datos.Salud=5000;
            Datos.FechaDeNacimiento = new DateTime(rnd.Next(Datos.FechaPelea1.Year-299,Datos.FechaPelea1.Year),rnd.Next(1,13),rnd.Next(1,30));
            selector = rnd.Next(1,4);
            switch (selector)
            {
                case 1:
                    Datos.Tipo=Tipo.cazador;
                    Caracteristicas.Fuerza = rnd.Next(3,6);
                    Caracteristicas.Armadura = rnd.Next(3,6);
                    Caracteristicas.Destreza = rnd.Next(5,11);
                    Caracteristicas.Velocidad = 30 - (Caracteristicas.Fuerza+Caracteristicas.Armadura+caracteristicas.Destreza);
                    if(Caracteristicas.Velocidad>10)
                    {
                        Caracteristicas.Nivel = rnd.Next(1,5);
                    } else {
                        Caracteristicas.Nivel = rnd.Next(2,10);
                    }
                    break;
                case 2:
                    Datos.Tipo=Tipo.hechizero;
                    Caracteristicas.Armadura = rnd.Next(5,10);
                    Caracteristicas.Fuerza = rnd.Next(4,10);
                    Caracteristicas.Velocidad = rnd.Next(5,10);
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
                    Caracteristicas.Velocidad = rnd.Next(1,5);
                    Caracteristicas.Armadura = rnd.Next(6,11);
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

        public void NombreAleatorio()
        {
            var url = "https://fakerapi.it/api/v1/persons?_quantity=1";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method="GET";
            request.ContentType = "aplication/json";
            request.Accept = "aplication/json";
            try
            {
                WebResponse response = request.GetResponse();
                Stream strReader = response.GetResponseStream();
                if(strReader == null)return;
                StreamReader objReader = new StreamReader(strReader);
                string responseBody = objReader.ReadToEnd();
                Root2 myDeserializedClass = JsonSerializer.Deserialize<Root2>(responseBody);
                Datos.Nombre=myDeserializedClass.Data[0].Firstname + ' ' + myDeserializedClass.Data[0].Lastname;
            }
            catch 
            {
                url = "https://random-data-api.com/api/users/random_user";
                var request2 = (HttpWebRequest)WebRequest.Create(url);
                request2.Method="GET";
                request2.ContentType = "aplication/json";
                request2.Accept = "aplication/json";
                try
                {
                    WebResponse response2 = request2.GetResponse();
                    Stream strReader2 = response2.GetResponseStream();
                    if(strReader2 == null)return;
                    StreamReader objReader2 = new StreamReader(strReader2);
                    string responseBody2 = objReader2.ReadToEnd();
                    Root myDeserializedClass2 = JsonSerializer.Deserialize<Root>(responseBody2);
                    Datos.Nombre = myDeserializedClass2.FirstName + ' ' + myDeserializedClass2.LastName;
                }
                catch
                {
                    Random rnd = new Random();
                    string [] nombre = new string[9] {"Ismael","Lucas","Sofia","Marcos","Brian","Olivia","Martha","Luis","Pedro"};
                    Datos.Nombre = nombre[rnd.Next(0,nombre.Count())];
                }
                
            }
        }
    }
}