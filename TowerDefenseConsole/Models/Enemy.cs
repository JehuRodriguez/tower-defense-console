using System;
using TowerDefenseConsole.Interfaces;


namespace TowerDefenseConsole.Models
{
    public class Enemy :IMovible
    {
        public string Nombre { get; set; }
        public int Vida { get; set; }
        public int Posicion { get; set; }
        public int Velocidad { get; set; }

        public Enemy(string nombre, int vida, int velocidad)
        {
            Nombre = nombre;
            Vida = vida;
            Velocidad = velocidad;
            Posicion = 0;
        }

        public void Mover()
        {
            Posicion += Velocidad;
            Console.WriteLine($"{Nombre} avanza hasta la posición {Posicion}");
        }

        public void RecibirDaño(int daño)
        {
            Vida -= daño;
            if (Vida < 0) Vida = 0;
            Console.WriteLine($"{Nombre} recibió {daño} de daño. Vida restante: {Vida}");
        }

        public bool EstaVivo()
        {
            return Vida > 0;
        }
    }
}
