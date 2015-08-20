using System.Web.Http.Results;
using NoteeFY.Buisness.DTOs;
using NoteeFY.Buisness.Helpers;
using NoteeFY.Buisness.Managers;

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
