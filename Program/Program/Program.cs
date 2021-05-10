using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Login();
        }

        static void Login()
        {
            Console.Clear();
            WebClient wb = new WebClient();
            string username;
            string password;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome! Please login.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Username:");
            Console.ResetColor();
            username = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Password:");
            Console.ResetColor();
            password = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;

            string APIrequest = wb.DownloadString("http://localhost/api/user/login.php?username=" + username + "&password=" + password);
            dynamic API = JsonConvert.DeserializeObject(APIrequest);
            if (API.status == "true")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You successfully logged in.");
                Thread.Sleep(5000);
                // Do something lol
            }
            else if (API.status == "false")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid credentials");
                Thread.Sleep(5000);
                Login(); // Just to loop
            }
        }
    }
}
