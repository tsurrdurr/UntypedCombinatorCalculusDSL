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

        public static Term Action(Applica term)
        {
            if (term.HasRedex && term.NextArgument.HasRedex)
            {
                var leftTerm = term.NextArgument;
                var rightTerm = term.NextArgument?.NextArgument?.NextArgument;
                return new Term(leftTerm, rightTerm);
            }
            else return term;
        }
    }
}
