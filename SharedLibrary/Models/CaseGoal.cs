using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Models
{
    public class CaseGoal
    {
        public int CaseId { get; set; }
        public int GoalId { get; set; }
        public bool Completed { get; set; }
        
        public Case Case { get; set; }
        public Goal Goal {  get; set; }
    }
}
