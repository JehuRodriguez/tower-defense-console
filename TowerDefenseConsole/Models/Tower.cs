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
        public int Nivel { get; set; } = 1;

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
            Console.WriteLine("Torre: " + Nombre + "| Daño:" + Daño + "| Rango: " + Rango + "| Costo: " + Costo + "| Nivel: " + Nivel);
        }

        public int CalcularFibonacci(int n)
        {
            if (n <= 1)
                return n;

            int anterior = 0;
            int actual = 1;

            for(int i= 2; i<=n; i++)
            {
                int siguiente = anterior + actual;

                anterior = actual;
                actual = siguiente;
            }
            return actual;
        }

        public void SubirNivel()
        {
            Nivel++;
            int multiplicadorFibonacci = CalcularFibonacci(Nivel);
            Daño = Daño + multiplicadorFibonacci;
            Console.WriteLine(Nombre + "subio a nivel " + Nivel + "! Nuevo daño: " + Daño + "(bonus Fibonacci : " + multiplicadorFibonacci + ")");


        }
    }
}
