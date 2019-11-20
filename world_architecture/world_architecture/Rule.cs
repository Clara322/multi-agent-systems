using System;
using System.Collections.Generic;
using System.Text;

namespace world_architecture
{
    class Rule
    {
        private Func<object, bool> func;

        Rule(Func<object, bool> func)
        {
            this.func = func;
        }

        public bool permit(object predicate)
        {
            bool outcome = func(predicate);
            return outcome;
        }
    }

    class Policy
    {
        private Func<object, List<object>> func;
        Policy(Func<object, List<object>> func)
        {
            this.func = func;
        }

        public List<object> allocate(object predicate)
        {
            List<object> result = func(predicate);
            return result;
        }
        
    }
}
