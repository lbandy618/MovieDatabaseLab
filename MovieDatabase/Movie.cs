using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
    internal class Movie
    {
        public string Title { get; set; }
        public string Catagory { get; set; }

        public double RunTime { get; set; }


        public Movie(string _title, string _catagory, double _runTime)
        {
            Title = _title;
            Catagory = _catagory;
            RunTime = _runTime;
        }
    }
}
