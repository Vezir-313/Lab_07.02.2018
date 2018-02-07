using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07._02._2018
{
    class Book
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string author { get; set; }

        public bool status { get; set; }

        public static void creatBook(int n)
        {
            Console.WriteLine("\n Yeni kitabin xususiyyetlerini daxil edin ");
            Book book = new Book();
            book.Id = n+1;
            book.status = true;

            Console.Write(" kitabin adi : ");
            string kitabinAdi = Console.ReadLine();

            if(string.IsNullOrEmpty(kitabinAdi) == true)
            {
                Console.WriteLine("\n Melumatlari duzgun daxil et !!!!");
                Book.creatBook(n);
            }

            Console.Write(" kitabin yazari : ");
            string kitabinyazar = Console.ReadLine();

            if (string.IsNullOrEmpty(kitabinyazar) == true)
            {
                Console.WriteLine("Melumatlari duzgun daxil et !!!!");
                Book.creatBook(n);
            }


            book.title = kitabinAdi;
            book.author = kitabinyazar;
            Console.WriteLine("Kitab Ugurla yaradildi !!!");
            Panel.activeUSer.books.Add(book);
            Panel.menu();

        }

        public static void showBooks()
        {
            Console.WriteLine("ID\t\t title \t\t author");
            Console.WriteLine("-------------------------------------------------");

            foreach (var item in Panel.activeUSer.books)
            {
                if(item.status == true)
                {
                    Console.WriteLine("{0}\t\t {1} \t\t{2}", item.Id, item.title, item.author);
                }
            }

            Panel.menu();
        }

        public static void deleteBook()
        {
            Console.WriteLine("ID\t\t title \t\t author");
            Console.WriteLine("-------------------------------------------------");

            foreach (var item in Panel.activeUSer.books)
            {
                if (item.status == true)
                {
                    Console.WriteLine("{0}\t\t {1} \t\t{2}", item.Id, item.title, item.author);
                }
            }
            Console.Write("Silmek istediyiniz kitabin id si : ");
            int n = int.Parse(Console.ReadLine());
            bool action = false;
            foreach (var item in Panel.activeUSer.books)
            {
                if(n == item.Id)
                {
                    item.status = false;
                    action = true;
                    Console.WriteLine("{0} Kitabi ugurla silindi",item.title);
                }
            }
            if (action == false)
            {
                Console.WriteLine("KItab silinmedi yeniden cehd edin ");
                Book.deleteBook();
                Panel.menu();
            }

            Panel.menu();
        }
    }
}
