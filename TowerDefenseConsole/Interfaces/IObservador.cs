using System;


namespace TowerDefenseConsole.Interfaces
{
    public interface IObservador
    {
        void Notificar(string evento, int valor);
    }
}
