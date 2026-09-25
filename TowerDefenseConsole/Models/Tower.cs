using System;
using TowerDefenseConsole.Interfaces;

namespace TowerDefenseConsole.Models
{
    public abstract class Tower : IAtacante
    {
        public string Nombre { get; set; }
        public int Daño { get; set; }
        public int Rango { get; set; }
        public int Costo { get; set; }

        public Tower(string nombre, int daño, int rango, int costo)
        {
            Nombre = nombre;
            Daño = daño;
            Rango = rango;
            Costo = costo;
        }

        public abstract void Atacar(Enemy objetivo);

        public void MostrarInfo()
        {
            Console.WriteLine($"Torre: {Nombre} | Daño: {Daño} | Rango: {Rango} | Costo: {Costo}");
        }
    }
}
