using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kombinator.Built_In;
using Kombinator.Models;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace KombinatorTests.ReductionTests
{
    [TestFixture]
    public class ComplexReductionTest
    {
        [Test]
        public void TermReductionTest_InputSKKIX_ReturnsTermX()
        {
            var S = CombinatorS.ConstructCombinator();
            var K1 = CombinatorK.ConstructCombinator();
            var K2 = CombinatorK.ConstructCombinator();
            var I = CombinatorI.ConstructCombinator();
            var x = new Variable("x");
            var expectedTerm = Term.BuildWith(new Term[] {x});
            var resultTerm = Term.EvaluateWith(new Term[] {S, K1, K2, I, x});
            Assert.AreEqual(expectedTerm.Stringify(), resultTerm.Stringify());
        }
    }
}
