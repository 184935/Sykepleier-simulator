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

        public int CaseId { get; set; }
        public virtual Case ConnectedCase { get; set; }

        public Debrief() {}
        public Debrief(DateTime timestamp, int caseid)
        {
            Timestamp = timestamp;
            Events = new List<Event>();
            Comments = new List<Comment>();
            CaseId = caseid;
        }
    }
}
