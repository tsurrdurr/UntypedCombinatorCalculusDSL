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
            var kCombinator = new Applica("K", null)
            {
                Action = Action
            };
            return kCombinator;
        }

        public static ReductionResult Action(Term term)
        {
            if (term.HasRedex && term.Right.HasRedex)
            {
                var newTerm = term.Right;
                newTerm.Right = term.Right?.Right?.Right ?? new VoidTerm();
                return new ReductionResult(newTerm, true);
            }
            else return new ReductionResult(term);
        }
    }
}
