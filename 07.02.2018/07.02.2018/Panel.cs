using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07._02._2018
{
    static class Panel
    {
        static List<User> users = new List<User>();
        public static User activeUSer { get; set; }

        public static int LoginPanel()
        {
            Console.WriteLine("Kitabxanaya xow geldin ");

            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");

            Console.Write("secim : ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");
            switch (n)
            {
                case 1: Panel.Login(); return 1;
                case 2: Panel.Register(); return 2;
                default:   Panel.LoginPanel(); return 0;
            }
        }

        public static void Register()
        {
            Console.Write("Istifadeci adi : ");

            string usernameWrite = Console.ReadLine();

            if (string.IsNullOrEmpty(usernameWrite) == false)
            {
                foreach (var item in users)
                {
                    if(item.userName == usernameWrite)
                    {
                        Console.WriteLine("Istifadeci adi artig istifade edilib tekrar cehd edin");
                        Panel.Register();
                    }
                }

                User user = new User();

                user.userName = usernameWrite;
                Panel.users.Add(user);
                Panel.activeUSer = user;
                Panel.menu();
            }
            else
            {
                Console.WriteLine("Istifadeci adini dogru daxil edin ");
                Panel.Register();
            }
        }

        public static void Login()
        {
            Console.Write("\n Istifadeci adi : ");

            string username = Console.ReadLine();
            if(string.IsNullOrEmpty(username.Trim()) == false)
            {
                foreach (var item in users)
                {

                    if (item.userName == username)
                    {
                        Panel.activeUSer = item;
                        Panel.menu();
                    }
                }

                Console.WriteLine("Bu adda istifadeci tapilmadi :(");
                Panel.Login();
            }
            else
            {
                Console.WriteLine("Duzgun daxil edin !!!!!!!!!!");
                Panel.Login();
            }
          

        }

        public static void menu()
        {
            Console.WriteLine("\n {0} Xidmetlerden birini secin ",Panel.activeUSer.userName);
            Console.WriteLine("1. Kitab elave et");
            Console.WriteLine("2. Kitablarin siyahi");
            Console.WriteLine("3. Kitabi sil");
            Console.WriteLine("4. sistemden cix");

            Console.Write("secim :");
            int n = int.Parse(Console.ReadLine());

            switch (n)
            {
                case 1: Book.creatBook(Panel.activeUSer.books.Count);  break;
                case 2: Book.showBooks(); break;
                case 3: Book.deleteBook(); break;
                case 4: Panel.Exit(); break;
                default: Panel.menu(); break;

            }

        }
        public static void Exit()
        {
            Panel.activeUSer = null;
            Panel.LoginPanel();
        }

    }
}
