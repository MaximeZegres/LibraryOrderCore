using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryOrderCore.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        public string Editor { get; set; }

        [Required]
        public string ISBN { get; set; }
    }
}
