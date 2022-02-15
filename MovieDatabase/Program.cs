using System;
using MovieDatabase;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie>()
            {
                new Movie("Click", "Comedy", 107),
                new Movie("Superbad", "Comedy", 119),
                new Movie("Pineapple Express", "Comedy", 117),
                new Movie("Benchwarmers", "Comedy", 98),
                new Movie("Were the Millers", "Comedy", 118),
                new Movie("Interstellar", "Sci-Fi", 169),
                new Movie("Insidious", "Horror", 103),
                new Movie("Attonement", "Drama", 123),
                new Movie("The Conjuring", "Horror", 112),
                new Movie("X-Men", "Action", 104)
            };

            //get distinct catagories
            List<Movie> distinctCatagories = movies.GroupBy(m => m.Catagory).Select(g => g.First()).ToList();
            Console.WriteLine("Welcome to the GC Theatre...");
            Console.WriteLine();
            Console.WriteLine($"There are {movies.Count} movies in this list.");
            //loop the program
            bool runProgram = true;
            while (runProgram)
            {
                //user input
                for(int i = 0; i < distinctCatagories.Count; i++)
                {
                    Console.WriteLine($"{i}. {distinctCatagories[i].Catagory}");
                }

                Console.Write("What catagory are you interested in?: ");
                int num = 0;
                while (!int.TryParse(Console.ReadLine(), out num))
                {
                    Console.Write("Not a valid catagory, please try again: ");
                }
                string catagory = distinctCatagories[num].Catagory;

                //getting matches using LINQ (EASIEST WAY TO DO LAB)

                List<Movie> result = movies.Where(m => m.Catagory.ToLower() == catagory.ToLower()).ToList();

                //manual way of getting code above
                //List<Movie> result = new List<Movie>();
                //foreach(Movie m in movies)
                //{
                //    if(m.Catagory.ToLower() == catagory.ToLower())
                //    {
                //        result.Add(m);
                //    }
                //}

                //displaying matches
                foreach (Movie m in result.OrderBy(m => m.Title))
                {
                    Console.WriteLine($"{m.Title}    Runtime: {m.RunTime} minutes.");
                }
                //checking for correct catagory entered
                if(result.Count == 0)
                {
                    Console.WriteLine("That catagory does not exist.");
                }
                // asking to continue
                while (true)
                {
                    Console.WriteLine();
                    Console.Write("Would you like to search again? y/n: ");
                    string choice = Console.ReadLine();
                    Console.WriteLine();
                    if(choice.ToLower() == "y")
                    {
                        runProgram = true;
                        break;
                    }
                    else if (choice.ToLower() == "n")
                    {
                        runProgram= false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("That was not a valid input, please try again.");
                    }
                }
            }

        }
    }
}