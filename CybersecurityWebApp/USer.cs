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
        private string loginName;
        private string password;
        Lists l = new Lists();
        private int loop = 0;

        public void CreateUser() //Adds all entered user information to its respective list
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
            // the following code hashes the entered password before it is stored in memory
            byte[] data = System.Text.Encoding.ASCII.GetBytes(this.password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);
            l.employees.Add(loginName);
            l.passwords.Add(hash);
            Console.WriteLine("\nNew account built, press enter to sign in at the main screen");
            Console.ReadLine();
            Authentication();
        }
        public void Authentication() //Basic front-end menu
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
        public void Exit() //Once the program is completed, this displays all of the usernames and 
            //hashed passwords that are stored
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
        
        public void EnterInfo() //Prompts the user for their login information
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
                Console.WriteLine("This Login name doesn't exist!\n" +
                    "Please try again, or enter 1 to return to the home screen: ");
                Console.Write(":>");
                this.loginName = Convert.ToString(Console.ReadLine());
                if (this.loginName == "1")
                {
                    Authentication();
                    loop++;  
                }
            }
            if (loop == 0)
            {
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
        } else if (loop != 0)
            {
                byte[] data = System.Text.Encoding.ASCII.GetBytes(this.password);
        data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
        String hash = System.Text.Encoding.ASCII.GetString(data);
        CheckInfo(this.loginName, hash);
    }

}
        //This determines if the entered information is correct
        public void CheckInfo(string loginName, string password)
        {
            if (VerifyInfo(loginName, password) == true)
            {
                Console.WriteLine("\nWelcome!");
                Thread.Sleep(1000);
                //Exit();
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