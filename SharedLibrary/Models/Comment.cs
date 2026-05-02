using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.Models
{
    public class Comment
    {
        [Key]
        public int Id {  get; set; }

        public string Text { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Timestamp { get; set; }

        public Comment() { }

        public Comment(string text,  DateTime timestamp)
        {
            Text = text;
            Timestamp = timestamp;
        }
    }
}
