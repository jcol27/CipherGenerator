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


        static void Main(string[] args)
        {
            int shift;
            string processed;
            string listofciphers = "Caesar\n";
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

                Console.WriteLine("Would you like to perform another operation? (yes/no)");
                if (Console.ReadLine().ToLowerInvariant() == "no")
                {
                    finished = true;
                    Console.WriteLine("Thank you for using this program!");
                }

            }
            //Console.ReadKey();
        }
    }
}
