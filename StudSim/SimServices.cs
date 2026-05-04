using System;
using System.Collections.Generic;
using System.Text;
using SharedLibrary.Models;

namespace StudSim
{
    public class SimServices
    {
        public static List<Goal> CheckGoals(List<Goal> Goals, Vitals Vitals)
        {
           

            foreach (Goal goal in Goals)
            {
                if (goal.Name.Equals("Stabalize underpressure"))
                {
                    goal.Validate(Vitals.UnderPressure);
                } else if(goal.Name.Equals("Stabalize overpressure"))
                {
                    goal.Validate(Vitals.OverPressure);
                } else if(goal.Name.Equals("Stabalize temperature"))
                {
                    goal.Validate(Vitals.Temperature);
                }
            }
            for (int i = Goals.Count-1; i >= 0; i--)
            {
                if (Goals[i].Completed)
                {
                    Goals.RemoveAt(i);
                }
            }
            return Goals;
        }
        public static bool CheckVitals(Vitals _vitals)
        {
            return true;
        }
        private static bool CheckRange(double upper, double under, double val)
        {
            return (upper > val && under < val);
        }

        public static void GiveBlanket(Vitals Vitals)
        {
            Vitals.Temperature = 37;
        }
        public static void CoolDown(Vitals Vitals)
        {
            Vitals.Temperature = 37;
        }
        public static void GiveMedication(Vitals Vitals)
        {
            Vitals.OverPressure = 120;
            Vitals.UnderPressure = 60;
        }
        public static void GiveIV(Vitals Vitals)
        {
            Vitals.OverPressure = 120;
            Vitals.UnderPressure = 60;
        }

    }
}
