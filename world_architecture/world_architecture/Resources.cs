using System;
using System.Collections.Generic;
using System.Text;

namespace world_architecture
{
    class Animals
    {
        public int reward { get; set; }
        public int energy;
        // List of agents
        public int difficulty { get; set; }
        // Bonus?
        // Location (or state in general) ?
        // Speed etc
        // Animal actions (e.g. escape or fight? effect on agent health? regeneration? level?)


        // Two animals and one level as the baseline
        // Always in pair
        // Society energy is the sum of individuals


        // Racism simulator 


        // Confidence level that adjust willingness to cooperate
    }

    public class Shelter
    {
        public int level;
        public int completion;
        public int levelDifficulty;
        public int buff;    // Increase with each level but never fully compensate for debuff
                            // Deterioration of the shelter?


        // Assignment of shelter
        // Random events
        // Degrading shelter

        // Space allocation 






    }
}
