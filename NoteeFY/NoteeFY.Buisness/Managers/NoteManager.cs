using NoteeFY.Buisness.DTOs;
using NoteeFY.Data.DBContext;
using NoteeFY.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace NoteeFY.Buisness.Managers
{
    public class NoteManager
    { 
        public List<NoteDTO> GetNotes()
        {
            using(NoteeContext db = new NoteeContext())
            {
                return GetNotesDTO(db.Notes.ToList());
            }
        }

        public Note GetNote(int id)
        {
            using (NoteeContext db = new NoteeContext())
            {
                return db.Notes.Find(id);
            }
        }

        private List<TaskItemDTO> GetTaskItemsDTO(ICollection<TaskItem> list)
        {
            List<TaskItemDTO> TaskItemsDTO = new List<TaskItemDTO>();
            foreach (TaskItem t in list)
            {
                TaskItemsDTO.Add(new TaskItemDTO(t));
            }
            return TaskItemsDTO;
        }

        private List<NoteDTO> GetNotesDTO(List<Note> notes)
        {
            List<NoteDTO> notesDTO = new List<NoteDTO>();
            foreach (Note note in notes)
            {
                NoteDTO noteDTO = new NoteDTO
                {
                    NoteID = note.NoteID,
                    Title = note.Title,
                    Text = note.Text,
                    Type = note.Type,
                    TaskItemsDTO = null
                };
                noteDTO.TaskItemsDTO = GetTaskItemsDTO(note.TaskItems);
                notesDTO.Add(noteDTO);
            }
            return notesDTO;
        }
    }
}