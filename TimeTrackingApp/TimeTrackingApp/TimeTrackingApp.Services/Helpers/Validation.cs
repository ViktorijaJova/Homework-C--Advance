using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TimeTrackingApp.Services.Helpers
{
     public class Validation
    {
        public static int ValidateNumber(string number, int range)
        {
            int num = 0;
            bool isNumber = int.TryParse(number, out num);
            if (!isNumber)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Error try again");
                Thread.Sleep(2000);
                Console.ResetColor();
     
                return -1;
            }
            if (num <= 0 || num > range)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Error try again");
                Thread.Sleep(2000);
                Console.ResetColor();
                return -1;
            }
            return num;
        }

        public static int ValidateAge(int age)
        {
            if (age < 18 && age > 120)
            {
                Console.WriteLine("Error try again");
                return -1;
            }
            return age;
        }

        public static string ValidateString(string str)
        {
            return str.Length < 2 ? null : str;
        }

        public static string ValidateUsername(string username)
        {
            return username.Length < 6 ? null : username;
        }

        public static string ValidatePassword(string password)
        {
            if (password.Length < 6)
            {
                return null;
            }

            // bool hasOneNumber = false;
            foreach (char character in password.ToCharArray())
            {
                //if(int.TryParse(character.ToString(), out int num))
                //{
                //    hasOneNumber = true;
                //    break;
                //}

                if (char.IsNumber(character))
                {
                    //hasOneNumber = true;
                    //break;
                    return password;
                }
            }
            return null;

            //if(!hasOneNumber)
            //{
            //    return null;
            //}
            //return password;
        }
    }
}
