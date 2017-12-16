using System;
using Xunit;
using Xunit.Abstractions;

namespace day3
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _output;

        public UnitTest1(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData(10, 3)]
        [InlineData(11, 2)]
        [InlineData(12, 3)]
        [InlineData(13, 4)]
        [InlineData(14, 3)]
        [InlineData(15, 2)]
        [InlineData(16, 3)]
        [InlineData(17, 4)]
        [InlineData(18, 3)]
        [InlineData(19, 2)]
        [InlineData(20, 3)]
        [InlineData(21, 4)]
        [InlineData(22, 3)]
        [InlineData(23, 2)]
        [InlineData(24, 3)]
        [InlineData(25, 4)]
        [InlineData(1024, 31)]
        [InlineData(347991, 1)]
        public void Test1(int value, int expectedValue)
        {
            var gridSize = 1;
            var actualDistance = 0;
            while (true)
            {
                if (value <= (gridSize * gridSize))
                    break;
                gridSize = gridSize + 2;
            }
            var minimumDistance = (int)((gridSize - 1) / 2);
            _output.WriteLine($"minmumdistance: {minimumDistance}");
            _output.WriteLine($"GridSize: {gridSize}");

            var startNumber = ((gridSize - 2) * (gridSize - 2)) + 1;
            _output.WriteLine($"startNumber: {startNumber}");

            var topRight = startNumber + (gridSize - 2);
            var topLeft = topRight + (gridSize - 1);
            var bottomLeft = topLeft + (gridSize - 1);
            var bottomRight = bottomLeft + (gridSize -1);
            _output.WriteLine($"corners {topRight},{topLeft},{bottomLeft},{bottomRight}");

            if (value <= topRight)
            {
                _output.WriteLine("Is On right");
                var middle = (int)((gridSize - 2) / 2);
                middle += startNumber;
                _output.WriteLine($"middle: {middle}");

                if (value == middle)
                    actualDistance = minimumDistance;
                if (value > middle)
                    actualDistance = minimumDistance + (value - middle);
                else 
                    actualDistance = minimumDistance + (middle - value);
            } 
            else if (value <= topLeft)
            {
                _output.WriteLine("Is On top");
                var middle = (int)((gridSize - 1) / 2);
                middle += topRight;
                _output.WriteLine($"middle: {middle}");

                if (value == middle)
                    actualDistance = minimumDistance;
                if (value > middle)
                    actualDistance = minimumDistance + (value - middle);
                else 
                    actualDistance = minimumDistance + (middle - value);
            }
            else if (value <= bottomLeft)
            {
                _output.WriteLine("Is On Left");
                var middle = (int)((gridSize - 1) / 2);
                middle += topLeft;
                _output.WriteLine($"middle: {middle}");

                if (value == bottomLeft)
                    actualDistance = minimumDistance;
                if (value > middle)
                    actualDistance = minimumDistance + (value - middle);
                else 
                    actualDistance = minimumDistance + (middle - value);
            }
            else 
            {
                _output.WriteLine("Is On Bottom");
                var middle = (int)((gridSize - 1) / 2);
                middle += bottomLeft;
                _output.WriteLine($"middle: {middle}");

                if (value == bottomLeft)
                    actualDistance = minimumDistance;
                if (value > middle)
                    actualDistance = minimumDistance + (value - middle);
                else 
                    actualDistance = minimumDistance + (middle - value);
            }

            Assert.Equal(expectedValue, actualDistance);
        }
    }
}
