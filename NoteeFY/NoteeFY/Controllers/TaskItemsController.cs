using NoteeFY.Buisness.Managers;
using System.Web.Http;
using NoteeFY.Buisness.DTOs;
using System.Web.Http.Description;
using NoteeFY.Data.Models;
using System.Web.Http.Results;

namespace NoteeFY.Controllers
{
    public class TaskItemsController : ApiControllerBase
    {
        private TaskItemsManager taskItemsManager = new TaskItemsManager();

        
        // POST: api/TaskItems
        public JsonResult<ModificationResult<TaskItemDTO>> PostTaskItem(TaskItemDTO taskItem)
        {
            var result = ValidateModelState<TaskItemDTO>();
            if (result != null)
            {
                return result;
            }

            if (taskItemsManager.AddOrUpdateTaskItem(taskItem))
            {
                return Json(new ModificationResult<TaskItemDTO>(true)
                {
                    Data = taskItem
                });
            }
            else
            {
                return Json(new ModificationResult<TaskItemDTO>("error: nie znaleziono notatki (nie mozna dolaczyc tego zadania do notatki o id: " + taskItem.NoteID + ")"));
            }
        }

        // DELETE: api/TaskItems/3 - DELETE
        public JsonResult<ModificationResult<TaskItemDTO>> DeleteTaskItem(int id)
        {
            if (taskItemsManager.DeleteTaskItem(id))
            {
                return Json(new ModificationResult<TaskItemDTO>(true));
            }
            else
            {
                return Json(new ModificationResult<TaskItemDTO>("error: nie znaleziono zadania (nie mozna znalezc zadania o id: " + id + ")"));
            }
        }

    }
}
