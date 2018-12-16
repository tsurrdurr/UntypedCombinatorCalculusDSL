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
    class ReductionTestsCombinatorI
    {
        [Test]
        public void TermReductionTest_InputCombinatorI_ReturnsSameStringification()
        {

            var term1 = CombinatorI.ConstructCombinator();
            var buildResult = Term.BuildWith(new Term[] { term1 });
            var expected = buildResult.Stringify();
       
            var evalResult = Term.EvaluateWith(new Term[] { term1 });
            var result = evalResult.Stringify();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TermReductionTest_InputCombinatorIAndConstant_ReturnsConstantStringification()
        {
            var term1 = CombinatorI.ConstructCombinator();
            string name = "const";
            var term2 = new Constant(name);

            var extepctedResult = Term.BuildWith(new Term[] { term2 });
            var expected = extepctedResult.Stringify();
            var reductionResult = Term.EvaluateWith(new Term[] { term1, term2 });
            var result = reductionResult.Stringify();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TermReductionTest_InputCombinatorsI3Times_ReturnsCombinatorStringification()
        {
            var term1 = CombinatorI.ConstructCombinator();
            var term2 = CombinatorI.ConstructCombinator();
            var term3 = CombinatorI.ConstructCombinator();
            var extepctedResult = Term.BuildWith(new Term[] { term1 });
            var expected = extepctedResult.Stringify();
            var reductionResult = Term.EvaluateWith(new Term[] { term1, term2, term3 });
            var result = reductionResult.Stringify();
            Assert.AreEqual(expected, result);
        }
    }
}
