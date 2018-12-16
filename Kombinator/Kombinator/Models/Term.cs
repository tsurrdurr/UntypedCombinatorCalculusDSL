using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kombinator.Logic;
using Kombinator.Traceability;

namespace Kombinator.Models
{
    public class Term
    {
        public Term Left { get; set; }

        public Term Right { get; set; }

        public Term Parent { get; set; }

        public string StringRepresentation = "";
        public string TestRepresentation => "(" + Left + "," + Right + ")";
        protected object ContainedObject;

        public Term(Term leftTerm, Term rightTerm)
        {
            this.Left = leftTerm;
            this.Right = rightTerm;
            SetParent();
            this.StringRepresentation = "(" + leftTerm + "," + rightTerm + ")";
            MyLogger.Log("Term 2 args invoked");
        }

        protected Term(string name)
        {
            StringRepresentation =  name;
            if (this is VoidTerm == false) Right = new VoidTerm();
            SetParent();
        }

        protected Term(object value)
        {
            StringRepresentation = value.ToString();
            ContainedObject = value;
            if (this is VoidTerm == false) Right = new VoidTerm();
            SetParent();
        }

        public Term SurgeryOnATerm(Term term, Term newRight)
        {

            var result = new Term(term, newRight);
            
            term.Parent = newRight.Parent;
            return result;
        }

        private Term()
        {
            this.Left = this.Right = null;
        }

        private void SetParent()
        {
            if (Left != null) Left.Parent = this;
            if (Right != null) Right.Parent = this;
        }

        public static Term BuildWith(Term[] args)
        {
            var firstElement = args.FirstOrDefault();
            if (firstElement == null) return new VoidTerm();
            var rootEntity = new Term(firstElement, new VoidTerm());
            AppendRecursively(ref rootEntity, args);
            rootEntity.Parent = new VoidTerm();
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
                    term.Right.Parent = term;
                    term.StringRepresentation = term.TestRepresentation;
                }
                else
                {
                    term = new Term(term, remainingArgs[0]);
                    term.Parent = term;
                    term.StringRepresentation = term.TestRepresentation;
                }
                AppendRecursively(ref term, remainingArgs);
            }

            return term;
        }

        public static Term EvaluateWith(Term[] args)
        {
            var builtTerm = BuildWith(args);
            var result = new Reductor(builtTerm).Reduce();
            MyLogger.Log(result.Stringify()); 
            return result;
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

            if (subject is VoidTerm == false && subject != null)
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

        public bool HasRedex
        {
            get
            {
                if (Parent.Right == this)
                {
                    if (Parent.Parent.Right is VoidTerm || Parent.Parent.Right == null) return false;
                    return true;
                }
                else return !(Parent.Right is VoidTerm);
            }
        }
        //!(Parent.Right is VoidTerm && Parent.Right != this) || !(Parent.Parent.Right is VoidTerm || Parent.Parent.Right == null);

        public virtual ReductionResult Reduce(Stack<Term> args = null) => new ReductionResult(this);

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
