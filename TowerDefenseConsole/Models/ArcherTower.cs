using System;



namespace TowerDefenseConsole.Models
{
    public class ArcherTower : Tower
    {
        public ArcherTower() : base("Torre Arquero", 15, 3, 50)
        {
        }


        public override void Atacar(Enemy objetivo)
        {
            Console.WriteLine($"{Nombre} dispara una flecha veloz a {objetivo.Nombre}!");
            objetivo.RecibirDaño(Daño);
        }
    }
}
