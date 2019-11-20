using System;
using System.Collections.Generic;
using System.Text;

namespace world_architecture
{
    public interface IActions
    {
        void Consume(double resource);
        AgentSkill ChooseActivity(Dictionary<Agent, AgentSkill> history);
        int Vote(int[] choices);
        void ExecuteActivity(AgentSkill skill, List<Agent> team);
        object Propose();
    }


    public enum AgentSkill
    {
        Hunting,
        Construction,
        Idle
    }


    abstract public class Agent
    {
        public Dictionary<AgentSkill, int> skills;
        public double energy;
        private int[] properties;
    }
}
