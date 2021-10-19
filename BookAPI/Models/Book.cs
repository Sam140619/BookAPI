using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
    }
}
