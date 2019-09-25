using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersecurityWebApp
{
    public class Lists
    {
        public static List<string> lastNames = new List<string>() { "Mancino" };
        public static List<string> phoneNumbers = new List<string>() { "867-5309" };
        public static List<string> organizations = new List<string>() { "Microsoft" };
        public static List<DateTime> reportDates = new List<DateTime>() { DateTime.Now };
        public static List<string> reportDescriptions = new List<string>() { "Turned the site on and off again" };
        public static List<string> reportTypes = new List<string>() { "Hot Site Fix" };
        public static List<int> reportIds = new List<int>(100);
        public List<string> employees = new List<string>() { /*"Alex"*/ };
        public List<string> passwords = new List<string>() { /*"password" */};

        public static List<string> LastNames
        {
            get => lastNames;
            set => lastNames = value;
        }

        public static List<string> PhoneNumbers
        {
            get => phoneNumbers;
            set => phoneNumbers = value;
        }

        public static List<string> Organizations
        {
            get => organizations;
            set => organizations = value;
        }
        //public static List<string> Employees
        //{
        //    get => employees;
        //    set => employees = value;
        //}

        //public static List<string> Passwords
        //{
        //    get => passwords;
        //    set => passwords = value;
        //}

    }
}
