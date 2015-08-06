using NoteeFY.Buisness.Menagers;
using NoteeFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NoteeFY.Controllers
{
    public class NotesController : ApiController
    {
        private NoteManager nt = new NoteManager();

        public IQueryable<Note> GetNotes()
        {
            return nt.GetNotes();
        }
    }
}
