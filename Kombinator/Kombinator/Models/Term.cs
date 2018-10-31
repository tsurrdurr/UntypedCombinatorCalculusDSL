using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kombinator.Traceability;

namespace Kombinator.Models
{
    public class Term
    {
        protected Term Left
        {
            get => _left ?? (_left = new Term());
            set
            {
                _left = value;
            }
        }

        protected Term Right
        {
            get => _right;
            set
            {
                _right = value;
            }
        }

        private Term _left;
        private Term _right;
        protected string stringRepresentation = "";

        protected object containedObject;

        public Term(Term leftTerm, Term rightTerm)
        {
            this.Left = leftTerm;
            this.Right = rightTerm;
            this.stringRepresentation = leftTerm.ToString();
            MyLogger.Log("Term 2 args invoked");
        }

        public Term(Term onlyTerm)
        {
            this.Left = onlyTerm;
            this.Right = null;
            MyLogger.Log("Term 1 arg invoked");
        }

        public Term NextArgument => this._right;

        private Term()
        {
            this.Left = this.Right = null;
            MyLogger.Log("Term private constructor invoked");
        }

        public static Term EvaluateWith(Term[] args)
        {
            var term = BuildWith(args);
            var pointer = term;
            while (pointer.Right != null)
            {
                pointer = pointer.Reduce();
            }
            MyLogger.Log(pointer.Stringify());
            return term;
        }

        public override string ToString()
        {
            return stringRepresentation;
        }

        public string Stringify()
        {
            string result = "";
            int smileys = 0;
            var hero = this;

            while (true)
            {
                result += "(" + hero.stringRepresentation + ",";
                smileys++;

                if (!hero.HasRedex) break;
                hero = hero.Right;
            }
            while (smileys != 0)
            {
                result += ")";
                smileys--;
            }
            return result;
        }

        public Term Dump()
        {
            MyLogger.Log(Stringify());
            return this;
        }

        public static Term BuildWith(Term[] args)
        {
            if (args.Length == 0) return null;
            var rootEntity = args.First();
            for (int i = 0; i < args.Length; i++)
            {
                var next = (i + 1 < args.Length) ? args[i + 1] : null;
                args[i].Right = next;
            }
            return rootEntity;
        }

        protected Term(string name)
        {
            stringRepresentation = name;
        }

        protected Term(object value)
        {
            stringRepresentation = value.ToString();
            containedObject = value;
        }

        public bool HasRedex => _right != null;

        public virtual Term Reduce() => this;

    }

}
