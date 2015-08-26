using System.Web.Http;
using System.Web.Http.Results;
using NoteeFY.Buisness.DTOs;
using NoteeFY.Buisness.Helpers;
using NoteeFY.Buisness.Managers;

namespace NoteeFY.Controllers
{
    [Authorize]
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

            if (taskItemsManager.AddOrUpdateTaskItem(taskItem, User.Identity.Name))
            {
                return Json(new ModificationResult<TaskItemDTO>(true)
                {
                    Data = taskItem
                });
            }
            else
            {
                return Json(new ModificationResult<TaskItemDTO>("Error: Nie znaleziono notatki (nie można dołączyć tego zadania do notatki o id: " + taskItem.NoteID + ")"));
            }
        }

        // DELETE: api/TaskItems/3 - DELETE
        public JsonResult<ModificationResult<TaskItemDTO>> DeleteTaskItem(int id)
        {
            if (taskItemsManager.DeleteTaskItem(id, User.Identity.Name))
            {
                return Json(new ModificationResult<TaskItemDTO>(true));
            }
            else
            {
                return Json(new ModificationResult<TaskItemDTO>("Error: Nie znaleziono zadania (Nie można znaleźć zadania o id: " + id + ")"));
            }
        }

    }
}
