using System;


namespace TowerDefenseConsole.Models
{
    public class CannonTower : Tower
    {
        public CannonTower() : base("Torre Cañón", 40, 2, 100)
        {
        }

        public override void Atacar(Enemy objetivo)
        {
            Console.WriteLine($"{Nombre} dispara una bala de cañón explosiva a {objetivo.Nombre}!");
            objetivo.RecibirDaño(Daño);
        }
    }
}
