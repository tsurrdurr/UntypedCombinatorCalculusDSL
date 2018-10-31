using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kombinator.Models;

namespace Kombinator.Built_In
{
    class CombinatorK
    {
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
