using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class LibShelf
    {
        public Book[] libsh;
        // Counter id books
        int counterId = 3;
        // Construktor
        public LibShelf()
        {
            libsh = new Book[2];
            Book book1 = new Book() { idbook = 1, namebook = "book1", authorbook = "author1", takebook = "not taken" };
            Book book2 = new Book() { idbook = 2, namebook = "book2", authorbook = "author2", takebook = "not taken" };
            libsh[0] = book1;
            libsh[1] = book2;
        }
        // Print library
        public void PrintLib(bool usadmin)
        {
            for (int i = 0; i < libsh.Length; i++)
            {
                if (usadmin == false & libsh[i].takebook != "not taken")
                {
                    continue;
                }
                libsh[i].PrintBook(usadmin);
            }
            Console.WriteLine(new string ('_', 80));
        }
        // Print list of take
        public void ListTake(bool usadmin)
        {
            for (int i = 0; i < libsh.Length; i++)
            {
                if (libsh[i].takebook == "not taken")
                {
                    continue;
                }
                libsh[i].PrintBook(usadmin);
            }
            Console.WriteLine(new string('_', 80));
        }
        // Take of books
        public Book TakeBooks()
        {
            //Console.Clear();
            Console.Write("Enter id book:");
            int idbook = -1;// = int.Parse(Console.ReadLine());
            bool result = Int32.TryParse(Console.ReadLine(), out idbook);
            if (result)
            {
                for (int i = 0; i < libsh.Length; i++)
                {
                    if (idbook == libsh[i].idbook)
                    {
                        if (libsh[i].takebook == "not taken")
                        {
                            libsh[i].takebook = "is taken";
                            return libsh[i];
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                return null;
            }
            else
            {
                //Program.IncNum();
                return null;
            }
        }
        // Put of books
        public void ReturnBooks(int idbook)
        {
            for (int i = 0; i < libsh.Length; i++)
            {
                if (libsh[i].idbook == idbook)
                {
                    libsh[i].takebook = "not taken";
                    break;
                }
            }
        }
        // Add books
        public void AddBooks()
        {
            Book[] libshnew = new Book[libsh.Length + 1];
            for (int i = 0; i < libsh.Length; i++)
            {
                libshnew[i] = libsh[i];
            }
            libshnew[libshnew.Length - 1] = new Book() { idbook = counterId, takebook = "not taken" };
            Console.Write("Enter name the book:");
            libshnew[libshnew.Length - 1].namebook = Console.ReadLine();
            Console.Write("\nEnter author the book:");
            libshnew[libshnew.Length - 1].authorbook = Console.ReadLine();
            libsh = libshnew;
            counterId++;
            Console.WriteLine("\nBook is added.");
        }
        // Delete books
        public void DelBooks(bool isadmin)
        {
            PrintLib(isadmin);
            bool bookId = false;
            Console.Write("\nEnter id book:");
            int idBook = -1;// = int.Parse(Console.ReadLine());
            bool result = Int32.TryParse(Console.ReadLine(), out idBook);
            if (result)
            {
                for (int i = 0; i < libsh.Length; i++)
                {
                    if(idBook == libsh[i].idbook)
                    {
                        if(libsh[i].takebook == "not taken")
                        {
                            bookId = true;
                            break;
                        }
                        Console.WriteLine("\nBook is taken.Can not be removed.");
                        break;
                    }
                }
                if (bookId == true)
                {
                    Book[] libshnew = new Book[libsh.Length - 1];
                    for (int i = 0, k = 0; i < libsh.Length; k++, i++)
                    {
                        if (idBook == libsh[i].idbook)
                        {
                            k--;
                            continue;
                        }
                        libshnew[k] = libsh[i];
                    }
                    libsh = libshnew;
                    Console.WriteLine("Book is deleted.\n");
                }
            }
            else
            {
                Program.IncNum();
            }
        }
    }
}
