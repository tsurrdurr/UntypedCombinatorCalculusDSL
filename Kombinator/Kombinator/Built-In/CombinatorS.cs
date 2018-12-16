using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using Kombinator.Models;

namespace Kombinator.Built_In
{
    public class CombinatorS : ICombinator
    {
        public static Term ConstructCombinator()
        {
            var sCombinator = new Applica("S", null)
            {
                Action = Action,
                ArgumentsNumber = ArgumentsNumber
            };
            return sCombinator;
        }

        public static ReductionResult Action(Term term, Stack<Term> args)
        {
            TypeAdapterConfig<Term, Term>.NewConfig().MapWith(src => src);
            var cTerm = args.Pop();
            cTerm.Parent = new VoidTerm();
            var bTerm = args.Pop();
            var aTerm = args.Pop();
            var cClone = cTerm.Adapt<Term, Term>();
            var term2 = new Term(bTerm, cTerm);
            bTerm.Parent = term2;
            cTerm.Parent = term2;
            var term1 = new Term(aTerm, cClone);
            aTerm.Parent = term1;
            cClone.Parent = term1;
            var superterm = new Term(term1, term2);
            return new ReductionResult(superterm, true);
        }

        public static uint ArgumentsNumber => 3;
    }
}
