using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryOrderCore.Data.Entities
{
    public class Book
    {
        /// <summary>
        /// Id of the Book
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Title of the Book
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Author of the Book
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Editor of the Book
        /// </summary>
        public string Editor { get; set; }

        /// <summary>
        /// ISBN of the book
        /// </summary>
        public string ISBN { get; set; }
    }
}
