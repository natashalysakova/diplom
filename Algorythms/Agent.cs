using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorythms
{
    public static class Agent
    {
        public static IAlgorythm Analyse(List<List<int>> data)
        {
            if (data.Count < 10)
                return new DynamicalProgramming(data);

            if (data.Count >= 10 && data.Count < 100)
                return new BranchAndBound(data);

            return new CombineMethod(data);
        }

    }
}
