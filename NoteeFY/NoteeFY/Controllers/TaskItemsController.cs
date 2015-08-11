using NoteeFY.Buisness.Managers;
using System.Web.Http;
using NoteeFY.Buisness.DTOs;
using System.Web.Http.Description;
using NoteeFY.Data.Models;

namespace NoteeFY.Controllers
{
    public class TaskItemsController : ApiController
    {
        private TaskItemsManager taskItemsManager = new TaskItemsManager();

        // POST: api/TaskItems
        [ResponseType(typeof(SaveResult<string>))]
        public SaveResult<string> PostTaskItem(TaskItemDTO taskItem)
        {
            if (!ModelState.IsValid)
            {
                return new SaveResult<string>("error: bad request", false);
            }

            if (taskItemsManager.AddOrUpdateTaskItem(taskItem))
            {
                return new SaveResult<string>("success: task created/updated", true);
            }
            else
            {
                return new SaveResult<string>("error: note not found (can not join this taskItem to the note with id: " + taskItem.NoteID + ")", false);
            }
        }

    }
}
