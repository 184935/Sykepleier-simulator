using CaseSetup.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedLibrary.Models
{
    public class Debrief
    {
        public int Id {  get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Timestamp { get; set; }
        public List<Event> Events { get; set; }
        public List<Comment> Comments { get; set; }

        public Debrief(DateTime timestamp, List<Event> events, List<Comment> comments)
        {
            Timestamp = timestamp;
            Events = events;
            Comments = comments;
        }
    }
}
