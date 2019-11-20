using System;
using System.Collections.Generic;
using System.Text;

namespace world_architecture
{
    class World
    {

        Dictionary<Policy, bool> mutableRules;
        static readonly Rule[] systemRules;
        int dayCount = 0;
        Agent[] agents;
        static readonly Duma duma;
        public int[] environments;


        void Run(int maxDays)
        {
            while (Step() && dayCount <= maxDays) ;

        }


        bool Step()
        {
            dayCount += 1;
            return true;
        }

        void Hunt()
        {

        }

        void BuildShelter()
        {

        }

        void DumaSession()
        {

        }

    }
}
