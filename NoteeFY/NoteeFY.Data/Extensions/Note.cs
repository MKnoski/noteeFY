namespace NoteeFY.Data
{
    public enum NoteType { Text = 0, ToDoList };

    public partial class Note
    {
        public NoteType NoteType
        {
            get
            {
                return (NoteType)Type;
            }
            set
            {
                Type = (int)value;
            }
        }
    }
}