using CaseSetup.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedLibrary.Models
{
    internal class Debrief
    {
        private int ID {  get; set; }
        [DataType(DataType.DateTime)]
        private DateTime Timestamp { get; set; }
        private List<Event> Events { get; set; }
        private List<Comment> Comments { get; set; }

        public Debrief(DateTime timestamp, List<Event> events, List<Comment> comments)
        {
            Timestamp = timestamp;
            Events = events;
            Comments = comments;
        }
    }
}
