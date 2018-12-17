using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kombinator.Models;

namespace Kombinator.Built_In
{
    public class CombinatorI
    {
        public static Term ConstructCombinator()
        {
            var iCombinator = new Applica("I");
            iCombinator.SetFunctionality(Action, ArgumentsNumber);
            return iCombinator;
        }

        public static ReductionResult Action(Term term, Stack<Term> arguments)
        {
            var newTerm = arguments.Pop();
            return new ReductionResult(newTerm, true);
        }

        public static uint ArgumentsNumber => 1;
    }
}
