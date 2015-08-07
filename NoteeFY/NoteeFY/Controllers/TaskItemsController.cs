using NoteeFY.Buisness.Managers;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NoteeFY.Buisness.DTOs;
using System.Web.Http.Description;

namespace NoteeFY.Controllers
{
    public class TaskItemsController : ApiController
    {
        private TaskManagers taskItemsManager = new TaskManagers();

        // GET: api/TaskItems
        public List<TaskItemDTO> GetTaskItems()
        {
            return taskItemsManager.GetSetOfTasks();
        }

        // GET: api/TaskItems/5 - READ Single
        [ResponseType(typeof(NoteDTO))]
        public IHttpActionResult GetTaskItem(int id)
        {
            TaskItemDTO task = taskItemsManager.GetSingleTask(id);
            if (task == null) return NotFound();
            else return Ok(task);
        } 

    }
}
