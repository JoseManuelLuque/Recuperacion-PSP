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
        throw new NotImplementedException();
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
    public int X { get; }
    public int Y { get; }

    public Punto(int x, int y)
    {
        X = x;
        Y = y;
    }
}

public class Circulo : IGrafico
{
    public Punto Centro { get; }
    public int Radio { get; }

    public Circulo(int x, int y, int radio)
    {
        Centro = new Punto(x, y);
        Radio = radio;
    }

    public bool Mover(int x, int y)
    {
        // Implementación de la lógica para mover el círculo
        throw new NotImplementedException();
    }

    public void Dibujar()
    {
        // Implementación de la lógica para dibujar el círculo
        Console.WriteLine($"Circulo: Centro({Centro.X}, {Centro.Y}), Radio={Radio}");
    }
}

public class Rectangulo : IGrafico
{
    public Punto EsquinaSuperiorIzquierda { get; }
    public int Ancho { get; }
    public int Alto { get; }

    public Rectangulo(int x, int y, int ancho, int alto)
    {
        EsquinaSuperiorIzquierda = new Punto(x, y);
        Ancho = ancho;
        Alto = alto;
    }

    public bool Mover(int x, int y)
    {
        // Implementación de la lógica para mover el rectángulo
        throw new NotImplementedException();
    }

    public void Dibujar()
    {
        // Implementación de la lógica para dibujar el rectángulo
        Console.WriteLine($"Rectangulo: EsquinaSuperiorIzquierda({EsquinaSuperiorIzquierda.X}, {EsquinaSuperiorIzquierda.Y}), Ancho={Ancho}, Alto={Alto}");
    }
}