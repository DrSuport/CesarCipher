﻿namespace CesarCipher
{
    public class Program
    {
        public static CesarEnryption Singleton = new CesarEnryption();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Szyfrowanie przy użyciu szyfru Cezara.");
                Console.WriteLine("Wybierz jedną z opcji:");
                Console.WriteLine("\t1 - Zaszyfruj");
                Console.WriteLine("\t2 - Odszyfruj");
                var key = Console.ReadKey();

                Console.WriteLine("Wpisz zdanie do konwersji:");
                string? sentence = Console.ReadLine().ToUpper();
                string result = string.Empty;

                if (key.Key == ConsoleKey.D1)
                {
                    result = Singleton.Perform(sentence, true);
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    result = Singleton.Perform(sentence, false);
                }
                Console.WriteLine("Oryginalne zdanie: " + sentence);
                Console.WriteLine("Zdanie po konwersji: " + result);
                Console.ReadKey();
            }
        }

    }

    public class CesarEnryption
    {
        public static readonly char[] Alphabet = new char[]
        {
            'A', 'Ą', 'B', 'C', 'Ć', 'D', 'E', 'Ę', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'Ł', 'M', 'N', 'Ń', 'O', 'Ó', 'P', 'Q', 'R', 'S', 'Ś', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'Ź', 'Ż'
        };

        public string Perform(string? sentence, bool encrypt)
        {
            char[] sentenceChars = sentence.ToUpper().ToCharArray();
            char[] encryptionResult = new char[sentenceChars.Length];
            for (int i = 0; i < sentenceChars.Length; i++)
            {
                char letter = sentenceChars[i];
                if (letter == ' ' || letter == '\n')
                {
                    encryptionResult[i] = ' ';
                    continue;
                }

                int oldPosition = Array.IndexOf(Alphabet, letter);
                int newPosition = encrypt ? (oldPosition + 3) % Alphabet.Length : (oldPosition - 3) % Alphabet.Length;
                encryptionResult[i] = Alphabet[newPosition];
            }
            return string.Join("", encryptionResult);
        }
    }
    
}