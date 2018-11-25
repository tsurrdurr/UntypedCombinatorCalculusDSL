using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kombinator.Built_In;
using Kombinator.Models;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace KombinatorTests
{
    [TestFixture]
    class ReductionTests
    {
        [Test]
        public void TermReductionTest_InputNormalForms_ReturnsSameStringificationResult()
        {
            var term1 = CombinatorK.ConstructCombinator();
            var expected = term1.Stringify();
            term1.TryReduce();
            var result = term1.Stringify();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TermReductionTest_InputNormalFormsThroughBuildWith_ReturnsSameStringificationResult()
        {
            var term1 = CombinatorK.ConstructCombinator();
            var expected = term1.Stringify();
            var reductionResult = Term.BuildWith(new Term[] { term1 }).TryReduce();
            var result = term1.Stringify();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TermReductionTest_InputReducableTermWithKCombinator_ReturnsReducedTerm()
        {
            var kTerm = CombinatorK.ConstructCombinator();
            string name2 = "pupa";
            var term2 = new Constant(name2);
            string name3 = "lupa";
            var term3 = new Constant(name3);
            var expected = Term.BuildWith(new Term[] { term2 }).Stringify();
            var resultTerm = Term.BuildWith(new Term[]
            { kTerm, term2, term3 });
            var reductionResult = resultTerm.TryReduce();
            var result = (Term) reductionResult.ResultTerm;
            var resultStr = result.Stringify();

            Assert.AreEqual(expected, resultStr);
        }

        [Test]
        public void TermReductionTest_InputReducableTermWith2KCombinators_ReturnsReducedTerm()
        {
            var kTerm = CombinatorK.ConstructCombinator();
            var kTerm1 = CombinatorK.ConstructCombinator();

            string name3 = "rumba";
            var term3 = new Constant(name3);
            string name4 = "spinner";
            var term4 = new Constant(name4);
            string name5 = "vape";
            var term5 = new Constant(name5);

            var expected = Term.BuildWith(new Term[] { term4 }).Stringify();
            var result = Term.EvaluateWith(new Term[]
                {kTerm, kTerm1, term3, term4, term5});
            Assert.AreEqual(expected, result.Stringify());
        }


    }
}
