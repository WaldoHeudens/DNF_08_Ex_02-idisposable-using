namespace Resources;

/// <summary>
/// Simuleert een resource die je expliciet moet sluiten. In echte code beheert
/// <see cref="IDisposable"/> zaken als bestandshandles, netwerkverbindingen of
/// databaseconnecties: dingen die de garbage collector niet vanzelf op tijd opruimt.
/// </summary>
public sealed class LogBestand : IDisposable
{
    private readonly string _naam;
    private bool _gesloten;

    public LogBestand(string naam)
    {
        _naam = naam;
        Console.WriteLine($"[{_naam}] geopend");
    }

    public void Schrijf(string regel)
    {
        // Werken met een reeds gesloten resource is een fout.
        if (_gesloten)
        {
            throw new ObjectDisposedException(nameof(LogBestand));
        }

        Console.WriteLine($"[{_naam}] {regel}");
    }

    public void Dispose()
    {
        // Dispose mag je meermaals aanroepen zonder gevolgen (idempotent).
        if (_gesloten)
        {
            return;
        }

        Console.WriteLine($"[{_naam}] gesloten");
        _gesloten = true;
    }
}
