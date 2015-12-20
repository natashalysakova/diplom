using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorythms
{
    public abstract class BaseAlgorythm : IAlgorythm
    {
        public BaseAlgorythm(List<List<int>> data)
        {
            if (data == null)
                throw new NullReferenceException();

            foreach (var item in data)
            {
                if (item == null)
                    throw new NullReferenceException();
            }

            Data = data;
        }

        public BaseAlgorythm()
        {

        }

        public List<List<int>> Data
        {
            get;
            set;
        }

        abstract public string Name
        {
            get;
        }

        virtual public string Calculate()
        {
            if (Data == null)
                throw new NullReferenceException();

            foreach (var item in Data)
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
