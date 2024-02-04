using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldOrleansAFPE.CustomGrain
{
    public interface ICustomGrain : IGrainWithStringKey
    {
        ValueTask<string> CustomString();
    }
}
