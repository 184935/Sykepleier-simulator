using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SharedLibrary.Models
{
    public class ChecksimDTO
    {
        public Vitals Vitals {  get; set; }
        public Case? Case {  get; set; }
        public int DebriefId { get; set; }
        
    }
}
