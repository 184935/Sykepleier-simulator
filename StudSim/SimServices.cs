using System;
using System.Collections.Generic;
using System.Text;
using SharedLibrary.Models;

namespace StudSim
{
    public class SimServices
    {
        public static void CheckGoals(Case Case)
        {
            List<Goal> Goals = Case.Goals;
            Goals[0].Validate(Case.Vitals.UnderPressure);
            Goals[1].Validate(Case.Vitals.OverPressure);
            Goals[2].Validate(Case.Vitals.Temperature);
            foreach (Goal goal in Goals)
            {
                if (goal.Completed)
                {
                    Goals.Remove(goal);
                }
            }
            Case.Goals = Goals;
        }

    }
}
