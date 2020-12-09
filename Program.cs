using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace OOPLab3Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Edition ed1 = new Edition();
            ed1.EdName = "Ed Times";
            ed1.Circulation = -322;
            ed1.EdTime = new DateTime(1979, 12, 01);

            Edition ed2 = new Edition();
            ed2.EdName = "Ed Times";
            ed2.Circulation = -322;
            ed2.EdTime = new DateTime(1979, 12, 01);

            Console.WriteLine(ed1.GetHashCode());
            Console.WriteLine(ed2.GetHashCode());
            Console.WriteLine(ed1);
            Console.WriteLine(ed2);

            Magazine magazine = new Magazine();
            Console.WriteLine(magazine.ToShortString());
            Console.WriteLine("The magazine is published every week: {0}", magazine[Frequency.Weekly]);
            Console.WriteLine("The magazine is published every month: {0}", magazine[Frequency.Monthly]);
            Console.WriteLine("The magazine is published every year: {0}", magazine[Frequency.Yearly]);
            Console.WriteLine("\n########################################################################\n");

            magazine.EdName = "New York Times";
            magazine.Circulation = 1488;
            magazine.GSFreq = Frequency.Monthly;
            Console.WriteLine("The magazine is published every month: {0}\n", magazine[Frequency.Monthly]);
            magazine.AddArticles(new Article(new Person("Vitaliy", "Goryanets", DateTime.Now), "Guide how to fish 100kg per hour", 93.3));
            magazine.AddArticles(new Article(new Person("Vladimir", "Putin", new DateTime(1971, 12, 12)), "Drinking vodka without getting drunk", 99.9));
            magazine.AddArticles(new Article(new Person("Danylo", "Velychko", new DateTime(1988, 2, 3)), "How to make ollie on skate", 3.1));
            Console.WriteLine(magazine);
            Console.WriteLine("\nAvarage rating: {0}", magazine.AvgRating);


            object mclone = magazine.DeepCopy();
            magazine.EdName = "New Times Times";

            Console.WriteLine(magazine);
            Console.WriteLine(mclone);

            Console.WriteLine("Enter rating to search to");
            foreach (Article a in magazine.GetRate(Convert.ToDouble(Console.ReadLine())))
            {
                Console.WriteLine(a.Rating);
            }

            Console.WriteLine("Enter word to search to");
            foreach (Article a in magazine.GetTitle(Console.ReadLine()))
            {
                Console.WriteLine(a.Title);
            }



        }

    }
}
