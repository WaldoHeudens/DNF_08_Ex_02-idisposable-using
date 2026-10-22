using Resources;

Console.WriteLine("== using-statement (met accolades) ==");
// Het using-blok roept Dispose() automatisch aan bij het verlaten van het blok.
using (var bestand = new LogBestand("app.log"))
{
    bestand.Schrijf("Programma gestart");
    bestand.Schrijf("Bezig met werk");
}   // hier wordt Dispose() aangeroepen
Console.WriteLine("Het using-blok is verlaten.\n");

Console.WriteLine("== using-declaration (zonder accolades) ==");
Verwerk();
Console.WriteLine("Verwerk() is klaar.\n");

Console.WriteLine("== Dispose draait ook bij een exception ==");
try
{
    using var bestand = new LogBestand("fout.log");
    bestand.Schrijf("Net voor de fout");
    throw new InvalidOperationException("Er ging iets mis");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Opgevangen: {ex.Message}");
}

static void Verwerk()
{
    // using-declaration: geen accolades. Dispose() volgt aan het einde van de method.
    using var bestand = new LogBestand("verwerk.log");
    bestand.Schrijf("Verwerking gestart");
    bestand.Schrijf("Verwerking klaar");
    // Dispose() gebeurt hier, bij het einde van Verwerk().
}
