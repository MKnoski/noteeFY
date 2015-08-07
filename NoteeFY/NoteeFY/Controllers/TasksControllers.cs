using NoteeFY.Data.Models;
using NoteeFY.Buisness.Managers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NoteeFY.Buisness.DTOs;

namespace NoteeFY.Controllers
{
    public class TasksControllers : ApiController
    {
        private TaskManagers taskItemsManager = new TaskManagers();

        // GET: api/TaskItems
        public List<TaskItemDTO> GetTaskItems()
        {
            return taskItemsManager.GetSetOfTasks();
        }

        // GET api/TaskItems/5
        public TaskItemDTO GetTaskItem(int id)
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
