using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class User
    {
        public string name;
        public string pass;
        public bool isadmin;
        public Book[] books;

        public User()
        {
            books = new Book[5];
        }

        public void PrintUser()
        {
            Console.Write("Name:{0},Books -", name);
            if (books[0] != null)
            {
                for (int i = 0; i < books.Length; i++)
                {
                    Console.Write(" {0},", books[i].namebook);
                    if(books[i + 1] == null)
                    {
                        break;
                    }
                }
            }
            else
            {
                Console.Write(" No books.");
            }
            Console.WriteLine();
        }

        public void TakeBook(Book book)
        {
            bool full = false;
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] == null)
                {
                    books[i] = book;
                    full = true;
                    break;
                }
            }
            if(full == true)
            {
                Console.WriteLine("\nBook is taked.\n\nPress any key to quit.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("You have 5 books.\nReturn one or more.\n\nPress any key to quit.");
                Console.ReadKey();
            }
        }

        public int PutBook()
        {
            Console.Write("\nEnter idbook for return book to library:");
            int idbook = -1;// = int.Parse(Console.ReadLine());
            bool result = Int32.TryParse(Console.ReadLine(), out idbook);
            if (result)
            {
                for (int i = 0; i < books.Length; i++)
                {
                    if (idbook == books[i].idbook)
                    {
                        books[i] = null;
                        return idbook;
                    }
                }
                return idbook = -1;
            }
            else
            {
                //Program.IncNum();
                return idbook = -1;

            }
        }

        public void ListBooksUser()
        {
            Console.WriteLine();
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] == null)
                {
                    continue;
                }
                Console.WriteLine("idbook:{0}, Name:{1}, Author:{2}", books[0].idbook, books[0].namebook, books[0].authorbook);
            }
            Console.WriteLine();
        }
    }
}
