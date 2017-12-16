using System;
using Xunit;
using System.Linq;
using System.IO;

namespace day4
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("aa bb cc dd ee", true)]
        [InlineData("aa bb cc dd aa", false)]
        [InlineData("aa bb cc dd aaa", true)]
        public void Test1(string phrase, bool isValid)
        {
            Assert.Equal(isValid, IsPassphraseValid(phrase));
        }

        [Fact]
        public void Test2()
        {
            var lines = File.ReadAllLines(@"C:\git\adventofcode\day4\part1-input.txt");
            Assert.Equal(1, lines.Count(l => IsPassphraseValid(l)));
        }

        [Fact]
        public void Test3()
        {
            var lines = File.ReadAllLines(@"C:\git\adventofcode\day4\part1-input.txt");
            Assert.Equal(1, lines.Count(l => IsPassphraseValidAnagram(l)));
        }

        private bool IsPassphraseValid(string phrase)
        {
            var words = phrase.Split(null);
            return words.Distinct().Count() == words.Count();
        }
        private bool IsPassphraseValidAnagram(string phrase)
        {
            var words = phrase.Split(null);
            var wordsAnagram = words.Select(w => String.Concat(w.OrderBy(c => c)));
            return wordsAnagram.Distinct().Count() == words.Count();
        }
    }
}
