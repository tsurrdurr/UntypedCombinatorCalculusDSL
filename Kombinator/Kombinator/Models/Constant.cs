using Kombinator.Traceability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kombinator.Models
{
    public class Constant : Term
    {

        public Constant(object value) : base(value)
        {
            MyLogger.Log("Constant public invoked");
        }

    }
}
