using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class NoteRepository
    {
        static Dictionary<Guid, Note> notes = new Dictionary<Guid, Note>();

        public static Dictionary<Guid, Note> Notes { get => notes; set => notes = value; }

        public NoteRepository()
        {

        }

        public Note GetNoteById (Guid id)
        {
            var result = Notes[id];

            return result;
        }
    }
}