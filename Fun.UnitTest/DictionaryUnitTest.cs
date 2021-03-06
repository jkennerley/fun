﻿using Fun;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using static Fun.DictionaryExt;
using static Fun.F;

namespace DictionaryExtUnitTest
{
    public class DictionaryUnitTest
    {
        private readonly ITestOutputHelper output;

        public DictionaryUnitTest(ITestOutputHelper output_)
        {
            this.output = output_;
        }

        [Fact]
        public void dictionary_lookup_to_OptionT()
        {
            // Arrange
            var xs = new Dictionary<string, string>
            {
                ["a"] = "AA",
                ["b"] = "BB",
            };

            // Act

            // Assert

            // the usual dictionary stuff
            Assert.Equal("AA", xs["a"]);
            Assert.Equal("BB", xs["b"]);

            //
            Assert.Equal(xs.Lookup("-NOT-THERE"), None);
            Assert.Equal(xs.Lookup("a"), Some("AA"));

            //
            var actualA = xs.Lookup("a").Match(() => "", v => v);
            //Assert.Equal(actualA, "AA");

            var actualANotExist = xs.Lookup("a-key-there-").Match(() => "", v => v);
            //Assert.Equal(actualANotExist, "");
        }
    }
}