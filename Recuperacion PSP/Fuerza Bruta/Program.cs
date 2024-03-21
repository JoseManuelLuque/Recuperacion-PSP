<<<<<<< HEAD
﻿// Ejemplo de como crear un archivo introducirle lineas por codgio y impresion de todas las lineas una por una

//Creamos un fichero y con el usiong le decimos que meta toda esas lineas

using System.Security.Cryptography;
using System.Text;

using (StreamWriter writer = new StreamWriter("Archivo1.txt"))
{
    writer.WriteLine("Linea 1");
    writer.WriteLine("Linea 2");
    writer.WriteLine("Linea 3");
    writer.WriteLine("Linea 4");
    writer.WriteLine("Linea 5");
    writer.WriteLine("Linea 6");
    writer.WriteLine("Linea 7");
    writer.WriteLine("Linea 8");
}

//Ahora queremos meter todas las lineas en una colección
List<string> lineasArchivo = File.ReadAllLines("Archivo1.txt").ToList();

//Imprimimos
foreach (var linea in lineasArchivo)
{
    Console.WriteLine(linea);
}

var random = new Random();
var itemRandom = random.Next(lineasArchivo.Count);
var password = lineasArchivo[itemRandom];
var encryptedPassword = Encrypt(password);
var result = BruteForce(Encrypt(password), lineasArchivo);
if (result != null)
{
    Console.WriteLine(result);
}
else
{
    Console.WriteLine("contraseña null");
}

string BruteForce(string hashCode, List<string> passwordList)
{
    foreach (var privpassword in passwordList)
    {
        Console.WriteLine(privpassword);
        if (Encrypt(privpassword) == hashCode) return privpassword;
    }

    return null;
}

int numberOfThreads = 4;
var step = lineasArchivo.Count / numberOfThreads;
for (int i = 0; i < numberOfThreads; i++)
{
    new Thread(() => BruteForce(Encrypt(password), lineasArchivo.GetRange(i * step, step)));
}

Console.WriteLine(password);
Console.WriteLine(Encrypt(password));



static string Encrypt(string originalString)
{
    var result = string.Empty;
    var hashValue = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(originalString));
    foreach (byte b in hashValue)
    {
        result += $"{b:X2}";
    }

    return result;
}
=======
Console.WriteLine("Hello, World!");
>>>>>>> 8f26b23820941aad9b4f44742f6d63f75ca2ed03
