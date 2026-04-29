using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Models
{
    internal class Goal
    {
        private int ID {  get; set; }
        private string Name { get; set; }
        private double Upper {  get; set; }
        private double Lower { get; set; }
        private bool Completed { get; set; }
        private long Time { get; set; }

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
