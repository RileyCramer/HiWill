using Microsoft.VisualBasic;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Xml.Linq;
using WillPart2;

namespace WillProject;


public class Program
{

    static void Main(string[] args)
    {
        string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
        string filePath = projectFolder + Path.DirectorySeparatorChar + "videogames.csv";

        List<VideoGame> game = new List<VideoGame>();
        
        using (var s = new StreamReader(filePath))
        {
            while (!s.EndOfStream)
            {
                string? line = s.ReadLine();

                string[] lineElements = line.Split(',');

                VideoGame v = new VideoGame()
                {
                    Name = lineElements[0].Trim(),
                    Platform = lineElements[1].Trim(),
                    Year = lineElements[2].Trim(),
                    Genre = lineElements[3].Trim(),
                    Publisher = lineElements[4].Trim(),
                    NASales = lineElements[5].Trim(),
                    EUSales = lineElements[6].Trim(),
                    JPSales = lineElements[7].Trim(),
                    OtherSales = lineElements[8].Trim(),
                    GlobalSales = lineElements[9].Trim(),
                };

                game.Add(v);
            }
        }
        game.Sort();
        //foreach (var v in game)
        {//
         // Console.WriteLine(v);
         //  Console.WriteLine("-----------------");
         //}

            var finder = game.Where(v => v.Publisher == "Ubisoft");

            foreach (var v in finder)
            {
                Console.WriteLine(v);
                Console.WriteLine("-----------------");
            }

            double ubiGames = finder.Count();
            double perc = ubiGames / game.Count() * 100;

            /* Console.WriteLine($"Out of {game.Count} there are {ubiGames} games.");
             Console.WriteLine($"This means that this makes up {perc: 0.##}% of the list");
            */
            var genrer = game.Where(v => v.Genre == "Action");

            foreach (var v in genrer)
            {
                Console.WriteLine(v);
                Console.WriteLine("-----------------");
            }

            double genreList = genrer.Count();
            double genrePerc = genreList / game.Count() * 100;

            Console.WriteLine($"Out of {game.Count} there are {genreList} games of this genre.");
            Console.WriteLine($"This means that this makes up{genrePerc: 0.##}% of the list");

            Console.WriteLine("Genre Finder: What is the genre you would like?");
            string genree = Console.ReadLine();
            GenreData(game, genree);

            Console.WriteLine("Publisher Finder: What is the publisher you would like to select?");
            string pubb = Console.ReadLine();
            PublisherData(game, pubb);
        }

        static void GenreData(List<VideoGame> game, string type)
        {
            var total = game.Count();
            var type2 = new List<VideoGame>();
            var genrers = game.Where(v => v.Genre == type);

            /*foreach (var g in genrers)
            {
                if (g.Genre == type)
                {
                    type2.Add(g);
                }
            }*/
            double numGenre = genrers.Count();

            var pct = numGenre / total * 100;


            Console.WriteLine($"There are {numGenre} {type} type games out of {total} total games which is {pct: 0.##}%.");

        }

        static void PublisherData(List<VideoGame> game, string type)
        {
            var total = game.Count();
            var type2 = new List<VideoGame>();
            var pubs = game.Where(v => v.Publisher == type);


            double numPub = pubs.Count();

            var pct = numPub / total * 100;


            Console.WriteLine($"There are {numPub} {type} type games out of {total} total games which is {pct:0.##}%.");
        }

        game.Sort();

        /*Dictionary<string, string> ungaBunga = new Dictionary<string, string>();

         Console.WriteLine("What is the game you are looking for");
         string name = Console.ReadLine();
         int counter = 0;

         foreach (var gamer in game)
         {

             if (!ungaBunga.ContainsKey(gamer.Name))
             {
                 ungaBunga.Add(gamer.Name, gamer.Platform);
             }

             else 
             {
                 ungaBunga.Add($"{gamer.Name}{counter}", gamer.Platform);
                 counter++;
             }

         }

         string keyN = name;
         Console.WriteLine($"{keyN} is on these platforms:");
         foreach (var gamer in ungaBunga)
         {
             if (gamer.Key.StartsWith(keyN))
             {
                 Console.WriteLine($"{gamer.Value}");
             }

         }
         */
         Stack<string> stack = new Stack<string>();
         Random random = new Random();

         Console.WriteLine("Pick a publisher to pull all the games from.");
        string answer = Console.ReadLine(); 

         foreach (var gamer in game.Where(g => g.Publisher == answer))
         {  
             stack.Push(gamer.Name);
         }
         int hi = random.Next(1, stack.Count - 1);

         for (int i = 0; i <= hi; i++)
          {
              stack.Pop();
          }

         Console.WriteLine("This is the new stack-----------------------------------------------------");
         Console.WriteLine($"{hi} games were taken off");
         foreach (var i in stack)
         {
             Console.WriteLine(i);
         }
         Console.WriteLine("This will now make a random number to take away from the stack\n --------------------------------------------------------------------------------------------------------");
        


        Console.WriteLine("DISPLAYING QUEUE HERE-----------------------------------------------------------------------------------------------------------------------------------------------------");
        Queue<string> queue = new Queue<string>();
        
        foreach (var gamer in game.Where(g => g.Publisher == "Sega"))
        {
            queue.Enqueue(gamer.Name);
        }
        int rng = random.Next(1, queue.Count());

        for (int i = 0; i <= rng; i++)
        {
            queue.Dequeue();
        }

        Console.Clear();
        Console.WriteLine("This is the queue with a random amount of games removed");
        Console.WriteLine($"The amount of gamers removed are: {rng}");

        foreach (var a in queue)
        {
            Console.WriteLine(a);
        }
        
        




    }
}










