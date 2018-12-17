using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kombinator.Models;

namespace Kombinator.Built_In
{
    public class CombinatorK
    {
        public static Term ConstructCombinator()
        {
            var kCombinator = new Applica("K");
            kCombinator.SetFunctionality(Action, ArgumentsNumber);
            return kCombinator;
        }

        public static ReductionResult Action(Term term, Stack<Term> arguments)
        {
            arguments.Pop();
            var newTerm = arguments.Pop();
            return new ReductionResult(newTerm, true);
        }

        public static uint ArgumentsNumber => 2;
    }
}
