using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Task_14_10_1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            string allTypesOfChar = "";
            int count = 0;
            int passwordLength;
            string fromUser;
            Dictionary<string, string> DictionaryOfCharacters = new Dictionary<string, string>();
            DictionaryOfCharacters.Add("capital_letters", "QWERTYUIOPASDFGHJKLZXCVBNM");
            DictionaryOfCharacters.Add("small_letters", "qwertyuiopasdfghjklzxcvbnm");
            DictionaryOfCharacters.Add("special_characters", "!@#$%^&*()-_=+<,>.");
            DictionaryOfCharacters.Add("numbers", "0123456789");
            foreach (KeyValuePair<string, string> kvp in DictionaryOfCharacters)
            {
                if (kvp.Key == "numbers")
                {
                    if (count == 0)
                    {
                        Console.WriteLine("The password must consist of something the last option is numbers which will be generated automatically");
                        allTypesOfChar += kvp.Value;
                        count++;
                    }
                    else
                    {
                        Console.WriteLine("If you want numbers in your password, enter [yes], or press enter if you wouldn't");
                        fromUser = Console.ReadLine();
                        if (FromUserYesController(fromUser))
                        {
                            allTypesOfChar += kvp.Value;
                            count++;
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"If you want {kvp.Key} in your password, enter [yes], or press enter if you wouldn't");
                    fromUser = Console.ReadLine();
                    if (FromUserYesController(fromUser))
                    {
                        allTypesOfChar += kvp.Value;
                        count++;
                    }
                }
            }
            Console.WriteLine($"For the password to have all selected options, it must contain at least {count} characters. Enter password length:");
            Console.WriteLine("Enter password length:");
            string passwordLengthInString = Console.ReadLine();
            while (FromUserController(passwordLengthInString, out passwordLength))
            {
                Console.WriteLine("Enter correct password length:");
                passwordLengthInString = Console.ReadLine();
            }
            while (!PasswordLengthController(passwordLength, count))
            {
                Console.WriteLine("Incorrect password");
                Console.WriteLine($"For the password to have all selected options, it must contain at least {count} characters.");
                Console.WriteLine("Enter correct password length:");
                passwordLengthInString = Console.ReadLine();
                while (FromUserController(passwordLengthInString, out passwordLength))
                {
                    Console.WriteLine("Enter correct password length:");
                    passwordLengthInString = Console.ReadLine();
                }
            }

            char[] password1 = passwordGenerator(allTypesOfChar, passwordLength, count);
            char[] password2 = GoodRandoms(DictionaryOfCharacters, count, allTypesOfChar);
            var stringChars = new char[password1.Length + password2.Length];
            stringChars = SumChars(password1, password2, stringChars);
            Shuffle(stringChars);
            string password = new(stringChars);
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            Console.WriteLine($"Generated password: {password} , {version}");

            
        }
        public static char[] SumChars(char[] password1, char[] password2, char[] stringChars)
        {
            Array.Copy(password1, stringChars, password1.Length);
            Array.Copy(password2, 0, stringChars, password1.Length, password2.Length);
            return stringChars;
        }
        public static bool FromUserYesController(string fromUser)
        {
            if (fromUser.ToLower() != "yes")
            {
                return false;
            }
            return true;
        }
        public static bool PasswordLengthController(int passwordLength, int count)
        {
            if (passwordLength >= count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool FromUserController(string passwordLengthInString, out int passwordLength)
        {
            passwordLength = 0;
            try
            {
                passwordLength = int.Parse(passwordLengthInString);
                
            }
            catch (FormatException)
            {
                Console.WriteLine("PasswordLength is outside of the range of the Int32 format.", passwordLength);
                return true;
                
            }
            return false;
        }
        public static void Shuffle( char[] array)
        {
            char[] OldArray = new char[array.Length];
            Array.Copy(array, OldArray, OldArray.Length);
            var rand = new Random();
            int n = array.Length;

            while (OldArray.Equals(array))
            {
                while (n > 1)
                {
                    int k = rand.Next(n--);
                    char temp = array[n];
                    array[n] = array[k];
                    array[k] = temp;
                }
            }
            
           
        }
        public static char[] passwordGenerator(string allTypesOfChar, int passwordLength, int count)
        {

            var Random = new Random();
            int numb = passwordLength - count;
            var stringChars = new char[numb];
            if (numb != 0)
            {
                for (int n = 0; n < numb; n++)
                {
                    stringChars[n] = allTypesOfChar[Random.Next(allTypesOfChar.Length)];
                }
            }
            return stringChars;
        }
        public static char[] GoodRandoms(Dictionary<string, string> DictionaryOfCharacters, int count, string allTypesOfChar)
        {
            var Random = new Random();
            var stringChars = new char[count];
            int i = 0;
            foreach (KeyValuePair<string, string> kvp in DictionaryOfCharacters)
            {
                if (allTypesOfChar.Contains(kvp.Value))
                {
                    stringChars[i] = kvp.Value[Random.Next((kvp.Value).Length)];
                    i++;
                }
            }
            return stringChars;
        }

    }

}



