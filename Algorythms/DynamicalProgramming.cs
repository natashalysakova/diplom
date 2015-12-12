using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Algorythms
{
    public class DynamicalProgramming : BaseAlgorythm
    {

        private const int M = -1;

        public override string Name
        {
            get
            {
                return "Метод динамічного програмування";
            }
        }

        public override string Calculate(List<List<int>> data)
        {
            base.Calculate(data);

            return string.Empty;
        }

        public override string GetDescription()
        {
            return "/description/dynamical.mht";
        }

        public override string GetSourceCode()
        {
            return "/description/dynamicalsource.mht";
        }
    }
}
