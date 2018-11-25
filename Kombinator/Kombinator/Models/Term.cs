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
        public Term Left
        {
            get => _left ?? (_left = new Term());
            set
            {
                _left = value;
            }
        }

        public Term Right { get; set; }

        private Term _left;
        protected string StringRepresentation = "";
        protected string TestRepresentation => "(" + Left + "," + Right + ")";
        protected object ContainedObject;

        public Term(Term leftTerm, Term rightTerm)
        {
            this.Left = leftTerm;
            this.Right = rightTerm;
            this.StringRepresentation = "(" + leftTerm + "," + rightTerm + ")";
            MyLogger.Log("Term 2 args invoked");
        }

        protected Term(string name)
        {
            StringRepresentation = name;
            if (this is VoidTerm == false) Right = new VoidTerm();
        }

        protected Term(object value)
        {
            StringRepresentation = value.ToString();
            ContainedObject = value;
        }

        private Term()
        {
            this.Left = this.Right = null;
        }

        public static Term BuildWith(Term[] args)
        {
            var firstElement = args.FirstOrDefault();
            if (firstElement == null) return new VoidTerm();
            var rootEntity = new Term(firstElement, new VoidTerm());
            AppendRecursively(ref rootEntity, args);
            return rootEntity;
        }

        private static Term AppendRecursively(ref Term term, Term[] args)
        {
            var remainingArgs = args.Reverse().Take(args.Length - 1).Reverse().ToArray();
            if (remainingArgs.Length > 0)
            {
                if (term.Right is VoidTerm)
                {
                    term.Right = remainingArgs[0];
                    term.StringRepresentation = term.TestRepresentation;
                }
                else
                {
                    term = new Term(term, remainingArgs[0]);
                    term.StringRepresentation = term.TestRepresentation;
                }
                AppendRecursively(ref term, remainingArgs);
            }

            return term;
        }

        public static Term EvaluateWith(Term[] args)
        {
            var builtTerm = BuildWith(args);
            PerformRecursiveReduction(ref builtTerm);
            MyLogger.Log(builtTerm.Stringify());
            return builtTerm;
        }

        private static Term PerformRecursiveReduction(ref Term pointer)
        {
            if (pointer.HasRedex)
            {
                var result = pointer.TryReduce();
                if (result.Success)
                {
                    pointer = result.ResultTerm;
                    PerformRecursiveReduction(ref pointer);
                }
                else
                {
                    var newPointer = pointer.Right;
                    pointer.Right = PerformRecursiveReduction(ref newPointer);
                }
            }
            return pointer;
        }

        public override string ToString() => StringRepresentation;

        public object Clone()
        {
            return this.MemberwiseClone();
        }


        public string Stringify()
        {
            return this.TestRepresentation;
            string result = "";
            var subject = this;
            if (subject is VoidTerm) return "()";
            if (subject.HasRedex)
            {
                result += "(" + subject + "," + subject.Right + ")";
                subject = subject.Right.Right;
            }
            else
            {
                return result = "(" + subject + ",())";
            }

            if (subject is VoidTerm == false)
            {
                while (subject.HasRedex)
                {
                    result = "(" + result;
                    result += "," + subject.StringRepresentation + ")";
                    subject = subject.Right;
                }
                result = "(" + result + "," + subject + ")";
            }
            return result;
        }

        public Term Dump()
        {
            MyLogger.Log(Stringify());
            return this;
        }

        public bool HasRedex => !(Right is VoidTerm);

        public virtual ReductionResult TryReduce() => new ReductionResult(this);

        private static Term Terminate(Term term)
        {
            if (term.Right == null)
            {
                term.Right = new VoidTerm();
            }
            else throw new ArgumentException($"{nameof(Term.Terminate)} - term provided has value in its right slot and is not terminal.");
            return term;
        }
    }

}
