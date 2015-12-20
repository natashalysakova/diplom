using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorythms
{
    public interface IAlgorythm
    {
        string Calculate();
        string GetDescription();
        string GetSourceCode();
        string Name { get; }
        List<List<int>> Data { get; set; }
    }
}
