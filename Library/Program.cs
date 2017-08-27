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
            Console.WriteLine("\nIncorrect input.\nPress any key.");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            LibShelf libshelf = new LibShelf();
            Users usersarr = new Users();
            
            while (true)
            {
                
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
                    usersarr.LogPass(libshelf);
                }
                else if (key == ConsoleKey.D2)
                {
                    usersarr.AddUsers();
                }
                else if (key == ConsoleKey.D3)
                {
                    break;
                }
            }
        }
    }
}
