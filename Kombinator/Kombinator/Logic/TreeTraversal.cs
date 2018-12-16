using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kombinator.Models;

namespace Kombinator.Logic
{
    public class TreeTraversal
    {
        public static Term GetLowestLeftNode(Term currentTerm)
        {
            while (currentTerm.Left != null)
            {
                currentTerm = currentTerm.Left;
            }

            return currentTerm;
        }

        public static Term GetNextNodeLRP(Term currenTerm)
        {
            var right = currenTerm?.Parent?.Right;
            var parentRight = currenTerm?.Parent?.Parent?.Right;
            if (right != null && !(right is VoidTerm) && right != currenTerm)
            {
                return right;
            }
            if (parentRight != null && !(parentRight is VoidTerm))
            {
                return parentRight;
            }
            return new VoidTerm();
        }

        public static void RenewRepresentation(Term lowestLeft)
        {
            lowestLeft = GetLowestLeftNode(lowestLeft);
            while (!(lowestLeft is VoidTerm))
            {
                lowestLeft.Parent.StringRepresentation = lowestLeft.Parent.TestRepresentation;
                lowestLeft = GetNextNodeLRP(lowestLeft);
            }
        }
    }
}
