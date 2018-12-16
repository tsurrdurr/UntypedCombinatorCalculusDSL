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
    class ReductionTestsCombinatorK
    {

        [Test]
        public void TermReductionTest_InputCombinatorK_ReturnsSameStringificationResult()
        {
            var term1 = CombinatorK.ConstructCombinator();
            var expected = term1.Stringify();
            var reductionResult = Term.BuildWith(new Term[] { term1 }).Reduce();
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
            var reductionResult = Term.EvaluateWith(new Term[] { kTerm, term2, term3 });
            var resultStr = reductionResult.Stringify();

            Assert.AreEqual(expected, resultStr);
        }

        [Test]
        public void TermReductionTest_InputNonLinearTerm_ReturnsCorrectlyRecudedTerm()
        {
            var name2 = "kyle";
            var name3 = "jacquline";
            var name4 = "trish";
            var kTerm = CombinatorK.ConstructCombinator();
            var termKyle = new Constant(name2);
            var expected = Term.BuildWith(new Term[] { new Term(new Constant(name3), new Constant(name4))}).Stringify();
            var termTwins = new Term(new Constant(name3), new Constant(name4));
            var term = Term.EvaluateWith(new Term[] {kTerm, termTwins, termKyle});
            Assert.AreEqual(expected, term.ToString());
        }

        [Test]
        public void TermReductionTest_InputNonLinearTermAltOrder_ReturnsCorrectlyRecudedTerm()
        {
            var name2 = "kyle";
            var name3 = "jacquline";
            var name4 = "trish";
            var kTerm = CombinatorK.ConstructCombinator();
            var termKyle = new Constant(name2);
            var expected = Term.BuildWith(new Term[] { termKyle }).Stringify();
            var termTwins = new Term(new Constant(name3), new Constant(name4));
            var term = Term.EvaluateWith(new Term[] { kTerm, termKyle, termTwins});
            Assert.AreEqual(expected, term.ToString());
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

        [Test]
        public void TermReductionTest_InputReducableNonLinearlyTermWith2KCombinators_ReturnsReducedTerm()
        {
            var kTerm = CombinatorK.ConstructCombinator();
            var kTerm1 = CombinatorK.ConstructCombinator();

            string name3 = "egg";
            var term3 = new Constant(name3);
            string name4 = "long egg";
            var term4 = new Constant(name4);
            string name5 = "applause";
            var term5 = new Constant(name5);
            string name6 = "gone";
            var term6 = new Constant(name6);


            var expected = Term.BuildWith(new Term[] { term3, term5 }).Stringify();
            var result = Term.EvaluateWith(new Term[] {kTerm, term3, term4, kTerm1, term5, term6 });
            Assert.AreEqual(expected, result.Stringify());
        }
    }
}
