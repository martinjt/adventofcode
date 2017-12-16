using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace day5
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("0 3 0 1 -3", 5)]
        public void Test1(string input, int expectedSteps)
        {
            var jumps = input
                .Split(null)
                .Select(i => Convert.ToInt32(i))
                .ToList();

            Assert.Equal(expectedSteps, DoJumps(jumps));
        }

        [Theory]
        [InlineData("0 3 0 1 -3", 10)]
        public void Test3(string input, int expectedSteps)
        {
            var jumps = input
                .Split(null)
                .Select(i => Convert.ToInt32(i))
                .ToList();

            Assert.Equal(expectedSteps, DoJumpsPart2(jumps));
        }

        [Fact]
        public void Test2()
        {
            var lines = System.IO.File.ReadAllLines(@"c:\git\adventofcode\day5\input-part1.txt");
            var jumps = lines.Select(l => Convert.ToInt32(l)).ToList();
            Assert.Equal(1, DoJumps(jumps));
        }

        [Fact]
        public void Test2Part2()
        {
            var lines = System.IO.File.ReadAllLines(@"c:\git\adventofcode\day5\input-part1.txt");
            var jumps = lines.Select(l => Convert.ToInt32(l)).ToList();
            Assert.Equal(1, DoJumpsPart2(jumps));
        }

        private int DoJumps(List<int> jumps)
        {
            var numberOfJumps = 1;
            var currentInterupt = 0;
            while (true)
            {

                var newInterupt = currentInterupt + jumps[currentInterupt];
                if (newInterupt < 0 || newInterupt > jumps.Count() - 1)
                    break;
                
                jumps[currentInterupt]++;
                currentInterupt = newInterupt;
                numberOfJumps++;
            }

            return numberOfJumps;
        }

        private int DoJumpsPart2(List<int> jumps)
        {
            var numberOfJumps = 1;
            var currentInterupt = 0;
            while (true)
            {

                var newInterupt = currentInterupt + jumps[currentInterupt];
                if (newInterupt < 0 || newInterupt > jumps.Count() - 1)
                    break;
                
                if (jumps[currentInterupt] >= 3)
                    jumps[currentInterupt]--;
                else
                    jumps[currentInterupt]++;

                currentInterupt = newInterupt;
                numberOfJumps++;
            }

            return numberOfJumps;
        }
    }
}
