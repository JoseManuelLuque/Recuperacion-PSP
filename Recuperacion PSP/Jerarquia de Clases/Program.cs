Console.WriteLine("MONDONGO");


public interface IGrafico
{
    bool Mover(int x, int y);
    void Dibujar();
}

public class GraficoCompuesto : IGrafico
{
    public List<IGrafico> Graficos { get; } = new List<IGrafico>();

    public bool Mover(int x, int y)
    {
        // Implementación de la lógica para mover el grafo compuesto
        return false;
    }

    public void Dibujar()
    {
        // Implementación de la lógica para dibujar el grafo compuesto
        foreach (IGrafico grafico in Graficos)
        {
            grafico.Dibujar();
        }
    }

    public void AgregarGrafico(IGrafico grafico)
    {
        Graficos.Add(grafico);
    }
}

public class Punto
{
    public int X;
    public int Y;

    public Punto(int x, int y)
    {
        X = x;
        Y = y;
    }
}

public class Circulo : IGrafico
{
    public Punto Centro;
    public int Radio;

    public Circulo(int x, int y, int radio)
    {
        Centro = new Punto(x, y);
        Radio = radio;
    }

    public bool Mover(int x, int y)
    {
        // Implementación de la lógica para mover el círculo
        return false;
    }

    public void Dibujar()
    {
        // Implementación de la lógica para dibujar el círculo
        Console.WriteLine($"Circulo: Centro({Centro.X}, {Centro.Y}), Radio={Radio}");
    }
}

public class Rectangulo : IGrafico
{
    public Punto EsquinaSuperiorIzquierda;
    public int Ancho;
    public int Alto;

    public Rectangulo(int x, int y, int ancho, int alto)
    {
        EsquinaSuperiorIzquierda = new Punto(x, y);
        Ancho = ancho;
        Alto = alto;
    }

    public bool Mover(int x, int y)
    {
        // Implementación de la lógica para mover el rectángulo
        return false;
    }

    public void Dibujar()
    {
        // Implementación de la lógica para dibujar el rectángulo
        Console.WriteLine($"Rectangulo: EsquinaSuperiorIzquierda({EsquinaSuperiorIzquierda.X}, {EsquinaSuperiorIzquierda.Y}), Ancho={Ancho}, Alto={Alto}");
    }
}