using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Note(string title, string desc)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = desc;
        }
    }
}