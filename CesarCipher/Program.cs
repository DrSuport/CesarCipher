namespace CesarCipher
{
    public class Program
    {
        public static readonly char[] Alphabet = new char[]
        {
            'A', 'Ą', 'B', 'C', 'Ć', 'D', 'E', 'Ę', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'Ł', 'M', 'N', 'Ń', 'O', 'Ó', 'P', 'Q', 'R', 'S', 'Ś', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'Ź', 'Ż'
        };

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
                string? sentence = Console.ReadLine();
                sentence = sentence.ToUpper();

                if (key.Key == ConsoleKey.D1)
                {
                    char[] sentenceChars = sentence.ToCharArray();
                    char[] encryptedResult = new char[sentenceChars.Length];

                    for (int i = 0; i < sentenceChars.Length; i++)
                    {
                        char letter = sentenceChars[i];
                        if (letter == ' ' || letter == '\n')
                        {
                            encryptedResult[i] = ' ';
                            continue;
                        }

                        int pozycja = Array.IndexOf(Alphabet, letter);
                        int nowaPozycja = (pozycja + 3) % Alphabet.Length;
                        char zaszyfrowanaLitera = Alphabet[nowaPozycja];
                        encryptedResult[i] = zaszyfrowanaLitera;

                    }

                    Console.WriteLine("Oryginalne zdanie: " + sentence);
                    Console.WriteLine("Zaszyfrowane zdanie: " + string.Join("", encryptedResult));
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    char[] sentenceChars = sentence.ToCharArray();
                    char[] decryptedResult = new char[sentenceChars.Length];

                    for (int i = 0; i < sentenceChars.Length; i++)
                    {
                        char letter = sentenceChars[i];
                        if (letter == ' ' || letter == '\n')
                        {
                            decryptedResult[i] = ' ';
                            continue;
                        }

                        int pozycja = Array.IndexOf(Alphabet, letter);
                        int nowaPozycja = (pozycja - 3) % Alphabet.Length;
                        char zaszyfrowanaLitera = Alphabet[nowaPozycja];
                        decryptedResult[i] = zaszyfrowanaLitera;
                    }

                    Console.WriteLine("Oryginalne zdanie: " + sentence);
                    Console.WriteLine("Odszyfrowane zdanie: " + string.Join("", decryptedResult));
                }
                Console.ReadKey();
            }
        }
    }
}