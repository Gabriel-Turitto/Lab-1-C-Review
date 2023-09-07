using System.Collections.Immutable;

namespace Lab_1___C__Review
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
            string filePath = "C:\\Users\\gt022\\source\\repos\\Lab 1 - C# Review\\Lab 1 - C# Review\\videogames.csv";
            List<Videogames> videogames = new List<Videogames>();

            using(var sr = new StreamReader(filePath))
            {
                while(!sr.EndOfStream)
                {
                    string fileHeader = sr.ReadLine();
                    string? line = sr.ReadLine();
                    string[] lineElements = line.Split(',');
                    Videogames v = new Videogames()
                    {
                        Name = lineElements[0],
                        Platform = lineElements[1],
                        Year = Convert.ToInt32(lineElements[2]),
                        Genre = lineElements[3],
                        Publisher = lineElements[4],
                        NA_Sales = Convert.ToDouble(lineElements[5]),
                        EU_Sales = Convert.ToDouble(lineElements[6]),
                        JP_Sales = Convert.ToDouble(lineElements[7]),
                        Other_Sales = Convert.ToDouble(lineElements[8]),
                        Global_Sales = Convert.ToDouble(lineElements[9])
                    };

                    videogames.Add(v);
                }
            }//stop using

            //Publisher
            var totalCount = videogames.Count();

            Console.WriteLine("What publisher would you like to look up? ");
            string userPub = Console.ReadLine();

            var pub = videogames.Where(pub => pub.Publisher == userPub);
            pub = pub.OrderBy(pub => pub.Name).ToList();
            foreach(var v in pub)
            { 
                Console.WriteLine(v); 
            }

            var count = pub.Count();
            var percentageOfTotal = totalCount / count;
            Console.WriteLine($"Out of {totalCount} games {count} were made by {userPub} which is {percentageOfTotal}%");

            //Genre
            Console.WriteLine("What Genre would you like to look up? ");
            string userGen = Console.ReadLine();

            var gen = videogames.Where(pub => pub.Genre == userGen);
            pub = pub.OrderBy(pub => pub.Name).ToList();
            foreach (var v in pub)
            {
                Console.WriteLine(v);
            }

            count = gen.Count();
            percentageOfTotal = totalCount / count;
            Console.WriteLine($"Out of {totalCount} games {count} are of the {userGen} genre, which is {percentageOfTotal}%");
        }

    }
}