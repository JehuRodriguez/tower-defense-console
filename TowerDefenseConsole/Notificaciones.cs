using System;
using TowerDefenseConsole.Interfaces;

namespace TowerDefenseConsole.Models
{
    public class Notificaciones : IObserver
    {
        public void Actualizar(string mensaje)
        {
            Console.WriteLine("Actualizacion: " + mensaje);
        }
    }
}