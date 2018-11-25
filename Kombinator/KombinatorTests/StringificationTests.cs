using System;
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
    }
}
