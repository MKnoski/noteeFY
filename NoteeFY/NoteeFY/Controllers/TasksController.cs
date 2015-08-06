using NoteeFY.Data.Models;
using NoteeFY.Buisness.Managers;
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
        public IEnumerable<TaskItem> GetTasks()
        {
            return taskMng.GetSetOfTasks();
        }

        // GET api/Tasks/5
        public TaskItem GetTasks(int id)
        {
            return taskMng.GetSingleTask(id);
        } 

    }
}
