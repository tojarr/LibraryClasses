using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Book
    {
        public int idbook;
        public string namebook;
        public string authorbook;
        public string takebook;

        public void PrintBook(bool usadmin)
        {
            if(usadmin == true)
            {
                Console.WriteLine("id:{0}, Name:{1}, Autor:{2}, Takebook:{3}\n", idbook, namebook, authorbook, takebook);
            }
            else
            {
                Console.WriteLine("id:{0}, Name:{1}, Autor:{2}\n", idbook, namebook, authorbook);
            }
        }
    }
}
