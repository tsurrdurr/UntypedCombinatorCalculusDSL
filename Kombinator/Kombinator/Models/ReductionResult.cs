using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kombinator.Models
{
    public class ReductionResult
    {
        public ReductionResult(Term term, bool success = false)
        {
            ResultTerm = term;
            this.Success = success;
        }

        public Term ResultTerm { get; set; }
        public bool Success { get; set; }
    }
}
