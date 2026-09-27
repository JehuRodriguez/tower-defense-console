using System;
using System.Collections.Generic;
using TowerDefenseConsole.Interfaces;

namespace TowerDefenseConsole.Models
{
    public class GameManager
    {
        private static GameManager instancia;
        private List<IObservador> observadores = new List<IObservador>();

        public int Dinero { get; private set; }
        public int Vidas { get; private set; }
        public int OleadaActual { get; private set; }

        private GameManager()
        {
            Dinero = 100;
            Vidas = 20;
            OleadaActual = 1;
        }

        public static GameManager Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new GameManager();
                }
                return instancia;
            }
        }

        public void Suscribir(IObservador observador)
        {
            observadores.Add(observador);
        }

        public void Desuscribir(IObservador observador)
        {
            observadores.Remove(observador);
        }

        private void NotificarATodos(string evento, int valor)
        {
            for (int i = 0; i < observadores.Count; i++)
            {
                IObservador obs = observadores[i];
                obs.Notificar(evento, valor);
            }
        }

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

        public void RegistrarEnemigoEliminado()
        {
            int recompensa = CalcularFibonacci(OleadaActual) * 5;
            Dinero += recompensa;
            NotificarATodos("EnemigoEliminado", recompensa);
        }

        public void RegistrarVidaPerdida()
        {
            Vidas--;
            NotificarATodos("VidaPerdida", Vidas);
        }

        public void AvanzarOleada()
        {
            OleadaActual++;
            NotificarATodos("NuevaOleada", OleadaActual);
        }



    }
}
