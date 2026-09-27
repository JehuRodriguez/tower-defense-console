using System;
using System.Collections.Generic;
using TowerDefenseConsole.Models;

namespace TowerDefenseConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tower> torres = new List<Tower>
            {
                new ArcherTower(),
                new CannonTower()
            };

            Enemy enemigoActual = new Enemy("Goblin Básicon", 60, 5);
            int oleadaActual = 1;

            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("     TOWER DEFENSE - CONSOLE GAME       ");
                Console.WriteLine("========================================");
                Console.WriteLine($"[ Oleada Actual: {oleadaActual} ]\n");

                Console.WriteLine("Estado del Enemigo:");
                if (enemigoActual.EstaVivo())
                {
                    Console.WriteLine($" -> {enemigoActual.Nombre} | Vida: {enemigoActual.Vida} | Posición: {enemigoActual.Posicion}");
                }
                else
                {
                    Console.WriteLine(" -> ¡No hay enemigos activos! (Derrotados)");
                }

                Console.WriteLine("\n----------------------------------------");
                Console.WriteLine("MENÚ DE ACCIONES:");
                Console.WriteLine("1. Ver información de las Torres");
                Console.WriteLine("2. Hacer avanzar al Enemigo (IMovible)");
                Console.WriteLine("3. Atacar al Enemigo con las Torres (Polimorfismo)");
                Console.WriteLine("4. Subir de nivel una Torre (Escala con Fibonacci)");
                Console.WriteLine("5. Simular Siguiente Oleada (Nueva dificultad)");
                Console.WriteLine("6. Salir del juego");
                Console.WriteLine("----------------------------------------");
                Console.Write("Elige una opción: ");

                string opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("--- TORRES DISPONIBLES EN LA BASE ---");
                        foreach (var torre in torres)
                        {
                            torre.MostrarInfo();
                        }
                        break;

                    case "2":
                        if (enemigoActual.EstaVivo())
                        {
                            enemigoActual.Mover();
                        }
                        else
                        {
                            Console.WriteLine("El enemigo actual ya fue derrotado. Pasa a la siguiente oleada.");
                        }
                        break;

                    case "3":
                        if (!enemigoActual.EstaVivo())
                        {
                            Console.WriteLine("No hay objetivos vivos para atacar. ¡Genera una nueva oleada!");
                            break;
                        }

                        Console.WriteLine("--- FASE DE ATAQUE ---");
                        foreach (var torre in torres)
                        {
                            torre.Atacar(enemigoActual);
                        }
                        break;

                    case "4":
                        Console.WriteLine("¿Qué torre deseas mejorar?");
                        for (int i = 0; i < torres.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {torres[i].Nombre} (Nivel actual: {torres[i].Nivel})");
                        }
                        Console.Write("Elige el número de torre: ");
                        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= torres.Count)
                        {
                            torres[index - 1].SubirNivel();
                        }
                        else
                        {
                            Console.WriteLine("Opción inválida.");
                        }
                        break;

                    case "5":
                        oleadaActual++;
                        int vidaNueva = 50 + (torres[0].CalcularFibonacci(oleadaActual) * 10);
                        string nombreEnemigo = oleadaActual % 2 == 0 ? "Orco de Asalto" : "Goblin Rápido";
                        enemigoActual = new Enemy(nombreEnemigo, vidaNueva, 5 + oleadaActual);

                        Console.WriteLine($"¡Oleada {oleadaActual} iniciada!");
                        Console.WriteLine($"Aparece un nuevo {enemigoActual.Nombre} con {enemigoActual.Vida} de vida.");
                        break;

                    case "6":
                        salir = true;
                        Console.WriteLine("¡Gracias por jugar! Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida, intenta de nuevo.");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}