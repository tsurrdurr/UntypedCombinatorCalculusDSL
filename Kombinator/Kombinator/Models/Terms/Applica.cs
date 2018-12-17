using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kombinator.Models
{
    public class Applica : Term
    {
        private Func<Applica, Stack<Term>, ReductionResult> Action = DefaultNoAction;
        private static ReductionResult DefaultNoAction(Applica app, Stack<Term> args = null) => new ReductionResult(app, false);

        public Applica(string funcName) : base(funcName) { }

        public void SetFunctionality(Func<Applica, Stack<Term>, ReductionResult> action, uint argumentsNumber)
        {
            Action = action;
            ArgumentsNumber = argumentsNumber;
        }

        public ReductionResult ReduceApplica(Stack<Term> args) => Action(this, args);

        public uint ArgumentsNumber { get; protected set; }
    }

}
