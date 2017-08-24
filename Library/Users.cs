using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Users
    {
        public User[] users;

        public Users()
        {
            users = new User[2];
            User user1 = new User() { name = "a", pass = "a", isadmin = true };
            User user2 = new User() { name = "u", pass = "u", isadmin = false };
            users[0] = user1;
            users[1] = user2;
        }

        public void PrintUsers()
        {
            for (int i = 0; i < users.Length; i++)
            {
                users[i].PrintUser();
            }
            Console.ReadKey();
        }

        //Method admin menu
        public void AdminMenu(LibShelf libshelf, int indus)
        {
            while (true)
            {
                //Menu admin
                Console.Clear();
                Console.WriteLine("--- ADMIN MENU ---\n\n" +
                    "1 - List of books.\n" +
                    "2 - Add book.\n" +
                    "3 - Delete book.\n" +
                    "4 - List of books taken.\n" +
                    "5 - Make the user admin/not admin.\n" +
                    "6 - Quit to main menu.\n");
                Console.CursorVisible = false;
                ConsoleKey key = Console.ReadKey(true).Key;
                Console.CursorVisible = true;
                // Goto list of books
                if (key == ConsoleKey.D1)
                {
                    Console.Clear();
                    Console.WriteLine("--- LIST OF BOOKS ---\n");
                    libshelf.PrintLib(users[indus].isadmin);
                    Console.WriteLine("\nPress any key to quit.");
                    Console.ReadKey();
                }
                // Add book
                else if (key == ConsoleKey.D2)
                {
                    Console.Clear();
                    Console.WriteLine("--- ADD OF BOOKS ---\n");
                    libshelf.AddBooks();
                    Console.WriteLine("\nPress any key to quit.");
                    Console.ReadKey();
                }
                // Delete book
                else if (key == ConsoleKey.D3)
                {
                    Console.Clear();
                    Console.WriteLine("--- DELETE BOOKS ---\n");
                    libshelf.DelBooks(users[indus].isadmin);
                    //Console.WriteLine("\nPress any key to quit.");
                    //Console.ReadKey();
                }
                // List of books taken
                else if (key == ConsoleKey.D4)
                {
                    Console.Clear();
                    Console.WriteLine("--- LIST OF BOOKS TAKEN ---\n");
                    libshelf.ListTake(users[indus].isadmin);
                    Console.WriteLine("\nPress any key to quit.");
                    Console.ReadKey();
                }
                //Goto make the user admin/not admin
                else if (key == ConsoleKey.D5)
                {
                    Console.Clear();
                    Console.WriteLine("--- MAKE THE ADMIN/USER STATUS ---\n");
                    AdminNotadmin();
                    Console.WriteLine("\nPress any key to quit.");
                    Console.ReadKey();
                }
                // Goto Quit to main menu
                else if (key == ConsoleKey.D6)
                {
                    Console.Clear();
                    break;
                }
            }
        }
        // Add users
        public void AddUsers()
        {
            User[] usersnew = new User[users.Length + 1];
            for (int i = 0; i < users.Length; i++)
            {
                usersnew[i] = users[i];
            }
            usersnew[usersnew.Length - 1] = new User() { isadmin = false };
            Console.Write("\nEnter login:");
            usersnew[usersnew.Length - 1].name = Console.ReadLine();
            Console.Write("\nEnter password:");
            usersnew[usersnew.Length - 1].pass = Console.ReadLine();
            users = usersnew;
            Console.WriteLine(new string ('-', 80));
            Console.WriteLine("\nUser is created.");
        }
        // Make the user admin/not admin
        public void AdminNotadmin()
        {
            Console.Write("Enter login:");
            string login = Console.ReadLine();
            for (int i = 0; i < users.Length; i++)
            {
                if(login == users[i].name)
                {
                    Console.WriteLine("\n1 - make the admin status.\n2 - make the user status.\n3 - quit/");
                    while (true)
                    {
                        Console.CursorVisible = false;
                        ConsoleKey key = Console.ReadKey(true).Key;
                        Console.CursorVisible = true;
                        if (key == ConsoleKey.D1)
                        {
                            users[i].isadmin = true;
                        }
                        else if (key == ConsoleKey.D2)
                        {
                            users[i].isadmin = false;
                        }
                        else if (key == ConsoleKey.D3)
                        {
                            break;
                        }
                    }
                }
            }
        }
        // User menu
        public void UserMet(LibShelf libshelf, int indus)
        {
            while (true)
            {
                // Menu user
                Console.Clear();
                Console.WriteLine("--- USER MENU ---\n\n" +
                    "1 - List of book.\n" +
                    "2 - Put the book.\n" +
                    "3 - Take off book.\n" +
                    "4 - Quit to main menu.\n");
                Console.CursorVisible = false;
                ConsoleKey key = Console.ReadKey(true).Key;
                Console.CursorVisible = true;
                // Goto list of book
                if (key == ConsoleKey.D1)
                {
                    Console.Clear();
                    Console.WriteLine("--- MENU LIST OF BOOKS ---\n");
                    libshelf.PrintLib(users[indus].isadmin);
                    Console.WriteLine("\nPress any key to quit.");
                    Console.ReadKey();
                }
                // Goto put the book
                if (key == ConsoleKey.D2)
                {
                    Console.Clear();
                    Console.WriteLine("--- MENU PUT BOOKS ---\n");
                    users[indus].ListBooksUser();
                    int idbook = users[indus].PutBook();
                    if(idbook == -1)
                    {
                        Program.IncNum();
                    }
                    else
                    {
                        libshelf.PutBooks(idbook);
                        Console.WriteLine("\nBook is returned.\n\nPress any key to quit.");
                        Console.ReadKey();
                    }
                }
                // Goto take off book
                else if (key == ConsoleKey.D3)
                {
                    Console.Clear();
                    Console.WriteLine("--- MENU TAKE BOOKS ---\n");
                    users[indus].ListBooksUser();
                    Book book = libshelf.TakeBooks();
                    if (book == null)
                    {
                        Program.IncNum();
                    }
                    else
                    {
                        users[indus].TakeBook(book);
                    }
                }
                // Goto quit to main menu
                else if (key == ConsoleKey.D4)
                {
                    Console.Clear();
                    break;
                }
            }
        }
    }
}
