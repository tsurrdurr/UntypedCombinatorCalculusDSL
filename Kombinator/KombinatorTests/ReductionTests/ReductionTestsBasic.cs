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
    public class ReductionTestsBasic
    {
        [Test]
        public void TermReductionTest_InputNormalForms_ReturnsSameStringificationResult()
        {
            var term1 = CombinatorK.ConstructCombinator();
            var expected = term1.Stringify();
            var result = term1.TryReduce();
            var resultStr = result.ResultTerm.Stringify();
            Assert.AreEqual(expected, resultStr);
        }

    }
}
