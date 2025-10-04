using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Configuración para mostrar acentos y ñ en consola
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Console.WriteLine("=== Cifrado César (C# en Visual Studio 2022) ===");
        Console.Write("Ingresa el mensaje a encriptar: ");
        string mensaje = Console.ReadLine() ?? string.Empty;

        int clave;
        while (true)
        {
            Console.Write("Ingresa la clave (entero, ej: 3): ");
            string? inputClave = Console.ReadLine();
            if (int.TryParse(inputClave, out clave))
                break;
            Console.WriteLine("Clave inválida. Introduce un número entero.");
        }

        // Encriptar
        string encriptado = CaesarEncrypt(mensaje, clave);
        Console.WriteLine("\nMensaje encriptado:");
        Console.WriteLine(encriptado);

        // Desencriptar
        string desencriptado = CaesarDecrypt(encriptado, clave);
        Console.WriteLine("\nMensaje desencriptado:");
        Console.WriteLine(desencriptado);

        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }

    // --- Función para encriptar con cifrado César ---
    static string CaesarEncrypt(string input, int key)
    {
        int shift = ((key % 26) + 26) % 26; // normaliza la clave
        var sb = new StringBuilder(input.Length);

        foreach (char c in input)
        {
            if (char.IsUpper(c))
            {
                char baseChar = 'A';
                char enc = (char)(baseChar + (c - baseChar + shift) % 26);
                sb.Append(enc);
            }
            else if (char.IsLower(c))
            {
                char baseChar = 'a';
                char enc = (char)(baseChar + (c - baseChar + shift) % 26);
                sb.Append(enc);
            }
            else
            {
                sb.Append(c); // deja igual números, signos, espacios, ñ, tildes
            }
        }

        return sb.ToString();
    }

    // --- Función para desencriptar ---
    static string CaesarDecrypt(string input, int key)
    {
        return CaesarEncrypt(input, -key);
    }
}
