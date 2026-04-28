using System.ComponentModel.DataAnnotations;

namespace CaseSetup.Models
{
    public class Comment
    {
        private int Id {  get; set; }

        private string Text { get; set; }

        [DataType(DataType.DateTime)]
        private DateTime Timestamp { get; set; }

        public Comment(string text,  DateTime timestamp)
        {
            Text = text;
            Timestamp = timestamp;
        }
    }
}
