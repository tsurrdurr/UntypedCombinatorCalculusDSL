using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kombinator.Models
{
    public class Applica : Term
    {
        public Func<Applica, Stack<Term>, ReductionResult> Action = DefaultNoAction;
        private static ReductionResult DefaultNoAction(Applica app, Stack<Term> args = null) => new ReductionResult(app, false);

        public Applica(string funcName, Term argument) : base(funcName)
        {
            Right = argument ?? Right;
        }

        public ReductionResult ReduceApplica(Stack<Term> args) => Action(this, args);

        public uint ArgumentsNumber { get; set; }
    }

}
