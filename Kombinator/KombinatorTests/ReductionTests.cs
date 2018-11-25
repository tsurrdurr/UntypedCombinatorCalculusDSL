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
        public void TermReductiontest_InputNormalForms_ReturnsSameStringificationResult()
        {
            var term1 = CombinatorK.ConstructCombinator();
            var expected = term1.Stringify();
            var reductionResult = term1.Reduce();
            var result = reductionResult.Stringify();
            Assert.AreEqual(expected, result);
        }
    }
}
