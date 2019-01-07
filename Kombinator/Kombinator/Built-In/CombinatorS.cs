using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kombinator.Logic;
using Kombinator.Models;

namespace Kombinator.Built_In
{
    public class CombinatorS
    {
        public static Applica ConstructCombinator()
        {
            var sCombinator = new Applica("S");
            sCombinator.SetFunctionality(Action, ArgumentsNumber);
            return sCombinator;
        }

        public static ReductionResult Action(Term term, Stack<Term> args)
        {
            var cPopped = args.Pop();
            var cTerm = cPopped.Clone();
            cTerm.Parent = new VoidTerm();
            var bTerm = args.Pop().Clone();
            bTerm.Parent = new VoidTerm();
            var aTerm = args.Pop().Clone();


            var cClone = cTerm.Clone();
            var tupledTermBC = new Term(bTerm, cTerm);
            var tupleTermAC = new Term(aTerm, cClone);
            var resultingTerm = new Term(tupleTermAC, tupledTermBC);

            return new ReductionResult(resultingTerm, true);
        }

        public static uint ArgumentsNumber => 3;
    }
}
