using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CybersecurityWebApp
{
    class User
    {
        //This is a primitive version of how to store employees and passwords
        //add in some sort of encryption
        private string loginName;
        private string password;
        Lists l = new Lists();
        private int loop = 0;

        public void CreateUser()
        {
            Console.WriteLine("\nCreate a new user:\n");
            Console.Write("Enter Login Name: ");
            this.loginName = Convert.ToString(Console.ReadLine());
            while (l.employees.Contains(this.loginName))
            {
                Console.WriteLine("\nThis Username is already in use, please choose another:");
                Console.Write("Enter Login Name: ");
                this.loginName = Convert.ToString(Console.ReadLine());
            }
            Console.Write("Enter Password: ");
            this.password = Console.ReadLine();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(this.password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);
            //do
            //{
            //    ConsoleKeyInfo key = Console.ReadKey(true);
            //    // Backspace Should Not Work
            //    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            //    {
            //        password += key.KeyChar;
            //        Console.Write("*");
            //    }
            //    else
            //    {
            //        if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            //        {
            //            password = password.Substring(0, (password.Length - 1));
            //            Console.Write("\b \b");
            //        }
            //        else if (key.Key == ConsoleKey.Enter)
            //        {
            //            break;
            //        }
            //    }
            //} while (true);
            l.employees.Add(loginName);
            l.passwords.Add(hash);
            Console.WriteLine("\nNew account built, press enter to sign in at the main screen");
            Console.ReadLine();
            Authentication();
        }
        public void Authentication()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------------------- \n");
            Console.WriteLine("        PASSWORD AUTHENTICATION SYSTEM\n");
            Console.WriteLine("        Please select one option:");
            Console.WriteLine("        1. Establish an account\n        2. Authenticate a user\n" +
                "        3. Exit the system\n");
            Console.WriteLine("        Enter selection:\n");
            Console.WriteLine("--------------------------------------------------------------------\n");
            Console.Write(":>");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    CreateUser();
                    break;
                case 2:
                    EnterInfo();
                    break;
                case 3:
                    Console.Clear();
                    Exit();
                    break;
            }

        }
        public void Exit()
        {
            int count = 0;
            Console.Clear();
            Console.WriteLine("The following pairs were made:\n");
            Console.WriteLine("------------------------------------------------------");
            foreach(var n in l.employees)
            {
                Console.WriteLine($"Username {n}'s password:");
                Console.WriteLine($"{l.passwords[count]}\n");
                count++;
            }
            Console.ReadLine();
            Console.WriteLine("The system will now exit");
            Thread.Sleep(2500);
            Environment.Exit(0);
        }
        //Prompts the user for their login information
        //need to hide the password entry
        public void EnterInfo()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------------------- \n");
            Console.WriteLine("        FORTRESS CYBERSECURITY\n");
            Console.WriteLine("        Enter information below\n");
            Console.WriteLine("--------------------------------------------------------------------\n");
            Console.Write("Enter Login Name: ");
            this.loginName = Convert.ToString(Console.ReadLine());
            while (!l.employees.Contains(loginName))
            {
                Console.Write("This Login name doesn't exist try again, or enter 1 to exit: ");
                this.loginName = Convert.ToString(Console.ReadLine());
                if (this.loginName == "1")
                {
                    Authentication();
                    loop++;  
                }
            }
            //if (loop == 0)
            //{
                Console.Write("Enter Password: ");
                this.password = Console.ReadLine();
                //do
                //{
                //    ConsoleKeyInfo key = Console.ReadKey(true);
                //    // Backspace Should Not Work
                //    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                //    {
                //        password += key.KeyChar;
                //        Console.Write("*");
                //    }
                //    else
                //    {
                //        if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                //        {
                //            password = password.Substring(0, (password.Length - 1));
                //            Console.Write("\b \b");
                //        }
                //        else if (key.Key == ConsoleKey.Enter)
                //        {
                //            break;
                //        }
                //    }
                //} while (true);
                byte[] data = System.Text.Encoding.ASCII.GetBytes(this.password);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                String hash = System.Text.Encoding.ASCII.GetString(data);
                CheckInfo(this.loginName, hash);
            //} else if (loop > 0)
            //{
            //    byte[] data = System.Text.Encoding.ASCII.GetBytes(this.password);
            //    data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            //    String hash = System.Text.Encoding.ASCII.GetString(data);
            //    CheckInfo(this.loginName, hash);
            //}
            
        }
        //This determines if the entered information is correct
        public void CheckInfo(string loginName, string password)
        {
            if (VerifyInfo(loginName, password) == true)
            {
                Console.WriteLine("\nWelcome!");
                Console.ReadLine();
                Exit();
            }
            else
            {
                Console.WriteLine("\nSomething went wrong, press enter to try again");
                Console.ReadLine();
                Console.Clear();
                EnterInfo();
            }
        }
        //Checks the lists for a valid entry
        public bool VerifyInfo(string loginName, string password)
        {
            bool verify = false;
            int loginNamePos = l.employees.IndexOf(loginName);
            int passwordPos = l.passwords.IndexOf(password);
            if (l.employees.Contains(loginName) && l.passwords.Contains(password) && loginNamePos == passwordPos)
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