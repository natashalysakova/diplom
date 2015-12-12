using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorythms
{
    public abstract class BaseAlgorythm : IAlgorythm
    {
        abstract public string Name
        {
            get;
        }

        public virtual string Calculate(List<List<int>> data)
        {
            if (data == null)
                throw new NullReferenceException();

            foreach (var item in data)
            {
                if (item == null)
                    throw new NullReferenceException();
            }

            return string.Empty;
        }

        abstract public string GetDescription();

        abstract public string GetSourceCode();
    }
}
