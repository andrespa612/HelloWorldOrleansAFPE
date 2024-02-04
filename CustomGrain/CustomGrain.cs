using HelloWorldOrleansAFPE.HelloGrain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldOrleansAFPE.CustomGrain
{
    public sealed class CustomGrain : Grain, ICustomGrain
    {
        private string mensaje = "";
        public CustomGrain() {
            Console.WriteLine("Ingrese la cadena que desea que muestre el Grain");
            var cadena = Console.ReadLine();
            mensaje = cadena;
        }
        public ValueTask<string> CustomString() =>
            ValueTask.FromResult(mensaje);
    }
}