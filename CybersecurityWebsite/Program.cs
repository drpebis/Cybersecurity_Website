using System;
using System.ComponentModel.Design;
using System.Reflection.Metadata;
using ProjectStep9;

namespace FortressCyber
{
    class Program
    {
        public void Menu()
        {
            Customer c = new Customer();
            Reports r = new Reports();

            Console.Clear();
            Console.Write("Fortress Cybersecurity\n1.Pull Report\n2.Write Report\n3.Search Customer\n:>");
            int choice = Convert.ToInt16(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    r.PullReport();
                    break;
                case 2:
                    r.WriteReport();
                    break;
                case 3:
                    c.GetProfile();
                    break;
            }
        }
        static void Main(string[] args)
        {
            User u = new User();
            Program p = new Program();

            u.EnterInfo();
            p.Menu();
        }
    }

}