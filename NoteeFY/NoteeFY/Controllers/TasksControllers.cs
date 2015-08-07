using NoteeFY.Data.Models;
using NoteeFY.Buisness.Managers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
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
            try
            {
                return taskItemsManager.GetSingleTask(id);
            }
            catch (ObjectNotFoundException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
        } 

    }
}
