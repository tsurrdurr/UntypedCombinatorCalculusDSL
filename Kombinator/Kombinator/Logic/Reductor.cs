using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kombinator.Models;

namespace Kombinator.Logic
{
    public class Reductor
    {
        private Term currentNode;
        private readonly Stack<Term> argumentsStack = new Stack<Term>();
        private readonly ReductionStatus currentStatus;

        public Reductor(Term builtTerm)
        {
            this.currentNode = TreeTraversal.GetLowestLeftNode(builtTerm);
            this.currentStatus = new ReductionStatus();
        }

        public Term Reduce()
        {
            while (currentNode.HasRedex)
            {
                var reductionResult = TryApply(currentNode);
                if (currentStatus.NeedsSurgery)
                {
                    currentNode = SpliceApplicationResultWithTerm(reductionResult, TreeTraversal.GetNextNodeLRP(currentNode));
                    currentNode = TreeTraversal.GetLowestLeftNode(currentNode.Parent);
                }
                else
                {
                    currentNode = TreeTraversal.GetNextNodeLRP(currentNode);
                }
            }
            var result = TryApply(currentNode);
            if (currentStatus.NeedsSurgery)
            {
                var formerNode = (Term)currentStatus.CurrentApplica;
                if (formerNode == TreeTraversal.GetLowestLeftNode(formerNode.Parent))
                {
                    if (!(result.Right is VoidTerm))
                    {
                        TreeTraversal.RenewRepresentation(formerNode);
                        return result;
                    }
                    else
                    {
                        formerNode.Parent.Left = result;
                        formerNode.Parent.Right = new VoidTerm();
                    }
                }
                else
                {
                    formerNode.Parent.Right = result;
                }
                TreeTraversal.RenewRepresentation(formerNode);
                return formerNode.Parent;
            }
            return new Term(currentNode, new VoidTerm());
        }

        private Term TryApply(Term addingNode)
        {
            bool isApplica = addingNode is Applica;
            if (currentStatus.GatheringArgumentsMode)
            {
                if (argumentsStack.Count + 1 >= currentStatus.NumberOfArgsRequired)
                {
                    argumentsStack.Push(addingNode);
                    var result = currentStatus.CurrentApplica.ReduceApplica(argumentsStack);
                    currentStatus.SetJustAppliedState();
                    return result.ResultTerm;
                }
                argumentsStack.Push(currentNode);
            }
            else
            {
                if (isApplica)
                {
                    currentStatus.EnterApplicaMode(addingNode);
                }
            }
            return addingNode;
        }

        private Term SpliceApplicationResultWithTerm(Term term, Term nextNode)
        {
            nextNode.Parent.Left = term;
            term.Parent = nextNode.Parent;
            TreeTraversal.RenewRepresentation(term);
            currentStatus.NeedsSurgery = false;
            return nextNode;
        }
    }
}
