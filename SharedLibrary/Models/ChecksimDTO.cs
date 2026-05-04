using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Models
{
    public class ChecksimDTO
    {
        public Vitals _vitals {  get; set; }
        public Case MedCase {  get; set; }
        public int DebriefId { get; set; }
        public ChecksimDTO(Vitals vitals, Case _case, int debriefId)
        {
            _vitals = vitals;
            MedCase = _case;
            DebriefId = debriefId;
        }
    }
}
