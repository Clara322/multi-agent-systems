using System;
using System.Collections.Generic;
using System.Text;

namespace world_architecture
{
    class Duma
    {
        DumaState state = DumaState.Closed;
        void InSession(IActions[] agents)
        {
            Queue<object> eventQueue = new Queue<object>();
            while (true)
            {
                foreach (IActions agent in agents)
                {
                    eventQueue.Enqueue(agent.Propose());
                }
                if (eventQueue.Count != 0)
                {
                    break;
                }
            }
        }
    }

    enum DumaState
    {
        Closed,
        Open,
        Proposing,
        Voting
    }
}
