using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldOrleansAFPE.HelloGrain
{
    public sealed class HelloGrain : Grain, IHelloGrain
    {
        public ValueTask<string> SayHello(string greeting) =>
            ValueTask.FromResult($"Hola, {greeting}!");
    }
}
