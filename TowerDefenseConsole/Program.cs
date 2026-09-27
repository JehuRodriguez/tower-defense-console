using TowerDefenseConsole.Models;

Console.WriteLine("=== TOWER DEFENSE - CONSOLA ===\n");

// Suscribimos el observador para que veamos las notificaciones del juego
ConsolaObservador observador = new ConsolaObservador();
GameManager.Instancia.Suscribir(observador);

GeneradorOleadas generador = new GeneradorOleadas();

// Creamos las torres disponibles del jugador
List<Tower> torresDelJugador = new List<Tower>();

bool jugando = true;

while (jugando)
{
    Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
    Console.WriteLine($"Dinero: {GameManager.Instancia.Dinero} | Vidas: {GameManager.Instancia.Vidas} | Oleada: {GameManager.Instancia.OleadaActual}");
    Console.WriteLine("1. Comprar Torre Arquero (50 oro)");
    Console.WriteLine("2. Comprar Torre Cañón (100 oro)");
    Console.WriteLine("3. Iniciar siguiente oleada");
    Console.WriteLine("4. Salir");
    Console.Write("Elige una opción: ");

    string opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            if (GameManager.Instancia.Dinero >= 50)
            {
                ArcherTower nuevaArquero = new ArcherTower();
                torresDelJugador.Add(nuevaArquero);
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
                CannonTower nuevaCanon = new CannonTower();
                torresDelJugador.Add(nuevaCanon);
                GameManager.Instancia.GastarDinero(100);
                Console.WriteLine("¡Compraste una Torre Cañón!");
            }
            else
            {
                Console.WriteLine("No tienes suficiente dinero.");
            }
            break;

        case "3":
            GameManager.Instancia.AvanzarOleada();
            List<Enemy> enemigos = generador.GenerarOleada(GameManager.Instancia.OleadaActual);
            Console.WriteLine($"\nVienen {enemigos.Count} enemigo(s) en esta oleada!\n");

            foreach (Enemy enemigo in enemigos)
            {
                Console.WriteLine($"--- Atacando a {enemigo.Nombre} (Vida: {enemigo.Vida}) ---");

                foreach (Tower torre in torresDelJugador)
                {
                    if (!enemigo.EstaVivo())
                        break;

                    torre.Atacar(enemigo);
                }

                if (enemigo.EstaVivo())
                {
                    Console.WriteLine($"{enemigo.Nombre} sobrevivió y llegó a tu base!");
                    GameManager.Instancia.RegistrarVidaPerdida();
                }
                else
                {
                    GameManager.Instancia.RegistrarEnemigoEliminado();
                }
            }

            if (GameManager.Instancia.Vidas <= 0)
            {
                Console.WriteLine("\n¡GAME OVER! Te quedaste sin vidas.");
                jugando = false;
            }
            break;

        case "4":
            jugando = false;
            Console.WriteLine("Gracias por jugar!");
            break;

        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
}

Console.WriteLine("\n=== FIN DEL JUEGO ===");
Console.ReadLine();