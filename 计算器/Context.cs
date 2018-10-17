using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 计算器
{
    //策略模式Context
    class Context
    {
        private Icalculation icalculation = null;
        public Context(Icalculation icalculation)
        {
            this.icalculation = icalculation;
        }
        public double Result()
        {
            return icalculation.Result();
        }

    }
}
