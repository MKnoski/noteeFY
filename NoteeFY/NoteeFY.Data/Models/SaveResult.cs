using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteeFY.Data.Models
{
    public class SaveResult<Object>
    {
        public bool Success { get; set; }
        public Object Data { get; set; }

        public SaveResult(Object data, bool success)
        {
            Success = success;
            Data = data;
        }
    }
}
