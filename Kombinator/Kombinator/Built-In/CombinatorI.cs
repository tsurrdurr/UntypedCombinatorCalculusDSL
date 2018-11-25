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
            var kCombinator = new Applica("I", null)
            {
                Action = Action
            };
            return kCombinator;
        }

        public static ReductionResult Action(Term term)
        {
            if (term.HasRedex)
            {
                var newTerm = term.Right;
                return new ReductionResult(newTerm, true);
            }
            else return new ReductionResult(term);
        }
    }
}
