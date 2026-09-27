using TowerDefenseConsole.Models;

Console.WriteLine("=== PRUEBA DE TOWER DEFENSE - CLASES BASE ===\n");

// Creamos un enemigo
Enemy goblin = new Enemy("Goblin", 50, 5);
Console.WriteLine($"Enemigo creado: {goblin.Nombre} | Vida: {goblin.Vida} | Velocidad: {goblin.Velocidad}\n");

// Probamos que el enemigo se mueve (interfaz IMovible)
goblin.Mover();
goblin.Mover();
Console.WriteLine();

// Creamos las 2 torres (clases concretas que heredan de Tower)
ArcherTower arquero = new ArcherTower();
CannonTower cañon = new CannonTower();

arquero.MostrarInfo();
cañon.MostrarInfo();
Console.WriteLine();

// Probamos el POLIMORFISMO: ambas torres implementan Atacar() distinto
Console.WriteLine("--- Ataques (polimorfismo) ---");
arquero.Atacar(goblin);
cañon.Atacar(goblin);
Console.WriteLine();

// Probamos si el enemigo sigue vivo
Console.WriteLine($"¿{goblin.Nombre} sigue vivo? {goblin.EstaVivo()}\n");

// Probamos FIBONACCI subiendo de nivel la torre arquero
Console.WriteLine("--- Subiendo de nivel (Fibonacci) ---");
arquero.SubirNivel();
arquero.SubirNivel();
arquero.SubirNivel();
arquero.MostrarInfo();

Console.WriteLine("\n=== FIN DE LA PRUEBA ===");

// ==================== NUEVO BLOQUE ====================

Console.WriteLine("\n=== PRUEBA DE SINGLETON + OBSERVER ===\n");

// Registramos un observador (patrón Observer)
ConsolaObservador observadorConsola = new ConsolaObservador();
GameManager.Instancia.Suscribir(observadorConsola);

// Probamos que el Singleton SIEMPRE es la misma instancia
GameManager manager1 = GameManager.Instancia;
GameManager manager2 = GameManager.Instancia;
Console.WriteLine($"¿Son la misma instancia? {ReferenceEquals(manager1, manager2)}\n");

Console.WriteLine($"Dinero inicial: {GameManager.Instancia.Dinero}");
Console.WriteLine($"Vidas iniciales: {GameManager.Instancia.Vidas}");
Console.WriteLine($"Oleada actual: {GameManager.Instancia.OleadaActual}\n");

// Simulamos que se elimina un enemigo (esto notifica al observador)
GameManager.Instancia.RegistrarEnemigoEliminado();
Console.WriteLine($"Dinero después de eliminar enemigo: {GameManager.Instancia.Dinero}\n");

// Simulamos que avanza la oleada
GameManager.Instancia.AvanzarOleada();

// Simulamos otro enemigo eliminado en la nueva oleada (la recompensa cambia por Fibonacci)
GameManager.Instancia.RegistrarEnemigoEliminado();
Console.WriteLine($"Dinero después de la oleada 2: {GameManager.Instancia.Dinero}\n");

// Simulamos que el jugador pierde una vida
GameManager.Instancia.RegistrarVidaPerdida();

Console.WriteLine("\n=== FIN PRUEBA SINGLETON + OBSERVER ===");

// ==================== FIN DEL NUEVO BLOQUE ====================

Console.ReadLine();

