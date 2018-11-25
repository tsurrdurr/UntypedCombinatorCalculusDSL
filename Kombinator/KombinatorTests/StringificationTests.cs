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
            string expected = "(,)";
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

        [Test]
        public void StringifyLongTerm_Input5ElementArrayv2_Returns5ElementTermRepresentation()
        {
            var kTerm = CombinatorK.ConstructCombinator();
            var kTerm1 = CombinatorK.ConstructCombinator();

            string name3 = "rumba";
            var term3 = new Constant(name3);
            string name4 = "spinner";
            var term4 = new Constant(name4);
            string name5 = "vape";
            var term5 = new Constant(name5);
            var expected = $"((((K,K),{name3}),{name4}),{name5})";
            var result = Term.BuildWith(new Term[]
                {kTerm, kTerm1, term3, term4, term5});
            Assert.AreEqual(expected, result.Stringify());
        }

        [Test]
        public void StringifyComplexTerm_Input2Tuples_ReturnsCorrectStringificaion()
        {
            var term2 = new Constant("x");
            var term3 = new Constant("y");
            var term4 = new Constant("z");
            var term4a = new Constant("z");
            var superterm1 = new Term(term2, term4);
            var superterm2 = new Term(term3, term4a);
            var expected = $"(({term2},{term4}),({term3},{term4a}))";
            var result = Term.BuildWith(new Term[] { superterm1, superterm2 }).Stringify();
            Assert.AreEqual(expected, result);
        }
    }
}
