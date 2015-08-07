using NoteeFY.Buisness.DTOs;
using NoteeFY.Data.DBContext;
using NoteeFY.Data.Models;
using System.Collections.Generic;
using System.Linq;

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

        public NoteDTO GetNote(int id)
        {
            using (NoteeContext db = new NoteeContext())
            {
                return GetNoteDTO(db.Notes.Find(id));
            }
        }

        private static List<TaskItemDTO> GetTaskItemsDTO(ICollection<TaskItem> list)
        {
            List<TaskItemDTO> TaskItemsDTO = new List<TaskItemDTO>();
            foreach (TaskItem t in list)
            {
                TaskItemsDTO.Add(new TaskItemDTO(t));
            }
            return TaskItemsDTO;
        }

        public static List<NoteDTO> GetNotesDTO(List<Note> notes)
        {
            List<NoteDTO> notesDTO = new List<NoteDTO>();
            foreach (Note note in notes)
            {
                notesDTO.Add(GetNoteDTO(note));
            }
            return notesDTO;
        }

        private NoteDTO GetNoteDTO(Note note)
        {
            if (note != null)
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
                return noteDTO;
            }
            else return null;
        }
    }
}