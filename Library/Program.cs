using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Program
    {
        // Print incorrect
        public static void IncNum()
        {
            //Console.Clear();
            Console.WriteLine("\nIncorrect input.\nPress any key.");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            LibShelf libshelf = new LibShelf();
            Users usersarr = new Users();
            string login, pass;
            while (true)
            {
                bool incnum = false;
                Console.Clear();
                Console.WriteLine("--- MAIN MENU ---\n\n" +
                    "1 - Log in.\n" +
                    "2 - Register.\n" +
                    "3 - Quit.\n");
                Console.CursorVisible = false;
                ConsoleKey key = Console.ReadKey(true).Key;
                Console.CursorVisible = true;
                if (key == ConsoleKey.D1)
                {
                    Console.Write("Enter login:");
                    login = Console.ReadLine();
                    Console.Write("\nEnter password:");
                    pass = Console.ReadLine();
                    for (int i = 0; i < usersarr.users.Length; i++)
                    {
                        if (login == usersarr.users[i].name && pass == usersarr.users[i].pass && usersarr.users[i].isadmin)
                        {
                            usersarr.AdminMenu(libshelf, i);
                            incnum = true;
                            break;
                        }
                        else if (login == usersarr.users[i].name && pass == usersarr.users[i].pass && !usersarr.users[i].isadmin)
                        {
                            usersarr.UserMet(libshelf, i);
                            incnum = true;
                            break;
                        }
                    }
                    if (incnum != true)
                    {
                        IncNum();
                    }
                }
                else if (key == ConsoleKey.D2)
                {
                    Console.Clear();
                    Console.WriteLine("--- REGISTRATION MENU ---");
                    usersarr.AddUsers();
                    Console.WriteLine("\nPress any key to quit.");
                    Console.ReadKey();
                }
                else if (key == ConsoleKey.D3)
                {
                    break;
                }
            }




            //libshelf.PrintLib();
            //usersarr.users[0].books[0] = "book1";
            //usersarr.PrintUsers();

        }
    }
}
