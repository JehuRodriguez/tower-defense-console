using System;
using TowerDefenseConsole.Interfaces;

namespace TowerDefenseConsole.Models
{
    public class ConsolaObservador : IObservador
    {

        public void Notificar(string evento, int valor)
        {
            switch (evento)
            {
                case "EnemigoEliminado":
                    Console.WriteLine("[Observer] Enemigo eliminado! Ganaste " + valor + " de oro.");
                    break;
                case "VidaPerdida":
                    Console.WriteLine("[Observer] Perdiste una vida! Vidas restantes: " + valor);
                    break;
                case "NuevaOleada":
                    Console.WriteLine("[Observer] ¡Comienza la oleada " + valor + "!");
                    break;
            }
        }
    }
}
