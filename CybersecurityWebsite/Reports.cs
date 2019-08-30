using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using FortressCyber;

namespace ProjectStep9
{
    class Reports
    {
        public static List<string> lastNames = new List<string>() { "Mancino" };
        public static List<string> phoneNumbers = new List<string>() { "867-5309" };
        public static List<string> organizations = new List<string>() { "Microsoft" };
        public static List<DateTime> reportDates = new List<DateTime>() { DateTime.Now };
        public static List<string> reportDescriptions = new List<string>() { "Turned the site on and off again" };
        public static List<string> reportTypes = new List<string>() { "Hot Site Fix" };
        public static List<int> reportIds = new List<int>(100){0,1,2,3,4,5,6,7,8,9,10};
        private int reportId;
        
        private string reportType;
        
        private string reportDescription;
        
        private string reportDate;
        
        private string organization;
        
        private string phoneNumber;
        
        private string lastName;
        

        public void WriteReport()
        {
            Program p = new Program();
            Console.Clear();
            
            Console.Write("Enter Organization: ");
            this.organization = Console.ReadLine();
            organizations.Add(organization);
            Console.Write("Enter Customer Name: ");
            this.lastName = Console.ReadLine();
            lastNames.Add(lastName);
            Console.Write("Enter Customer Phone Number: ");
            this.phoneNumber = Console.ReadLine();
            phoneNumbers.Add(phoneNumber);
            Console.Write("Enter report type: ");
            this.reportType = Console.ReadLine();
            reportTypes.Add(reportType);
            Console.Write("Enter report description: ");
            this.reportDescription = Console.ReadLine();
            reportDescriptions.Add(reportDescription);
            reportDates.Add(DateTime.Today);
            this.reportId++;
            reportIds.Add(reportId);


            Console.WriteLine("Done... Press enter to preview");
            Console.ReadLine();
            BuildReport(reportId);
            p.Menu();
        }
        public void PullReport()
        {
            Program p = new Program();
            Console.Clear();
            Console.Write(@"Pull by what criteria? 
1. Report ID 
2. Report Type 
3. Report Description 
4. Organization
:>");
            int choice = Convert.ToInt16(Console.ReadLine());
            FindReport(choice);
            p.Menu();
        }

        public void BuildReport(int reportId)
        {
            Console.WriteLine($"Report ID: {reportIds[reportId]}");
            Console.WriteLine($"Organization: {organizations[reportId]}");
            Console.WriteLine($"Report Date: {reportDates[reportId]}");
            Console.WriteLine($"Customer Name: {lastNames[reportId]}");
            Console.WriteLine($"Customer Phone Number: {phoneNumbers[reportId]}");
            Console.WriteLine($"Report Type: {reportTypes[reportId]}");
            Console.WriteLine($"Report Description: {reportDescriptions[reportId]}");
            Console.WriteLine("\nPress ENTER...");
            Console.ReadLine();
        }

        public void FindReport(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.Write("Enter Report ID: ");
                    this.reportId = Convert.ToInt16(Console.ReadLine());
                    if (!reportIds.Contains(reportId))
                    {
                        Console.WriteLine("Report ID not found, press ENTER to retry");
                        Console.ReadLine();
                        FindReport(choice);
                    }
                    else
                    {
                        BuildReport(reportId);
                    }
                    break;
                case 2:
                    Console.Clear();
                    Console.Write("Enter Report Type (Hot Site Fix): ");
                    this.reportType = Console.ReadLine();
                    if (!reportTypes.Contains(reportType))
                    {
                        Console.WriteLine("Report type not found, press ENTER to retry");
                        Console.ReadLine();
                        FindReport(choice);
                    }
                    else
                    {
                        reportId = reportTypes.IndexOf(reportType);
                        BuildReport(reportId);
                    }
                    break;
                case 3:
                    Console.Clear();
                    Console.Write("Enter report description(Turned the site on and off again): ");
                    this.reportDescription = Console.ReadLine();
                    if (!reportDescriptions.Contains(reportDescription))
                    {
                        Console.WriteLine("Report description not found, press ENTER to retry");
                        Console.ReadLine();
                        FindReport(choice);
                    }
                    else
                    {
                        reportId = reportDescriptions.IndexOf(reportDescription);
                        BuildReport(reportId);
                    }
                    break;
                case 4:
                    Console.Clear();
                    Console.Write("Enter organization(Microsoft): ");
                    this.organization = Console.ReadLine();
                    if (!organizations.Contains(organization))
                    {
                        Console.WriteLine("Organization not found, press ENTER to retry");
                        Console.ReadLine();
                        FindReport(choice);
                    }
                    else
                    {
                        reportId = organizations.IndexOf(organization);
                        BuildReport(reportId);
                    }
                    break;
            }
        }
    }
}
