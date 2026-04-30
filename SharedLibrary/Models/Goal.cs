using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedLibrary.Models
{
    public class Goal
    {
        [Key]
        public int Id {  get; set; }
        public string Name { get; set; }
        public double Upper {  get; set; }
        public double Lower { get; set; }
        public bool Completed { get; set; }
        public long Time { get; set; }

        public Goal() { }
        public Goal(string name, double upper, double lower, long time)
        {
            Name = name;
            Upper = upper;
            Lower = lower;
            Completed = false;
            Time = time;
        }

        public bool Validate(double value)
        {
            if (value > Lower && value < Upper)
            {
                Completed = true;
                return true;
            } else
            {
                return false;
            }
        }


    }
}
