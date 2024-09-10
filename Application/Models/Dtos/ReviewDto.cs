using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dtos
{
    public class CreateReview
    {
        public Estrellas Valoration { get; set; }
        public required string Comment { get; set; }
    }

    public class UpdateReview
    {
        public Estrellas? Valoration { get; set; }
        public string? Comment { get; set; }
    }


}
