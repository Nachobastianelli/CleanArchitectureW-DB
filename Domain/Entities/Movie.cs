using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int Duration { get; set; }
        public List<ReviewMovie> Review { get; set; } = new List<ReviewMovie>();

        public Movie() { }

        public Movie(string name, string description, int durationInMinutes, List<ReviewMovie> review)
        {
            Name = name;
            Description = description;
            Duration = durationInMinutes;
            Review = review;
        }

    }
}
