using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kombinator.Built_In;
using Kombinator.Models;

namespace Kombinator
{
    class Program
    {


        static void Main(string[] args)
        {
            var K = CombinatorK.ConstructCombinator();
            var one = new Constant("1");
            var two = new Constant("2");

            var stmt = Term.BuildWith(new Term[] { K, one, two }).Dump();
            var stmt2 = Term.EvaluateWith(new Term[] { K, one, two }).Dump();
            Console.ReadKey();
        }

        private void Demonstration()
        {
            var variable = new Variable("x");
            var variable2 = new Variable("y");
            var term = new Term(variable, variable2);

            
        }
    }
}
