using System;
using Kombinator.Built_In;
using NUnit.Framework;
using Kombinator.Models;

namespace KombinatorTests
{
    [TestFixture]
    public class StringificationTests
    {
        [Test]
        public void StringiftyEmpty_InputEmptyArray_ReturnsEmpryTermRepresentation()
        {
            string expected = "()";
            var term = Term.BuildWith(new Term[] { });
            var result = term.Stringify();
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void StringifySingleConstant_ImputSingleElementArray_ReturnsSingleElementTermRepresentation()
        {
            string name = "dabbing_squidward";
            string expected = $"({name},())";
            var term = Term.BuildWith(new Term[] {new Constant(name)});
            var result = term.Stringify();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StringifySingleVariable_ImputSingleElementArray_ReturnsSingleElementTermRepresentation()
        {
            string name = "thanos";
            string expected = $"({name},())";
            var term = Term.BuildWith(new Term[] { new Variable(name)  });
            var result = term.Stringify();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StringifyMidrangeTerm_Imput3ElementArray_Returns3ElementTermRepresentation()
        {
            var term1 = CombinatorK.ConstructCombinator();
            var name2 = "mtn_dew";
            var term2 = new Constant(name2);
            var name3 = "bepis";
            var term3 = new Constant(name3);
            string expected = $"((K,{name2}),{name3})";
            var term = Term.BuildWith(new Term[] { term1, term2, term3 });
            var result = term.Stringify();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StringifyLongTerm_Input5ElementArray_Returns5ElementTermRepresentation()
        {
            var KTerm = CombinatorK.ConstructCombinator();
            var name1 = "drake";
            var term1 = new Constant(name1);
            var name2 = "kanye";
            var term2 = new Constant(name2);
            string expected = $"((((K,K),K),{name1}),{name2})";
            var term = Term.BuildWith(new Term[]
            {
                KTerm, KTerm, KTerm, term1, term2
            });
        }

    }
}
