using System;
using System.Collections.Generic;
using System.Text;

namespace FortressCyber
{
    class User
    {
        //This is a primitive version of how to store employees and passwords
        //add in some sort of encryption
        private List<string> employees = new List<string>(){"Alex"};

        private List<string> passwords = new List<string>(){"password"};
        string loginName { get; set; }
        string password { get; set; }
        byte roleId;
        int employeeId;

        //Prompts the user for their login information
        //need to hide the password entry
        public void EnterInfo()
        {
            Console.Write("Enter Login Name: ");
            this.loginName = Console.ReadLine();
            Console.Write("Enter Password: ");
            //this.password = Console.ReadLine();
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                // Backspace Should Not Work
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        password = password.Substring(0, (password.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);
            CheckInfo(loginName, this.password);
        }
        //This determines if the entered information is correct
        public void CheckInfo(string loginName, string password)
        {
            if (VerifyInfo(loginName, password) == true)
            {
                Console.WriteLine("\nWelcome!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Something went wrong, press enter to try again");
                Console.ReadLine();
                Console.Clear();
                EnterInfo();
            }
        }
        //Checks the lists for a valid entry
        public bool VerifyInfo(string loginName, string password)
        {
            bool verify = false;
            if (employees.Contains(loginName) && passwords.Contains(password))
            {
                return verify = true;
            }
            else
            {
                return verify;
            }
        }
    }
}
