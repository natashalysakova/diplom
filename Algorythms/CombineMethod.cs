using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Algorythms
{
    public class CombineMethod : BaseAlgorythm
    {

        private const int M = -1;

        public override string Name
        {
            get
            {
                return "Комбінований алгоритм";
            }
        }

        public CombineMethod(List<List<int>> data) : base(data)
        {

        }

        public CombineMethod() : base()
        {
        }

        public override string Calculate()
        {
            return string.Empty;
        }


        public override string GetDescription()
        {
            return "/description/combine.mht";
        }

        public override string GetSourceCode()
        {
            return "/description/combinesource.mht";
        }
    }
}
