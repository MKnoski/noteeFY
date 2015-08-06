using NoteeFY.Models;
using NoteeFY.Buisness.Menagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NoteeFY.Controllers
{
    public class TasksController : ApiController
    {
        private TaskManager taskMng = new TaskManager();

        // GET: api/Tasks
        public IEnumerable<Task> GetTasks()
        {
            return taskMng.GetSetOfTasks();
        }

        // GET api/Attractions/5
        public Task GetTasks(int id)
        {
            return taskMng.GetSingleTask(id);
        } 

    }
}
