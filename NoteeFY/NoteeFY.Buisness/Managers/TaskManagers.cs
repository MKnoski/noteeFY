using System.Collections.Generic;
using System.Linq;
using NoteeFY.Data.DBContext;
using NoteeFY.Buisness.DTOs;

namespace NoteeFY.Buisness.Managers
{
    public class TaskManagers
    {
        public List<TaskItemDTO> GetSetOfTasks()
        {
            using ( NoteeContext db = new NoteeContext())
            {
                 return db.TaskItems.ToList().Select(t => new TaskItemDTO(t)).ToList();
            }
        }

        public TaskItemDTO GetSingleTask(int id)
        {
            using (NoteeContext db = new NoteeContext())
            {
                var singleTask = db.TaskItems.Find(id);
                if (singleTask == null) return null;
                return new TaskItemDTO(singleTask);
            }
        }

    }
}
