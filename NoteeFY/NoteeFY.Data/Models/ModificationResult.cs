using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteeFY.Data.Models
{
    public class ModificationResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ModificationResult(bool success)
        {
            Success = success;
        }

        public ModificationResult(string message)
        {
            Message = message;
            Success = string.IsNullOrWhiteSpace(message);
        }
    }
}
