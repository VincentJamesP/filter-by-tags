using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterByTags.Models
{
    public class Book
    {
        public string Identifier { get; set; }
        public string Title { get; set; }
        public List<string> Tags { get; set; }
    }

}
