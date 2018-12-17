using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kombinator.Built_In;
using Kombinator.Logic;
using Kombinator.Models;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace KombinatorTests
{
    [TestFixture]
    public class TreeTraversalTests
    {
        [Test]
        public void GetLowestLeftTerm_Input1ElementTerm_ReturnsTheElement()
        {
            var kTerm = CombinatorK.ConstructCombinator();
            var startingTermsList = new Term[] { kTerm,};
            var term = Term.BuildWith(startingTermsList);
            var result = TreeTraversal.GetLowestLeftNode(term);
            Assert.AreEqual(result.Stringify(), kTerm.Stringify());
        }

        [Test]
        public void GetLowestLeftTerm_Input5ElementTerm_ReturnsFirstAddedTerm()
        {
            var kTerm = CombinatorK.ConstructCombinator();
            var kTerm1 = CombinatorK.ConstructCombinator();

            string name3 = "rumba";
            var term3 = new Constant(name3);
            string name4 = "spinner";
            var term4 = new Constant(name4);
            string name5 = "vape";
            var term5 = new Constant(name5);
            var startingTermsList = new Term[] { kTerm, kTerm1, term3, term4, term5 };
            var term = Term.BuildWith(startingTermsList);
            var result = TreeTraversal.GetLowestLeftNode(term);
            Assert.AreEqual(result.Stringify(), kTerm.Stringify());
        }

        [Test]
        public void GetNextNodeLRPTest_Input5ElementTerm_ReturnsListOf4InReversedOrder()
        {
            var kTerm = CombinatorK.ConstructCombinator();
            var iTerm = CombinatorI.ConstructCombinator();

            string name3 = "rumba";
            var term3 = new Constant(name3);
            string name4 = "spinner";
            var term4 = new Constant(name4);
            string name5 = "vape";
            var term5 = new Constant(name5);
            var startingTermsList = new Term[] {kTerm, iTerm, term3, term4, term5};
            var term = Term.BuildWith(startingTermsList);
            var result = new List<Term>();
            term = TreeTraversal.GetLowestLeftNode(term);
            for (int i = 0; i < startingTermsList.Length - 1; i++)
            {
                term = TreeTraversal.GetNextNodeLRP(term);
                result.Add(term);
            }
            Assert.Multiple(() =>
            {
                Assert.AreEqual(iTerm.Stringify(), result[0].Stringify());
                Assert.AreEqual(term3.Stringify(), result[1].Stringify());
                Assert.AreEqual(term4.Stringify(), result[2].Stringify());
                Assert.AreEqual(term5.Stringify(), result[3].Stringify());

            });


        }
    }
}
