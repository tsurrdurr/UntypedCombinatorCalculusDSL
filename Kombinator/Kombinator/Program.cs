using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kombinator.Models;

namespace Kombinator
{
    class Program
    {


        static void Main(string[] args)
        {
            var K = new Applica("K", null);
            K.Action = Built_In.CombinatorK.Action;
            var one = new Constant("1");
            var two = new Constant("2");

            var stmt = Term.BuildWith(new Term[] { K, one, two }).Dump();
            var stmt2 = Term.EvaluateWith(new Term[] { K, one, two }).Dump();
            Console.ReadKey();
        }

        private void Demonstration()
        {
            var variable = new Variable("x");
            
        }
    }
}
