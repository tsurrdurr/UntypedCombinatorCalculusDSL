using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kombinator.Models
{
    class VoidTerm : Term
    {
        public VoidTerm() : base((string) null)
        {
            this.StringRepresentation = "|end|";
        }
    }
}
