﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kombinator.Models
{
    public class Applica : Term
    {
        public Func<Applica, Term> Action = DefaultNoAction;
        private static Term DefaultNoAction(Term input) => input;

        public Term NextArgument => this.Right;

        public Applica(string funcName, Term argument) : base(funcName)
        {
            this.Right = argument;
        }

        public override Term Reduce() => Action(this);
    }

}