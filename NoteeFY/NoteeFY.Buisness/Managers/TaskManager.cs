using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using NoteeFY.Data.DBContext;
using NoteeFY.Models;

namespace NoteeFY.Buisness.Menagers
{
    public class TaskManager
    {
        public IEnumerable<Task> GetSetOfTasks()
        {
            using ( NoteeContext db = new NoteeContext())
            {
                 return db.Tasks.AsEnumerable();
            }
        }

        public Task GetSingleTask(int id)
        {
            using (NoteeContext db = new NoteeContext())
            {
                var singleTask = db.Tasks.Find(id);

                if (singleTask == null)
                {
                    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
                }

                return singleTask;
            }
        } 

    }
}
