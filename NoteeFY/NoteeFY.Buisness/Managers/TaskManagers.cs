using System;
using System.Collections.Generic;
using System.Linq;
using NoteeFY.Data.DBContext;
using NoteeFY.Data.Models;
using NoteeFY.Buisness.DTOs;

namespace NoteeFY.Buisness.Managers
{
    public class TaskManagers
    {
        public List<TaskItemDTO> GetSetOfTasks()
        {
            using ( NoteeContext db = new NoteeContext())
            {
                 return GetTaskItemsDTO(db.TaskItems.ToList());
            }
        }

        public TaskItemDTO GetSingleTask(int id) 
        {
            using (NoteeContext db = new NoteeContext())
            {
                var singleTask = new TaskItemDTO(db.TaskItems.Find(id));

                if (singleTask == null)
                {
                    throw new Exception("Not found");
                }

                return singleTask;
            }
        }

        public static List<TaskItemDTO> GetTaskItemsDTO(List<TaskItem> TaskItems)
        {
            List<TaskItemDTO> tasksDTO = new List<TaskItemDTO>();
            foreach (TaskItem task in TaskItems)
            {
                tasksDTO.Add(new TaskItemDTO(task));
            }
            return tasksDTO;
        }

    }
}
