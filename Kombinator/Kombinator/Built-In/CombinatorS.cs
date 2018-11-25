using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Kombinator.Models;

namespace Kombinator.Built_In
{
    public class CombinatorS
    {
        public static Term ConstructCombinator()
        {
            var sCombinator = new Applica("S", null)
            {
                Action = Action
            };
            return sCombinator;
        }

        public static ReductionResult Action(Term term)
        {
            if (term.HasRedex && term.Right.HasRedex && term.Right.Right.HasRedex)
            {
                var newTerm1 = term.Right;
                var newTerm2 = term.Right?.Right;
                newTerm1.Right = term.Right?.Right?.Right;
                newTerm1.Right.Right = newTerm2;
                 
                Mapper.Instance.Map(newTerm1.Right, newTerm2.Right);
                return new ReductionResult(newTerm1, true);
            }
            else return new ReductionResult(term);
        }
    }
}
