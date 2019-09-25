using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersecurityWebApp
{
    class Customer
    {
        //All lists and variables, quick note:
        //every piece of customer information is stored sequentially based off of custId
        private int custId;
        private List<int> custIds = new List<int>() { 0 };
        private string firstName;
        private List<string> firstNames = new List<string>() { "Alex" };
        private string lastName;
        private List<string> lastNames = new List<string>() { "Mancino" };
        private string phoneNumber;
        private List<string> phoneNumbers = new List<string>() { "867-5309" };
        private string address;
        private List<string> addresses = new List<string>() { "123 Street St. Zip, State" };
        private string organization;
        private List<string> organizations = new List<string>() { "Microsoft" };
        private List<DateTime> dateAdded = new List<DateTime>() { DateTime.Now };

        //searches for the requested customer based off of the requested criteria, custID, last name, 
        //or customer organization
        public void SearchCustomer(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.Write("Enter Customer ID: ");
                    this.custId = Convert.ToInt16(Console.ReadLine());
                    if (!custIds.Contains(custId))
                    {
                        Console.WriteLine("Customer ID not found, press ENTER to retry");
                        Console.ReadLine();
                        SearchCustomer(choice);
                    }
                    else
                    {
                        BuildProfile(custId);
                    }
                    break;
                case 2:
                    Console.Clear();
                    Console.Write("Enter Customer Last Name: ");
                    this.lastName = Console.ReadLine();
                    if (!lastNames.Contains(lastName))
                    {
                        Console.WriteLine("Customer last name not found, press ENTER to retry");
                        Console.ReadLine();
                        SearchCustomer(choice);
                    }
                    else
                    {
                        custId = lastNames.IndexOf(lastName);
                        BuildProfile(custId);
                    }
                    break;
                case 3:
                    Console.Clear();
                    Console.Write("Enter Customer Organization: ");
                    this.organization = Console.ReadLine();
                    if (!organizations.Contains(organization))
                    {
                        Console.WriteLine("Customer organization not found, press ENTER to retry");
                        Console.ReadLine();
                        SearchCustomer(choice);
                    }
                    else
                    {
                        custId = organizations.IndexOf(organization);
                        BuildProfile(custId);
                    }
                    break;
            }
            Console.ReadLine();
        }

        //Console-focused method which interfaces with the user
        public void GetProfile()
        {
            Program p = new Program();
            Console.Clear();
            Console.Write(@"Choose: 
1. Search by Customer Id
2. Search by Customer Last Name
3. Search by Customer Organization
:>");
            int choice = Convert.ToInt16(Console.ReadLine());
            SearchCustomer(choice);
            p.Menu();
        }

        //Builds the requested profile
        public void BuildProfile(int custId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(firstNames[custId] + " " +
                      lastNames[custId] + " " +
                      organizations[custId] + " " +
                      phoneNumbers[custId] + " " +
                      addresses[custId] + " " +
                      dateAdded[custId]);
            Console.WriteLine(sb);
        }
    }
}
