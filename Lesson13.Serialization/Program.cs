using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

namespace Lesson13.Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book
            {
                Name = ".NET 4.8",
                Author = "Troelsen. Lop",
                PublishYear = 2017,
                Id = 6677
            };

            book.Chapets.Add(new Chapets{Name = "Yellow Screen", StartPage = 23, EndPage = 45});
            book.Chapets.Add(new Chapets{Name = "Gray Box", StartPage = 159, EndPage = 275});

            var sBook = new SoapBook
            {
                Name = ".NET 4.8",
                Author = "Troelsen. Lop",
                PublishYear = 2017,
                Id = 564
            };

            sBook.AddChapet(new Chapets { Name = "Yellow Screen", StartPage = 23, EndPage = 45 });
            sBook.AddChapet(new Chapets { Name = "Gray Box", StartPage = 159, EndPage = 275 });

            //BinarySerialize(book);
            XmlSerialization(book);
            //SoapSerialization(sBook);

            Console.ReadLine();
        }

        private static void BinarySerialize(Book book)
        {
#if fasle


            book.SetPages(1345);

            var fs = new FileStream("books.dat", FileMode.Create, FileAccess.Write);
            var bs = new BinaryFormatter();
            bs.Serialize(fs, book);

            fs.Close(); 
#endif

            var fs = new FileStream("books.dat", FileMode.Open, FileAccess.Read);
            var bs = new BinaryFormatter();

            var b = (Book) bs.Deserialize(fs);

            if (b != null)
            {
                Console.WriteLine(
                    $"Name: {b.Name}\nAuthor: {b.Author}\nPublish year: {b.PublishYear}\nPages: {b.GetPages()}");
            }
        }

        private static void XmlSerialization(Book book)
        {
#if fasle
            var fs = new FileStream("books.xml", FileMode.Create, FileAccess.Write);

            var xs = new XmlSerializer(typeof(List<Book>));
            xs.Serialize(fs, new List<Book> { book, new Book { Name = "FRo", PublishYear = 2012, Author = "Azimov", Id = 14578} });
            fs.Close();

            Console.WriteLine("Success!"); 
#endif
#if true
            var fs = new FileStream("books.xml", FileMode.Open, FileAccess.Read);

            var xs = new XmlSerializer(typeof(List<Book>));

            var books = (List<Book>)xs.Deserialize(fs);

            if (books.Count > 0)
            {
                foreach (var b in books)
                {
                    Console.WriteLine(
                        $"Name: {b.Name}\nAuthor: {b.Author}\nPublish year: {b.PublishYear}\nPages: {b.GetPages()}\nId: {b.Id}");

                    if (b.Chapets != null && b.Chapets.Count > 0)
                    {
                        Console.WriteLine("----Chapets----");
                        foreach (var chapet in b.Chapets)
                        {
                            Console.WriteLine(
                                $"Name: {chapet.Name}\nStart Page: {chapet.StartPage}\nEnd Page: {chapet.EndPage}");

                        }

                        Console.WriteLine();
                    }
                }
            } 
#endif
        }

        private static void SoapSerialization(SoapBook book)
        {
#if fasle
            var fs = new FileStream("books.soap", FileMode.Create, FileAccess.Write);

            var so = new SoapFormatter();
            so.Serialize(fs, new [] { book, new SoapBook { Name = "Global", PublishYear = 2014, Author = "Issac", Id = 378} });
            fs.Close();

            Console.WriteLine("Success!"); 
#endif
#if true
            var fs = new FileStream("books.soap", FileMode.Open, FileAccess.Read);

            var xs = new SoapFormatter();

            var books = (SoapBook[])xs.Deserialize(fs);

            if (books.Length > 0)
            {
                foreach (var b in books)
                {
                    Console.WriteLine(
                        $"Name: {b.Name}\nAuthor: {b.Author}\nPublish year: {b.PublishYear}\nPages: {b.GetPages()}\nId: {b.Id}");

                    if (b.Chapets != null && b.Chapets.Length > 0)
                    {
                        Console.WriteLine("----Chapets----");
                        foreach (var chapet in b.Chapets)
                        {
                            Console.WriteLine(
                                $"Name: {chapet.Name}\nStart Page: {chapet.StartPage}\nEnd Page: {chapet.EndPage}");

                        }

                        Console.WriteLine();
                    }
                }
            } 
#endif
        }
    }
}
