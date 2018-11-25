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
    class ReductionTestsCombinatorS
    {
        [Test]
        public void TermReductionTest_InputCombinatorS_ReturnsSameStringificationResult()
        {
            var term1 = CombinatorS.ConstructCombinator();
            var expected = term1.Stringify();
            var reductionResult = Term.BuildWith(new Term[] { term1 }).TryReduce();
            var result = reductionResult.ResultTerm.Stringify();
            Assert.AreEqual(expected, result);
        }


        public void TermReductionTest_InputCombinatorSWith3Constants_ReturnsEvaluatedStringificationResult()
        {
            var term1 = CombinatorS.ConstructCombinator();
            var term2 = new Constant("x");
            var term3 = new Constant("y");
            var term4 = new Constant("z");
            var term4a = new Constant("z");
            var superterm1 = term2;
            superterm1.Right = term4;
            var superterm2 = term3;
            superterm2.Right = term4a;
            var expectedResult = Term.BuildWith(new Term[] {superterm1, superterm2});
            string expected = expectedResult.Stringify();
            var reductionResult = Term.EvaluateWith(new Term[] { term1, term2, term3, term4 });
            var result = term1.Stringify();
            Assert.AreEqual(expected, result);
        }


    }
}
