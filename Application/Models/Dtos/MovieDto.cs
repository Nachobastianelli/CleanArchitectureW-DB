using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dtos
{
    public class CreateMovie
    {
        public required string Description { get; set; }
        public required string Name { get; set; } 
        public int Duration { get; set; }
    }

    public class UpdateMovie
    {
        public string? Description { get; set; }
        public string? Name { get; set; }
        public int Duration { get; set; }
    }

    
}
