using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kombinator.Traceability;

namespace Kombinator.Models
{
    public class Variable : Term
    {
        public Variable(string name) : base(name)
        {
            MyLogger.Log("Variable public invoked");
        }

    }
}
