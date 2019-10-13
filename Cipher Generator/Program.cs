using System;

namespace Cipher_Generator
{
    class Cipher_Generator
    {
        // Function to encrypt a string using standard Caesar encryption
        public static string EncryptCaesar(string input)
        {
            string output = string.Empty;

            foreach (char c in input)
            {
                output += CaesarConvert(c, 3);
            }

            return output;
        }

        // Function to encrypt a string using custom shift value Caesar 
        // encryption
        public static string EncryptCustomCaesar(string input, int shift)
        {
            string output = string.Empty;

            foreach (char c in input)
            {
                output += CaesarConvert(c, 3);
            }

            return output;
        }

        // Function to decrypt a string using standard Caesar encryption
        public static string DecryptCaesar(string input)
        {
            return EncryptCustomCaesar(input, 23);
        }

        // Function to decrypt a string using standard Caesar encryption
        public static string DecryptCustomCaesar(string input, int shift)
        {
            return EncryptCustomCaesar(input, 23 - shift);
        }

        public static char CaesarConvert(char c, int shift)
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


        static void Main(string[] args)
        {
            int shift;
            string encrypted;
            Console.WriteLine("Type a string to encrypt: ");
            string UserString = Console.ReadLine();

            Console.WriteLine("\nEnter a custom shift value (or zero for default): ");
            if (Convert.ToInt32(Console.ReadLine()) == 0)
            {
                shift = 3;
            }
            else
            {
                shift = (Convert.ToInt32(Console.ReadLine()));
            }

            Console.WriteLine("\nEncrypting...");
            if (shift == 3)
            {
                encrypted = EncryptCaesar(UserString);
            }
            else
            {
                encrypted = EncryptCustomCaesar(UserString, shift);
            }

            Console.WriteLine("\nEncrypted Data: ");
            Console.WriteLine(encrypted);
            Console.WriteLine("\n");
            Console.ReadKey();

        }
    }
}
