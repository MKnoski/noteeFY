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
    public class TasksControllers : ApiController
    {
        private TaskManagers taskItemsManager = new TaskManagers();

        // GET: api/Tasks
        public IEnumerable<TaskItem> GetTasks()
        {
            return taskItemsManager.GetSetOfTasks();
        }

        // GET api/Tasks/5
        public TaskItem GetTask(int id)
        {
            return taskItemsManager.GetSingleTask(id);
        } 

    }
}
