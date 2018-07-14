using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public string Text { get; set; }
    }
}
