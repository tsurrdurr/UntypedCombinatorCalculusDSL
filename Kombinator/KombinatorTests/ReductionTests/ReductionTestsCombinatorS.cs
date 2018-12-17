using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        [SetUp]
        public void Initialize()
        {
            
        }

        [Test]
        public void TermReductionTest_InputCombinatorS_ReturnsSameStringificationResult()
        {
            var term1 = CombinatorS.ConstructCombinator();
            var sTerm = Term.BuildWith(new Term[] {term1});
            var expected = sTerm.Stringify();
            var reductionResult = Term.EvaluateWith( new Term[] { term1 });
            var result = reductionResult.Stringify();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TermReductionTest_InputCombinatorSWith3Constants_ReturnsEvaluatedStringificationResult()
        {
            var Scomb = CombinatorS.ConstructCombinator();
            var termX = new Constant("x");
            var termY = new Constant("y");
            var termZ = new Constant("z");
            var termZcopy = new Constant("z");
            var superterm1 = new Term(termX, termZ);
            var superterm2 = new Term(termY, termZcopy); 
            var expectedResult = Term.BuildWith(new Term[] { termX, termZ, superterm2 });
            string expected = expectedResult.Stringify();
            var reductionResult = Term.EvaluateWith(new Term[] { Scomb, termX, termY, termZ });
            var result = reductionResult.Stringify();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TermReductionTest_InputCombinatorSWith3ConstantsAndTuple_ReturnsEvaluatedStringificationResult()
        {
            var term1 = CombinatorS.ConstructCombinator();
            var term2 = new Constant("x");
            var term2copy = new Constant("x");
            var term3 = new Constant("y");
            var term4 = new Constant("z");
            var term4a = new Constant("z");
            var subterm = new Term(term2, term2copy);
            var superterm2 = new Term(term3, term4a);
            var expectedResult = Term.BuildWith(new Term[] { subterm, term4, superterm2 });
            string expected = expectedResult.Stringify();
            var reductionResult = Term.EvaluateWith(new Term[] { term1, subterm, term3, term4 });
            var result = reductionResult.Stringify();
            Assert.AreEqual(expected, result);
        }

    }
}
