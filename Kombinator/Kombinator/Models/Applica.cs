using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kombinator.Models
{
    public class Applica : Term
    {
        public Func<Applica, ReductionResult> Action = DefaultNoAction;
        private static ReductionResult DefaultNoAction(Applica app) => new ReductionResult(app, false);

        public Applica(string funcName, Term argument) : base(funcName)
        {
            Right = argument ?? Right;
        }

        public override ReductionResult TryReduce() => Action(this);
    }

}
