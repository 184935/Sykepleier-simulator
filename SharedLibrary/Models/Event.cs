using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.Models
{
    public class Event
    {
        public int Id {  get; set; }
        public string Action { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Timestamp { get; set; }

        public Event() { }
        public Event(string action, DateTime timestamp)
        {
            Action = action;
            Timestamp = timestamp;
        }

    }
}
