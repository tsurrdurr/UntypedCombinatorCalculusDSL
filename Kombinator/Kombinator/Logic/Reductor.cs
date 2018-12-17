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
        private Term node;
        private Stack<Term> argumentsStack = new Stack<Term>();
        private bool gatheringArgumentsMode = false;
        private bool needsSurgery = false;
        private uint argsRequired = 0;
        private Applica currentApplica = null;

        public Reductor(Term builtTerm)
        {
            this.node = TreeTraversal.GetLowestLeftNode(builtTerm);
        }

        public Term Reduce()
        {
            while (node.HasRedex)
            {
                var reductionResult = TryApply(node);
                if (needsSurgery)
                {
                    node = SurgeryOnATerm(reductionResult, TreeTraversal.GetNextNodeLRP(node));
                    node = TreeTraversal.GetLowestLeftNode(node.Parent);
                }
                else
                {
                    node = TreeTraversal.GetNextNodeLRP(node);
                }
            }
            var result = TryApply(node);

            if (needsSurgery)
            {
                var formerNode = (Term) currentApplica;
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
            return new Term(node, new VoidTerm());
        }

        private Term SurgeryOnATerm(Term term, Term getNextNodeLrp)
        {
            getNextNodeLrp.Parent.Left = term;
            term.Parent = getNextNodeLrp.Parent;
            TreeTraversal.RenewRepresentation(term);
            needsSurgery = false;
            return getNextNodeLrp;
        }

        private Term TryApply(Term addingNode)
        {
            bool isApplica = addingNode is Applica;
            if (gatheringArgumentsMode)
            {
                if (argumentsStack.Count + 1 >= argsRequired)
                {
                    argumentsStack.Push(addingNode);
                    var result = currentApplica.ReduceApplica(argumentsStack);
                    gatheringArgumentsMode = false;
                    needsSurgery = true;
                    argsRequired = 0;
                    return result.ResultTerm;
                }
                argumentsStack.Push(node);
            }
            else
            {
                if (isApplica)
                {
                    gatheringArgumentsMode = true;
                    currentApplica = addingNode as Applica;
                    argsRequired = currentApplica.ArgumentsNumber;
                }
            }
            return addingNode;
        }
    }
}
