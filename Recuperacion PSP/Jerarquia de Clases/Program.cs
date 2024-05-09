﻿// Solucion para el error del uso de la clase JerarquiaDeClases
namespace Jerarquia_de_Clases;

public class JerarquiaDeClases
{   
    // Funcion Main, codigo a ejecutar
    static void Main(string[] args)
    {   
        //Comprobacion de Punto
        Console.WriteLine("Punto: ");
        
        var punto1 = new Punto(1, 1);
        Console.WriteLine(punto1.Dibujar());
        punto1.Mover(1, 2);
        Console.WriteLine(punto1.Dibujar());
        punto1.Mover(0, -1);
        Console.WriteLine(punto1.Dibujar());
        
        //Separación
        Console.WriteLine();
        
        //Prueba Rectangulo
        Console.WriteLine("Rectangulo: ");
        
        var rectangulo = new Rectangulo(10, 15, 5, 2);
        Console.WriteLine(rectangulo.Dibujar());
        
        //Separación
        Console.WriteLine();
        
        //Prueba Circulo
        var circulo = new Circulo(200, 200, 10);
        Console.WriteLine(circulo.Dibujar());
    }
    
    public interface IGrafico
    {
        bool Mover(int x, int y);
        string Dibujar();
    }

    public class GraficoCompuesto : IGrafico
    {
        public List<IGrafico> Graficos { get; } = new List<IGrafico>();

        public bool Mover(int x, int y)
        {
            // Implementación de la lógica para mover el grafo compuesto
            return false;
        }

        public string Dibujar()
        {
            // Implementación de la lógica para dibujar el grafo compuesto
            var resultado = "Gráfico complejo:\n";
            foreach (IGrafico grafico in Graficos)
            {
                resultado += grafico.Dibujar() + "\n";
            }

            return resultado;
        }

        public void AgregarGrafico(IGrafico grafico)
        {
            Graficos.Add(grafico);
        }
    }

    public class Punto: IGrafico
    {
        public int X;
        public int Y;
        private IGrafico _graficoImplementation;

        public Punto(int x, int y)
        {   
            //Excepcion tamaño pantalla
            if (x > 600 || y > 800 || x < 0 || y < 0)
            {
                throw new Exception("Gráfico fuera de area disponible");
            }
            X = x;
            Y = y;
        }

        public bool Mover(int x, int y)
        {   
            //Comporbamos que el punto no se salga de la pantalla
            if ((X + x) > 600 || (X + x) < 0 || (Y + y) > 800 || ((X + x) < 0))
            {
                return false;
            }
            
            //Y si no se sale le cambiamos los valores al punto y devolvemos un true como que se ha podido mover
            X += x;
            Y += y;
            return true;
        }

        public string Dibujar()
        {
            return "Punto: x = " + X + " y = " + Y;
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

        public string Dibujar()
        {
            // Implementación de la lógica para dibujar el círculo
            return ($"Circulo: Centro({Centro.X}, {Centro.Y}), Radio={Radio}");
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

        public string Dibujar()
        {
            // Implementación de la lógica para dibujar el rectángulo
            return ($"Rectangulo: Esquin superior izquierda({EsquinaSuperiorIzquierda.X}, {EsquinaSuperiorIzquierda.Y}), Ancho={Ancho}, Alto={Alto}");
        }
    }
}