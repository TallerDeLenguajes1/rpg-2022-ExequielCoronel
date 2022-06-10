using System;


namespace RPG
{
    public class Caracteristicas
    {
        private int nivel;//1 a 10
        private int velocidad;// 1 a 10
        private int destreza;//1 a 5
        private int fuerza;//1 a 10
        private int armadura;//1 a 10
        public int Velocidad { get => this.velocidad; set => this.velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Armadura { get => armadura; set => armadura = value; }
        public int Nivel { get => nivel; set => nivel = value; }

        public Caracteristicas()
        {
            nivel = 0;
            armadura=0;
            fuerza=0;
            destreza=0;
            velocidad=0;
        }
    }
}