using System.Security.Cryptography;
using System.Text;

// Leemos el archivo con las contraseñas y lo pasamos a una lista
List<string> listaPasswords = File.ReadAllLines("C:\\Users\\josem\\Desktop\\PSP\\Recuperacion-PSP\\passwords.txt").ToList();

Console.Write("Codigo Hash: ");
string? passwordEncriptada = Console.ReadLine();

// FUNCIONES

// Pasa la palabra intoducida por parametros a su codigo en SHA-256
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

string BruteForce(string hashCode, List<string> passwordList)
{
    foreach (var privpassword in passwordList)
    {
        Console.WriteLine(privpassword);
        if (Encrypt(privpassword) == hashCode) return privpassword;
    }

    return null;
}

int numberOfThreads = 5;
for (int i = 0; i < numberOfThreads; i++)
{
    //new Thread(() => BruteForce(Encrypt(password), lineasArchivo.GetRange(i * step, step)));
    //Thread thread = new Thread(new ThreadStart(FuncionThread)).Start();
    //new Thread (FuncionThread).Start();
    //thread.Start();
    //Thread.Join();
}


void FuncionThread()
{   
    var threadReader = listaPasswords.Count / numberOfThreads;
    
    
}

// Prueba Escritura
// using (StreamWriter writer = new StreamWriter("C:\\Users\\josem\\Escritorio\\PSP\\Archivo.txt"))
// {
//     writer.WriteLine("Linea 1");
//     writer.WriteLine("Linea 2");
// }

var random = new Random();
var itemRandom = random.Next(listaPasswords.Count);
var password = listaPasswords[itemRandom];
var encryptedPassword = Encrypt(password);
var result = BruteForce(Encrypt(password), listaPasswords);



Console.WriteLine(password);
Console.WriteLine(Encrypt(password));

// RESULTADO FINAL
if (result != null)
{
    Console.WriteLine(result);
}
else
{
    Console.WriteLine("contraseña null");
}