using System;
using System.Collections.Generic;
using TowerDefenseConsole.Interfaces;

namespace TowerDefenseConsole
{
    public class GameManager
    {
        private static GameManager instancia;

        public int Dinero { get; set; }
        public int Vidas { get; set; }
        public int EnemigosDestruidos { get; set; }
        private List<IObserver> observadores;

        private GameManager()
        {
            Dinero = 500;
            Vidas = 10;
            EnemigosDestruidos = 0;
            observadores = new List<IObserver>();
        }

        public static GameManager ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new GameManager();
            }
            return instancia;
        }

        public void AgregarObserver(IObserver observer)
        {
            observadores.Add(observer);
        }

        private void Notificar(string mensaje)
        {
            foreach (IObserver observer in observadores)
            {
                observer.Actualizar(mensaje);
            }
        }

        public void AgregarDinero(int cantidad)
        {
            Dinero += cantidad;
            Notificar("El dinero cambio   /   Dinero actual: " + Dinero);
        }

        public void GastarDinero(int cantidad)
        {
            Dinero -= cantidad;
            Notificar("El dinero cambio   /   Dinero actual: " + Dinero);
        }

        public void PerderVida()
        {
            Vidas--;
            Notificar("Perdiste una vida   /   Vidas restantes: " + Vidas);
        }

        public void EnemigoDestruido()
        {
            EnemigosDestruidos++;
            Dinero += 50;
            Notificar("Enemigo destruido   /   Dinero: " + Dinero + " | Enemigos destruidos: " + EnemigosDestruidos);
        }

        public void ConstruirTorre(int costo)
        {
            Dinero -= costo;
            Notificar("Torre construida   /   Dinero restante: " + Dinero);
        }
    }
}