﻿using System;
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

        protected Term Right { get; set; }

        private Term _left;
        protected string StringRepresentation = "";

        protected object ContainedObject;

        public Term(Term leftTerm, Term rightTerm)
        {
            this.Left = leftTerm;
            this.Right = rightTerm;
            this.StringRepresentation = leftTerm.ToString();
            MyLogger.Log("Term 2 args invoked");
        }

        protected Term(string name)
        {
            StringRepresentation = name;
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
            var rootEntity = args.FirstOrDefault();
            if (rootEntity == null) return new VoidTerm();
            for (int i = 0; i < args.Length; i++)
            {
                var next = (i + 1 < args.Length) ? args[i + 1] : null;
                args[i].Right = next;
            }
            var lastTerm = args[args.Length - 1];
            lastTerm = Terminate(lastTerm);
            return rootEntity;
        }

        public static Term EvaluateWith(Term[] args)
        {
            var term = BuildWith(args);
            var pointer = term;
            while (pointer.HasRedex)
            {
                pointer = pointer.Reduce();
            }
            MyLogger.Log(pointer.Stringify());
            return pointer;
        }

        public Term NextArgument => this.Right;

        public override string ToString() => StringRepresentation;
        

        public string Stringify()
        {
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
            while (subject.HasRedex)
            {
                result = "(" + result + subject.StringRepresentation;
                if(subject == null) continue;
                result += "," + subject.StringRepresentation + "),";
                subject = subject.Right;
            }
            result = "(" + result + "," + subject + ")";
            return result;
        }

        public Term Dump()
        {
            MyLogger.Log(Stringify());
            return this;
        }

        public bool HasRedex => !(Right is VoidTerm);

        public virtual Term Reduce() => this;

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
