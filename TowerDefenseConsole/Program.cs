using TowerDefenseConsole.Models;

Console.Clear();
Console.WriteLine("========================================");
Console.WriteLine("     TOWER DEFENSE - CONSOLE GAME       ");
Console.WriteLine("========================================\n");

// Suscribimos el observador (patrón Observer)
ConsolaObservador observador = new ConsolaObservador();
GameManager.Instancia.Suscribir(observador);

GeneradorOleadas generador = new GeneradorOleadas();
List<Tower> torresDelJugador = new List<Tower>();
List<Enemy> enemigosActuales = new List<Enemy>();

bool salir = false;
int oleadaVictoria = 7;

while (!salir)
{
    Console.Clear();
    Console.WriteLine("========================================");
    Console.WriteLine("     TOWER DEFENSE - CONSOLE GAME       ");
    Console.WriteLine("========================================");
    Console.WriteLine($"Dinero: {GameManager.Instancia.Dinero} | Vidas: {GameManager.Instancia.Vidas} | Oleada: {GameManager.Instancia.OleadaActual}\n");

    Console.WriteLine("MENÚ DE ACCIONES:");
    Console.WriteLine("1. Comprar Torre Arquero (50 oro)");
    Console.WriteLine("2. Comprar Torre Cañón (100 oro)");
    Console.WriteLine("3. Ver información de las Torres");
    Console.WriteLine("4. Subir de nivel una Torre (Fibonacci)");
    Console.WriteLine("5. Iniciar siguiente Oleada");
    Console.WriteLine("6. Salir del juego");
    Console.WriteLine("----------------------------------------");
    Console.Write("Elige una opción: ");

    string opcion = Console.ReadLine();
    Console.WriteLine();

    switch (opcion)
    {
        case "1":
            if (GameManager.Instancia.Dinero >= 50)
            {
                torresDelJugador.Add(new ArcherTower());
                GameManager.Instancia.GastarDinero(50);
                Console.WriteLine("¡Compraste una Torre Arquero!");
            }
            else
            {
                Console.WriteLine("No tienes suficiente dinero.");
            }
            break;

        case "2":
            if (GameManager.Instancia.Dinero >= 100)
            {
                torresDelJugador.Add(new CannonTower());
                GameManager.Instancia.GastarDinero(100);
                Console.WriteLine("¡Compraste una Torre Cañón!");
            }
            else
            {
                Console.WriteLine("No tienes suficiente dinero.");
            }
            break;

        case "3":
            Console.WriteLine("--- TORRES DISPONIBLES ---");
            if (torresDelJugador.Count == 0)
                Console.WriteLine("Aún no tienes torres.");
            foreach (var torre in torresDelJugador)
                torre.MostrarInfo();
            break;

        case "4":
            if (torresDelJugador.Count == 0)
            {
                Console.WriteLine("No tienes torres para mejorar.");
                break;
            }
            Console.WriteLine("¿Qué torre deseas mejorar?");
            for (int i = 0; i < torresDelJugador.Count; i++)
                Console.WriteLine($"{i + 1}. {torresDelJugador[i].Nombre} (Nivel: {torresDelJugador[i].Nivel})");
            Console.Write("Elige el número: ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= torresDelJugador.Count)
                torresDelJugador[idx - 1].SubirNivel();
            else
                Console.WriteLine("Opción inválida.");
            break;

        case "5":
            GameManager.Instancia.AvanzarOleada();
            enemigosActuales = generador.GenerarOleada(GameManager.Instancia.OleadaActual);
            Console.WriteLine($"\n¡Vienen {enemigosActuales.Count} enemigo(s)!\n");

            foreach (Enemy enemigo in enemigosActuales)
            {
                Console.WriteLine($"--- Atacando a {enemigo.Nombre} (Vida: {enemigo.Vida}) ---");
                foreach (Tower torre in torresDelJugador)
                {
                    if (!enemigo.EstaVivo()) break;
                    torre.Atacar(enemigo);
                }

                if (enemigo.EstaVivo())
                {
                    Console.WriteLine($"{enemigo.Nombre} llegó a tu base!");
                    GameManager.Instancia.RegistrarVidaPerdida();
                }
                else
                {
                    GameManager.Instancia.RegistrarEnemigoEliminado();
                }
            }

            if (GameManager.Instancia.Vidas <= 0)
            {
                Console.WriteLine("\n¡GAME OVER!");
                salir = true;
            }
            else if (GameManager.Instancia.OleadaActual >= oleadaVictoria)
            {
                Console.WriteLine("\n¡VICTORIA! Sobreviviste todas las oleadas y defendiste tu base.");
                salir = true;
            }

            break;

        case "6":
            salir = true;
            Console.WriteLine("¡Gracias por jugar!");
            break;

        default:
            Console.WriteLine("Opción no válida.");
            break;
    }

    if (!salir)
    {
        Console.WriteLine("\nPresiona una tecla para continuar...");
        Console.ReadKey();
    }

    Console.WriteLine("\n=== FIN DEL JUEGO ===");
}
