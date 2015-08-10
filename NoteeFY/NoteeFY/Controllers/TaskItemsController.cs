using NoteeFY.Buisness.Managers;
using System.Collections.Generic;
using System.Web.Http;
using NoteeFY.Buisness.DTOs;
using System.Web.Http.Description;

namespace NoteeFY.Controllers
{
    public class TaskItemsController : ApiController
    {
        private TaskItemsManager taskItemsManager = new TaskItemsManager();

        // POST: api/TaskItems
        [ResponseType(typeof(TaskItemDTO))]
        public IHttpActionResult PostTaskItem(TaskItemDTO taskItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = taskItemsManager.AddOrUpdateTaskItem(taskItem);

            if (result) return CreatedAtRoute("DefaultApi", new { id = taskItem.TaskItemID }, taskItem);
            else return NotFound();
        }

    }
}
