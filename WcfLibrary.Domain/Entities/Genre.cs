using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfLibrary.Domain.Entities
{
    public class Genre
    {
        public int id { get; set; }
        public string genre_name { get; set; }
        public List<Book> Books { get; set; }
    }
}
