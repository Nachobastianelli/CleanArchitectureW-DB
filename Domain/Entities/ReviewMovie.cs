using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ReviewMovie
    {
        public int Id { get; set; }
        public Estrellas Valoration { get; set; }
        public required string Comment { get; set; }
        public int IdMovie {  get; set; }
        [JsonIgnore]
        public Movie Movie { get; set; }

        public ReviewMovie() { }
        

        public ReviewMovie(Estrellas valoration, string comment, int idMovie)
        {
            Valoration = valoration;
            Comment = comment;
            IdMovie = idMovie;
        }
    }
}
