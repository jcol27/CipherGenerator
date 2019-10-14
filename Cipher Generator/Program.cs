using System;

namespace Cipher_Generator
{
    class Cipher_Generator
    {
        // Function to encrypt a string using standard Caesar encryption
        public static string EncryptCaesar(string input, int shift = 3)
        {
            string output = string.Empty;

            foreach (char c in input)
            {
                output += CaesarConvert(c, shift);
            }

            return output;
        }

        // Function to decrypt a string using standard Caesar encryption
        public static string DecryptCaesar(string input, int shift = 3)
        {
            return EncryptCaesar(input, 26 - shift);
        }

        // Function to convert a char using standard Caesar encryption
        public static char CaesarConvert(char c, int shift = 3)
        {
            // Catch for non letters
            if (!char.IsLetter(c))
            {
                return c;
            }
            else
            {
                char d = char.IsUpper(c) ? 'A' : 'a';
                return (char)((((c + shift) - d) % 26) + d);
            }
        }

        // Function to encrypt a string using Vigenere encryption
        public static string EncryptVigenere (string input, string key)
        {
            string output = string.Empty;
            int count = 0; // Keeps track of position in key

            foreach (char c in input)
            {
                output += VigenereConvert(c, key, count, 1);
                count++;
                if (count == key.Length)
                {
                    count = 0;
                }
            }

            return output;
        }

        // Function to decrypt a string using Vigenere encryption
        public static string DecryptVigenere (string input, string key)
        {
            string output = string.Empty;
            int count = 0; // Keeps track of position in key

            foreach (char c in input)
            {
                output += VigenereConvert(c, key, count, -1);
                count++;
                if (count == key.Length)
                {
                    count = 0;
                }
            }

            return output;
        }

        // Function to convert a char using Vigenere encryption/decryption
        public static char VigenereConvert(char c, string key, int count, int encrypt)
        {
            if (!char.IsLetter(c))
            {
                return c;
            }
            else 
            {
                if (char.IsUpper(c))
                {
                    int pos = ((((c - 'A') + (encrypt) * (key[count] - 'A')) % 26));
                    if (pos < 0) { return (char)((26 + pos) + 'A'); }
                    else { return (char)(pos + 'A'); }
                }
                else
                {
                    int pos = ((((c - 'a') + (encrypt) * (key[count] - 'a')) % 26));
                    if (pos < 0) { return (char)((26 + pos) + 'a'); }
                    else { return (char)(pos + 'a'); }
                }
            }
        }

        // Main
        static void Main(string[] args)
        {
            int shift;
            string processed;
            string listofciphers = "Caesar, Vigenere\n";
            bool finished = false;

            Console.WriteLine("Classical Cipher Encryper/Decrypter\n");
            Console.WriteLine("Current supported ciphers: " + listofciphers);


            while (finished == false)
            {
                Console.WriteLine("===================\n");
                Console.WriteLine("New Operation\n");
                Console.WriteLine("===================\n\n");

                Console.WriteLine("Enter a type of cipher: ");
                string cipher = Console.ReadLine();

                Console.WriteLine("Encryption or decryption? ");
                string operation = Console.ReadLine();

                Console.WriteLine("Enter data: ");
                string UserString = Console.ReadLine();

                if (cipher.ToLowerInvariant() == "caesar")
                {
                    Console.WriteLine("\nEnter a custom shift value: ");
                    shift = (Convert.ToInt32(Console.ReadLine()));
                    if (operation.ToLowerInvariant() == "encryption")
                    {
                        Console.WriteLine("\nEncrypting...");
                        processed = EncryptCaesar(UserString, shift);
                        Console.WriteLine("\nEncrypted Data: ");
                        Console.WriteLine(processed);
                        Console.WriteLine("\n");
                    }
                    else
                    {
                        Console.WriteLine("\nDecrypting...");
                        processed = DecryptCaesar(UserString, shift);
                        Console.WriteLine("\nDecrypted Data: ");
                        Console.WriteLine(processed);
                        Console.WriteLine("\n");
                    }
                }
                else if (cipher.ToLowerInvariant() == "vigenere")
                {
                    Console.WriteLine("Enter a custom keyword: ");
                    string key = Console.ReadLine();
                    if (operation.ToLowerInvariant() == "encryption")
                    {
                        Console.WriteLine("\nEncrypting...");
                        processed = EncryptVigenere(UserString, key);
                        Console.WriteLine("\nEncrypted Data: ");
                        Console.WriteLine(processed);
                        Console.WriteLine("\n");
                    }
                    else
                    {
                        Console.WriteLine("\nDecrypting...");
                        processed = DecryptVigenere(UserString, key);
                        Console.WriteLine("\nDecrypted Data: ");
                        Console.WriteLine(processed);
                        Console.WriteLine("\n");
                    }
                }

                Console.WriteLine("Would you like to perform another operation? (yes/no)");
                if (Console.ReadLine().ToLowerInvariant() == "no")
                {
                    finished = true;
                    Console.WriteLine("Thank you for using this program!");
                }

            }
            System.Threading.Thread.Sleep(1000)
            Environment.Exit(0);
        }
    }
}
