using System;


namespace TowerDefenseConsole.Models
{
    public class GeneradorOleadas
    {
        public int CalcularFibonacci(int n)
        {
            if (n <= 1)
                return n;

            int anterior = 0;
            int actual = 1;

            for (int i = 2; i <= n; i++)
            {
                int siguiente = anterior + actual;
                anterior = actual;
                actual = siguiente;
            }


            return actual;
        }

        public List<Enemy> GenerarOleada(int numeroOleada)
        {
            List<Enemy> enemigos = new List<Enemy>();
            int cantidadEnemigos = CalcularFibonacci(numeroOleada);

            if (cantidadEnemigos == 0)
                cantidadEnemigos = 1;

            int vidaBase = 30 + (numeroOleada * 10);
            int velocidadBase = 3 + numeroOleada;

            for (int i = 1; i <= cantidadEnemigos; i++)
            {
                Enemy nuevoEnemigo = new Enemy($"Goblin-{i}", vidaBase, velocidadBase);
                enemigos.Add(nuevoEnemigo);
            }

            return enemigos;

        }
    }
}
