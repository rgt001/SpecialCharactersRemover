using ConsoleApp5;
using System;
using System.Diagnostics;
using System.Text;

public class Program
{
    private static readonly Random random = new Random();
    private const string specialCharacters = "!@#$%^&*()_+-=[]{}|;':\",./<>?";

    public static void Main()
    {
        int textLength = 1000;
        int rowsAmmount = 10;

        string randomText = GenerateRandomText(textLength);
        Stopwatch sw = new Stopwatch();

        SpecialCharacters.RemoveSpecialCharacters(randomText);
        sw.Start();
        for (int i = 0; i < rowsAmmount; i++) 
        {
            SpecialCharacters.RemoveSpecialCharacters(randomText);
        }
        sw.Stop();
        Console.WriteLine($"RemoveSpecialCharacters took {sw.ElapsedTicks}");

        SpecialCharacters.RemoveSpecialCharacters2(randomText);
        sw.Reset();
        for (int i = 0; i < rowsAmmount; i++)
        {
            SpecialCharacters.RemoveSpecialCharacters3(randomText);
        }
        sw.Stop();
        Console.WriteLine($"RemoveSpecialCharacters took {sw.ElapsedTicks}");

        SpecialCharacters.RemoveSpecialCharacters3(randomText);
        sw.Reset();
        for (int i = 0; i < rowsAmmount; i++)
        {
            SpecialCharacters.RemoveSpecialCharacters3(randomText);
        }
        sw.Stop();
        Console.WriteLine($"RemoveSpecialCharacters took {sw.ElapsedTicks}");

        Console.ReadLine();
    }

    public static string GenerateRandomText(int length)
    {
        StringBuilder sb = new StringBuilder(length);

        for (int i = 0; i < length; i++)
        {
            if (i % 10 == 0)
            {
                // Insert a special character every 10th position
                sb.Append(GetRandomSpecialCharacter());
            }
            else
            {
                // Insert a random alphanumeric character
                sb.Append(GetRandomAlphanumericCharacter());
            }
        }

        return sb.ToString();
    }

    public static char GetRandomAlphanumericCharacter()
    {
        const string alphanumericCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return alphanumericCharacters[random.Next(alphanumericCharacters.Length)];
    }

    public static char GetRandomSpecialCharacter()
    {
        return specialCharacters[random.Next(specialCharacters.Length)];
    }
}