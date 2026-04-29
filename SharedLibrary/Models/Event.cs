using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.Models
{
    public class Event
    {
        private int Id {  get; set; }
        private string Action { get; set; }
        [DataType(DataType.DateTime)]
        private DateTime Timestamp { get; set; }

        public Event(string action, DateTime timestamp)
        {
            Action = action;
            Timestamp = timestamp;
        }

    }
}
