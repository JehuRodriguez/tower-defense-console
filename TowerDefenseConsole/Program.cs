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
Console.ReadLine();

