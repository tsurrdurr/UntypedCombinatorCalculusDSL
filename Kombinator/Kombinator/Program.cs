using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

            BuildAndPrintKxx();

            EvaluateAndPrintKxx();

            EvaluateAndPrintSKKx();

            EvaluateAndPrintSxyz();

            EvaluateAndPrintTermWithCommas();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void BuildAndPrintKxx()
        {
            var K = CombinatorK.ConstructCombinator();
            var one = new Constant("1");
            var two = new Constant("2");
            Console.WriteLine($"Building term {K} {one} {two}");
            var stmt = Term.BuildWith(new Term[] { K, one, two }).Dump();
            Whitespace();
        }

        private static void EvaluateAndPrintKxx()
        {
            var K = CombinatorK.ConstructCombinator();
            var one = new Constant("1");
            var two = new Constant("2");
            Console.WriteLine($"Evaluating term {K} {one} {two}");
            var stmt2 = Term.EvaluateWith(new Term[] { K, one, two }).Dump();
            Whitespace();
        }

        private static void EvaluateAndPrintSKKx()
        {
            var S = CombinatorS.ConstructCombinator();
            var Ka = CombinatorK.ConstructCombinator();
            var Kb = CombinatorK.ConstructCombinator();
            var x = new Constant("x");
            Console.WriteLine($"Evaluating term {S} {Ka} {Kb} {x}");
            Term.EvaluateWith(new Term[] { S, Ka, Kb, x }).Dump();
            Whitespace();
        }

        private static void EvaluateAndPrintSxyz()
        {
            var S = CombinatorS.ConstructCombinator();
            var x = new Variable("x");
            var y = new Variable("y");
            var z = new Variable("z");
            Console.WriteLine($"Evaluating term {S} {x} {y} {z}");
            Term.EvaluateWith(new Term[] { S, x, y, z }).Dump();
            Whitespace();
        }

        private static void EvaluateAndPrintTermWithCommas()
        {
            var kTerm = CombinatorK.ConstructCombinator();
            var x = new Variable("x");
            var y = new Variable("y");
            var z = new Variable("z");
            var tupleTerm = new Term(y, z);
            Console.WriteLine($"Evaluating {kTerm} ({y} {z}) {x}");
            Console.WriteLine("After evaluation:");
            Term.EvaluateWith(new Term[] { kTerm, tupleTerm, x }).Dump();
            Whitespace();
        }

        private static void test()
        {
            var kTerm = CombinatorK.ConstructCombinator();
            var kTerm1 = CombinatorK.ConstructCombinator();
            var x = new Constant("x");
            var y = new Constant("y");
            var z = new Constant("z");
            Console.WriteLine($"Evaluating {kTerm} {kTerm1} {x} {y} {z}");
            Term.EvaluateWith(new Term[] {kTerm, kTerm1, x, y, z}).Dump();
            Whitespace();
        }

        private static void Whitespace()
        {
            Console.WriteLine("\n");
        }

        private void Demonstration()
        {
            var variable = new Variable("x");
            var variable2 = new Variable("y");
            var term = new Term(variable, variable2);

            
        }
    }
}
