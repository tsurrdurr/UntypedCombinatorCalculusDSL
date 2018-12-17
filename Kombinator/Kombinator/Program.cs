using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kombinator.Built_In;
using Kombinator.Models;
using Kombinator.Traceability;

namespace Kombinator
{
    class Program
    {


        static void Main(string[] args)
        {
            MyLogger.Enabled = false;
            var K = CombinatorK.ConstructCombinator();
            var one = new Constant("1");
            var two = new Constant("2");
            Console.WriteLine($"{K},{one},{two}");
            var stmt = Term.BuildWith(new Term[] { K, one, two }).Dump();
            var stmt2 = Term.EvaluateWith(new Term[] { K, one, two }).Dump();
            var stmt3 = stmt.Reduce().Dump();
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
