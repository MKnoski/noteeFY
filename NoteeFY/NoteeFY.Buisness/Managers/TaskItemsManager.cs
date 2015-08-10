using System.Collections.Generic;
using System.Linq;
using NoteeFY.Data.DBContext;
using NoteeFY.Buisness.DTOs;
using NoteeFY.Data.Models;

namespace NoteeFY.Buisness.Managers
{
    public class TaskItemsManager
    {

        public void AddOrUpdateTaskItems(int noteId, IEnumerable<TaskItemDTO> tasks)
        {
            using (NoteeContext db = new NoteeContext())
            {

                foreach (var taskItem in tasks)
                {
                        TaskItem model;
                        if (taskItem.TaskItemID > 0)
                        {
                            model = db.TaskItems.Single(ti => ti.TaskItemID == taskItem.TaskItemID);
                        }
                        else
                        {
                            model = db.TaskItems.Create();
                            model.Note = db.Notes.Single(n => n.NoteID == noteId);
                            db.TaskItems.Add(model);
                        }

                        model.Text = taskItem.Text;
                        model.IsDone = taskItem.IsDone;
                }

                db.SaveChanges();
            }
        }

        public bool AddOrUpdateTaskItem(TaskItemDTO taskItem)
        {
            using (NoteeContext db = new NoteeContext())
            {
                if(db.Notes.Any(n => n.NoteID == taskItem.NoteID))
                {
                    TaskItem model;
                    if (taskItem.TaskItemID > 0) model = db.TaskItems.Single(ti => ti.TaskItemID == taskItem.TaskItemID);
                    else
                    {
                        model = db.TaskItems.Create();
                        model.Note = db.Notes.Single(n => n.NoteID == taskItem.NoteID);
                        db.TaskItems.Add(model);
                    }

                    model.Text = taskItem.Text;
                    model.IsDone = taskItem.IsDone;

                    db.SaveChanges();
                    return true;
                }
                else return false;
            }
        }
    }
}
