using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Models
{
    public class StartsimDTO
    {
        public int VitalsId { get; set; }
        public int DebriefId { get; set; }
        public StartsimDTO(int vitalsId, int debriefId)
        {
            VitalsId = vitalsId;
            DebriefId = debriefId;
        }
    }
}
